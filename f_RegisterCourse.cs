using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_RegisterCourse : Form
    {
        public f_RegisterCourse()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện tương tác dữ liệu trên Form
        /// </summary>
        private void RegisterFormEvents()
        {
            this.Load += f_RegisterCourse_Load;

            // Đồng bộ tên nút bấm theo yêu cầu mới (btn_...)
            this.btnRoundRegister.Click += btn_Register_Click;
            this.btnRoundCancel.Click += btn_CancelRegistration_Click;

            // Sự kiện tự động cập nhật bảng môn học đã đăng ký khi đổi sinh viên khác
            this.cboSinhVien.SelectedIndexChanged += cboSinhVien_SelectedIndexChanged;
        }

        private void f_RegisterCourse_Load(object sender, EventArgs e)
        {
            PopulateSinhVienComboBox();
            PopulateMonHocComboBox();
        }

        // =========================================================================
        // ĐỔ DỮ LIỆU BAN ĐẦU VÀO CÁC COMBOBOX (ĐỒNG BỘ NVARCHAR CHUỖI)
        // =========================================================================

        private void PopulateSinhVienComboBox()
        {
            DataTable dt = Student.GetStudents();

            // Tạo cột hiển thị kết hợp "MSSV - Họ Tên" giúp dễ nhìn hơn trên giao diện
            dt.Columns.Add("DisplayMember", typeof(string), "MSSV + ' - ' + [Họ đệm] + ' ' + [Tên]");

            cboSinhVien.DataSource = dt;
            cboSinhVien.DisplayMember = "DisplayMember";
            cboSinhVien.ValueMember = "MSSV"; // 🟢 Giá trị nhận về hiện tại là chuỗi string công khai

            if (cboSinhVien.Items.Count > 0) cboSinhVien.SelectedIndex = 0;
        }

        private void PopulateMonHocComboBox()
        {
            DataTable dt = Course.GetCourses();

            // Tạo cột hiển thị kết hợp "MaMH - TenMH"
            dt.Columns.Add("DisplayMember", typeof(string), "MaMH + ' - ' + TenMH");

            cboMonHoc.DataSource = dt;
            cboMonHoc.DisplayMember = "DisplayMember";
            cboMonHoc.ValueMember = "MaMH"; // 🟢 Giá trị nhận về là chuỗi mã môn học dạng NVARCHAR(20)

            if (cboMonHoc.Items.Count > 0) cboMonHoc.SelectedIndex = 0;
        }

        /// <summary>
        /// Tải danh sách môn học đã đăng ký của sinh viên đang được chọn lên lưới DataGridView
        /// </summary>
        private void LoadRegisteredCoursesGrid(string mssv)
        {
            Student studentModel = new Student();
            DataTable dt = studentModel.GetRegisteredCourses(mssv); // 🟢 Hàm nhận tham số string mssv
            dgvRegisterCourses.DataSource = dt;

            // Định dạng hiển thị DataGridView cho đồng bộ giao diện chung
            dgvRegisterCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegisterCourses.MultiSelect = false;
            dgvRegisterCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cboSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 🟢 SỬA TẠI ĐÂY: Nhận giá trị chuỗi trực tiếp, loại bỏ int.TryParse cũ
            if (cboSinhVien.SelectedValue != null && !string.IsNullOrEmpty(cboSinhVien.SelectedValue.ToString()))
            {
                string mssv = cboSinhVien.SelectedValue.ToString();
                LoadRegisteredCoursesGrid(mssv);
            }
        }

        // =========================================================================
        // XỬ LÝ ĐĂNG KÝ VÀ HỦY ĐĂNG KÝ MÔN HỌC (ĐỒNG BỘ KHÓA NVARCHAR)
        // =========================================================================

        /// <summary>
        /// Xử lý nút Đăng ký môn học
        /// </summary>
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedValue == null || cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Môn học cần đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🟢 SỬA TẠI ĐÂY: Truyền dữ liệu dạng chuỗi string
            string mssv = cboSinhVien.SelectedValue.ToString();
            string maMH = cboMonHoc.SelectedValue.ToString();

            // Kiểm tra trùng lịch hoặc đã đăng ký môn này trước đó chưa tránh lỗi SQL duplicate
            if (IsCourseAlreadyRegistered(mssv, maMH))
            {
                MessageBox.Show("Môn học này đã được sinh viên đăng ký từ trước!", "Trùng lặp môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student studentModel = new Student();
            if (studentModel.RegisterCourse(mssv, maMH)) // 🟢 Hàm trong class Student nhận (string, string)
            {
                MessageBox.Show("Đăng ký môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegisteredCoursesGrid(mssv); // Tải lại danh sách realtime
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý nút Hủy đăng ký môn học (Xóa dòng khỏi bảng DKMH)
        /// </summary>
        private void btn_CancelRegistration_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedValue == null) return;
            string mssv = cboSinhVien.SelectedValue.ToString();

            string maMH = string.Empty;

            // Ưu tiên lấy mã môn từ dòng đang được chọn trên lưới DataGridView để hủy cho chính xác
            if (dgvRegisterCourses.CurrentRow != null && dgvRegisterCourses.CurrentRow.Index >= 0)
            {
                // Sử dụng chính xác tên trường vật lý của lưới (Thường trả về cột đầu tiên hoặc cột MaMH tùy cấu trúc thiết kế)
                maMH = dgvRegisterCourses.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                // Nếu chưa chọn dòng dưới lưới, lấy tạm mã môn đang hiển thị trên ComboBox
                maMH = cboMonHoc.SelectedValue.ToString();
            }

            if (!IsCourseAlreadyRegistered(mssv, maMH))
            {
                MessageBox.Show("Môn học này hiện chưa có trong danh sách đăng ký của sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn hủy đăng ký môn học [{maMH.Trim()}] của sinh viên này không?",
                                                  "Xác nhận hành động", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Student studentModel = new Student();
                if (studentModel.UnregisterCourse(mssv, maMH)) // 🟢 Nhận tham số (string, string)
                {
                    MessageBox.Show("Đã hủy bỏ đăng ký môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegisteredCoursesGrid(mssv); // Cập nhật lại giao diện lưới
                }
                else
                {
                    MessageBox.Show("Hủy đăng ký thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Kiểm tra nhanh trùng lặp bản ghi đăng ký môn học trong CSDL (Đồng bộ tham số chuỗi)
        /// </summary>
        private bool IsCourseAlreadyRegistered(string mssv, string maMH)
        {
            My_DB db = new My_DB();
            string query = "SELECT COUNT(*) FROM DKMH WHERE MSSV = @mssv AND MaMH = @mamh";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 SỬA TẠI ĐÂY: Chuyển đổi SqlDbType sang NVarChar(20) cho đồng bộ khóa ngoại
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv.Trim();
                    cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = maMH.Trim();

                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                    catch { return false; }
                }
            }
        }
    }
}
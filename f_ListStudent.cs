using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ListStudent : Form
    {
        public f_ListStudent()
        {
            InitializeComponent();
            RegisterRealTimeEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện thời gian thực khi form load
        /// </summary>
        private void RegisterRealTimeEvents()
        {
            this.Load += f_ListStudent_Load;
            this.txtSearch.TextChanged += txtSearch_SelectionChanged; // Tìm kiếm động khi đang gõ
            this.cboGioiTinh.SelectedIndexChanged += txtSearch_SelectionChanged; // Lọc tự động khi đổi giới tính
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
        {
            // Cấu hình mặc định cho ComboBox Giới tính tránh bị trống
            if (cboGioiTinh.Items.Count > 0)
            {
                cboGioiTinh.SelectedIndex = 0; // Chọn dòng đầu tiên ("Tất cả")
            }
            FormatDataGridView();
            LoadStudentData();
        }

        private void FormatDataGridView()
        {
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvStudents.RowHeadersVisible = false;

            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ReadOnly = true;

            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
        }

        /// <summary>
        /// Bộ lọc nâng cao: Kết hợp tìm kiếm ký tự và phân loại giới tính realtime (Tối ưu Pool)
        /// </summary>
        private void txtSearch_SelectionChanged(object sender, EventArgs e)
        {
            My_DB db = new My_DB();
            string keyword = txtSearch.Text.Trim();
            string genderFilter = cboGioiTinh.Text; // Lấy bộ lọc giới tính hiện tại

            // 🟢 SỬA TẠI ĐÂY: Gọi thẳng trường MSSV LIKE @key vì cấu trúc mới đã là NVARCHAR, loại bỏ CAST dư thừa
            string query = "SELECT MSSV AS [Mã SV], Fname AS [Họ], Lname AS [Tên], Dob AS [Ngày sinh], Gder AS [Giới tính], Phone AS [SĐT], Email " +
                           "FROM Student WHERE (MSSV LIKE @key OR Fname LIKE @key OR Lname LIKE @key)";

            // Nếu không chọn "Tất cả", tiến hành ép thêm điều kiện lọc giới tính vật lý vào trường Gder
            if (genderFilter != "Tất cả")
            {
                query += " AND Gder = @gender";
            }

            // Bọc tài nguyên ADO.NET trong using để Connection Pooling tự giải phóng luồng
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@key", SqlDbType.NVarChar, 100).Value = "%" + keyword + "%";
                    if (genderFilter != "Tất cả")
                    {
                        cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 10).Value = genderFilter;
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        try
                        {
                            conn.Open(); // Mượn kết nối siêu tốc từ Pool
                            adapter.Fill(table);
                            dgvStudents.DataSource = table; // Binding dữ liệu lên lưới

                            UpdateSummaryCard(); // Cập nhật tổng số sinh viên dưới cuối danh sách
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi lọc tìm kiếm dữ liệu: " + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sự kiện bấm nút Làm mới (btnRefresh)
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear(); // Xóa thanh tìm kiếm
            if (cboGioiTinh.Items.Count > 0)
            {
                cboGioiTinh.SelectedIndex = 0; // Đưa bộ lọc giới tính về "Tất cả"
            }
            LoadStudentData(); // Reload danh sách
        }

        /// <summary>
        /// Nạp toàn bộ danh sách sinh viên gốc lên bảng dữ liệu (Tối ưu using)
        /// </summary>
        public void LoadStudentData()
        {
            My_DB db = new My_DB();
            string query = "SELECT MSSV AS [Mã SV], Fname AS [Họ], Lname AS [Tên], Dob AS [Ngày sinh], Gder AS [Giới tính], Phone AS [SĐT], Email FROM Student";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        try
                        {
                            conn.Open();
                            table.Clear();
                            adapter.Fill(table);
                            dgvStudents.DataSource = table; // Đổ dữ liệu gốc

                            UpdateSummaryCard(); // Cập nhật số lượng sinh viên ban đầu
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể nạp danh sách dữ liệu sinh viên: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Hàm phụ trợ đếm và hiển thị tổng số sinh viên thời gian thực ở cuối danh sách
        /// </summary>
        private void UpdateSummaryCard()
        {
            if (dgvStudents.Rows != null)
            {
                int totalStudents = dgvStudents.Rows.Count;

                if (dgvStudents.AllowUserToAddRows && dgvStudents.Rows.Count > 0)
                {
                    totalStudents--;
                }

                // GÁN THỰC TẾ LÊN GIAO DIỆN:
                // Bạn hãy bỏ ghi chú (uncomment) dòng dưới đây và đổi 'lblTotalStudents' thành đúng tên ID Label đếm dòng trên giao diện của bạn nhé!
                // lblTotalStudents.Text = $"Tổng số sinh viên: {totalStudents}";
            }
        }
    }
}
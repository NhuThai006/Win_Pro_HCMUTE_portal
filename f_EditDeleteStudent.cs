using QuanLySinhVien;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_EditDeleteStudent : Form
    {
        // Biến lưu trữ mảng byte của ảnh đại diện
        private byte[] studentImage = null;

        // Các biểu thức chính quy chuẩn hóa dùng chung
        private readonly string namePattern = @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÂÊÔƠỨỪỬỮỰẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăâêôơứừửữựấẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪỬỮỰYỲÝỶỸỸỳýỷỹ\s]+$";
        private readonly string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private readonly string phonePattern = @"^\d{9,11}$";

        // 🟢 SỬA TẠI ĐÂY: Đổi thuộc tính nhận sang kiểu string để lưu trữ MSSV NVARCHAR(20)
        public string TargetMSSV { get; set; }

        public f_EditDeleteStudent()
        {
            InitializeComponent();
            RegisterRealTimeValidationEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện TextChanged để kiểm tra dữ liệu thời gian thực
        /// </summary>
        private void RegisterRealTimeValidationEvents()
        {
            this.Load += f_EditDeleteStudent_Load;
            this.FormClosed += f_EditStudent_FormClosed;

            txb_EditFname.TextChanged += txb_EditFname_TextChanged;
            txb_EditLname.TextChanged += txb_EditLname_TextChanged;
            txb_EditPhone.TextChanged += txb_EditPhone_TextChanged;
            txb_EditEmail.TextChanged += txb_EditEmail_TextChanged;
        }

        private void f_EditDeleteStudent_Load(object sender, EventArgs e)
        {
            // 🟢 SỬA TẠI ĐÂY: Thay đổi logic kiểm tra điều kiện chuỗi hợp lệ
            if (!string.IsNullOrEmpty(TargetMSSV))
            {
                // Gọi hàm tìm thông tin chi tiết sinh viên theo mã số dạng chuỗi
                Student sv = Student.GetStudentByID(TargetMSSV);

                if (sv != null)
                {
                    if (this.Controls.Find("txb_EditMSSV", true).Length > 0)
                    {
                        var txtMSSV = this.Controls.Find("txb_EditMSSV", true)[0] as TextBox;
                        txtMSSV.Text = sv.MSSV; // Bản thân sv.MSSV đã là string
                        txtMSSV.Enabled = false;
                    }

                    txb_EditFname.Text = sv.Fname;
                    txb_EditLname.Text = sv.Lname;
                    dtpEditDob.Value = sv.Dob;
                    cboEditGender.Text = sv.Gender;
                    txb_EditPhone.Text = sv.Phone;
                    txb_EditAddress.Text = sv.Address;
                    txb_EditHometown.Text = sv.Hometown;
                    txb_EditEmail.Text = sv.Email;

                    studentImage = sv.Picture;

                    if (sv.Picture != null && sv.Picture.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(sv.Picture))
                        {
                            if (picEditStudent.Image != null) picEditStudent.Image.Dispose();
                            picEditStudent.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picEditStudent.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu sinh viên hợp lệ!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        // =========================================================================
        // CÁC SỰ KIỆN KIỂM TRA THỜI GIAN THỰC (REAL-TIME VALIDATION)
        // =========================================================================

        private void txb_EditFname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_EditFname.Text))
                errorProvider1.SetError(txb_EditFname, "Họ và tên đệm không được để trống!");
            else if (!Regex.IsMatch(txb_EditFname.Text.Trim(), namePattern))
                errorProvider1.SetError(txb_EditFname, "Họ tên không được chứa số hoặc ký tự đặc biệt!");
            else
                errorProvider1.SetError(txb_EditFname, null);
        }

        private void txb_EditLname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_EditLname.Text))
                errorProvider1.SetError(txb_EditLname, "Tên không được để trống!");
            else if (!Regex.IsMatch(txb_EditLname.Text.Trim(), namePattern))
                errorProvider1.SetError(txb_EditLname, "Tên không được chứa số hoặc ký tự đặc biệt!");
            else
                errorProvider1.SetError(txb_EditLname, null);
        }

        private void txb_EditPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_EditPhone.Text))
                errorProvider1.SetError(txb_EditPhone, "Số điện thoại không được để trống!");
            else if (!Regex.IsMatch(txb_EditPhone.Text.Trim(), phonePattern))
                errorProvider1.SetError(txb_EditPhone, "Số điện thoại phải là chữ số dài từ 9 đến 11 ký tự!");
            else
                errorProvider1.SetError(txb_EditPhone, null);
        }

        private void txb_EditEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_EditEmail.Text))
                errorProvider1.SetError(txb_EditEmail, "Địa chỉ Email không được để trống!");
            else if (!Regex.IsMatch(txb_EditEmail.Text.Trim(), emailPattern))
                errorProvider1.SetError(txb_EditEmail, "Email không đúng định dạng chuẩn (Ví dụ: abc@gmail.com)!");
            else
                errorProvider1.SetError(txb_EditEmail, null);
        }

        // =========================================================================
        // THỰC THI LỆNH CẬP NHẬT HOẶC XÓA HỒ SƠ
        // =========================================================================

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txb_EditFname_TextChanged(null, null);
            txb_EditLname_TextChanged(null, null);
            txb_EditPhone_TextChanged(null, null);
            txb_EditEmail_TextChanged(null, null);

            if (!string.IsNullOrEmpty(errorProvider1.GetError(txb_EditFname)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_EditLname)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_EditPhone)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_EditEmail)))
            {
                MessageBox.Show("Vui lòng sửa các trường thông tin đang báo lỗi màu đỏ trước khi lưu dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime birthDate = dtpEditDob.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            if (birthDate >= today || age < 17 || age > 60)
            {
                MessageBox.Show($"Độ tuổi chỉnh sửa ({age} tuổi) không hợp lệ quy chế đào tạo (Yêu cầu từ 17 - 60 tuổi)!", "Lỗi tuổi học viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🟢 SỬA TẠI ĐÂY: Khởi tạo thực thể sinh viên nhận MSSV kiểu chuỗi string công khai
            Student sv = new Student(
                TargetMSSV,
                txb_EditFname.Text.Trim(),
                txb_EditLname.Text.Trim(),
                dtpEditDob.Value,
                cboEditGender.Text,
                txb_EditPhone.Text.Trim(),
                txb_EditAddress.Text.Trim(),
                txb_EditHometown.Text.Trim(),
                txb_EditEmail.Text.Trim(),
                studentImage
            );

            if (sv.EditStudent())
            {
                MessageBox.Show("Cập nhật thông tin hồ sơ sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi hệ thống hoặc kết nối cơ sở dữ liệu.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 🟢 SỬA TẠI ĐÂY: Kiểm tra chuỗi rỗng
            if (string.IsNullOrEmpty(TargetMSSV)) return;

            // Kiểm tra ràng buộc ngăn chặn xóa nếu tồn tại bản ghi điểm số trong bảng Score
            if (HasScoreRecords(TargetMSSV))
            {
                MessageBox.Show($"Tuyệt đối không thể xóa sinh viên này! Sinh viên mã số {TargetMSSV} hiện đã được ghi nhận bảng điểm chi tiết trong hệ thống (Bảng Score).",
                                "Vi phạm ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vĩnh viễn sinh viên mang mã số {TargetMSSV} khỏi hệ thống?",
                "Xác nhận hành động xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                Student sv = new Student();
                sv.MSSV = TargetMSSV; // MSSV kiểu string nhận trực tiếp từ TargetMSSV

                if (sv.DeleteStudent())
                {
                    MessageBox.Show("Xóa thông tin hồ sơ sinh viên thành công vĩnh viễn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại! Lỗi kết nối máy chủ SQL Server.", "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Hàm kiểm tra phụ trợ check bảng Score sử dụng tham số chuỗi
        /// </summary>
        private bool HasScoreRecords(string mssv)
        {
            My_DB myDb = new My_DB();
            string query = "SELECT COUNT(*) FROM Score WHERE MSSV = @mssv";

            using (SqlConnection conn = myDb.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 SỬA TẠI ĐÂY: Chuyển đổi SqlDbType sang NVarChar kích thước 20
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv.Trim();
                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                    catch { return false; }
                }
            }
        }

        // =========================================================================
        // HỆ THỐNG GIAO DIỆN PHỤ TRỢ KHÁC
        // =========================================================================

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (picEditStudent.Image != null) picEditStudent.Image.Dispose();

                    picEditStudent.Image = Image.FromFile(ofd.FileName);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        picEditStudent.Image.Save(ms, picEditStudent.Image.RawFormat);
                        studentImage = ms.ToArray();
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_EditStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (picEditStudent.Image != null)
            {
                picEditStudent.Image.Dispose();
            }
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
    }
}
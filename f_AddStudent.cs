using QuanLySinhVien;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_AddStudent : Form
    {
        private byte[] studentImage = null;

        // Định nghĩa sẵn các chuỗi mẫu biểu thức chính quy (Regex) dùng chung
        private readonly string namePattern = @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÂÊÔƠỨỪỬỮỰẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăâêôơứừửữựấẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪỬỮỰYỲÝỶỸỸửữựỳýỷỹ\s]+$";
        private readonly string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private readonly string phonePattern = @"^\d{9,11}$"; // Số điện thoại từ 9 đến 11 chữ số

        public f_AddStudent()
        {
            InitializeComponent();
            // Đổ bóng hiệu ứng viền hiện đại cho Form Dialog
            Guna.UI2.WinForms.Guna2ShadowForm shadow = new Guna.UI2.WinForms.Guna2ShadowForm();
            shadow.SetShadowForm(this);

            RegisterRealTimeValidation();
        }

        private void RegisterRealTimeValidation()
        {
            txtMSSV.TextChanged += txtMSSV_TextChanged;
            txtFname.TextChanged += txtFname_TextChanged;
            txtLname.TextChanged += txtLname_TextChanged;
            txtPhone.TextChanged += txtPhone_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
        }

        // =========================================================================
        // CÁC SỰ KIỆN KIỂM TRA DỮ LIỆU ĐẾN ĐÂU CHECK ĐẾN ĐÓ (REAL-TIME VALIDATION)
        // =========================================================================

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {
            // 🟢 SỬA TẠI ĐÂY: Chấp nhận mã sinh viên dạng chuỗi, chỉ validate không được để trống và độ dài tối đa 20 ký tự
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                errorProvider1.SetError(txtMSSV, "Mã số sinh viên (MSSV) không được để trống!");
            }
            else if (txtMSSV.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(txtMSSV, "Mã số sinh viên vượt quá độ dài tối đa cho phép (20 ký tự)!");
            }
            else
            {
                errorProvider1.SetError(txtMSSV, null); // Hợp lệ -> Xóa lỗi đỏ
            }
        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                errorProvider1.SetError(txtFname, "Họ đệm không được để trống!");
            }
            else if (!Regex.IsMatch(txtFname.Text.Trim(), namePattern))
            {
                errorProvider1.SetError(txtFname, "Họ đệm không được chứa chữ số hoặc ký tự đặc biệt!");
            }
            else
            {
                errorProvider1.SetError(txtFname, null);
            }
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                errorProvider1.SetError(txtLname, "Tên không được để trống!");
            }
            else if (!Regex.IsMatch(txtLname.Text.Trim(), namePattern))
            {
                errorProvider1.SetError(txtLname, "Tên không được chứa chữ số hoặc ký tự đặc biệt!");
            }
            else
            {
                errorProvider1.SetError(txtLname, null);
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại không được để trống!");
            }
            else if (!Regex.IsMatch(txtPhone.Text.Trim(), phonePattern))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại bắt buộc phải là số và dài từ 9 đến 11 ký tự!");
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Địa chỉ Email không được để trống!");
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng cấu trúc chuẩn (Ví dụ: sv@school.edu.vn)!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        // =========================================================================
        // XỬ LÝ SỰ KIỆN NÚT BẤM (BUTTON CLICK)
        // =========================================================================

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (picStudent.Image != null) picStudent.Image.Dispose();

                    picStudent.Image = Image.FromFile(ofd.FileName);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                        studentImage = ms.ToArray();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kích hoạt đồng loạt kiểm tra dữ liệu
            txtMSSV_TextChanged(null, null);
            txtFname_TextChanged(null, null);
            txtLname_TextChanged(null, null);
            txtPhone_TextChanged(null, null);
            txtEmail_TextChanged(null, null);

            if (!string.IsNullOrEmpty(errorProvider1.GetError(txtMSSV)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txtFname)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txtLname)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txtPhone)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txtEmail)))
            {
                MessageBox.Show("Vui lòng sửa các trường thông tin đang báo lỗi màu đỏ trước khi thực hiện thêm mới!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime birthDate = dtpDob.Value;
            DateTime today = DateTime.Today;

            if (birthDate >= today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng chọn ngày nhỏ hơn ngày hiện tại.", "Lỗi ngày sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            if (age < 17 || age > 60)
            {
                MessageBox.Show($"Độ tuổi của sinh viên ({age} tuổi) không hợp lệ (Yêu cầu từ 17 - 60 tuổi)!", "Lỗi ngày sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (studentImage == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh thẻ đại diện cho sinh viên!", "Thiếu ảnh thẻ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🟢 SỬA TẠI ĐÂY: Truyền trực tiếp chuỗi txtMSSV.Text sạch không cần ép sang kiểu int
            string mssv = txtMSSV.Text.Trim();

            Student sv = new Student(
                mssv, // Nhận giá trị chuỗi NVARCHAR(20) mới
                txtFname.Text.Trim(),
                txtLname.Text.Trim(),
                dtpDob.Value,
                cboGender.Text,
                txtPhone.Text.Trim(),
                txtHometown.Text.Trim(), // Cột Address
                txtHometown.Text.Trim(), // Cột Htown
                txtEmail.Text.Trim(),
                studentImage
            );

            if (sv.AddStudent())
            {
                MessageBox.Show("Thêm dữ liệu hồ sơ sinh viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Mã số sinh viên (MSSV) này có thể đã tồn tại trong hệ thống.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtPhone.Clear();
            txtHometown.Clear();
            txtEmail.Clear();
            cboGender.SelectedIndex = 0;
            dtpDob.Value = new DateTime(2005, 1, 1);

            errorProvider1.SetError(txtMSSV, null);
            errorProvider1.SetError(txtFname, null);
            errorProvider1.SetError(txtLname, null);
            errorProvider1.SetError(txtPhone, null);
            errorProvider1.SetError(txtEmail, null);

            if (picStudent.Image != null)
            {
                picStudent.Image.Dispose();
                picStudent.Image = null;
            }
            studentImage = null;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_AddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (picStudent.Image != null)
            {
                picStudent.Image.Dispose();
            }
        }
    }
}
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Register : Form
    {
        private int position;

        // =========================================================================
        // Bộ Regex tối ưu hóa 100% tiếng Việt chuẩn Unicode và bảo mật mật khẩu
        // =========================================================================
        private readonly string namePattern = @"^[\p{L}\s]+$";
        private readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private readonly string passwordPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        public f_Register()
        {
            InitializeComponent();
            RegisterRealTimeValidationEvents();
        }

        public f_Register(int pos)
        {
            InitializeComponent();
            RegisterRealTimeValidationEvents();

            if (pos == 1 || pos == 2)
            {
                this.position = pos;
            }
            else
            {
                this.position = 1;
            }
        }

        private void RegisterRealTimeValidationEvents()
        {
            txb_ID.TextChanged += txb_ID_TextChanged;
            txb_Fname.TextChanged += txb_Fname_TextChanged;
            txb_Lname.TextChanged += txb_Lname_TextChanged;
            txb_User.TextChanged += txb_User_TextChanged;
            txb_Pass.TextChanged += txb_Pass_TextChanged;
            txb_Email.TextChanged += txb_Email_TextChanged;
        }

        private void txb_ID_TextChanged(object sender, EventArgs e)
        {
            // 🟢 SỬA TẠI ĐÂY: Chấp nhận ID dạng chuỗi ký tự tự đặt, chỉ validate không trống và độ dài tối đa 20 ký tự
            if (string.IsNullOrWhiteSpace(txb_ID.Text))
            {
                errorProvider1.SetError(txb_ID, "Vui lòng nhập mã định danh (ID)!");
            }
            else if (txb_ID.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(txb_ID, "Mã định danh vượt quá độ dài tối đa cho phép (20 ký tự)!");
            }
            else
            {
                errorProvider1.SetError(txb_ID, null);
            }
        }

        private void txb_Fname_TextChanged(object sender, EventArgs e)
        {
            string value = txb_Fname.Text.Trim();

            if (string.IsNullOrWhiteSpace(txb_Fname.Text))
            {
                errorProvider1.SetError(txb_Fname, "Họ và tên đệm không được để trống!");
            }
            else if (!Regex.IsMatch(value, namePattern))
            {
                errorProvider1.SetError(txb_Fname, "Họ tên không chứa số hoặc ký tự đặc biệt!");
            }
            else
            {
                errorProvider1.SetError(txb_Fname, null);
            }
        }

        private void txb_Lname_TextChanged(object sender, EventArgs e)
        {
            string value = txb_Lname.Text.Trim();

            if (string.IsNullOrWhiteSpace(txb_Lname.Text))
            {
                errorProvider1.SetError(txb_Lname, "Tên không được để trống!");
            }
            else if (!Regex.IsMatch(value, namePattern))
            {
                errorProvider1.SetError(txb_Lname, "Tên không chứa số hoặc ký tự đặc biệt!");
            }
            else
            {
                errorProvider1.SetError(txb_Lname, null);
            }
        }

        private void txb_User_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_User.Text))
            {
                errorProvider1.SetError(txb_User, "Vui lòng nhập tên tài khoản!");
            }
            else
            {
                errorProvider1.SetError(txb_User, null);
            }
        }

        private void txb_Pass_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_Pass.Text))
            {
                errorProvider1.SetError(txb_Pass, "Vui lòng nhập mật khẩu!");
            }
            else if (!Regex.IsMatch(txb_Pass.Text, passwordPattern))
            {
                errorProvider1.SetError(txb_Pass, "Mật khẩu yếu! Cần ít nhất 8 ký tự, 1 chữ hoa, 1 số và 1 ký tự đặc biệt.");
            }
            else
            {
                errorProvider1.SetError(txb_Pass, null);
            }
        }

        private void txb_Email_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_Email.Text))
            {
                errorProvider1.SetError(txb_Email, "Vui lòng nhập Email!");
            }
            else if (!Regex.IsMatch(txb_Email.Text.Trim(), emailPattern))
            {
                errorProvider1.SetError(txb_Email, "Email không đúng định dạng chuẩn (Ví dụ: abc@school.edu.vn)!");
            }
            else
            {
                errorProvider1.SetError(txb_Email, null);
            }
        }

        private void bt_Register_Click(object sender, EventArgs e)
        {
            txb_ID_TextChanged(null, null);
            txb_Fname_TextChanged(null, null);
            txb_Lname_TextChanged(null, null);
            txb_User_TextChanged(null, null);
            txb_Pass_TextChanged(null, null);
            txb_Email_TextChanged(null, null);

            if (!string.IsNullOrEmpty(errorProvider1.GetError(txb_ID)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_Fname)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_Lname)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_User)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_Pass)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txb_Email)))
            {
                MessageBox.Show("Vui lòng sửa các trường thông tin đang báo lỗi màu đỏ trước khi đăng ký!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ptb_Picture.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh đại diện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!existID())
            {
                MessageBox.Show("Mã định danh đã tồn tại!", "Lỗi duy nhất", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ID.Focus();
                return;
            }
            if (!existUser())
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại trên hệ thống!", "Lỗi duy nhất", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_User.Focus();
                return;
            }
            if (!existEmail())
            {
                MessageBox.Show("Địa chỉ Email này đã được đăng ký tài khoản khác!", "Lỗi duy nhất", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_Email.Focus();
                return;
            }

            string generatedOTP = Globals.SendOTPEmail(txb_Email.Text.Trim());

            if (generatedOTP != null)
            {
                f_OTP otpForm = new f_OTP(generatedOTP, txb_Email.Text.Trim());
                this.Hide();

                if (otpForm.ShowDialog() == DialogResult.OK)
                {
                    if (RegisterAccount())
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công! Vui lòng chờ Quản trị viên (Admin) phê duyệt để có thể đăng nhập.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.FormClosing -= f_Register_FormClosing;
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong quá trình thao tác ghi dữ liệu xuống cơ sở dữ liệu!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                    }
                }
                else
                {
                    this.Show();
                }
            }
        }

        bool RegisterAccount()
        {
            My_DB my_db = new My_DB();

            using (MemoryStream picture = new MemoryStream())
            {
                ptb_Picture.Image.Save(picture, ptb_Picture.Image.RawFormat);
                byte[] picBytes = picture.ToArray();

                string query = "INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Pic, Valid) " +
                               "VALUES (@id, @fn, @ln, @pos, @user, @pass, @email, @pic, @val)";

                using (SqlConnection conn = my_db.getConnection)
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        // 🟢 SỬA TẠI ĐÂY: Truyền chuỗi trực tiếp, đổi SqlDbType sang NVarChar(20)
                        command.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = txb_ID.Text.Trim();
                        command.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = txb_Fname.Text.Trim();
                        command.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = txb_Lname.Text.Trim();
                        command.Parameters.Add("@pos", SqlDbType.Int).Value = this.position;
                        command.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txb_User.Text.Trim();
                        command.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = txb_Pass.Text;
                        command.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txb_Email.Text.Trim();
                        command.Parameters.Add("@pic", SqlDbType.VarBinary).Value = picBytes;
                        command.Parameters.Add("@val", SqlDbType.Int).Value = 0;

                        try
                        {
                            conn.Open();
                            return command.ExecuteNonQuery() == 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi thực thi CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
        }

        bool existUser()
        {
            My_DB my_db = new My_DB();
            string query = "SELECT COUNT(*) FROM Login WHERE UserName = @user";

            using (SqlConnection conn = my_db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txb_User.Text.Trim();
                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar() == 0;
                    }
                    catch { return false; }
                }
            }
        }

        bool existID()
        {
            My_DB my_db = new My_DB();
            string query = "SELECT COUNT(*) FROM Login WHERE Id = @id";

            using (SqlConnection conn = my_db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 SỬA TẠI ĐÂY: Check trùng khóa chính bằng tham số chuỗi NVarChar(20)
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = txb_ID.Text.Trim();

                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar() == 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        bool existEmail()
        {
            My_DB my_db = new My_DB();
            string query = "SELECT COUNT(*) FROM Login WHERE Email = @email";

            using (SqlConnection conn = my_db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txb_Email.Text.Trim();
                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar() == 0;
                    }
                    catch { return false; }
                }
            }
        }

        private void ptb_Picture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opnfd = new OpenFileDialog())
            {
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (opnfd.ShowDialog() == DialogResult.OK)
                {
                    ptb_Picture.Image = new Bitmap(opnfd.FileName);
                    ptb_Picture.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void f_Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát đăng ký không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.FormClosing -= f_Register_FormClosing;
                Application.Exit();
            }
        }

        private void f_Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ptb_Picture.Image != null)
            {
                ptb_Picture.Image.Dispose();
            }
        }
    }
}
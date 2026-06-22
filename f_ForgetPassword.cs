using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ForgetPassword : Form
    {
        // Bộ nhớ đệm lưu trữ thông tin xác thực an toàn ngầm
        private string systemGeneratedOTP = string.Empty;
        private bool isOtpVerified = false;

        public f_ForgetPassword()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        private void RegisterFormEvents()
        {
            this.Load += f_ForgetPassword_Load;
            this.btnGuiOTP.Click += btnGuiOTP_Click;
            this.btnCapNhat.Click += btnCapNhat_Click;
        }

        private void f_ForgetPassword_Load(object sender, EventArgs e)
        {
            // Trạng thái ban đầu: Dọn trống dữ liệu mẫu
            txtEmail.Clear();
            txtMaOTP.Clear();
            txtMatKhauMoi.Clear();

            // BẢO MẬT: Khóa các ô mã OTP và mật khẩu mới lại, chỉ mở khi Email tồn tại và gửi OTP thành công
            txtMaOTP.Enabled = false;
            txtMatKhauMoi.Enabled = false;
            btnCapNhat.Enabled = false;
        }

        // =========================================================================
        // LUỒNG XỬ LÝ 1: KIỂM TRA EMAIL VÀ TIẾN HÀNH GỬI MÃ OTP XÁC THỰC
        // =========================================================================
        private void btnGuiOTP_Click(object sender, EventArgs e)
        {
            string emailInput = txtEmail.Text.Trim();

            // Kiểm tra định dạng Email cấu trúc chuẩn bằng Regex tránh gửi bừa
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (string.IsNullOrWhiteSpace(emailInput) || !Regex.IsMatch(emailInput, emailPattern))
            {
                MessageBox.Show("Địa chỉ Email trống hoặc không đúng định dạng chuẩn hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Kiểm tra sự tồn tại của Email trong cơ sở dữ liệu
            if (IsEmailExistInSystem(emailInput))
            {
                try
                {
                    // Gọi hàm gửi mail an toàn từ lớp Globals.cs tập trung
                    string otp = Globals.SendOTPEmail(emailInput);

                    if (!string.IsNullOrEmpty(otp))
                    {
                        systemGeneratedOTP = otp; // Lưu lại mã để đối chiếu
                        isOtpVerified = false;    // Reset lại trạng thái xác thực

                        MessageBox.Show("Mã xác thực OTP đã được gửi thành công vào hòm thư của bạn.\nVui lòng kiểm tra và nhập mã!",
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở khóa các điều khiển để người dùng nhập tiếp bước sau
                        txtMaOTP.Enabled = true;
                        txtMatKhauMoi.Enabled = true;
                        btnCapNhat.Enabled = true;
                        txtMaOTP.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống gửi mail gặp sự cố, vui lòng thử lại sau!", "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi luồng xử lý gửi OTP: " + ex.Message, "Thông báo lỗi");
                }
            }
            else
            {
                MessageBox.Show("Địa chỉ Email này hoàn toàn không tồn tại trên hệ thống dữ liệu toàn trường!", "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }

        // =========================================================================
        // LUỒNG XỬ LÝ 2: ĐỐI CHIẾU OTP VÀ TIẾN HÀNH CẬP NHẬT MẬT KHẨU MỚI
        // =========================================================================
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string emailInput = txtEmail.Text.Trim();
            string otpInput = txtMaOTP.Text.Trim();
            string newPass = txtMatKhauMoi.Text;

            // 1. Kiểm tra tính hợp lệ của mã OTP nhập vào
            if (string.IsNullOrEmpty(systemGeneratedOTP) || !otpInput.Equals(systemGeneratedOTP))
            {
                MessageBox.Show("Mã xác thực OTP nhập vào không chính xác hoặc đã hết hạn! Vui lòng kiểm tra lại.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaOTP.Focus();
                return;
            }

            isOtpVerified = true; // Đánh dấu xác thực thành công vượt qua rào bảo mật

            // 2. Kiểm tra độ mạnh mật khẩu mới bám sát tiêu chuẩn dự án
            string passPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            if (string.IsNullOrWhiteSpace(newPass) || !Regex.IsMatch(newPass, passPattern))
            {
                MessageBox.Show("Mật khẩu mới quá yếu! Phải chứa ít nhất 8 ký tự, bao gồm ít nhất 1 chữ hoa, 1 chữ số và 1 ký tự đặc biệt.",
                                "Mật khẩu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // 3. Thực thi băm mật khẩu mã hóa SHA-256 an toàn thông tin
            string secureHashPassword = ComputeSHA256(newPass);

            // 4. Ghi đè cập nhật mật khẩu mới xuống CSDL
            if (isOtpVerified && UpdateUserPassword(emailInput, secureHashPassword))
            {
                MessageBox.Show("Mật khẩu tài khoản của bạn đã được khôi phục và cập nhật thành công!\nBạn có thể đăng nhập bằng mật khẩu mới ngay bây giờ.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Hệ thống dữ liệu CSDL gặp sự cố khi cập nhật. Vui lòng thử lại sau!", "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // CÁC HÀM TRUY VẤN VẬT LÝ TỐI ƯU SỬ DỤNG CONNECTION POOLING
        // =========================================================================

        private bool IsEmailExistInSystem(string email)
        {
            My_DB myDb = new My_DB();
            // Truy vấn cộng gộp tối ưu bằng chỉ mục ExecuteScalar trả về 1 con số duy nhất
            string query = "SELECT (SELECT COUNT(*) FROM Login WHERE Email = @email) + (SELECT COUNT(*) FROM HR WHERE Email = @email)";

            using (SqlConnection conn = myDb.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                    catch { return false; }
                }
            }
        }

        private bool UpdateUserPassword(string email, string encryptedPassword)
        {
            My_DB myDb = new My_DB();

            using (SqlConnection conn = myDb.getConnection)
            {
                try
                {
                    conn.Open(); // Mở kết nối duy nhất của khối using phục vụ đúng cơ chế Transaction
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Cập nhật bảng Login tập trung (Dành cho Sinh viên/Admin)
                            string queryLogin = "UPDATE Login SET Password = @pass WHERE Email = @email";
                            using (SqlCommand cmdLogin = new SqlCommand(queryLogin, conn, transaction))
                            {
                                cmdLogin.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = encryptedPassword;
                                cmdLogin.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
                                cmdLogin.ExecuteNonQuery();
                            }

                            // Cập nhật bảng HR độc lập (Dành cho Giảng viên/Quản lý nhân sự)
                            string queryHR = "UPDATE HR SET Pass = @pass WHERE Email = @email";
                            using (SqlCommand cmdHR = new SqlCommand(queryHR, conn, transaction))
                            {
                                cmdHR.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = encryptedPassword;
                                cmdHR.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
                                cmdHR.ExecuteNonQuery();
                            }

                            transaction.Commit(); // Xác nhận lưu thay đổi đồng loạt an toàn dữ liệu
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback(); // Hoàn tác thu hồi nếu có bất kỳ bảng nào cập nhật lỗi
                            return false;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Hàm băm bảo mật SHA-256 đồng bộ hệ thống đăng ký tài khoản
        /// </summary>
        private string ComputeSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
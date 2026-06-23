using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace QuanLySinhVien
{
    public partial class f_Login : Form
    {
        // Dictionary để lưu số lần đăng nhập sai theo từng UserName
        private static System.Collections.Generic.Dictionary<string, int> failedLoginAttempts = new System.Collections.Generic.Dictionary<string, int>();

        public f_Login()
        {
            InitializeComponent();
        }

        private void f_Login_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;
        }

        /// <summary>
        /// Logic xử lý sự kiện bấm nút Đăng nhập - Tự động dò vai trò từ cơ sở dữ liệu
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào không được bỏ trống
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentUsernameInput = txtUsername.Text.Trim();

            // Kiểm tra xem tài khoản này có đang bị khóa do nhập sai 5 lần không
            if (failedLoginAttempts.ContainsKey(currentUsernameInput) && failedLoginAttempts[currentUsernameInput] >= 5)
            {
                TriggerOTPLockflow(currentUsernameInput);
                return;
            }

            My_DB db = new My_DB();
            DataTable table = new DataTable();

            // 2. Câu lệnh SQL tự động quét tài khoản, phân biệt chữ hoa/thường bằng mệnh đề COLLATE
            // Điều kiện: Tài khoản đã kích hoạt (Valid = 1) HOẶC là tài khoản Admin (Position = 0)
            string query = "SELECT * FROM [Login] WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @User " +
                           "AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = @Password " +
                           "AND (Valid = 1 OR Position = 0)";

            // 3. Sử dụng cấu trúc using lồng nhau để giải phóng bộ nhớ kết nối (Connection Pooling)
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Sử dụng SqlParameter bảo mật tuyệt đối chống lỗi SQL Injection
                    command.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 255).Value = ComputeSHA256(txtPassword.Text);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            conn.Open(); // Mượn một kết nối đang rảnh ngầm từ Connection Pool
                            adapter.Fill(table);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                } // command tự giải phóng tài nguyên mạng
            } // conn tự động đóng hoàn toàn và đẩy ngược về lại Connection Pool tại đây

            // 4. Kiểm tra kết quả trả về sau khi ngắt kết nối an toàn
            if (table.Rows.Count > 0)
            {
                // Reset số lần sai khi đăng nhập thành công
                failedLoginAttempts[currentUsernameInput] = 0;

                DataRow row = table.Rows[0];

                // 🟢 SỬA TẠI ĐÂY: Đọc trực tiếp trường Id dưới dạng chuỗi string, loại bỏ Convert.ToInt32 cũ
                string userId = row["Id"].ToString();
                string currentUsername = row["UserName"].ToString();
                int finalPosition = Convert.ToInt32(row["Position"]); // TỰ ĐỘNG DÒ VAI TRÒ: 0 = Admin, 1 = Student, 2 = HR
                string email = row["Email"].ToString();

                // 5. Đưa thông tin tài khoản vừa dò được lên bộ nhớ tạm toàn cục Globals
                // Giúp Form chính (f_main) sau này có thể đọc trực tiếp ra để hiển thị menu mà không cần SELECT lại DB
                Globals.SetGlobalUserInfo(userId, currentUsername, finalPosition, email);

                string roleName = finalPosition == 0 ? "Quản trị viên" : (finalPosition == 2 ? "Nhân sự HR" : "Sinh viên");
                MessageBox.Show($"Chào mừng {Globals.GlobalUserName}! Đăng nhập thành công với vai trò {roleName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 6. Khởi chạy Form chính f_MainDashboard nhận biến truyền vào kiểu chuỗi string và ẩn Form hiện tại
                f_MainDashboard main = new f_MainDashboard(userId, finalPosition, currentUsername, email);
                main.Show();
                this.Hide();
            }
            else
            {
                if (!failedLoginAttempts.ContainsKey(currentUsernameInput))
                {
                    failedLoginAttempts[currentUsernameInput] = 0;
                }
                failedLoginAttempts[currentUsernameInput]++;

                if (failedLoginAttempts[currentUsernameInput] >= 5)
                {
                    TriggerOTPLockflow(currentUsernameInput);
                }
                else
                {
                    MessageBox.Show($"Tên đăng nhập, mật khẩu không chính xác hoặc tài khoản của bạn đang chờ hệ thống phê duyệt!\n(Đã sai {failedLoginAttempts[currentUsernameInput]}/5 lần)",
                                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void TriggerOTPLockflow(string username)
        {
            string userEmail = GetEmailByUsername(username);
            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Tài khoản không tồn tại hoặc không có email liên kết. Vui lòng liên hệ Quản trị viên.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tài khoản của bạn đã bị khóa do nhập sai mật khẩu 5 lần!\nHệ thống sẽ tiến hành gửi một mã OTP đến email của bạn để xác thực mở khóa.", "Khóa tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            string otp = Globals.SendOTPEmail(userEmail);
            if (!string.IsNullOrEmpty(otp))
            {
                f_OTP fOtp = new f_OTP(otp, userEmail);
                if (fOtp.ShowDialog() == DialogResult.OK)
                {
                    failedLoginAttempts[username] = 0; // Reset số lần sai
                    MessageBox.Show("Đã xác nhận OTP thành công! Bạn có thể tiến hành nhập lại mật khẩu để vào hệ thống.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lỗi gửi mail hệ thống, vui lòng kiểm tra kết nối mạng và thử lại sau!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f_Register fRegister = new f_Register(1); // Mặc định đăng ký mới là quyền Student
            fRegister.Show();
            this.Hide();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f_ForgetPassword forgetPass = new f_ForgetPassword();
            this.Hide();
            forgetPass.ShowDialog();
            this.Show();
        }

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

        private string GetEmailByUsername(string username)
        {
            My_DB db = new My_DB();
            string query = "SELECT Email FROM [Login] WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @User";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = username;
                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                    catch { }
                }
            }
            return null;
        }
    }
}
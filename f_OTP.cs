using QuanLySinhVien;
using System;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_OTP : Form
    {
        private string receivedOTP;
        private string destinationEmail;

        // Cấu hình các biến phục vụ bộ đếm ngược thời gian
        private int totalSeconds = 300; // 5 phút = 300 giây theo đặc tả hệ thống
        private int resendCooldown = 60; // Người dùng phải đợi 60 giây mới được bấm gửi lại mã mới
        private Timer countdownTimer;

        public f_OTP(string otp, string email)
        {
            InitializeComponent();
            this.receivedOTP = otp;
            this.destinationEmail = email;
            InitializeTimer();
        }

        /// <summary>
        /// Khởi tạo và cấu hình bộ đếm thời gian an toàn ngầm
        /// </summary>
        private void InitializeTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Chạy lặp lại sau mỗi 1 giây (1000 ms)
            countdownTimer.Tick += CountdownTimer_Tick;

            this.Load += (s, e) => {
                countdownTimer.Start();
                btn_Resend.Enabled = false; // Khóa nút gửi lại khi vừa mở form
            };
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            // 1. Xử lý đếm ngược thời gian sống của mã OTP (5 phút)
            if (totalSeconds > 0)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                // Định dạng hiển thị chuỗi mm:ss (Ví dụ: 04:59) lên giao diện
                lbl_Timer.Text = $"Mã OTP hết hiệu lực sau: {minutes:D2}:{seconds:D2}";
            }
            else
            {
                countdownTimer.Stop();
                receivedOTP = string.Empty; // Xóa mã OTP cũ để vô hiệu hóa hoàn toàn
                lbl_Timer.Text = "Mã OTP đã hết hiệu lực! Vui lòng bấm gửi lại mã mới.";
                btn_Verify.Enabled = false; // Vô hiệu hóa nút Xác thực
            }

            // 2. Xử lý thời gian chờ để được bấm nút Gửi lại mã (Cooldown 60s)
            if (resendCooldown > 0)
            {
                resendCooldown--;
                btn_Resend.Text = $"Gửi lại ({resendCooldown}s)";
            }
            else
            {
                if (totalSeconds > 0) // Chỉ cho gửi lại nếu form chưa hoàn toàn hết hạn
                {
                    btn_Resend.Enabled = true;
                    btn_Resend.Text = "Gửi lại mã";
                }
            }
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Code.Text))
            {
                MessageBox.Show("Vui lòng nhập mã OTP xác thực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đối chiếu chính xác mã nhập vào với bộ nhớ đệm hệ thống
            if (txt_Code.Text.Trim().Equals(receivedOTP))
            {
                countdownTimer.Stop();
                MessageBox.Show("Xác nhận mã OTP thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Phản hồi tín hiệu hợp lệ về Form Register
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã xác nhận không chính xác, vui lòng kiểm tra lại hòm thư!", "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Resend_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm gửi qua lớp Globals tập trung dùng chung
                string newOTP = Globals.SendOTPEmail(destinationEmail);

                // Kiểm tra an toàn bảo mật đề phòng luồng mạng xảy ra lỗi
                if (!string.IsNullOrEmpty(newOTP))
                {
                    receivedOTP = newOTP; // Cập nhật mã OTP mới thành công
                    MessageBox.Show("Mã OTP mới đã được gửi lại vào hòm thư của bạn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset lại toàn bộ chu trình thời gian sống của form
                    totalSeconds = 300;
                    resendCooldown = 60;
                    btn_Resend.Enabled = false;
                    btn_Verify.Enabled = true;
                    countdownTimer.Start();
                }
                else
                {
                    MessageBox.Show("Hệ thống gửi mail gặp sự cố, vui lòng thử lại sau ít phút!", "Lỗi gửi mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối mạng gửi lại mã: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đảm bảo dừng bộ Timer giải phóng tài nguyên bộ nhớ khi Form đóng lại
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (countdownTimer != null)
            {
                countdownTimer.Stop();
                countdownTimer.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
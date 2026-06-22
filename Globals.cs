using System;
using System.Configuration; // Dùng để đọc App.config
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public static class Globals
    {
        // Đưa Random ra ngoài làm biến static tĩnh để tránh trùng lặp mã OTP khi gọi liên tục
        private static readonly Random _rand = new Random();

        // =========================================================================
        // 1. CÁC THUỘC TÍNH PHIÊN ĐĂNG NHẬP
        // =========================================================================
        public static string GlobalUserId { get; private set; }
        public static string GlobalUserName { get; private set; }
        public static int GlobalUserRole { get; private set; } // (0: Admin, 1: Sinh viên, 2: HR)
        public static string GlobalUserEmail { get; private set; }

        public static void SetGlobalUserInfo(string id, string username, int role, string email)
        {
            GlobalUserId = id;
            GlobalUserName = username;
            GlobalUserRole = role;
            GlobalUserEmail = email;
        }

        public static void ClearSession()
        {
            GlobalUserId = string.Empty;
            GlobalUserName = string.Empty;
            GlobalUserRole = 1;
            GlobalUserEmail = string.Empty;
        }

        // =========================================================================
        // 2. CƠ CHẾ TỰ ĐỘNG PHÁT SINH VÀ GỬI MÃ OTP QUA HỆ THỐNG EMAIL (TỐI ƯU)
        // =========================================================================
        public static string SendOTPEmail(string targetEmail)
        {
            // Sinh mã OTP 6 số an toàn từ biến Random tĩnh dùng chung
            string otpCode = _rand.Next(100000, 999999).ToString();

            try
            {
                // Đọc an toàn thông tin bảo mật từ App.config thay vì hardcode
                string senderEmail = ConfigurationManager.AppSettings["SmtpSenderEmail"];
                string appPassword = ConfigurationManager.AppSettings["SmtpAppPassword"];

                var fromAddress = new MailAddress(senderEmail, "HỆ THỐNG QUẢN LÝ SV");
                var toAddress = new MailAddress(targetEmail);

                string subject = "Mã xác thực hệ thống - OTP Code";
                string body = $"Mã OTP xác thực mới của bạn là: {otpCode}\nLưu ý: Mã này chỉ có hiệu lực trong vòng 5 phút.";

                // Áp dụng cấu trúc using cho SmtpClient để tự động đóng kết nối mạng sau khi gửi xong
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    // Cấu hình Credentials
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                    smtp.Timeout = 20000;

                    using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                    {
                        smtp.Send(message);
                    }
                } // Kết nối mạng của smtp tự động ngắt và giải phóng an toàn tại đây

                return otpCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chi tiết lỗi phản hồi từ máy chủ SMTP:\n" + ex.Message, "Lỗi thực thi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
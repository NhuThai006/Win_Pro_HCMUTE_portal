using System;
using System.Configuration; // Bắt buộc phải có để đọc file App.config
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    internal class My_DB
    {
        // 1. Đọc chuỗi kết nối linh hoạt từ file App.config bằng ConfigurationManager
        private readonly string _connectionString = ConfigurationManager.AppSettings["MyDbConnectionString"];

        // 2. Thuộc tính luôn sinh ra đối tượng kết nối mới để phục vụ cấu trúc 'using' ở các Form
        // Giúp cơ chế Connection Pooling của ADO.NET hoạt động tối ưu, tự động đóng/mở và giải phóng tài nguyên.
        public SqlConnection getConnection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        // 3. Giữ lại hàm mở kết nối trống để đảm bảo các mã nguồn cũ không bị lỗi biên dịch
        public void openConnection()
        {
            // Không cần viết mã vì cấu trúc 'using' sẽ tự động mở và quản lý trực tiếp tại Form nghiệp vụ
        }

        // 4. Giữ lại hàm đóng kết nối trống
        public void closeConnection()
        {
            // Không cần viết mã vì khi thoát khỏi khối lệnh 'using', kết nối tự động đóng an toàn
        }
    }
}
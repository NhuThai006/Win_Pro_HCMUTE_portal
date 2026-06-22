using QuanLySinhVien;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class Course
    {
        private readonly My_DB db = new My_DB();

        // Đồng bộ thuộc tính với cấu trúc bảng bạn vừa gửi
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTC { get; set; }
        public int Tuan { get; set; }
        public int HocKy { get; set; }
        public string Mota { get; set; }

        public Course() { }

        public Course(string mamh, string tenmh, int sotc, int tuan, int hocky, string mota)
        {
            MaMH = mamh;
            TenMH = tenmh;
            SoTC = sotc;
            Tuan = tuan;
            HocKy = hocky;
            Mota = mota;
        }

        public bool AddCourse()
        {
            // Sửa tên cột khớp 100% với cấu trúc CREATE TABLE bạn cung cấp
            string query = "INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES (@id, @name, @stc, @tuan, @hk, @desc)";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // NVarChar(20) khớp với [MaMH] NVARCHAR(20)
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = MaMH.Trim();
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = TenMH.Trim();
                    cmd.Parameters.Add("@stc", SqlDbType.Int).Value = SoTC;
                    cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = Tuan;
                    cmd.Parameters.Add("@hk", SqlDbType.Int).Value = HocKy;
                    cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = (object)Mota?.Trim() ?? DBNull.Value;

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi SQL AddCourse: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool EditCourse()
        {
            string query = "UPDATE Course SET TenMH=@name, SoTC=@stc, Tuan=@tuan, HocKy=@hk, Mota=@desc WHERE MaMH=@id";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = MaMH.Trim();
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = TenMH.Trim();
                    cmd.Parameters.Add("@stc", SqlDbType.Int).Value = SoTC;
                    cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = Tuan;
                    cmd.Parameters.Add("@hk", SqlDbType.Int).Value = HocKy;
                    cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = (object)Mota?.Trim() ?? DBNull.Value;

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi SQL EditCourse: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static DataTable GetCourses()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            string query = "SELECT MaMH, TenMH, SoTC, Tuan, HocKy, Mota FROM Course";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        try { conn.Open(); adapter.Fill(dt); }
                        catch { }
                    }
                }
            }
            return dt;
        }
        public bool DeleteCourse()
        {
            // 1. Kiểm tra xem môn học có đang tồn tại không trước khi xóa
            string queryCheck = "SELECT COUNT(*) FROM Course WHERE MaMH = @id";

            // 2. Lệnh xóa thực thi trong Transaction để bảo đảm dữ liệu điểm (Score) không bị treo
            // Lưu ý: Nếu bạn có bảng DKMH, hãy thêm lệnh DELETE FROM DKMH vào đây tương tự
            string queryDeleteScore = "DELETE FROM Score WHERE MaMH = @id";
            string queryDeleteCourse = "DELETE FROM Course WHERE MaMH = @id";

            using (SqlConnection conn = db.getConnection)
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Xóa dữ liệu liên quan trước (Score)
                            using (SqlCommand cmd1 = new SqlCommand(queryDeleteScore, conn, transaction))
                            {
                                cmd1.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = MaMH.Trim();
                                cmd1.ExecuteNonQuery();
                            }

                            // Xóa môn học chính
                            using (SqlCommand cmd2 = new SqlCommand(queryDeleteCourse, conn, transaction))
                            {
                                cmd2.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = MaMH.Trim();
                                int rowsAffected = cmd2.ExecuteNonQuery();

                                transaction.Commit();
                                return rowsAffected > 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            System.Diagnostics.Debug.WriteLine("Lỗi xóa môn học: " + ex.Message);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi kết nối DB: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
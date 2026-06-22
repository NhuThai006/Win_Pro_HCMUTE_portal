using QuanLySinhVien;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Score
    {
        private readonly My_DB db = new My_DB();

        public string Mssv { get; set; }
        public string Mamh { get; set; }
        public decimal Diemqt { get; set; }
        public decimal Diemck { get; set; }
        public decimal Diemtk { get; set; }
        public string Mota { get; set; }

        public Score() { }

        public Score(string mssv, string mamh, decimal diemqt, decimal diemck, string mota)
        {
            Mssv = mssv;
            Mamh = mamh;
            Diemqt = diemqt;
            Diemck = diemck;
            Mota = mota;
            Diemtk = Math.Round(diemqt * 0.4m + diemck * 0.6m, 2);
        }

        public bool AddOrUpdateScore()
        {
            string query = "IF EXISTS (SELECT 1 FROM Score WHERE MSSV = @mssv AND MaMH = @mamh) " +
                           "UPDATE Score SET DiemQT = @qt, DiemCK = @ck, DiemTK = @tk, Mota = @mota WHERE MSSV = @mssv AND MaMH = @mamh " +
                           "ELSE " +
                           "INSERT INTO Score (MSSV, MaMH, DiemQT, DiemCK, DiemTK, Mota) VALUES (@mssv, @mamh, @qt, @ck, @tk, @mota)";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 ĐỒNG BỘ: Dùng NVarChar, 20 cho MSSV
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = Mssv.Trim();
                    cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = Mamh.Trim();
                    cmd.Parameters.Add("@qt", SqlDbType.Decimal).Value = Diemqt;
                    cmd.Parameters.Add("@ck", SqlDbType.Decimal).Value = Diemck;
                    cmd.Parameters.Add("@tk", SqlDbType.Decimal).Value = Diemtk;
                    cmd.Parameters.Add("@mota", SqlDbType.NVarChar, 200).Value = (object)Mota ?? DBNull.Value;

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch { return false; }
                }
            }
        }

        public bool DeleteScore()
        {
            string query = "DELETE FROM Score WHERE MSSV = @mssv AND MaMH = @mamh";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 SỬA LỖI: Trước đó bạn đang dùng SqlDbType.Int ở đây
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = Mssv.Trim();
                    cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = Mamh.Trim();

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch { return false; }
                }
            }
        }

        public static DataTable GetStudentScoreBoard(string mssv)
        {
            My_DB dbHelper = new My_DB();
            DataTable dt = new DataTable();
            string query = "SELECT s.MaMH, c.TenMH, c.SoTC, s.DiemQT, s.DiemCK, s.DiemTK, s.Mota " +
                           "FROM Score s JOIN Course c ON s.MaMH = c.MaMH WHERE s.MSSV = @mssv";

            using (SqlConnection conn = dbHelper.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 ĐỒNG BỘ: Dùng NVarChar, 20
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv.Trim();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        try { conn.Open(); adapter.Fill(dt); } catch { }
                    }
                }
            }
            return dt;
        }

        public static decimal CalculateGPA(string mssv, out int tongTinChi)
        {
            My_DB dbHelper = new My_DB();
            tongTinChi = 0;
            string query = "SELECT s.DiemTK, c.SoTC FROM Score s JOIN Course c ON s.MaMH = c.MaMH WHERE s.MSSV = @mssv";

            using (SqlConnection conn = dbHelper.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 ĐỒNG BỘ: Dùng NVarChar, 20
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv.Trim();
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            decimal tongDiemNhanTinChi = 0;
                            while (reader.Read())
                            {
                                double diem = Convert.ToDouble(reader["DiemTK"]);
                                int tinChi = Convert.ToInt32(reader["SoTC"]);

                                tongDiemNhanTinChi += (decimal)diem * tinChi;
                                tongTinChi += tinChi;
                            }
                            return (tongTinChi == 0) ? 0 : Math.Round(tongDiemNhanTinChi / tongTinChi, 2);
                        }
                    }
                    catch { return 0; }
                }
            }
        }
    }
}
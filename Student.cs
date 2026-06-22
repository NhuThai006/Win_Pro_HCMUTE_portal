using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class Student
    {
        private readonly My_DB db = new My_DB();

        // 🟢 SỬA TẠI ĐÂY: Đổi MSSV sang string để khớp NVARCHAR(20)
        public string MSSV { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Hometown { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }

        public Student() { }

        public Student(string mssv, string fname, string lname, DateTime dob,
            string gender, string phone, string address, string hometown,
            string email, byte[] picture)
        {
            MSSV = mssv; Fname = fname; Lname = lname; Dob = dob;
            Gender = gender; Phone = phone; Address = address;
            Hometown = hometown; Email = email; Picture = picture;
        }

        public bool AddStudent()
        {
            string query = "INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture) " +
                           "VALUES (@mssv, @fname, @lname, @dob, @gder, @phone, @addr, @htown, @email, @pic)";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 🟢 SỬA TẠI ĐÂY: Truyền tham số kiểu NVarChar(20)
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = MSSV;
                    cmd.Parameters.Add("@fname", SqlDbType.NVarChar, 50).Value = Fname;
                    cmd.Parameters.Add("@lname", SqlDbType.NVarChar, 50).Value = Lname;
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = Dob;
                    cmd.Parameters.Add("@gder", SqlDbType.NVarChar, 10).Value = Gender;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 20).Value = Phone; // Sửa VarChar sang NVarChar cho chuẩn Unicode
                    cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 200).Value = Address;
                    cmd.Parameters.Add("@htown", SqlDbType.NVarChar, 100).Value = Hometown;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = Email;
                    cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = (object)Picture ?? DBNull.Value;

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool EditStudent()
        {
            string query = "UPDATE Student SET Fname=@fname, Lname=@lname, Dob=@dob, Gder=@gder, " +
                           "Phone=@phone, Address=@addr, Htown=@htown, Email=@email, Pture=@pic WHERE MSSV=@mssv";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = MSSV;
                    cmd.Parameters.Add("@fname", SqlDbType.NVarChar, 50).Value = Fname;
                    cmd.Parameters.Add("@lname", SqlDbType.NVarChar, 50).Value = Lname;
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = Dob;
                    cmd.Parameters.Add("@gder", SqlDbType.NVarChar, 10).Value = Gender;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 20).Value = Phone;
                    cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 200).Value = Address;
                    cmd.Parameters.Add("@htown", SqlDbType.NVarChar, 100).Value = Hometown;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = Email;
                    cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = (object)Picture ?? DBNull.Value;

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi sửa sinh viên: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool DeleteStudent()
        {
            using (SqlConnection conn = db.getConnection)
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Xóa Score và DKMH trước (Ràng buộc khóa ngoại)
                            string queryScore = "DELETE FROM Score WHERE MSSV = @id";
                            string queryDKMH = "DELETE FROM DKMH WHERE MSSV = @id";
                            string queryStudent = "DELETE FROM Student WHERE MSSV = @id";

                            using (SqlCommand cmd = new SqlCommand("", conn, transaction))
                            {
                                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = MSSV;

                                cmd.CommandText = queryScore; cmd.ExecuteNonQuery();
                                cmd.CommandText = queryDKMH; cmd.ExecuteNonQuery();
                                cmd.CommandText = queryStudent;
                                int rows = cmd.ExecuteNonQuery();

                                transaction.Commit();
                                return rows > 0;
                            }
                        }
                        catch { transaction.Rollback(); return false; }
                    }
                }
                catch { return false; }
            }
        }
        public static DataTable GetStudents()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email FROM Student";

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
        public static Student GetStudentByID(string mssv) // 🟢 Nhận tham số string
        {
            My_DB db = new My_DB();
            string query = "SELECT * FROM Student WHERE MSSV = @id";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = mssv;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            DataRow row = table.Rows[0];
                            return new Student(
                                row["MSSV"].ToString(),
                                row["Fname"].ToString(),
                                row["Lname"].ToString(),
                                Convert.ToDateTime(row["Dob"]),
                                row["Gder"].ToString(),
                                row["Phone"].ToString(),
                                row["Address"].ToString(),
                                row["Htown"].ToString(),
                                row["Email"].ToString(),
                                row["Pture"] != DBNull.Value ? (byte[])row["Pture"] : null
                            );
                        }
                    }
                    catch { return null; }
                }
            }
            return null;
        }

        public bool RegisterCourse(string mssv, string mamh)
        {
            string query = "INSERT INTO DKMH (MSSV, MaMH) VALUES (@mssv, @mamh)";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv;
                    cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = mamh;
                    try { conn.Open(); return cmd.ExecuteNonQuery() > 0; } catch { return false; }
                }
            }
        }

        public bool UnregisterCourse(string mssv, string mamh)
        {
            string query = "DELETE FROM DKMH WHERE MSSV = @mssv AND MaMH = @mamh";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv;
                    cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = mamh;
                    try { conn.Open(); return cmd.ExecuteNonQuery() > 0; } catch { return false; }
                }
            }
        }

        public DataTable GetRegisteredCourses(string mssv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT d.MaMH AS [Mã MH], c.TenMH AS [Tên môn học], c.SoTC AS [Số tín chỉ] " +
                           "FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH WHERE d.MSSV = @mssv";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@mssv", SqlDbType.NVarChar, 20).Value = mssv;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    try { conn.Open(); adapter.Fill(dt); } catch { }
                }
            }
            return dt;
        }
    }
}
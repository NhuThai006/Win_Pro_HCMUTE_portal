using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_HRAssign : Form
    {
        private readonly My_DB db = new My_DB();

        // Cờ hiệu ngăn chặn vòng lặp vô hạn khi tự động cập nhật DataSource trong sự kiện TextChanged
        private bool isSearching = false;

        public f_HRAssign()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        private void RegisterFormEvents()
        {
            this.Load += f_HRAssign_Load;
            this.dgvPhanCong.CellClick += dgvPhanCong_CellClick;

            // Kích đúp dòng để thực hiện Hủy phân công môn học
            this.dgvPhanCong.CellDoubleClick += dgvPhanCong_CellDoubleClick;

            // Bộ nút CRUD hồ sơ nhân sự HR/Giảng viên
            this.btnThemHR.Click += btnThemHR_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnXoa.Click += btnXoa_Click;

            // Bộ lọc tìm kiếm gợi ý thông minh trên ComboBox
            this.cboHR.TextChanged += cboHR_TextChanged;
            this.cboMon.TextChanged += cboMon_TextChanged;

            // Nút bấm phân công
            this.btnPhanCong.Click += btnPhanCong_Click;
        }

        private void f_HRAssign_Load(object sender, EventArgs e)
        {
            cboHR.DropDownStyle = ComboBoxStyle.DropDown;
            cboMon.DropDownStyle = ComboBoxStyle.DropDown;

            OptimizeUIByRole();
            LoadHRComboBox();
            LoadCourseComboBox();
            LoadAssignGrid();
        }

        private void OptimizeUIByRole()
        {
            bool isAdmin = (Globals.GlobalUserRole == 0);
            btnThemHR.Enabled = isAdmin;
            btnSua.Enabled = isAdmin;
            btnXoa.Enabled = isAdmin;
            btnPhanCong.Enabled = isAdmin;
        }

        // =========================================================================
        // LUỒNG 1: QUẢN LÝ THÔNG TIN HỒ SƠ CÁN BỘ HR / GIẢNG VIÊN (NVARCHAR)
        // =========================================================================

        private void btnThemHR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSGV.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin cốt lõi (Mã Id tài khoản, MSGV, Username, Password)!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện thêm tuần tự vào bảng Login (Tài khoản) trước, rồi đến bảng HR (Hồ sơ giảng viên)
            using (SqlConnection conn = db.getConnection)
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Chèn tài khoản hệ thống vào bảng Login (Khóa Id mới là NVARCHAR)
                            string queryLogin = "INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) " +
                                                 "VALUES (@uid, @fn, @ln, 2, @user, @pass, @email, 1)";

                            using (SqlCommand cmdL = new SqlCommand(queryLogin, conn, trans))
                            {
                                cmdL.Parameters.Add("@uid", SqlDbType.NVarChar, 20).Value = txtMSGV.Text.Trim();
                                cmdL.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = txtHo.Text.Trim();
                                cmdL.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = txtTen.Text.Trim();
                                cmdL.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
                                cmdL.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = ComputeSHA256(txtPassword.Text);
                                cmdL.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();
                                cmdL.ExecuteNonQuery();
                            }

                            // 2. Chèn thông tin nhân sự vào bảng HR (MSGV kiểu NVARCHAR)
                            string queryHR = "INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) " +
                                             "VALUES (@msgv, @fn, @ln, 2, @user, @pass, @email, 1)";

                            using (SqlCommand cmdH = new SqlCommand(queryHR, conn, trans))
                            {
                                cmdH.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = txtMSGV.Text.Trim();
                                cmdH.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = txtHo.Text.Trim();
                                cmdH.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = txtTen.Text.Trim();
                                cmdH.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
                                cmdH.Parameters.Add("@pass", SqlDbType.VarChar, 255).Value = ComputeSHA256(txtPassword.Text);
                                cmdH.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();
                                cmdH.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show("Thêm hồ sơ tài khoản cán bộ giảng viên HR thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHRComboBox();
                            ClearInputFields();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
                catch { MessageBox.Show("Mã giảng viên, ID hoặc tài khoản đăng nhập đã tồn tại trong hệ thống!", "Lỗi trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSGV.Text)) return;

            // Đồng bộ cập nhật thông tin họ tên, email ở cả hai bảng HR và Login
            string query = "UPDATE HR SET Fname = @fn, Lname = @ln, Email = @email WHERE MSGV = @msgv; " +
                           "UPDATE Login SET Fname = @fn, Lname = @ln, Email = @email WHERE UserName = @user;";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = txtMSGV.Text.Trim();
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
                    cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = txtHo.Text.Trim();
                    cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = txtTen.Text.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Cập nhật hồ sơ giảng viên HR thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHRComboBox();
                            LoadAssignGrid();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSGV.Text)) return;

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản giảng viên mang mã số {txtMSGV.Text.Trim()} không?\nHành động này sẽ xóa các lịch phân công liên quan.",
                                                  "Cảnh báo hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                // Xóa ràng buộc phân công trước, sau đó xóa hồ sơ HR và tài khoản Login liên quan
                string query = "DELETE FROM Assign WHERE MSGV = @msgv; " +
                               "DELETE FROM HR WHERE MSGV = @msgv; " +
                               "DELETE FROM Login WHERE UserName = @user;";

                using (SqlConnection conn = db.getConnection)
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = txtMSGV.Text.Trim();
                        cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txtUsername.Text.Trim();
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa tài khoản giảng viên thành công vĩnh viễn!");
                            LoadHRComboBox();
                            LoadAssignGrid();
                            ClearInputFields();
                        }
                        catch (Exception ex) { MessageBox.Show("Lỗi thực thi lệnh xóa: " + ex.Message); }
                    }
                }
            }
        }

        // =========================================================================
        // LUỒNG 2: XỬ LÝ PHÂN CÔNG GIẢNG DẠY & HỦY PHÂN CÔNG (KHÓA CHUỖI)
        // =========================================================================

        private void LoadHRComboBox()
        {
            // Lấy dữ liệu giảng viên có Valid = 1 (đang hoạt động)
            string query = "SELECT MSGV, Fname + ' ' + Lname AS HoTenHR FROM HR WHERE Valid = 1";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        // Gán nguồn dữ liệu (đặt cờ chặn TextChanged để không bị query lại ngay khi gán)
                        isSearching = true;

                        cboHR.DataSource = dt;
                        cboHR.DisplayMember = "HoTenHR"; // Tên hiển thị là Họ và Tên
                        cboHR.ValueMember = "MSGV";     // Giá trị ẩn là Mã số giảng viên

                        // Đặt mặc định không chọn gì để người dùng bắt đầu tìm kiếm
                        cboHR.SelectedIndex = -1;

                        isSearching = false;
                    }
                    catch (Exception ex)
                    {
                        isSearching = false;
                        MessageBox.Show("Lỗi nạp danh sách giảng viên: " + ex.Message);
                    }
                }
            }
        }
        private void cboHR_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn từ danh sách xổ xuống, nạp thông tin giảng viên đó
            if (cboHR.SelectedValue != null && cboHR.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string msgv = cboHR.SelectedValue.ToString();
                LoadHRDetailsToTextBoxes(msgv);
            }
        }
        private void LoadCourseComboBox()
        {
            string query = "SELECT MaMH, TenMH FROM Course";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);

                        isSearching = true;

                        cboMon.DataSource = dt;
                        cboMon.DisplayMember = "TenMH";
                        cboMon.ValueMember = "MaMH";

                        isSearching = false;
                    }
                    catch { isSearching = false; }
                }
            }
        }

        private void LoadAssignGrid()
        {
            dgvPhanCong.Rows.Clear();
            string query = @"SELECT a.MSGV, h.Fname + ' ' + h.Lname AS [HoTen], a.MaMH, c.TenMH, c.SoTC 
                             FROM Assign a 
                             INNER JOIN HR h ON a.MSGV = h.MSGV 
                             INNER JOIN Course c ON a.MaMH = c.MaMH";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int rowIndex = dgvPhanCong.Rows.Add();
                                dgvPhanCong.Rows[rowIndex].Cells["colMSGV"].Value = reader["MSGV"].ToString();
                                dgvPhanCong.Rows[rowIndex].Cells["colHoTenHR"].Value = reader["HoTen"].ToString();
                                dgvPhanCong.Rows[rowIndex].Cells["colMaMH"].Value = reader["MaMH"].ToString();
                                dgvPhanCong.Rows[rowIndex].Cells["colTenMon"].Value = reader["TenMH"].ToString();
                                dgvPhanCong.Rows[rowIndex].Cells["colSoTC"].Value = reader["SoTC"].ToString();
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (cboHR.SelectedValue == null || cboMon.SelectedValue == null) return;

            string msgv = cboHR.SelectedValue.ToString();
            string mamh = cboMon.SelectedValue.ToString();

            if (CountAssignedCourses(msgv) >= 5)
            {
                MessageBox.Show("Thao tác bị chặn! Giảng viên này đã đạt giới hạn phân công tối đa 5 môn học.", "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string query = "INSERT INTO Assign (MSGV, MaMH) VALUES (@msgv, @mamh)";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = msgv;
                    cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = mamh;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Phân công lịch trình giảng dạy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAssignGrid();
                    }
                    catch { MessageBox.Show("Giảng viên này đã được phân công đảm nhận môn học từ trước!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private int CountAssignedCourses(string msgv)
        {
            string query = "SELECT COUNT(*) FROM Assign WHERE MSGV = @msgv";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = msgv;
                    try { conn.Open(); return (int)cmd.ExecuteScalar(); } catch { return 0; }
                }
            }
        }

        private void dgvPhanCong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string msgv = dgvPhanCong.Rows[e.RowIndex].Cells["colMSGV"].Value.ToString();
                string mamh = dgvPhanCong.Rows[e.RowIndex].Cells["colMaMH"].Value.ToString();
                string tenMon = dgvPhanCong.Rows[e.RowIndex].Cells["colTenMon"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn HỦY PHÂN CÔNG môn học [{tenMon}] của giảng viên {msgv} không?",
                                                      "Xác nhận hủy lịch dạy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string query = "DELETE FROM Assign WHERE MSGV = @msgv AND MaMH = @mamh";
                    using (SqlConnection conn = db.getConnection)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = msgv;
                            cmd.Parameters.Add("@mamh", SqlDbType.NVarChar, 20).Value = mamh;
                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Đã hủy lịch dạy phân công môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadAssignGrid();
                            }
                            catch (Exception ex) { MessageBox.Show("Lỗi thực thi lệnh hủy: " + ex.Message); }
                        }
                    }
                }
            }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhanCong.Rows[e.RowIndex];

                // Bật cờ chặn TextChanged TRƯỚC khi gán Text bằng code.
                // Nếu không chặn, cboHR_TextChanged / cboMon_TextChanged sẽ tự kích hoạt,
                // query lại DB với từ khóa là HỌ TÊN GHÉP ĐẦY ĐỦ (vd "Nguyễn Văn A").
                // Vì SQL chỉ so khớp riêng Fname LIKE @key hoặc Lname LIKE @key (không phải tên ghép),
                // kết quả trả về 0 dòng -> DataSource bị gán DataTable rỗng -> mất hết lựa chọn trong combo.
                isSearching = true;

                txtMSGV.Text = row.Cells["colMSGV"].Value?.ToString();
                cboHR.Text = row.Cells["colHoTenHR"].Value?.ToString();
                cboMon.Text = row.Cells["colTenMon"].Value?.ToString();
                txtMSGV.Enabled = false;

                isSearching = false;

                LoadHRDetailsToTextBoxes(txtMSGV.Text);
            }
        }

        private void LoadHRDetailsToTextBoxes(string msgv)
        {
            string query = "SELECT Fname, Lname, Username, Email FROM HR WHERE MSGV = @id";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = msgv;
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtHo.Text = reader["Fname"].ToString();
                                txtTen.Text = reader["Lname"].ToString();
                                txtUsername.Text = reader["Username"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtPassword.Text = "********";
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        // =========================================================================
        // LUỒNG TỐI ƯU CỰC KỲ QUAN TRỌNG: SỬA LỖI ĐƠ / KẸT PHÍM GÕ CHỮ TRÊN COMBOBOX
        // =========================================================================

        private void cboHR_TextChanged(object sender, EventArgs e)
        {
            if (isSearching) return; // Nếu đang trong trạng thái gán nguồn dữ liệu tìm kiếm (hoặc gán Text bằng code) -> Bỏ qua chặn vòng lặp

            string keyword = cboHR.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) return;

            string query = @"SELECT MSGV, Fname + ' ' + Lname AS HoTenHR 
                             FROM HR 
                             WHERE Valid = 1 AND (MSGV LIKE @key OR Fname LIKE @key OR Lname LIKE @key OR (Fname + ' ' + Lname) LIKE @key)";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@key", SqlDbType.NVarChar, 50).Value = "%" + keyword + "%";
                    DataTable dt = new DataTable();

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        // Nếu không có kết quả khớp, GIỮ NGUYÊN DataSource hiện tại (không xóa hết lựa chọn)
                        if (dt.Rows.Count == 0) return;

                        isSearching = true; // Bật cờ khóa chặn gõ phím

                        cboHR.DataSource = dt;
                        cboHR.DisplayMember = "HoTenHR";
                        cboHR.ValueMember = "MSGV";

                        cboHR.Text = keyword; // Trả lại từ khóa đang gõ dở không bị nuốt chữ
                        cboHR.SelectionStart = keyword.Length; // Đưa con trỏ văn bản xuống cuối chuỗi
                        cboHR.DroppedDown = true; // Tự động mở menu lựa chọn bên dưới

                        isSearching = false; // Mở khóa cờ hiệu sau khi hoàn tất
                    }
                    catch { isSearching = false; }
                }
            }
        }

        private void cboMon_TextChanged(object sender, EventArgs e)
        {
            if (isSearching) return;

            string keyword = cboMon.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) return;

            string query = "SELECT MaMH, TenMH FROM Course WHERE MaMH LIKE @key OR TenMH LIKE @key";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@key", SqlDbType.NVarChar, 50).Value = "%" + keyword + "%";
                    DataTable dt = new DataTable();

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        // Nếu không có kết quả khớp, GIỮ NGUYÊN DataSource hiện tại (không xóa hết lựa chọn)
                        if (dt.Rows.Count == 0) return;

                        isSearching = true;

                        cboMon.DataSource = dt;
                        cboMon.DisplayMember = "TenMH";
                        cboMon.ValueMember = "MaMH";

                        cboMon.Text = keyword;
                        cboMon.SelectionStart = keyword.Length;
                        cboMon.DroppedDown = true;

                        isSearching = false;
                    }
                    catch { isSearching = false; }
                }
            }
        }

        private string ComputeSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        private void ClearInputFields()
        {

            txtMSGV.Clear();
            txtMSGV.Enabled = true;
            txtHo.Clear();
            txtTen.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
        }
    }
}
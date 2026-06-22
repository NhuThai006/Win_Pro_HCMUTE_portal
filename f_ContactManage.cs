using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ContactManage : Form
    {
        private readonly My_DB db = new My_DB();
        private bool isInitializing = true;

        public f_ContactManage()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        private void RegisterFormEvents()
        {
            this.Load += f_ContactManage_Load;
            this.dgvContact.CellClick += dgvContact_CellClick;

            this.txtTimKiem.TextChanged += FilterChanged_Event;
            this.cboFilterNhom.SelectedIndexChanged += FilterChanged_Event;

            this.btnThem.Click += btnThem_Click;
            this.btnSua.Click += btnSua_Click;
            this.btnXoa.Click += btnXoa_Click;

           
        }

        private void f_ContactManage_Load(object sender, EventArgs e)
        {
            isInitializing = true;

            // Cho phép nhập hoặc hiển thị ID chuỗi tùy ý (không khóa cứng khắt khe như cột IDENTITY số cũ)
            txtID.Enabled = true;
            dtpDob.Value = DateTime.Today;

            LoadGroupsToComboBoxes();

            isInitializing = false;
            LoadContactGrid();
        }

        // =========================================================================
        // LUỒNG 1: NẠP DANH SÁCH NHÓM DÙNG CHUNG TOÀN HỆ THỐNG (KHÔNG LỌC THEO USERID)
        // Groups là danh mục dùng chung (GR01=Quản trị, GR02=Giảng viên, GR03=Sinh viên...)
        // nên mọi tài khoản đăng nhập đều thấy đầy đủ danh sách nhóm như nhau.
        // =========================================================================
        private void LoadGroupsToComboBoxes()
        {
            string query = "SELECT ID, Name FROM Groups ORDER BY ID";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtForm = new DataTable();

                    try
                    {
                        conn.Open();
                        adapter.Fill(dtForm);

                        // Xóa các item tĩnh được Designer thêm sẵn (Items.AddRange lúc thiết kế UI)
                        // trước khi gán DataSource động — nếu không, ComboBox sẽ hiển thị cộng dồn cả 2.
                        cboNhom.Items.Clear();
                        cboFilterNhom.Items.Clear();

                        // ---- ComboBox dùng để THÊM/SỬA liên hệ (CÓ thêm dòng "Tất cả nhóm") ----
                        // Lưu ý: "Tất cả nhóm" (ID = "0") chỉ mang tính hiển thị/placeholder,
                        // không được phép chọn khi thực sự Thêm/Sửa (xem kiểm tra trong btnThem_Click, btnSua_Click).
                        DataTable dtNhom = dtForm.Copy();
                        DataRow nhomAllRow = dtNhom.NewRow();
                        nhomAllRow["ID"] = "0";
                        nhomAllRow["Name"] = "Tất cả nhóm";
                        dtNhom.Rows.InsertAt(nhomAllRow, 0);

                        cboNhom.DataSource = dtNhom;
                        cboNhom.DisplayMember = "Name";
                        cboNhom.ValueMember = "ID";
                        cboNhom.SelectedIndex = 0;

                        // ---- ComboBox dùng để LỌC danh bạ (CÓ thêm dòng "Tất cả nhóm") ----
                        DataTable dtFilter = dtForm.Copy();
                        DataRow filterAllRow = dtFilter.NewRow();
                        filterAllRow["ID"] = "0"; // Mã đặc biệt đại diện cho "Tất cả nhóm"
                        filterAllRow["Name"] = "Tất cả nhóm";
                        dtFilter.Rows.InsertAt(filterAllRow, 0);

                        cboFilterNhom.DataSource = dtFilter;
                        cboFilterNhom.DisplayMember = "Name";
                        cboFilterNhom.ValueMember = "ID";
                        cboFilterNhom.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi nạp nhóm danh bạ: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // LUỒNG 2: TRUY VẤN VÀ LỌC DANH BẠ THEO THỜI GIAN THỰC (REAL-TIME BINDING)
        // Contact giờ là danh bạ DÙNG CHUNG toàn hệ thống — không tách riêng theo từng tài khoản.
        // =========================================================================
        private void LoadContactGrid()
        {
            FilterChanged_Event(null, null);
        }

        private void FilterChanged_Event(object sender, EventArgs e)
        {
            if (isInitializing) return;

            string keyword = txtTimKiem.Text.Trim();
            if (keyword == "Tên, SĐT, email") keyword = "";

            string filterGroupID = cboFilterNhom.SelectedValue != null ? cboFilterNhom.SelectedValue.ToString() : "0";

            string query = "SELECT c.ID, c.Fname + ' ' + c.Lname AS HoTen, c.Dob, c.Gender, g.Name AS TenNhom, c.Phone, c.Email, c.Address " +
                           "FROM Contact c INNER JOIN Groups g ON c.Group_ID = g.ID " +
                           "WHERE (c.Fname LIKE @key OR c.Lname LIKE @key OR c.Phone LIKE @key OR c.Email LIKE @key)";

            if (filterGroupID != "0")
            {
                query += " AND c.Group_ID = @gid";
            }

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@key", SqlDbType.NVarChar, 100).Value = "%" + keyword + "%";
                    if (filterGroupID != "0") cmd.Parameters.Add("@gid", SqlDbType.NVarChar, 20).Value = filterGroupID;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dtContact = new DataTable();
                        try
                        {
                            conn.Open();
                            adapter.Fill(dtContact);

                            dgvContact.AutoGenerateColumns = false;

                            dgvContact.Columns["colID"].DataPropertyName = "ID";
                            dgvContact.Columns["colHoTen"].DataPropertyName = "HoTen";
                            dgvContact.Columns["colNgaySinh"].DataPropertyName = "Dob";
                            dgvContact.Columns["colGioiTinh"].DataPropertyName = "Gender";
                            dgvContact.Columns["colNhom"].DataPropertyName = "TenNhom";
                            dgvContact.Columns["colSDT"].DataPropertyName = "Phone";
                            dgvContact.Columns["colEmail"].DataPropertyName = "Email";

                            dgvContact.DataSource = dtContact;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi lọc danh bạ: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // =========================================================================
        // LUỒNG 3: THỰC THI CHỨC NĂNG CRUD DANH BẠ (ĐỒNG BỘ KHÓA NVARCHAR(20))
        // =========================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || cboNhom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc (Bao gồm cả trường ID chuỗi tự đặt, Tên, Số điện thoại và Nhóm)!", "Cảnh báo trống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chặn trường hợp chọn "Tất cả nhóm" (ID = "0") khi Thêm — vì đây chỉ là item hiển thị,
            // không phải nhóm thật trong bảng Groups.
            if (cboNhom.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Vui lòng chọn một nhóm cụ thể cho liên hệ, không thể chọn \"Tất cả nhóm\" khi thêm/sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = DateTime.Now.Year - dtpDob.Value.Year;
            if (age < 21 || age > 65)
            {
                MessageBox.Show("Yêu cầu độ tuổi của liên hệ danh bạ phải nằm trong khoảng từ 21 đến 65 tuổi!", "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm trường ID chuỗi vào câu lệnh chèn SQL (vì đã gỡ bỏ thuộc tính IDENTITY tự tăng)
            string query = "INSERT INTO Contact(ID, Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic, UserID) " +
                           "VALUES(@id, @fn, @ln, @dob, @gder, @gid, @phone, @addr, @email, @pic, @uid)";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = txtID.Text.Trim();
                    cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = txtHo.Text.Trim();
                    cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = txtTen.Text.Trim();
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dtpDob.Value;
                    cmd.Parameters.Add("@gder", SqlDbType.NVarChar, 10).Value = cboGioiTinh.Text;
                    cmd.Parameters.Add("@gid", SqlDbType.NVarChar, 20).Value = cboNhom.SelectedValue.ToString();
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 15).Value = txtSDT.Text.Trim();
                    cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 200).Value = txtDiaChi.Text.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("@pic", SqlDbType.Image).Value = DBNull.Value;
                    cmd.Parameters.Add("@uid", SqlDbType.NVarChar, 20).Value = Globals.GlobalUserId;

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Thêm mới liên hệ vào danh bạ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadContactGrid();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi thực thi (Trùng khóa ID)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng click chọn một hàng trên bảng danh bạ để tiến hành sửa đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chặn trường hợp chọn "Tất cả nhóm" (ID = "0") khi Sửa — vì đây chỉ là item hiển thị,
            // không phải nhóm thật trong bảng Groups.
            if (cboNhom.SelectedValue != null && cboNhom.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Vui lòng chọn một nhóm cụ thể cho liên hệ, không thể chọn \"Tất cả nhóm\" khi thêm/sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = DateTime.Now.Year - dtpDob.Value.Year;
            if (age < 21 || age > 65)
            {
                MessageBox.Show("Yêu cầu độ tuổi của liên hệ danh bạ phải nằm trong khoảng từ 21 đến 65 tuổi!", "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Contact SET Fname = @fn, Lname = @ln, Dob = @dob, Gender = @gder, " +
                           "Group_ID = @gid, Phone = @phone, Address = @addr, Email = @email " +
                           "WHERE ID = @id";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = txtID.Text.Trim();
                    cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = txtHo.Text.Trim();
                    cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = txtTen.Text.Trim();
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dtpDob.Value;
                    cmd.Parameters.Add("@gder", SqlDbType.NVarChar, 10).Value = cboGioiTinh.Text;
                    cmd.Parameters.Add("@gid", SqlDbType.NVarChar, 20).Value = cboNhom.SelectedValue.ToString();
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 15).Value = txtSDT.Text.Trim();
                    cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 200).Value = txtDiaChi.Text.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = txtEmail.Text.Trim();

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin liên hệ danh bạ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadContactGrid();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy liên hệ phù hợp để cập nhật (ID hoặc tài khoản không khớp).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi thực thi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) return;

            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa số liên hệ này ra khỏi danh bạ?", "Xác nhận hành động", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Contact WHERE ID = @id";
                using (SqlConnection conn = db.getConnection)
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = txtID.Text.Trim();

                        try
                        {
                            conn.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Xóa liên hệ ra khỏi hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadContactGrid();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy liên hệ phù hợp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi thực thi lệnh xóa: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvContact.CurrentRow == null) return;

            object idCellValue = dgvContact.CurrentRow.Cells["colID"].Value;
            if (idCellValue == null) return;

            string contactID = idCellValue.ToString();

            // Bắt buộc phải có WHERE ID = @id, nếu thiếu sẽ luôn lấy dòng đầu tiên của bảng Contact.
            string query = "SELECT Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic " +
                           "FROM Contact WHERE ID = @id";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = contactID.Trim();

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtID.Text = contactID;
                                txtHo.Text = reader["Fname"].ToString();
                                txtTen.Text = reader["Lname"].ToString();

                                dtpDob.Value = reader["Dob"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["Dob"])
                                    : DateTime.Today;

                                cboGioiTinh.Text = reader["Gender"].ToString();

                                // Group_ID có thể null nếu dữ liệu chưa gán nhóm
                                if (reader["Group_ID"] != DBNull.Value)
                                {
                                    cboNhom.SelectedValue = reader["Group_ID"].ToString();
                                }

                                txtSDT.Text = reader["Phone"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtDiaChi.Text = reader["Address"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi nạp chi tiết liên hệ: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtHo.Clear();
            txtTen.Clear();
            dtpDob.Value = DateTime.Today;
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboNhom.Items.Count > 0) cboNhom.SelectedIndex = 0;
        }
    }
}
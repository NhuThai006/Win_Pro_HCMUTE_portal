using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_AccountManage : Form
    {
        private readonly My_DB db = new My_DB();

        public f_AccountManage()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        private void RegisterFormEvents()
        {
            this.Load += f_AccountManage_Load;

            // Đăng ký sự kiện Click cho 4 nút chức năng điều khiển Guna2
            this.btnDuyet.Click += btnDuyet_Click;
            this.btnTuChoi.Click += btnTuChoi_Click;
            this.btnXem.Click += btnXem_Click;
            this.btnXoaTaiKhoan.Click += btnXoaTaiKhoan_Click;
        }

        private void f_AccountManage_Load(object sender, EventArgs e)
        {
            RefreshAllGrids();
        }

        /// <summary>
        /// Đồng bộ làm mới dữ liệu trên cả 2 bảng Chờ duyệt và Đã duyệt
        /// </summary>
        private void RefreshAllGrids()
        {
            LoadPendingAccounts();
            LoadApprovedAccounts();
        }

        // =========================================================================
        // LUỒNG 1: NẠP DANH SÁCH TÀI KHOẢN CHỜ DUYỆT (VALID = 0)
        // =========================================================================
        private void LoadPendingAccounts()
        {
            dgvChoDuyet.Rows.Clear();
            string query = "SELECT Id, Fname + ' ' + Lname AS HoTen, UserName, position, Email " +
                           "FROM Login WHERE VALID = 0"; 

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
                                string msgv = reader["Id"].ToString();
                                string hoTen = reader["HoTen"].ToString();
                                string username = reader["Username"].ToString();
                                int pos = Convert.ToInt32(reader["position"]); 
                                string email = reader["Email"].ToString();

                              // Đọc giá trị số và chuyển đổi hiển thị vai trò trực quan bằng chữ [cite: 414, 421]
                                string vaiTro = pos == 0 ? "Admin" : pos == 1 ? "Sinh viên" : "HR / Giảng viên"; 

                                // Nạp giá trị vào chính xác các tên cột colCho... của bảng bên trái
                                int rowIndex = dgvChoDuyet.Rows.Add();
                                dgvChoDuyet.Rows[rowIndex].Cells["colChoMSGV"].Value = msgv;
                                dgvChoDuyet.Rows[rowIndex].Cells["colChoHoTen"].Value = hoTen;
                                dgvChoDuyet.Rows[rowIndex].Cells["colChoUsername"].Value = username;
                                dgvChoDuyet.Rows[rowIndex].Cells["colChoVaiTro"].Value = vaiTro;
                                dgvChoDuyet.Rows[rowIndex].Cells["colChoEmail"].Value = email;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi nạp danh sách chờ duyệt: " + ex.Message);
                    }
                }
            }
        }

        // =========================================================================
        // LUỒNG 2: NẠP DANH SÁCH TÀI KHOẢN ĐÃ DUYỆT THÀNH CÔNG (VALID = 1)
        // =========================================================================
        private void LoadApprovedAccounts()
        {
            dgvDaDuyet.Rows.Clear();
            string query = "SELECT Id, Fname + ' ' + Lname AS HoTen, UserName, position " +
                           "FROM Login WHERE VALID = 1"; 

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
                                string msgv = reader["Id"].ToString();
                                string hoTen = reader["HoTen"].ToString();
                                string username = reader["UserName"].ToString();
                                int pos = Convert.ToInt32(reader["position"]);

                                string vaiTro = pos == 0 ? "Admin" : pos == 1 ? "Sinh viên" : "HR / Giảng viên"; 

                                // Nạp giá trị vào chính xác các tên cột colDa... của bảng bên phải
                                int rowIndex = dgvDaDuyet.Rows.Add();
                                dgvDaDuyet.Rows[rowIndex].Cells["colDaMSGV"].Value = msgv;
                                dgvDaDuyet.Rows[rowIndex].Cells["colDaHoTen"].Value = hoTen;
                                dgvDaDuyet.Rows[rowIndex].Cells["colDaUsername"].Value = username;
                                dgvDaDuyet.Rows[rowIndex].Cells["colDaVaiTro"].Value = vaiTro;
                                dgvDaDuyet.Rows[rowIndex].Cells["colDaTrangThai"].Value = "Đang hoạt động";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi nạp danh sách đã duyệt: " + ex.Message);
                    }
                }
            }
        }

        // =========================================================================
        // XỬ LÝ SỰ KIỆN CLICK CÁC NÚT BẤM PHÊ DUYỆT / TỪ CHỐI TÀI KHOẢN
        // =========================================================================

        /// <summary>
        /// Nút Duyệt: Chuyển VALID từ 0 lên 1 [cite: 394, 403]
                    /// </summary>
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvChoDuyet.CurrentRow == null || dgvChoDuyet.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách chờ duyệt bên trái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetID = dgvChoDuyet.CurrentRow.Cells["colChoMSGV"].Value.ToString();
            string query = "UPDATE Login SET VALID = 1 WHERE Id = @id"; 

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = targetID;
                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show($"Kích hoạt phê duyệt thành công cho tài khoản mã số {targetID}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAllGrids();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi duyệt tài khoản: " + ex.Message, "Lỗi hệ thống");
                    }
                }
            }
        }

        /// <summary>
        /// Nút Từ chối: Xóa bản ghi khỏi bảng Login nếu thông tin đăng ký không hợp lệ [cite: 394]
                    /// </summary>
        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (dgvChoDuyet.CurrentRow == null || dgvChoDuyet.CurrentRow.Index < 0) return;

            string targetID = dgvChoDuyet.CurrentRow.Cells["colChoMSGV"].Value.ToString();
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn TỪ CHỐI và XÓA yêu cầu đăng ký của tài khoản {targetID} không?",
                                                  "Xác nhận từ chối", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DeleteAccountFromDB(targetID);
            }
        }

        /// <summary>
        /// Nút Xóa tài khoản: Gỡ bỏ tài khoản đã duyệt ra khỏi hệ thống
        /// </summary>
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgvDaDuyet.CurrentRow == null || dgvDaDuyet.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách đã duyệt bên phải để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetID = dgvDaDuyet.CurrentRow.Cells["colDaMSGV"].Value.ToString();
            DialogResult confirm = MessageBox.Show($"Hành động này sẽ xóa vĩnh viễn tài khoản {targetID} khỏi hệ thống đăng nhập.\nBạn có chắc chắn muốn tiếp tục?",
                                                  "Cảnh báo xóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DeleteAccountFromDB(targetID);
            }
        }

        /// <summary>
        /// Nút Xem: Hiển thị nhanh hộp thoại thông tin chi tiết tài khoản đang chọn
        /// </summary>
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvChoDuyet.CurrentRow != null && dgvChoDuyet.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvChoDuyet.CurrentRow;
                string detail = $"--- THÔNG TIN CHI TIẾT ĐĂNG KÝ ---\n\n" +
                               $"- Mã số định danh: {row.Cells["colChoMSGV"].Value}\n" +
                               $"- Họ và tên: {row.Cells["colChoHoTen"].Value}\n" +
                               $"- Tên tài khoản: {row.Cells["colChoUsername"].Value}\n" +
                               $"- Vai trò đăng ký: {row.Cells["colChoVaiTro"].Value}\n" +
                               $"- Hòm thư Email: {row.Cells["colChoEmail"].Value}\n\n" +
                               $"Trạng thái: Đang chờ phê duyệt cấp quyền truy cập.";
                MessageBox.Show(detail, "Hồ sơ đăng ký tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Hàm phụ trợ thực thi lệnh xóa vật lý bản ghi tài khoản (Tối ưu Pool)
        /// </summary>
        private void DeleteAccountFromDB(string id)
        {
            string query = "DELETE FROM Login WHERE Id = @id";
            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        RefreshAllGrids();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thực thi xóa dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
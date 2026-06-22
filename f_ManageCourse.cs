using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageCourse : Form
    {
        private readonly My_DB db = new My_DB();

        public f_ManageCourse()
        {
            InitializeComponent();
            RegisterRealTimeEvents();
        }

        private void RegisterRealTimeEvents()
        {
            this.Load += f_ManageCourse_Load;
            this.dgvCourses.CellClick += dgvCourses_CellClick;

            this.btn_Add.Click += btn_Add_Click;
            this.btn_Edit.Click += btn_Edit_Click;
            this.btn_Delete.Click += btn_Delete_Click;

            // Đăng ký sự kiện tìm kiếm real-time
            this.txtSearch.TextChanged += txtSearch_FilterChanged;
            this.cboFilterHocKy.SelectedIndexChanged += txtSearch_FilterChanged;
        }

        private void f_ManageCourse_Load(object sender, EventArgs e)
        {
            LoadCourseData();
        }

        public void LoadCourseData()
        {
            string query = "SELECT MaMH AS [Mã MH], TenMH AS [Tên môn học], SoTC AS [Số tín chỉ], Tuan AS [Số tuần], HocKy AS [Học kỳ], Mota AS [Mô tả] FROM Course";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            conn.Open();
                            adapter.Fill(dt);
                            dgvCourses.DataSource = dt;
                            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                    }
                }
            }
        }

        private void txtSearch_FilterChanged(object sender, EventArgs e)
        {
            string keyword = "%" + txtSearch.Text.Trim() + "%";
            string semester = cboFilterHocKy.Text.Trim();

            string query = "SELECT MaMH AS [Mã MH], TenMH AS [Tên môn học], SoTC AS [Số tín chỉ], Tuan AS [Số tuần], HocKy AS [Học kỳ], Mota AS [Mô tả] " +
                           "FROM Course WHERE (MaMH LIKE @key OR TenMH LIKE @key)";

            if (semester != "Tất cả HK" && !string.IsNullOrEmpty(semester))
            {
                // Trích xuất số từ "Học kỳ 1" -> 1
                string hkyNum = System.Text.RegularExpressions.Regex.Match(semester, @"\d+").Value;
                if (!string.IsNullOrEmpty(hkyNum)) query += " AND HocKy = @hk";
            }

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@key", SqlDbType.NVarChar, 100).Value = keyword;
                    if (semester != "Tất cả HK" && !string.IsNullOrEmpty(semester))
                    {
                        string hkyNum = System.Text.RegularExpressions.Regex.Match(semester, @"\d+").Value;
                        if (!string.IsNullOrEmpty(hkyNum)) cmd.Parameters.Add("@hk", SqlDbType.Int).Value = int.Parse(hkyNum);
                    }

                    DataTable dt = new DataTable();
                    try { conn.Open(); new SqlDataAdapter(cmd).Fill(dt); dgvCourses.DataSource = dt; }
                    catch { }
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaMH.Text)) return;

            int.TryParse(txtSoTinChi.Text, out int stc);
            int.TryParse(txtSoTuan.Text, out int tuan);
            int.TryParse(cboHocKy.Text.Replace("Học kỳ ", ""), out int hk);

            Course c = new Course(txtMaMH.Text.Trim(), txtTenMonHoc.Text.Trim(), stc, tuan, hk, txtMoTa.Text.Trim());

            if (c.AddCourse())
            {
                MessageBox.Show("Thêm thành công!");
                LoadCourseData();
                ClearFields();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int.TryParse(txtSoTinChi.Text, out int stc);
            int.TryParse(txtSoTuan.Text, out int tuan);
            int.TryParse(cboHocKy.Text.Replace("Học kỳ ", ""), out int hk);

            Course c = new Course(txtMaMH.Text.Trim(), txtTenMonHoc.Text.Trim(), stc, tuan, hk, txtMoTa.Text.Trim());

            if (c.EditCourse())
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadCourseData();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text)) return;

            Course c = new Course();
            c.MaMH = txtMaMH.Text.Trim();

            if (c.DeleteCourse())
            {
                MessageBox.Show("Xóa thành công!");
                LoadCourseData();
                ClearFields();
            }
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                txtMaMH.Text = row.Cells[0].Value.ToString();
                txtTenMonHoc.Text = row.Cells[1].Value.ToString();
                txtSoTinChi.Text = row.Cells[2].Value.ToString();
                txtSoTuan.Text = row.Cells[3].Value.ToString();
                cboHocKy.Text = "Học kỳ " + row.Cells[4].Value.ToString();
                txtMoTa.Text = row.Cells[5].Value?.ToString();
            }
        }

        private void ClearFields()
        {
            txtMaMH.Clear();
            txtTenMonHoc.Clear();
            txtSoTinChi.Clear();
            txtSoTuan.Clear();
            txtMoTa.Clear();
        }
    }
}
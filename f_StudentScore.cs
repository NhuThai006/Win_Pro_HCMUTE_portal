using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MiniSoftware; // Hỗ trợ xuất biểu mẫu văn bản Word

namespace QuanLySinhVien
{
    public partial class f_StudentScore : Form
    {
        // Đường dẫn đến kịch bản file mẫu Word lưu trong thư mục hệ thống
        private readonly string path_template = Application.StartupPath + @"\Template\Template_BangDiem.docx";

        public f_StudentScore()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        /// <summary>
        /// Đăng ký chuỗi sự kiện điều khiển học vụ thời gian thực
        /// </summary>
        private void RegisterFormEvents()
        {
            this.Load += f_StudentScore_Load;
            this.cboSinhVien.SelectedIndexChanged += cboSinhVien_SelectedIndexChanged;
            this.dgvBangDiem.CellClick += dgvBangDiem_CellClick;

            // Bộ tính toán tự động realtime điểm tổng kết môn học khi đang gõ chữ
            this.txtDiemQT.TextChanged += txtDiem_TextChanged;
            this.txtDiemCK.TextChanged += txtDiem_TextChanged;

            
        }

        private void f_StudentScore_Load(object sender, EventArgs e)
        {
            LoadSinhVienComboBox();
            LoadMonHocComboBox();
        }

        /// <summary>
        /// Nạp danh sách sinh viên vào ComboBox
        /// </summary>
        private void LoadSinhVienComboBox()
        {
            try
            {
                DataTable dt = Student.GetStudents();

                dt.Columns.Add(
                    "Display",
                    typeof(string),
                    "Convert(MSSV,'System.String') + ' - ' + Fname + ' ' + Lname"
                );

                cboSinhVien.DataSource = dt;
                cboSinhVien.DisplayMember = "Display";
                cboSinhVien.ValueMember = "MSSV";
                if (cboSinhVien.Items.Count > 0) cboSinhVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nạp danh sách môn học đồng bộ theo trường MaMH, TenMH thô từ lớp Course gốc
        /// </summary>
        private void LoadMonHocComboBox()
        {
            try
            {
                DataTable dt = Course.GetCourses();

                // Tạo trường gộp hiển thị trên ComboBox không sợ lỗi gạch tên cột
                dt.Columns.Add("Display", typeof(string), "MaMH + ' - ' + TenMH");

                cboMonHoc.DataSource = dt;
                cboMonHoc.DisplayMember = "Display";
                cboMonHoc.ValueMember = "MaMH"; // Lưu giá trị ẩn vật lý an toàn

                if (cboMonHoc.Items.Count > 0) cboMonHoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách môn học: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedValue == null)
                return;

            if (cboSinhVien.SelectedValue is DataRowView)
                return;

            RefreshScoreBoardAndSummary();
        }

        /// <summary>
        /// Luồng xử lý nạp bảng điểm, dựng cột hiển thị động và tính toán tổng kết học vụ
        /// </summary>
        private void RefreshScoreBoardAndSummary()
        {
            if (!(cboSinhVien.SelectedValue is string))
                return; 
            {
                string mssv = cboSinhVien.SelectedValue.ToString();
                // 1. Trích xuất DataTable điểm số từ CSDL (tên cột thô không dấu)
                DataTable dt = Score.GetStudentScoreBoard(mssv);
                
                // Khóa tính năng tự sinh cột rác của DataGridView WinForms
                dgvBangDiem.DataSource = null;
                dgvBangDiem.Columns.Clear();
                dgvBangDiem.AutoGenerateColumns = false;

                // Dựng lại các cột tĩnh hiển thị Tiếng Việt và ánh xạ (Mapping) trường dữ liệu thô
                DataGridViewTextBoxColumn colMaMH = new DataGridViewTextBoxColumn();
                colMaMH.DataPropertyName = "MaMH";
                colMaMH.HeaderText = "Mã MH";
                colMaMH.Name = "Mã MH";
                dgvBangDiem.Columns.Add(colMaMH);

                DataGridViewTextBoxColumn colTenMH = new DataGridViewTextBoxColumn();
                colTenMH.DataPropertyName = "TenMH";
                colTenMH.HeaderText = "Tên môn học";
                colTenMH.Name = "Tên môn học";
                dgvBangDiem.Columns.Add(colTenMH);

                DataGridViewTextBoxColumn colSoTC = new DataGridViewTextBoxColumn();
                colSoTC.DataPropertyName = "SoTC";
                colSoTC.HeaderText = "Số tín chỉ";
                colSoTC.Name = "Số tín chỉ";
                dgvBangDiem.Columns.Add(colSoTC);

                DataGridViewTextBoxColumn colQT = new DataGridViewTextBoxColumn();
                colQT.DataPropertyName = "DiemQT";
                colQT.HeaderText = "Điểm QT";
                colQT.Name = "Điểm QT";
                dgvBangDiem.Columns.Add(colQT);

                DataGridViewTextBoxColumn colCK = new DataGridViewTextBoxColumn();
                colCK.DataPropertyName = "DiemCK";
                colCK.HeaderText = "Điểm CK";
                colCK.Name = "Điểm CK";
                dgvBangDiem.Columns.Add(colCK);

                DataGridViewTextBoxColumn colTK = new DataGridViewTextBoxColumn();
                colTK.DataPropertyName = "DiemTK";
                colTK.HeaderText = "Điểm TK";
                colTK.Name = "Điểm TK";
                dgvBangDiem.Columns.Add(colTK);

                DataGridViewTextBoxColumn colMota = new DataGridViewTextBoxColumn();
                colMota.DataPropertyName = "Mota";
                colMota.HeaderText = "Mô tả";
                colMota.Name = "Mô tả";
                dgvBangDiem.Columns.Add(colMota);

                // Gán nguồn dữ liệu sạch lên ô lưới
                dgvBangDiem.DataSource = dt;
                dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 2. ĐỒNG BỘ HIỂN THỊ ĐIỂM TB VÀ TỔNG TÍN CHỈ LÊN PANEL
                decimal gpa = Score.CalculateGPA(mssv, out int tongTC);
                lblDiemTB.Text = $"Điểm TB: {gpa:F2}";
                lblTongTinChi.Text = $"Tổng tín chỉ: {tongTC}";

                // Duyệt tô màu đỏ cảnh báo rớt môn (< 5.0)
                for (int i = 0; i < dgvBangDiem.Rows.Count; i++)
                {
                    if (dgvBangDiem.Rows[i].Cells["Điểm TK"].Value != DBNull.Value && dgvBangDiem.Rows[i].Cells["Điểm TK"].Value != null)
                    {
                        double diemTK = Convert.ToDouble(dgvBangDiem.Rows[i].Cells["Điểm TK"].Value);
                        if (diemTK < 5.0)
                        {
                            dgvBangDiem.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                            dgvBangDiem.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 240);
                        }
                    }
                }

                // 3. ĐỒNG BỘ HIỂN THỊ XẾP LOẠI HỌC VỤ CHÍNH XÁC
                if (tongTC == 0) lblXepLoai.Text = "Xếp loại: ---";
                else if (gpa >= 9.0m) lblXepLoai.Text = "Xếp loại: Xuất sắc";
                else if (gpa >= 8.0m) lblXepLoai.Text = "Xếp loại: Giỏi";
                else if (gpa >= 6.5m) lblXepLoai.Text = "Xếp loại: Khá";
                else if (gpa >= 5.0m) lblXepLoai.Text = "Xếp loại: Trung bình";
                else lblXepLoai.Text = "Xếp loại: Yếu";
            }
        }

        private void txtDiem_TextChanged(object sender, EventArgs e)
        {
            // Trình xử lý tự động tính điểm tổng kết vật lý realtime theo tỷ lệ quy định (Quá trình 40% - Cuối kỳ 60%)
            if (decimal.TryParse(txtDiemQT.Text.Trim(), out decimal qt) && decimal.TryParse(txtDiemCK.Text.Trim(), out decimal ck))
            {
                if (qt >= 0 && qt <= 10 && ck >= 0 && ck <= 10)
                {
                    decimal tk = Math.Round(qt * 0.4m + ck * 0.6m, 2);
                    txtDiemTK.Text = tk.ToString("F2");
                }
                else { txtDiemTK.Clear(); }
            }
            else { txtDiemTK.Clear(); }
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedValue == null || cboMonHoc.SelectedValue == null) return;

            if (!decimal.TryParse(txtDiemQT.Text.Trim(), out decimal qt) || !decimal.TryParse(txtDiemCK.Text.Trim(), out decimal ck))
            {
                MessageBox.Show("Điểm số thành phần nhập vào không đúng định dạng số thực!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssv = cboSinhVien.SelectedValue.ToString();
            string maMH = cboMonHoc.SelectedValue.ToString();

            // Khởi tạo thực thể lớp Score để lưu trữ dữ liệu vật lý xuống kịch bản SQL
            Score scoreModel = new Score(mssv, maMH, qt, ck, "Nhập bởi Giảng viên");
            if (scoreModel.AddOrUpdateScore())
            {
                MessageBox.Show("Cập nhật lưu hồ sơ điểm số của học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshScoreBoardAndSummary();
                ClearInputFields();
            }
        }

        private void btnXoaDiem_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedValue == null || cboMonHoc.SelectedValue == null) return;

            string mssv = cboSinhVien.SelectedValue.ToString();
            string maMH = cboMonHoc.SelectedValue.ToString();

            DialogResult result = MessageBox.Show($"Bạn có thực sự muốn xóa vĩnh viễn điểm môn [{maMH.Trim()}] của sinh viên này không?",
                                                  "Xác nhận hành động", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Score scoreModel = new Score { Mssv = mssv, Mamh = maMH };
                if (scoreModel.DeleteScore())
                {
                    MessageBox.Show("Xóa bản ghi điểm số môn học ra khỏi hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshScoreBoardAndSummary();
                    ClearInputFields();
                }
            }
        }

        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBangDiem.CurrentRow != null)
            {
                DataGridViewRow row = dgvBangDiem.Rows[e.RowIndex];

                // Dùng .ToString() an toàn, tránh lỗi null và tránh định dạng số bị sai
                cboMonHoc.Text = row.Cells["Mã MH"].Value?.ToString().Trim() + " - " + row.Cells["Tên môn học"].Value?.ToString().Trim();

                // Thay vì gán trực tiếp, hãy xử lý để tránh lỗi định dạng
                txtDiemQT.Text = row.Cells["Điểm QT"].Value?.ToString() ?? "0";
                txtDiemCK.Text = row.Cells["Điểm CK"].Value?.ToString() ?? "0";
                txtDiemTK.Text = row.Cells["Điểm TK"].Value?.ToString() ?? "0";
            }
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            if (dgvBangDiem.Rows.Count == 0 || cboSinhVien.SelectedValue == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Word Document|*.docx";
                sfd.FileName = $"BangDiem_ChiTiet_SV_{cboSinhVien.SelectedValue}.docx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<object> dataList = new List<object>();
                        for (int r = 0; r < dgvBangDiem.Rows.Count; r++)
                        {
                            dataList.Add(new
                            {
                                Mamh = dgvBangDiem.Rows[r].Cells["Mã MH"].Value?.ToString(),
                                Tenmh = dgvBangDiem.Rows[r].Cells["Tên môn học"].Value?.ToString(),
                                Sotc = int.Parse(dgvBangDiem.Rows[r].Cells["Số tín chỉ"].Value?.ToString() ?? "0"),
                                Diemqt = float.Parse(dgvBangDiem.Rows[r].Cells["Điểm QT"].Value?.ToString() ?? "0"),
                                Diemck = float.Parse(dgvBangDiem.Rows[r].Cells["Điểm CK"].Value?.ToString() ?? "0"),
                                Diemtk = float.Parse(dgvBangDiem.Rows[r].Cells["Điểm TK"].Value?.ToString() ?? "0")
                            });
                        }

                        var value = new
                        {
                            Score = dataList.ToArray(),
                            Mssv = cboSinhVien.SelectedValue.ToString(),
                            DTB = lblDiemTB.Text,
                            SOTC = lblTongTinChi.Text,
                            XEPLOAI = lblXepLoai.Text,
                            ky_ten = "Trưởng Khoa Đào Tạo"
                        };

                        MiniWord.SaveAsByTemplate(sfd.FileName, path_template, value);
                        MessageBox.Show("Kết xuất báo cáo kết quả bảng điểm văn bản Word bằng MiniWord thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sự cố hệ thống khi kết xuất tệp văn bản mẫu Word: " + ex.Message, "Lỗi thư viện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearInputFields()
        {
            txtDiemQT.Clear();
            txtDiemCK.Clear();
            txtDiemTK.Clear();
        }
    }
}
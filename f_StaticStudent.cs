using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLySinhVien
{
    public partial class f_StaticStudent : Form
    {
        private readonly Color colorTotal = Color.FromArgb(43, 108, 176);
        private readonly Color colorMale = Color.FromArgb(49, 151, 149);
        private readonly Color colorFemale = Color.FromArgb(184, 50, 128);
        private readonly Color colorOther = Color.FromArgb(113, 128, 150);

        public f_StaticStudent()
        {
            InitializeComponent();
            RegisterFormEvents();
        }

        private void RegisterFormEvents()
        {
            this.Load += f_StaticStudent_Load;

            pnlCardTotal.MouseEnter += (s, e) => HoverCard(pnlCardTotal, lblTotalTitle, lblTotalValue, colorTotal, true);
            pnlCardTotal.MouseLeave += (s, e) => HoverCard(pnlCardTotal, lblTotalTitle, lblTotalValue, colorTotal, false);

            pnlCardMale.MouseEnter += (s, e) => HoverCard(pnlCardMale, lblMaleTitle, lblMaleValue, colorMale, true);
            pnlCardMale.MouseLeave += (s, e) => HoverCard(pnlCardMale, lblMaleTitle, lblMaleValue, colorMale, false);

            pnlCardFemale.MouseEnter += (s, e) => HoverCard(pnlCardFemale, lblFemaleTitle, lblFemaleValue, colorFemale, true);
            pnlCardFemale.MouseLeave += (s, e) => HoverCard(pnlCardFemale, lblFemaleTitle, lblFemaleValue, colorFemale, false);

            pnlCardOther.MouseEnter += (s, e) => HoverCard(pnlCardOther, lblOtherTitle, lblOtherValue, colorOther, true);
            pnlCardOther.MouseLeave += (s, e) => HoverCard(pnlCardOther, lblOtherTitle, lblOtherValue, colorOther, false);
        }

        private void f_StaticStudent_Load(object sender, EventArgs e)
        {
            LoadMetricsAndChart();
            LoadGPAStatisticsGrid();
        }

        private void LoadMetricsAndChart()
        {
            My_DB db = new My_DB();
            string query = "SELECT " +
                           "(SELECT COUNT(*) FROM Student) AS Total, " +
                           "(SELECT COUNT(*) FROM Student WHERE Gder = N'Nam') AS Male, " +
                           "(SELECT COUNT(*) FROM Student WHERE Gder = N'Nữ') AS Female, " +
                           "(SELECT COUNT(*) FROM Student WHERE Gder NOT IN (N'Nam', N'Nữ')) AS Other";

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Chuyển từ GetInt32 sang int (số lượng đếm luôn trả về int)
                                double total = reader.GetInt32(0);
                                double male = reader.GetInt32(1);
                                double female = reader.GetInt32(2);
                                double other = reader.GetInt32(3);

                                lblTotalValue.Text = total.ToString("#,##0");

                                if (total > 0)
                                {
                                    lblMaleValue.Text = $"{(male / total * 100):F2}%";
                                    lblFemaleValue.Text = $"{(female / total * 100):F2}%";
                                    lblOtherValue.Text = $"{(other / total * 100):F2}%";
                                }

                                chartGioiTinh.Series.Clear();
                                Series series = chartGioiTinh.Series.Add("GenderSeries");
                                series.ChartType = SeriesChartType.Doughnut;
                                series.IsValueShownAsLabel = true;

                                if (male > 0) series.Points.AddXY($"Nam ({male})", male);
                                if (female > 0) series.Points.AddXY($"Nữ ({female})", female);
                                if (other > 0) series.Points.AddXY($"Khác ({other})", other);

                                // Gán màu cho biểu đồ (nếu có đủ lát cắt)
                                if (series.Points.Count > 0) series.Points[0].Color = colorMale;
                                if (series.Points.Count > 1) series.Points[1].Color = colorFemale;
                                if (series.Points.Count > 2) series.Points[2].Color = colorOther;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi thống kê: " + ex.Message);
                    }
                }
            }
        }

        private void LoadGPAStatisticsGrid()
        {
            My_DB db = new My_DB();
            // Lưu ý: MSSV hiện là NVARCHAR(20), các hàm JOIN/GROUP BY vẫn hoạt động bình thường
            string query = @"SELECT s.MSSV, s.Fname + ' ' + s.Lname AS HoTen, 
                                    ROUND(AVG(sc.DiemTK), 2) AS DiemTB, 
                                    CASE 
                                        WHEN AVG(sc.DiemTK) >= 9 THEN N'Xuất sắc' 
                                        WHEN AVG(sc.DiemTK) >= 8 THEN N'Giỏi' 
                                        WHEN AVG(sc.DiemTK) >= 6.5 THEN N'Khá' 
                                        WHEN AVG(sc.DiemTK) >= 5 THEN N'Trung bình' 
                                        ELSE N'Yếu' 
                                    END AS XepLoai 
                             FROM Student s JOIN Score sc ON s.MSSV = sc.MSSV 
                             GROUP BY s.MSSV, s.Fname, s.Lname";

            dgvDiemTrungBinh.Rows.Clear();

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
                                int rowIndex = dgvDiemTrungBinh.Rows.Add();
                                dgvDiemTrungBinh.Rows[rowIndex].Cells["colMSSV"].Value = reader["MSSV"].ToString();
                                dgvDiemTrungBinh.Rows[rowIndex].Cells["colHoTen"].Value = reader["HoTen"].ToString();
                                dgvDiemTrungBinh.Rows[rowIndex].Cells["colDiemTB"].Value = reader["DiemTB"].ToString();
                                dgvDiemTrungBinh.Rows[rowIndex].Cells["colXepLoai"].Value = reader["XepLoai"].ToString();

                                if (Convert.ToDouble(reader["DiemTB"]) < 5.0)
                                {
                                    dgvDiemTrungBinh.Rows[rowIndex].Cells["colDiemTB"].Style.ForeColor = Color.DarkRed;
                                    dgvDiemTrungBinh.Rows[rowIndex].Cells["colDiemTB"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi nạp lưới điểm: " + ex.Message);
                    }
                }
            }
        }

        private void HoverCard(Panel card, Label title, Label value, Color themeColor, bool isMouseEnter)
        {
            if (isMouseEnter)
            {
                card.BackColor = themeColor;
                title.ForeColor = Color.White;
                value.ForeColor = Color.White;
            }
            else
            {
                card.BackColor = Color.White;
                title.ForeColor = Color.FromArgb(45, 55, 72);
                value.ForeColor = themeColor;
            }
        }
    }
}
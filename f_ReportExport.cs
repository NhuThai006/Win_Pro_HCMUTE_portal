using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using OfficeOpenXml;
using MiniSoftware;

namespace QuanLySinhVien
{
    public partial class f_ReportExport : Form
    {
        private readonly My_DB db = new My_DB();

        public f_ReportExport()
        {
            InitializeComponent();
            RegisterReportEvents();
        }

        private void RegisterReportEvents()
        {
            this.Load += f_ReportExport_Load;
            this.cboLoaiBaoCao.SelectedIndexChanged += FilterConfiguration_Changed;
            this.cboHocKy.SelectedIndexChanged += FilterConfiguration_Changed;

            this.btnExportPDF.Click += btnExportPDF_Click;
            this.btnExportExcel.Click += btnExportExcel_Click;
            this.btnExportWord.Click += btnExportWord_Click;
        }

        private void f_ReportExport_Load(object sender, EventArgs e)
        {
            if (cboLoaiBaoCao.Items.Count > 0) cboLoaiBaoCao.SelectedIndex = 0;
            if (cboDinhDang.Items.Count > 0) cboDinhDang.SelectedIndex = 0;
            if (cboHocKy.Items.Count > 0) cboHocKy.SelectedIndex = 0;

            chkHeaderFooter.Checked = true;
            chkLogo.Checked = true;

            LoadPreviewData();
        }

        private void FilterConfiguration_Changed(object sender, EventArgs e)
        {
            lblReportHeader.Text = cboLoaiBaoCao.Text.ToUpper();
            lblReportDate.Text = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy");

            if (cboLoaiBaoCao.SelectedIndex == 2)
                cboDinhDang.Text = "Word";
            else
                cboDinhDang.SelectedIndex = cboLoaiBaoCao.SelectedIndex;

            LoadPreviewData();
        }

        private void LoadPreviewData()
        {
            DataTable table = new DataTable();
            string query = "";

            dgvPreview.Columns.Clear();

            int loaiBaoCao = cboLoaiBaoCao.SelectedIndex;
            int hocKy = cboHocKy.SelectedIndex;

            if (loaiBaoCao == 0)
            {
                // Alias không dấu để khớp placeholder {{...}} trong template Word
                query = "SELECT MSSV, Fname AS [HoDem], Lname AS [Ten], Gder AS [GioiTinh], Email FROM Student";
            }
            else if (loaiBaoCao == 1)
            {
                query = "SELECT MaMH, TenMH, SoTC, Tuan, HocKy FROM Course";
                if (hocKy > 0) query += " WHERE HocKy = @hky";
            }
            else if (loaiBaoCao == 2)
            {
                query = @"SELECT s.MSSV, s.Fname + ' ' + s.Lname AS [HoTen],
                                 COUNT(sc.MaMH) AS [SoMonHoc],
                                 ROUND(AVG(sc.DiemTK), 2) AS [DiemTB]
                          FROM Student s
                          INNER JOIN Score sc ON s.MSSV = sc.MSSV
                          GROUP BY s.MSSV, s.Fname, s.Lname";
            }

            using (SqlConnection conn = db.getConnection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (hocKy > 0 && loaiBaoCao == 1)
                        cmd.Parameters.Add("@hky", SqlDbType.Int).Value = hocKy;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        dgvPreview.DataSource = table;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi nạp dữ liệu xem trước: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvPreview.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = $"BaoCao_{cboLoaiBaoCao.Text.Replace(" ", "")}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Font tiếng Việt: ưu tiên font đóng gói trong project, nếu không có thì dò các font hệ thống phổ biến
                    string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "arial.ttf");

                    if (!File.Exists(fontPath))
                    {
                        string fontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                        string[] candidates = { "arial.ttf", "Arial.ttf", "times.ttf", "Times.ttf", "tahoma.ttf", "segoeui.ttf" };
                        fontPath = null;
                        foreach (var name in candidates)
                        {
                            string p = Path.Combine(fontsFolder, name);
                            if (File.Exists(p)) { fontPath = p; break; }
                        }
                    }

                    if (fontPath == null)
                    {
                        MessageBox.Show(
                            "Không tìm thấy font hỗ trợ tiếng Việt trên máy.\n" +
                            "Vui lòng đặt file arial.ttf vào thư mục Template của ứng dụng.",
                            "Thiếu font", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (PdfWriter writer = new PdfWriter(sfd.FileName))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (iText.Layout.Document document = new iText.Layout.Document(pdf))
                    {
                        iText.Kernel.Font.PdfFont vietnamFont;
                        try
                        {
                            vietnamFont = iText.Kernel.Font.PdfFontFactory.CreateFont(
                                fontPath, "Identity-H", iText.Kernel.Font.PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
                        }
                        catch (Exception fontEx)
                        {
                            throw new Exception($"Không thể nạp font tại '{fontPath}': {fontEx.Message}");
                        }
                        document.SetFont(vietnamFont);

                        if (chkLogo.Checked)
                            document.Add(new iText.Layout.Element.Paragraph("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP.HCM")
                                .SetFontSize(10f).SetBold());

                        document.Add(new iText.Layout.Element.Paragraph(lblReportHeader.Text)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFontSize(16f).SetBold());

                        string userInfo = !string.IsNullOrEmpty(Globals.GlobalUserId)
                            ? $" | Người xuất ID: {Globals.GlobalUserId}" : "";
                        document.Add(new iText.Layout.Element.Paragraph(lblReportDate.Text + userInfo)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(10f));

                        int colCount = dgvPreview.Columns.Count;
                        iText.Layout.Element.Table pdfTable = new iText.Layout.Element.Table(colCount).UseAllAvailableWidth();

                        foreach (DataGridViewColumn col in dgvPreview.Columns)
                            pdfTable.AddCell(new iText.Layout.Element.Cell()
                                .Add(new iText.Layout.Element.Paragraph(col.HeaderText)).SetBold());

                        for (int r = 0; r < dgvPreview.Rows.Count; r++)
                            for (int c = 0; c < colCount; c++)
                                pdfTable.AddCell(dgvPreview.Rows[r].Cells[c].Value?.ToString() ?? "");

                        document.Add(pdfTable);
                    }

                    MessageBox.Show("Kết xuất PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sự cố iText PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvPreview.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = $"BaoCao_{cboLoaiBaoCao.Text.Replace(" ", "")}.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // EPPlus 4.5.3.3 (LGPL) không cần khai báo LicenseContext
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Báo cáo");

                        for (int i = 0; i < dgvPreview.Columns.Count; i++)
                            ws.Cells[1, i + 1].Value = dgvPreview.Columns[i].HeaderText;

                        for (int r = 0; r < dgvPreview.Rows.Count; r++)
                            for (int c = 0; c < dgvPreview.Columns.Count; c++)
                                // Giữ nguyên kiểu dữ liệu gốc (số vẫn là số) thay vì ép thành string
                                ws.Cells[r + 2, c + 1].Value = dgvPreview.Rows[r].Cells[c].Value;

                        ws.Cells[1, 1, 1, dgvPreview.Columns.Count].Style.Font.Bold = true;
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        package.SaveAs(new FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            if (dgvPreview.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Word Documents|*.docx";
                sfd.FileName = $"BaoCao_{cboLoaiBaoCao.Text.Replace(" ", "")}.docx";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                // Chọn template tương ứng theo loại báo cáo
                string templateName;
                switch (cboLoaiBaoCao.SelectedIndex)
                {
                    case 0: templateName = "template_sv.docx"; break;
                    case 1: templateName = "template_mon.docx"; break;
                    case 2: templateName = "template_diem.docx"; break;
                    default: templateName = "template_sv.docx"; break;
                }

                string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", templateName);

                if (!File.Exists(templatePath))
                {
                    MessageBox.Show($"Thiếu file template: {templatePath}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var items = new List<Dictionary<string, string>>();

                    foreach (DataGridViewRow row in dgvPreview.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cells = row.Cells;
                        var item = new Dictionary<string, string>();

                        switch (cboLoaiBaoCao.SelectedIndex)
                        {
                            case 0: // Danh sách SV: MSSV, HoDem, Ten, GioiTinh, Email
                                item["MSSV"] = cells[0].Value?.ToString() ?? "";
                                item["HoDem"] = cells[1].Value?.ToString() ?? "";
                                item["Ten"] = cells[2].Value?.ToString() ?? "";
                                item["GioiTinh"] = cells[3].Value?.ToString() ?? "";
                                item["Email"] = cells[4].Value?.ToString() ?? "";
                                break;

                            case 1: // Danh sách môn học: MaMH, TenMH, SoTC, Tuan, HocKy
                                item["MaMH"] = cells[0].Value?.ToString() ?? "";
                                item["TenMH"] = cells[1].Value?.ToString() ?? "";
                                item["SoTC"] = cells[2].Value?.ToString() ?? "";
                                item["Tuan"] = cells[3].Value?.ToString() ?? "";
                                item["HocKy"] = cells[4].Value?.ToString() ?? "";
                                break;

                            case 2: // Bảng điểm SV: MSSV, HoTen, SoMonHoc, DiemTB
                                item["MSSV"] = cells[0].Value?.ToString() ?? "";
                                item["HoTen"] = cells[1].Value?.ToString() ?? "";
                                item["SoMonHoc"] = cells[2].Value?.ToString() ?? "";
                                item["DiemTB"] = cells[3].Value?.ToString() ?? "";
                                break;
                        }

                        items.Add(item);
                    }

                    var valueData = new
                    {
                        Title = lblReportHeader.Text,
                        Date = DateTime.Now.ToString("dd/MM/yyyy"),
                        Exporter = Globals.GlobalUserName ?? "Admin",
                        TotalCount = dgvPreview.Rows.Count.ToString(),
                        Items = items
                    };

                    MiniWord.SaveAsByTemplate(sfd.FileName, templatePath, valueData);
                    MessageBox.Show("Xuất Word thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Word: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
namespace QuanLySinhVien
{
    partial class f_ReportExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlConfig = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExportWord = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportPDF = new Guna.UI2.WinForms.Guna2Button();
            this.chkLogo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkHeaderFooter = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cboHocKy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboDinhDang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDinhDang = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLoaiBaoCao = new System.Windows.Forms.Label();
            this.lblTitleConfig = new System.Windows.Forms.Label();
            this.pnlPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.lblReportHeader = new System.Windows.Forms.Label();
            this.dgvPreview = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitlePreview = new System.Windows.Forms.Label();
            this.lblCodeHint = new System.Windows.Forms.Label();
            this.pnlConfig.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlConfig
            // 
            this.pnlConfig.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlConfig.BorderRadius = 10;
            this.pnlConfig.BorderThickness = 1;
            this.pnlConfig.Controls.Add(this.btnExportWord);
            this.pnlConfig.Controls.Add(this.btnExportExcel);
            this.pnlConfig.Controls.Add(this.btnExportPDF);
            this.pnlConfig.Controls.Add(this.chkLogo);
            this.pnlConfig.Controls.Add(this.chkHeaderFooter);
            this.pnlConfig.Controls.Add(this.cboHocKy);
            this.pnlConfig.Controls.Add(this.lblHocKy);
            this.pnlConfig.Controls.Add(this.cboDinhDang);
            this.pnlConfig.Controls.Add(this.lblDinhDang);
            this.pnlConfig.Controls.Add(this.cboLoaiBaoCao);
            this.pnlConfig.Controls.Add(this.lblLoaiBaoCao);
            this.pnlConfig.Controls.Add(this.lblTitleConfig);
            this.pnlConfig.FillColor = System.Drawing.Color.White;
            this.pnlConfig.Location = new System.Drawing.Point(25, 25);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(368, 842);
            this.pnlConfig.TabIndex = 0;
            // 
            // btnExportWord
            // 
            this.btnExportWord.BorderRadius = 6;
            this.btnExportWord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            this.btnExportWord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportWord.ForeColor = System.Drawing.Color.White;
            this.btnExportWord.Location = new System.Drawing.Point(20, 545);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(315, 45);
            this.btnExportWord.TabIndex = 11;
            this.btnExportWord.Text = "Xuất Word";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BorderRadius = 6;
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(154)))), ((int)(((byte)(73)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(190, 480);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(145, 45);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "Xuất Excel";
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BorderRadius = 6;
            this.btnExportPDF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(20, 480);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(145, 45);
            this.btnExportPDF.TabIndex = 9;
            this.btnExportPDF.Text = "Xuất PDF";
            // 
            // chkLogo
            // 
            this.chkLogo.AutoSize = true;
            this.chkLogo.BackColor = System.Drawing.Color.Transparent;
            this.chkLogo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkLogo.CheckedState.BorderRadius = 2;
            this.chkLogo.CheckedState.BorderThickness = 0;
            this.chkLogo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            this.chkLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.chkLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.chkLogo.Location = new System.Drawing.Point(25, 415);
            this.chkLogo.Name = "chkLogo";
            this.chkLogo.Size = new System.Drawing.Size(162, 29);
            this.chkLogo.TabIndex = 8;
            this.chkLogo.Text = "Có logo trường";
            this.chkLogo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkLogo.UncheckedState.BorderRadius = 2;
            this.chkLogo.UncheckedState.BorderThickness = 0;
            this.chkLogo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chkLogo.UseVisualStyleBackColor = false;
            // 
            // chkHeaderFooter
            // 
            this.chkHeaderFooter.AutoSize = true;
            this.chkHeaderFooter.BackColor = System.Drawing.Color.Transparent;
            this.chkHeaderFooter.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkHeaderFooter.CheckedState.BorderRadius = 2;
            this.chkHeaderFooter.CheckedState.BorderThickness = 0;
            this.chkHeaderFooter.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            this.chkHeaderFooter.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.chkHeaderFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.chkHeaderFooter.Location = new System.Drawing.Point(25, 365);
            this.chkHeaderFooter.Name = "chkHeaderFooter";
            this.chkHeaderFooter.Size = new System.Drawing.Size(177, 29);
            this.chkHeaderFooter.TabIndex = 7;
            this.chkHeaderFooter.Text = "Có header/footer";
            this.chkHeaderFooter.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHeaderFooter.UncheckedState.BorderRadius = 2;
            this.chkHeaderFooter.UncheckedState.BorderThickness = 0;
            this.chkHeaderFooter.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chkHeaderFooter.UseVisualStyleBackColor = false;
            // 
            // cboHocKy
            // 
            this.cboHocKy.BackColor = System.Drawing.Color.Transparent;
            this.cboHocKy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboHocKy.BorderRadius = 6;
            this.cboHocKy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboHocKy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboHocKy.ItemHeight = 30;
            this.cboHocKy.Items.AddRange(new object[] {
            "Tất cả",
            "Học kỳ 1",
            "Học kỳ 2"});
            this.cboHocKy.Location = new System.Drawing.Point(20, 295);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(315, 36);
            this.cboHocKy.StartIndex = 0;
            this.cboHocKy.TabIndex = 6;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.BackColor = System.Drawing.Color.Transparent;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblHocKy.ForeColor = System.Drawing.Color.Gray;
            this.lblHocKy.Location = new System.Drawing.Point(20, 265);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(64, 23);
            this.lblHocKy.TabIndex = 5;
            this.lblHocKy.Text = "Học Kỳ";
            // 
            // cboDinhDang
            // 
            this.cboDinhDang.BackColor = System.Drawing.Color.Transparent;
            this.cboDinhDang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboDinhDang.BorderRadius = 6;
            this.cboDinhDang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDinhDang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDinhDang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboDinhDang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboDinhDang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDinhDang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboDinhDang.ItemHeight = 30;
            this.cboDinhDang.Items.AddRange(new object[] {
            "PDF",
            "Excel",
            "Word"});
            this.cboDinhDang.Location = new System.Drawing.Point(20, 205);
            this.cboDinhDang.Name = "cboDinhDang";
            this.cboDinhDang.Size = new System.Drawing.Size(315, 36);
            this.cboDinhDang.StartIndex = 0;
            this.cboDinhDang.TabIndex = 4;
            // 
            // lblDinhDang
            // 
            this.lblDinhDang.AutoSize = true;
            this.lblDinhDang.BackColor = System.Drawing.Color.Transparent;
            this.lblDinhDang.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDinhDang.ForeColor = System.Drawing.Color.Gray;
            this.lblDinhDang.Location = new System.Drawing.Point(20, 175);
            this.lblDinhDang.Name = "lblDinhDang";
            this.lblDinhDang.Size = new System.Drawing.Size(90, 23);
            this.lblDinhDang.TabIndex = 3;
            this.lblDinhDang.Text = "Định dạng";
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiBaoCao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboLoaiBaoCao.BorderRadius = 6;
            this.cboLoaiBaoCao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboLoaiBaoCao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboLoaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboLoaiBaoCao.ItemHeight = 30;
            this.cboLoaiBaoCao.Items.AddRange(new object[] {
            "Danh sách SV",
            "Danh sách môn học",
            "Bảng điểm sinh viên"});
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(20, 115);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(315, 36);
            this.cboLoaiBaoCao.StartIndex = 0;
            this.cboLoaiBaoCao.TabIndex = 2;
            // 
            // lblLoaiBaoCao
            // 
            this.lblLoaiBaoCao.AutoSize = true;
            this.lblLoaiBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.lblLoaiBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblLoaiBaoCao.ForeColor = System.Drawing.Color.Gray;
            this.lblLoaiBaoCao.Location = new System.Drawing.Point(20, 85);
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Size = new System.Drawing.Size(107, 23);
            this.lblLoaiBaoCao.TabIndex = 1;
            this.lblLoaiBaoCao.Text = "Loại báo cáo";
            // 
            // lblTitleConfig
            // 
            this.lblTitleConfig.AutoSize = true;
            this.lblTitleConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleConfig.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitleConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitleConfig.Location = new System.Drawing.Point(20, 25);
            this.lblTitleConfig.Name = "lblTitleConfig";
            this.lblTitleConfig.Size = new System.Drawing.Size(236, 37);
            this.lblTitleConfig.TabIndex = 0;
            this.lblTitleConfig.Text = "Cấu hình báo cáo";
            // 
            // pnlPreview
            // 
            this.pnlPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlPreview.BorderRadius = 10;
            this.pnlPreview.BorderThickness = 1;
            this.pnlPreview.Controls.Add(this.lblReportDate);
            this.pnlPreview.Controls.Add(this.lblReportHeader);
            this.pnlPreview.Controls.Add(this.dgvPreview);
            this.pnlPreview.Controls.Add(this.lblTitlePreview);
            this.pnlPreview.FillColor = System.Drawing.Color.White;
            this.pnlPreview.Location = new System.Drawing.Point(410, 25);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(912, 842);
            this.pnlPreview.TabIndex = 1;
            // 
            // lblReportDate
            // 
            this.lblReportDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblReportDate.BackColor = System.Drawing.Color.Transparent;
            this.lblReportDate.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblReportDate.ForeColor = System.Drawing.Color.Gray;
            this.lblReportDate.Location = new System.Drawing.Point(121, 732);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(670, 25);
            this.lblReportDate.TabIndex = 3;
            this.lblReportDate.Text = "Ngày xuất: 14/06/2026";
            this.lblReportDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReportHeader
            // 
            this.lblReportHeader.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblReportHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblReportHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblReportHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            this.lblReportHeader.Location = new System.Drawing.Point(121, 682);
            this.lblReportHeader.Name = "lblReportHeader";
            this.lblReportHeader.Size = new System.Drawing.Size(670, 41);
            this.lblReportHeader.TabIndex = 2;
            this.lblReportHeader.Text = "DANH SÁCH SINH VIÊN";
            this.lblReportHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPreview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPreview.ColumnHeadersHeight = 35;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMSSV,
            this.colHo,
            this.colTen,
            this.colGioiTinh,
            this.colEmail});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreview.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPreview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvPreview.Location = new System.Drawing.Point(20, 85);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowHeadersWidth = 51;
            this.dgvPreview.RowTemplate.Height = 32;
            this.dgvPreview.Size = new System.Drawing.Size(873, 594);
            this.dgvPreview.TabIndex = 1;
            this.dgvPreview.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPreview.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvPreview.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.dgvPreview.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvPreview.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvPreview.ThemeStyle.ReadOnly = true;
            this.dgvPreview.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvPreview.ThemeStyle.RowsStyle.Height = 32;
            this.dgvPreview.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.dgvPreview.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // colMSSV
            // 
            this.colMSSV.FillWeight = 85F;
            this.colMSSV.HeaderText = "MSSV";
            this.colMSSV.MinimumWidth = 6;
            this.colMSSV.Name = "colMSSV";
            this.colMSSV.ReadOnly = true;
            // 
            // colHo
            // 
            this.colHo.FillWeight = 110F;
            this.colHo.HeaderText = "Họ";
            this.colHo.MinimumWidth = 6;
            this.colHo.Name = "colHo";
            this.colHo.ReadOnly = true;
            // 
            // colTen
            // 
            this.colTen.FillWeight = 75F;
            this.colTen.HeaderText = "Tên";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.FillWeight = 80F;
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.MinimumWidth = 6;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.FillWeight = 150F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // lblTitlePreview
            // 
            this.lblTitlePreview.AutoSize = true;
            this.lblTitlePreview.BackColor = System.Drawing.Color.Transparent;
            this.lblTitlePreview.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitlePreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitlePreview.Location = new System.Drawing.Point(15, 25);
            this.lblTitlePreview.Name = "lblTitlePreview";
            this.lblTitlePreview.Size = new System.Drawing.Size(260, 37);
            this.lblTitlePreview.TabIndex = 0;
            this.lblTitlePreview.Text = "Xem trước báo cáo";
            // 
            // lblCodeHint
            // 
            this.lblCodeHint.AutoSize = true;
            this.lblCodeHint.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblCodeHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCodeHint.Location = new System.Drawing.Point(21, 870);
            this.lblCodeHint.Name = "lblCodeHint";
            this.lblCodeHint.Size = new System.Drawing.Size(669, 23);
            this.lblCodeHint.TabIndex = 6;
            this.lblCodeHint.Text = "Code xử lý: Tuần 13 - ExportPDF(), ExportExcel(); nâng cao: MiniWord cho bảng điể" +
    "m.";
            // 
            // f_ReportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1334, 902);
            this.Controls.Add(this.lblCodeHint);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.pnlConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_ReportExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất Báo Cáo Hệ Thống";
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlConfig;
        private System.Windows.Forms.Label lblTitleConfig;
        private System.Windows.Forms.Label lblLoaiBaoCao;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label lblDinhDang;
        private Guna.UI2.WinForms.Guna2ComboBox cboDinhDang;
        private System.Windows.Forms.Label lblHocKy;
        private Guna.UI2.WinForms.Guna2ComboBox cboHocKy;
        private Guna.UI2.WinForms.Guna2CheckBox chkHeaderFooter;
        private Guna.UI2.WinForms.Guna2CheckBox chkLogo;
        private Guna.UI2.WinForms.Guna2Button btnExportPDF;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2Button btnExportWord;
        private Guna.UI2.WinForms.Guna2Panel pnlPreview;
        private System.Windows.Forms.Label lblTitlePreview;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Label lblReportHeader;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.Label lblCodeHint;
    }
}
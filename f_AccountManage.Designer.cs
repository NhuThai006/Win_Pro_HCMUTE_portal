namespace QuanLySinhVien
{
    partial class f_AccountManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlChoDuyet = new Guna.UI2.WinForms.Guna2Panel();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuChoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChoDuyet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colChoMSGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitleChoDuyet = new System.Windows.Forms.Label();
            this.pnlDaDuyet = new Guna.UI2.WinForms.Guna2Panel();
            this.btnXoaTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDaDuyet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colDaMSGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitleDaDuyet = new System.Windows.Forms.Label();
            this.pnlChoDuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoDuyet)).BeginInit();
            this.pnlDaDuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDuyet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChoDuyet
            // 
            this.pnlChoDuyet.BackColor = System.Drawing.Color.Transparent;
            this.pnlChoDuyet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlChoDuyet.BorderRadius = 10;
            this.pnlChoDuyet.BorderThickness = 1;
            this.pnlChoDuyet.Controls.Add(this.btnXem);
            this.pnlChoDuyet.Controls.Add(this.btnTuChoi);
            this.pnlChoDuyet.Controls.Add(this.btnDuyet);
            this.pnlChoDuyet.Controls.Add(this.dgvChoDuyet);
            this.pnlChoDuyet.Controls.Add(this.lblTitleChoDuyet);
            this.pnlChoDuyet.FillColor = System.Drawing.Color.White;
            this.pnlChoDuyet.Location = new System.Drawing.Point(33, 31);
            this.pnlChoDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChoDuyet.Name = "pnlChoDuyet";
            this.pnlChoDuyet.Size = new System.Drawing.Size(1172, 412);
            this.pnlChoDuyet.TabIndex = 0;
            // 
            // btnXem
            // 
            this.btnXem.BorderRadius = 6;
            this.btnXem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.btnXem.Location = new System.Drawing.Point(302, 338);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(133, 47);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem";
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.BorderRadius = 6;
            this.btnTuChoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuChoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuChoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuChoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuChoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTuChoi.Location = new System.Drawing.Point(161, 338);
            this.btnTuChoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(133, 47);
            this.btnTuChoi.TabIndex = 3;
            this.btnTuChoi.Text = "Từ chối";
            // 
            // btnDuyet
            // 
            this.btnDuyet.BorderRadius = 6;
            this.btnDuyet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDuyet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDuyet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDuyet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDuyet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(154)))), ((int)(((byte)(73)))));
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(119)))), ((int)(((byte)(54)))));
            this.btnDuyet.Location = new System.Drawing.Point(20, 338);
            this.btnDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(133, 47);
            this.btnDuyet.TabIndex = 2;
            this.btnDuyet.Text = "Duyệt";
            // 
            // dgvChoDuyet
            // 
            this.dgvChoDuyet.AllowUserToAddRows = false;
            this.dgvChoDuyet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChoDuyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChoDuyet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChoDuyet.ColumnHeadersHeight = 35;
            this.dgvChoDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChoDuyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChoMSGV,
            this.colChoHoTen,
            this.colChoUsername,
            this.colChoVaiTro,
            this.colChoEmail});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChoDuyet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChoDuyet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvChoDuyet.Location = new System.Drawing.Point(20, 74);
            this.dgvChoDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChoDuyet.Name = "dgvChoDuyet";
            this.dgvChoDuyet.ReadOnly = true;
            this.dgvChoDuyet.RowHeadersVisible = false;
            this.dgvChoDuyet.RowHeadersWidth = 51;
            this.dgvChoDuyet.RowTemplate.Height = 32;
            this.dgvChoDuyet.Size = new System.Drawing.Size(1121, 256);
            this.dgvChoDuyet.TabIndex = 1;
            this.dgvChoDuyet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChoDuyet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvChoDuyet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.dgvChoDuyet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvChoDuyet.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvChoDuyet.ThemeStyle.ReadOnly = true;
            this.dgvChoDuyet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvChoDuyet.ThemeStyle.RowsStyle.Height = 32;
            this.dgvChoDuyet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.dgvChoDuyet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // colChoMSGV
            // 
            this.colChoMSGV.HeaderText = "MSGV";
            this.colChoMSGV.MinimumWidth = 6;
            this.colChoMSGV.Name = "colChoMSGV";
            this.colChoMSGV.ReadOnly = true;
            // 
            // colChoHoTen
            // 
            this.colChoHoTen.HeaderText = "Họ tên";
            this.colChoHoTen.MinimumWidth = 6;
            this.colChoHoTen.Name = "colChoHoTen";
            this.colChoHoTen.ReadOnly = true;
            // 
            // colChoUsername
            // 
            this.colChoUsername.HeaderText = "Username";
            this.colChoUsername.MinimumWidth = 6;
            this.colChoUsername.Name = "colChoUsername";
            this.colChoUsername.ReadOnly = true;
            // 
            // colChoVaiTro
            // 
            this.colChoVaiTro.HeaderText = "Vai trò";
            this.colChoVaiTro.MinimumWidth = 6;
            this.colChoVaiTro.Name = "colChoVaiTro";
            this.colChoVaiTro.ReadOnly = true;
            // 
            // colChoEmail
            // 
            this.colChoEmail.HeaderText = "Email";
            this.colChoEmail.MinimumWidth = 6;
            this.colChoEmail.Name = "colChoEmail";
            this.colChoEmail.ReadOnly = true;
            // 
            // lblTitleChoDuyet
            // 
            this.lblTitleChoDuyet.AutoSize = true;
            this.lblTitleChoDuyet.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleChoDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitleChoDuyet.Location = new System.Drawing.Point(20, 25);
            this.lblTitleChoDuyet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleChoDuyet.Name = "lblTitleChoDuyet";
            this.lblTitleChoDuyet.Size = new System.Drawing.Size(243, 32);
            this.lblTitleChoDuyet.TabIndex = 0;
            this.lblTitleChoDuyet.Text = "Tài khoản chờ duyệt";
            // 
            // pnlDaDuyet
            // 
            this.pnlDaDuyet.BackColor = System.Drawing.Color.Transparent;
            this.pnlDaDuyet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlDaDuyet.BorderRadius = 10;
            this.pnlDaDuyet.BorderThickness = 1;
            this.pnlDaDuyet.Controls.Add(this.btnXoaTaiKhoan);
            this.pnlDaDuyet.Controls.Add(this.dgvDaDuyet);
            this.pnlDaDuyet.Controls.Add(this.lblTitleDaDuyet);
            this.pnlDaDuyet.FillColor = System.Drawing.Color.White;
            this.pnlDaDuyet.Location = new System.Drawing.Point(33, 475);
            this.pnlDaDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDaDuyet.Name = "pnlDaDuyet";
            this.pnlDaDuyet.Size = new System.Drawing.Size(1172, 385);
            this.pnlDaDuyet.TabIndex = 1;
            // 
            // btnXoaTaiKhoan
            // 
            this.btnXoaTaiKhoan.BorderRadius = 6;
            this.btnXoaTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaTaiKhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXoaTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnXoaTaiKhoan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaTaiKhoan.Location = new System.Drawing.Point(20, 316);
            this.btnXoaTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            this.btnXoaTaiKhoan.Size = new System.Drawing.Size(187, 47);
            this.btnXoaTaiKhoan.TabIndex = 3;
            this.btnXoaTaiKhoan.Text = "Xóa tài khoản";
            // 
            // dgvDaDuyet
            // 
            this.dgvDaDuyet.AllowUserToAddRows = false;
            this.dgvDaDuyet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvDaDuyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDaDuyet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDaDuyet.ColumnHeadersHeight = 35;
            this.dgvDaDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDaDuyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDaMSGV,
            this.colDaHoTen,
            this.colDaUsername,
            this.colDaVaiTro,
            this.colDaTrangThai});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDaDuyet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDaDuyet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvDaDuyet.Location = new System.Drawing.Point(20, 74);
            this.dgvDaDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDaDuyet.Name = "dgvDaDuyet";
            this.dgvDaDuyet.ReadOnly = true;
            this.dgvDaDuyet.RowHeadersVisible = false;
            this.dgvDaDuyet.RowHeadersWidth = 51;
            this.dgvDaDuyet.RowTemplate.Height = 32;
            this.dgvDaDuyet.Size = new System.Drawing.Size(1121, 234);
            this.dgvDaDuyet.TabIndex = 1;
            this.dgvDaDuyet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDaDuyet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvDaDuyet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.dgvDaDuyet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvDaDuyet.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvDaDuyet.ThemeStyle.ReadOnly = true;
            this.dgvDaDuyet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDaDuyet.ThemeStyle.RowsStyle.Height = 32;
            this.dgvDaDuyet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.dgvDaDuyet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // colDaMSGV
            // 
            this.colDaMSGV.HeaderText = "MSGV";
            this.colDaMSGV.MinimumWidth = 6;
            this.colDaMSGV.Name = "colDaMSGV";
            this.colDaMSGV.ReadOnly = true;
            // 
            // colDaHoTen
            // 
            this.colDaHoTen.HeaderText = "Họ tên";
            this.colDaHoTen.MinimumWidth = 6;
            this.colDaHoTen.Name = "colDaHoTen";
            this.colDaHoTen.ReadOnly = true;
            // 
            // colDaUsername
            // 
            this.colDaUsername.HeaderText = "Username";
            this.colDaUsername.MinimumWidth = 6;
            this.colDaUsername.Name = "colDaUsername";
            this.colDaUsername.ReadOnly = true;
            // 
            // colDaVaiTro
            // 
            this.colDaVaiTro.HeaderText = "Vai trò";
            this.colDaVaiTro.MinimumWidth = 6;
            this.colDaVaiTro.Name = "colDaVaiTro";
            this.colDaVaiTro.ReadOnly = true;
            // 
            // colDaTrangThai
            // 
            this.colDaTrangThai.HeaderText = "Trạng thái";
            this.colDaTrangThai.MinimumWidth = 6;
            this.colDaTrangThai.Name = "colDaTrangThai";
            this.colDaTrangThai.ReadOnly = true;
            // 
            // lblTitleDaDuyet
            // 
            this.lblTitleDaDuyet.AutoSize = true;
            this.lblTitleDaDuyet.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleDaDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitleDaDuyet.Location = new System.Drawing.Point(20, 25);
            this.lblTitleDaDuyet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleDaDuyet.Name = "lblTitleDaDuyet";
            this.lblTitleDaDuyet.Size = new System.Drawing.Size(230, 32);
            this.lblTitleDaDuyet.TabIndex = 0;
            this.lblTitleDaDuyet.Text = "Tài khoản đã duyệt";
            // 
            // f_AccountManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1243, 888);
            this.Controls.Add(this.pnlDaDuyet);
            this.Controls.Add(this.pnlChoDuyet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "f_AccountManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            this.pnlChoDuyet.ResumeLayout(false);
            this.pnlChoDuyet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoDuyet)).EndInit();
            this.pnlDaDuyet.ResumeLayout(false);
            this.pnlDaDuyet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDuyet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlChoDuyet;
        private System.Windows.Forms.Label lblTitleChoDuyet;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChoDuyet;
        private Guna.UI2.WinForms.Guna2Button btnDuyet;
        private Guna.UI2.WinForms.Guna2Button btnTuChoi;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Panel pnlDaDuyet;
        private System.Windows.Forms.Label lblTitleDaDuyet;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDaDuyet;
        private Guna.UI2.WinForms.Guna2Button btnXoaTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoMSGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaMSGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaTrangThai;
    }
}
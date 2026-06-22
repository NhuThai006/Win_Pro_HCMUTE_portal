namespace QuanLySinhVien
{
    partial class f_ContactManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlChiTiet = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.cboNhom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNhom = new System.Windows.Forms.Label();
            this.cboGioiTinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtHo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHo = new System.Windows.Forms.Label();
            this.txtID = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTitleChiTiet = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboFilterNhom = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblFilterNhom = new System.Windows.Forms.Label();
            this.dgvContact = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCodeHint = new System.Windows.Forms.Label();
            this.pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChiTiet
            // 
            this.pnlChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.pnlChiTiet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlChiTiet.BorderRadius = 10;
            this.pnlChiTiet.BorderThickness = 1;
            this.pnlChiTiet.Controls.Add(this.dtpDob);
            this.pnlChiTiet.Controls.Add(this.btnXoa);
            this.pnlChiTiet.Controls.Add(this.btnSua);
            this.pnlChiTiet.Controls.Add(this.btnThem);
            this.pnlChiTiet.Controls.Add(this.txtDiaChi);
            this.pnlChiTiet.Controls.Add(this.lblDiaChi);
            this.pnlChiTiet.Controls.Add(this.txtEmail);
            this.pnlChiTiet.Controls.Add(this.lblEmail);
            this.pnlChiTiet.Controls.Add(this.txtSDT);
            this.pnlChiTiet.Controls.Add(this.lblSDT);
            this.pnlChiTiet.Controls.Add(this.cboNhom);
            this.pnlChiTiet.Controls.Add(this.lblNhom);
            this.pnlChiTiet.Controls.Add(this.cboGioiTinh);
            this.pnlChiTiet.Controls.Add(this.lblGioiTinh);
            this.pnlChiTiet.Controls.Add(this.lblNgaySinh);
            this.pnlChiTiet.Controls.Add(this.txtTen);
            this.pnlChiTiet.Controls.Add(this.lblTen);
            this.pnlChiTiet.Controls.Add(this.txtHo);
            this.pnlChiTiet.Controls.Add(this.lblHo);
            this.pnlChiTiet.Controls.Add(this.txtID);
            this.pnlChiTiet.Controls.Add(this.lblID);
            this.pnlChiTiet.Controls.Add(this.lblTitleChiTiet);
            this.pnlChiTiet.FillColor = System.Drawing.Color.White;
            this.pnlChiTiet.Location = new System.Drawing.Point(13, 13);
            this.pnlChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChiTiet.Name = "pnlChiTiet";
            this.pnlChiTiet.Size = new System.Drawing.Size(453, 873);
            this.pnlChiTiet.TabIndex = 0;
            // 
            // dtpDob
            // 
            this.dtpDob.CustomFormat = "dd/MM/yyyy";
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDob.Location = new System.Drawing.Point(20, 361);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(412, 31);
            this.dtpDob.TabIndex = 23;
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 6;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoa.Location = new System.Drawing.Point(316, 815);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(87, 47);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa";
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 6;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.btnSua.Location = new System.Drawing.Point(180, 815);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(87, 47);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Sửa";
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 6;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(154)))), ((int)(((byte)(73)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(119)))), ((int)(((byte)(54)))));
            this.btnThem.Location = new System.Drawing.Point(27, 815);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 47);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "Thêm";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtDiaChi.BorderRadius = 6;
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChi.DefaultText = "TP. Hồ Chí Minh";
            this.txtDiaChi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiaChi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiaChi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtDiaChi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtDiaChi.Location = new System.Drawing.Point(20, 751);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PlaceholderText = "";
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.Size = new System.Drawing.Size(413, 39);
            this.txtDiaChi.TabIndex = 18;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblDiaChi.ForeColor = System.Drawing.Color.Gray;
            this.lblDiaChi.Location = new System.Drawing.Point(20, 724);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(58, 21);
            this.lblDiaChi.TabIndex = 17;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtEmail.Location = new System.Drawing.Point(20, 671);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(413, 39);
            this.txtEmail.TabIndex = 16;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(20, 644);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // txtSDT
            // 
            this.txtSDT.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtSDT.BorderRadius = 6;
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.DefaultText = "";
            this.txtSDT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtSDT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSDT.Location = new System.Drawing.Point(20, 591);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PlaceholderText = "";
            this.txtSDT.SelectedText = "";
            this.txtSDT.Size = new System.Drawing.Size(413, 39);
            this.txtSDT.TabIndex = 14;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblSDT.ForeColor = System.Drawing.Color.Gray;
            this.lblSDT.Location = new System.Drawing.Point(20, 564);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(39, 21);
            this.lblSDT.TabIndex = 13;
            this.lblSDT.Text = "SĐT";
            // 
            // cboNhom
            // 
            this.cboNhom.BackColor = System.Drawing.Color.Transparent;
            this.cboNhom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboNhom.BorderRadius = 6;
            this.cboNhom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhom.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboNhom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboNhom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboNhom.ItemHeight = 26;
            this.cboNhom.Items.AddRange(new object[] {
            "Công việc",
            "Bạn bè"});
            this.cboNhom.Location = new System.Drawing.Point(20, 511);
            this.cboNhom.Margin = new System.Windows.Forms.Padding(4);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Size = new System.Drawing.Size(412, 32);
            this.cboNhom.StartIndex = 0;
            this.cboNhom.TabIndex = 12;
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.lblNhom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblNhom.ForeColor = System.Drawing.Color.Gray;
            this.lblNhom.Location = new System.Drawing.Point(20, 484);
            this.lblNhom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(55, 21);
            this.lblNhom.TabIndex = 11;
            this.lblNhom.Text = "Nhóm";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.BackColor = System.Drawing.Color.Transparent;
            this.cboGioiTinh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboGioiTinh.BorderRadius = 6;
            this.cboGioiTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboGioiTinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboGioiTinh.ItemHeight = 26;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(20, 431);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(412, 32);
            this.cboGioiTinh.StartIndex = 0;
            this.cboGioiTinh.TabIndex = 10;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.Gray;
            this.lblGioiTinh.Location = new System.Drawing.Point(20, 404);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(71, 21);
            this.lblGioiTinh.TabIndex = 9;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Gray;
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 324);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(81, 21);
            this.lblNgaySinh.TabIndex = 7;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // txtTen
            // 
            this.txtTen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTen.BorderRadius = 6;
            this.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTen.DefaultText = "2";
            this.txtTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtTen.Location = new System.Drawing.Point(20, 271);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTen.Name = "txtTen";
            this.txtTen.PlaceholderText = "";
            this.txtTen.SelectedText = "";
            this.txtTen.Size = new System.Drawing.Size(413, 39);
            this.txtTen.TabIndex = 6;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblTen.ForeColor = System.Drawing.Color.Gray;
            this.lblTen.Location = new System.Drawing.Point(20, 244);
            this.lblTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(35, 21);
            this.lblTen.TabIndex = 5;
            this.lblTen.Text = "Tên";
            // 
            // txtHo
            // 
            this.txtHo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtHo.BorderRadius = 6;
            this.txtHo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHo.DefaultText = "1";
            this.txtHo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtHo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtHo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtHo.Location = new System.Drawing.Point(20, 191);
            this.txtHo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtHo.Name = "txtHo";
            this.txtHo.PlaceholderText = "";
            this.txtHo.SelectedText = "";
            this.txtHo.Size = new System.Drawing.Size(413, 39);
            this.txtHo.TabIndex = 4;
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblHo.ForeColor = System.Drawing.Color.Gray;
            this.lblHo.Location = new System.Drawing.Point(20, 164);
            this.lblHo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(32, 21);
            this.lblHo.TabIndex = 3;
            this.lblHo.Text = "Họ";
            // 
            // txtID
            // 
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtID.BorderRadius = 6;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.DefaultText = "";
            this.txtID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtID.Location = new System.Drawing.Point(20, 111);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtID.Name = "txtID";
            this.txtID.PlaceholderText = "";
            this.txtID.SelectedText = "";
            this.txtID.Size = new System.Drawing.Size(413, 39);
            this.txtID.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblID.ForeColor = System.Drawing.Color.Gray;
            this.lblID.Location = new System.Drawing.Point(20, 84);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 21);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // lblTitleChiTiet
            // 
            this.lblTitleChiTiet.AutoSize = true;
            this.lblTitleChiTiet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitleChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitleChiTiet.Location = new System.Drawing.Point(20, 25);
            this.lblTitleChiTiet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleChiTiet.Name = "lblTitleChiTiet";
            this.lblTitleChiTiet.Size = new System.Drawing.Size(202, 37);
            this.lblTitleChiTiet.TabIndex = 0;
            this.lblTitleChiTiet.Text = "Chi tiết liên hệ";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTimKiem.BorderRadius = 6;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtTimKiem.Location = new System.Drawing.Point(493, 43);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tên, SĐT, email";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 39);
            this.txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.lblTimKiem.Location = new System.Drawing.Point(493, 16);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(76, 21);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // cboFilterNhom
            // 
            this.cboFilterNhom.BackColor = System.Drawing.Color.Transparent;
            this.cboFilterNhom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboFilterNhom.BorderRadius = 6;
            this.cboFilterNhom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilterNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterNhom.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboFilterNhom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.cboFilterNhom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilterNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.cboFilterNhom.ItemHeight = 26;
            this.cboFilterNhom.Location = new System.Drawing.Point(819, 43);
            this.cboFilterNhom.Margin = new System.Windows.Forms.Padding(4);
            this.cboFilterNhom.Name = "cboFilterNhom";
            this.cboFilterNhom.Size = new System.Drawing.Size(192, 32);
            this.cboFilterNhom.StartIndex = 0;
            this.cboFilterNhom.TabIndex = 4;
            // 
            // lblFilterNhom
            // 
            this.lblFilterNhom.AutoSize = true;
            this.lblFilterNhom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblFilterNhom.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterNhom.Location = new System.Drawing.Point(819, 16);
            this.lblFilterNhom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterNhom.Name = "lblFilterNhom";
            this.lblFilterNhom.Size = new System.Drawing.Size(55, 21);
            this.lblFilterNhom.TabIndex = 3;
            this.lblFilterNhom.Text = "Nhóm";
            // 
            // dgvContact
            // 
            this.dgvContact.AllowUserToAddRows = false;
            this.dgvContact.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvContact.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContact.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvContact.ColumnHeadersHeight = 35;
            this.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvContact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colHoTen,
            this.colNgaySinh,
            this.colGioiTinh,
            this.colNhom,
            this.colSDT,
            this.colEmail});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContact.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvContact.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvContact.Location = new System.Drawing.Point(474, 92);
            this.dgvContact.Margin = new System.Windows.Forms.Padding(4);
            this.dgvContact.Name = "dgvContact";
            this.dgvContact.ReadOnly = true;
            this.dgvContact.RowHeadersVisible = false;
            this.dgvContact.RowHeadersWidth = 51;
            this.dgvContact.RowTemplate.Height = 32;
            this.dgvContact.Size = new System.Drawing.Size(756, 786);
            this.dgvContact.TabIndex = 5;
            this.dgvContact.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvContact.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvContact.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.dgvContact.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvContact.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvContact.ThemeStyle.ReadOnly = true;
            this.dgvContact.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvContact.ThemeStyle.RowsStyle.Height = 32;
            this.dgvContact.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.dgvContact.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // colID
            // 
            this.colID.FillWeight = 50F;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colHoTen
            // 
            this.colHoTen.FillWeight = 110F;
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.FillWeight = 95F;
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.MinimumWidth = 6;
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.FillWeight = 75F;
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.MinimumWidth = 6;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            // 
            // colNhom
            // 
            this.colNhom.FillWeight = 85F;
            this.colNhom.HeaderText = "Nhóm";
            this.colNhom.MinimumWidth = 6;
            this.colNhom.Name = "colNhom";
            this.colNhom.ReadOnly = true;
            // 
            // colSDT
            // 
            this.colSDT.HeaderText = "SĐT";
            this.colSDT.MinimumWidth = 6;
            this.colSDT.Name = "colSDT";
            this.colSDT.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.FillWeight = 120F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // lblCodeHint
            // 
            this.lblCodeHint.AutoSize = true;
            this.lblCodeHint.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblCodeHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCodeHint.Location = new System.Drawing.Point(527, 935);
            this.lblCodeHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodeHint.Name = "lblCodeHint";
            this.lblCodeHint.Size = new System.Drawing.Size(770, 23);
            this.lblCodeHint.TabIndex = 6;
            this.lblCodeHint.Text = "Code xử lý: Tuần 12 / Phần 9 - Groups, Contact, LoadGroups(), Add/Edit/Delete Con" +
    "tact, cboGroup.";
            // 
            // f_ContactManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1243, 888);
            this.Controls.Add(this.lblCodeHint);
            this.Controls.Add(this.dgvContact);
            this.Controls.Add(this.cboFilterNhom);
            this.Controls.Add(this.lblFilterNhom);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.pnlChiTiet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "f_ContactManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh bạ";
            this.pnlChiTiet.ResumeLayout(false);
            this.pnlChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlChiTiet;
        private System.Windows.Forms.Label lblTitleChiTiet;
        private System.Windows.Forms.Label lblID;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Guna.UI2.WinForms.Guna2TextBox txtHo;
        private System.Windows.Forms.Label lblHo;
        private Guna.UI2.WinForms.Guna2TextBox txtTen;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboGioiTinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhom;
        private System.Windows.Forms.Label lblNhom;
        private Guna.UI2.WinForms.Guna2TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilterNhom;
        private System.Windows.Forms.Label lblFilterNhom;
        private Guna.UI2.WinForms.Guna2DataGridView dgvContact;
        private System.Windows.Forms.Label lblCodeHint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DateTimePicker dtpDob;
    }
}
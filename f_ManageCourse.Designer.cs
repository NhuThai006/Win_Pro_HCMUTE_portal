namespace QuanLySinhVien
{
    partial class f_ManageCourse
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
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblTitleInfo = new System.Windows.Forms.Label();
            this.lblMaMH = new System.Windows.Forms.Label();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.lblTenMonHoc = new System.Windows.Forms.Label();
            this.txtTenMonHoc = new System.Windows.Forms.TextBox();
            this.lblSoTinChi = new System.Windows.Forms.Label();
            this.txtSoTinChi = new System.Windows.Forms.TextBox();
            this.lblSoTuan = new System.Windows.Forms.Label();
            this.txtSoTuan = new System.Windows.Forms.TextBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterHocKy = new System.Windows.Forms.Label();
            this.cboFilterHocKy = new System.Windows.Forms.ComboBox();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.lblTitleInfo);
            this.panelInfo.Controls.Add(this.lblMaMH);
            this.panelInfo.Controls.Add(this.txtMaMH);
            this.panelInfo.Controls.Add(this.lblTenMonHoc);
            this.panelInfo.Controls.Add(this.txtTenMonHoc);
            this.panelInfo.Controls.Add(this.lblSoTinChi);
            this.panelInfo.Controls.Add(this.txtSoTinChi);
            this.panelInfo.Controls.Add(this.lblSoTuan);
            this.panelInfo.Controls.Add(this.txtSoTuan);
            this.panelInfo.Controls.Add(this.lblHocKy);
            this.panelInfo.Controls.Add(this.cboHocKy);
            this.panelInfo.Controls.Add(this.lblMoTa);
            this.panelInfo.Controls.Add(this.txtMoTa);
            this.panelInfo.Controls.Add(this.btn_Add);
            this.panelInfo.Controls.Add(this.btn_Edit);
            this.panelInfo.Controls.Add(this.btn_Delete);
            this.panelInfo.Location = new System.Drawing.Point(25, 25);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(350, 520);
            this.panelInfo.TabIndex = 0;
            // 
            // lblTitleInfo
            // 
            this.lblTitleInfo.AutoSize = true;
            this.lblTitleInfo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTitleInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            this.lblTitleInfo.Location = new System.Drawing.Point(18, 15);
            this.lblTitleInfo.Name = "lblTitleInfo";
            this.lblTitleInfo.Size = new System.Drawing.Size(219, 31);
            this.lblTitleInfo.TabIndex = 0;
            this.lblTitleInfo.Text = "Thông tin môn học";
            // 
            // lblMaMH
            // 
            this.lblMaMH.AutoSize = true;
            this.lblMaMH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaMH.ForeColor = System.Drawing.Color.Gray;
            this.lblMaMH.Location = new System.Drawing.Point(20, 60);
            this.lblMaMH.Name = "lblMaMH";
            this.lblMaMH.Size = new System.Drawing.Size(96, 20);
            this.lblMaMH.TabIndex = 1;
            this.lblMaMH.Text = "Mã môn học";
            // 
            // txtMaMH
            // 
            this.txtMaMH.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtMaMH.Location = new System.Drawing.Point(20, 82);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(310, 30);
            this.txtMaMH.TabIndex = 2;
            // 
            // lblTenMonHoc
            // 
            this.lblTenMonHoc.AutoSize = true;
            this.lblTenMonHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenMonHoc.ForeColor = System.Drawing.Color.Gray;
            this.lblTenMonHoc.Location = new System.Drawing.Point(20, 120);
            this.lblTenMonHoc.Name = "lblTenMonHoc";
            this.lblTenMonHoc.Size = new System.Drawing.Size(99, 20);
            this.lblTenMonHoc.TabIndex = 3;
            this.lblTenMonHoc.Text = "Tên môn học";
            // 
            // txtTenMonHoc
            // 
            this.txtTenMonHoc.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtTenMonHoc.Location = new System.Drawing.Point(20, 142);
            this.txtTenMonHoc.Name = "txtTenMonHoc";
            this.txtTenMonHoc.Size = new System.Drawing.Size(310, 30);
            this.txtTenMonHoc.TabIndex = 4;
            // 
            // lblSoTinChi
            // 
            this.lblSoTinChi.AutoSize = true;
            this.lblSoTinChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoTinChi.ForeColor = System.Drawing.Color.Gray;
            this.lblSoTinChi.Location = new System.Drawing.Point(20, 180);
            this.lblSoTinChi.Name = "lblSoTinChi";
            this.lblSoTinChi.Size = new System.Drawing.Size(73, 20);
            this.lblSoTinChi.TabIndex = 5;
            this.lblSoTinChi.Text = "Số tín chỉ";
            // 
            // txtSoTinChi
            // 
            this.txtSoTinChi.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtSoTinChi.Location = new System.Drawing.Point(20, 202);
            this.txtSoTinChi.Name = "txtSoTinChi";
            this.txtSoTinChi.Size = new System.Drawing.Size(310, 30);
            this.txtSoTinChi.TabIndex = 6;
            // 
            // lblSoTuan
            // 
            this.lblSoTuan.AutoSize = true;
            this.lblSoTuan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoTuan.ForeColor = System.Drawing.Color.Gray;
            this.lblSoTuan.Location = new System.Drawing.Point(20, 240);
            this.lblSoTuan.Name = "lblSoTuan";
            this.lblSoTuan.Size = new System.Drawing.Size(62, 20);
            this.lblSoTuan.TabIndex = 7;
            this.lblSoTuan.Text = "Số tuần";
            // 
            // txtSoTuan
            // 
            this.txtSoTuan.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtSoTuan.Location = new System.Drawing.Point(20, 262);
            this.txtSoTuan.Name = "txtSoTuan";
            this.txtSoTuan.Size = new System.Drawing.Size(310, 30);
            this.txtSoTuan.TabIndex = 8;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHocKy.ForeColor = System.Drawing.Color.Gray;
            this.lblHocKy.Location = new System.Drawing.Point(20, 300);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(56, 20);
            this.lblHocKy.TabIndex = 9;
            this.lblHocKy.Text = "Học kỳ";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboHocKy.Location = new System.Drawing.Point(20, 322);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(310, 31);
            this.cboHocKy.TabIndex = 10;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.ForeColor = System.Drawing.Color.Gray;
            this.lblMoTa.Location = new System.Drawing.Point(20, 360);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(50, 20);
            this.lblMoTa.TabIndex = 11;
            this.lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtMoTa.Location = new System.Drawing.Point(20, 382);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(310, 60);
            this.txtMoTa.TabIndex = 12;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(20, 460);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(95, 40);
            this.btn_Add.TabIndex = 13;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(121)))), ((int)(((byte)(194)))));
            this.btn_Edit.FlatAppearance.BorderSize = 0;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Location = new System.Drawing.Point(127, 460);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(95, 40);
            this.btn_Edit.TabIndex = 14;
            this.btn_Edit.Text = "Sửa";
            this.btn_Edit.UseVisualStyleBackColor = false;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(235, 460);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(95, 40);
            this.btn_Delete.TabIndex = 15;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.Gray;
            this.lblSearch.Location = new System.Drawing.Point(405, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 20);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtSearch.Location = new System.Drawing.Point(405, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 31);
            this.txtSearch.TabIndex = 2;
            // 
            // lblFilterHocKy
            // 
            this.lblFilterHocKy.AutoSize = true;
            this.lblFilterHocKy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterHocKy.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterHocKy.Location = new System.Drawing.Point(650, 25);
            this.lblFilterHocKy.Name = "lblFilterHocKy";
            this.lblFilterHocKy.Size = new System.Drawing.Size(56, 20);
            this.lblFilterHocKy.TabIndex = 3;
            this.lblFilterHocKy.Text = "Học kỳ";
            // 
            // cboFilterHocKy
            // 
            this.cboFilterHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterHocKy.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.cboFilterHocKy.FormattingEnabled = true;
            this.cboFilterHocKy.Items.AddRange(new object[] {
            "Tất cả HK",
            "1",
            "2",
            "3"});
            this.cboFilterHocKy.Location = new System.Drawing.Point(650, 50);
            this.cboFilterHocKy.Name = "cboFilterHocKy";
            this.cboFilterHocKy.Size = new System.Drawing.Size(120, 33);
            this.cboFilterHocKy.TabIndex = 4;
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourses.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCourses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCourses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCourses.ColumnHeadersHeight = 35;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCourses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCourses.EnableHeadersVisualStyles = false;
            this.dgvCourses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dgvCourses.Location = new System.Drawing.Point(405, 110);
            this.dgvCourses.MultiSelect = false;
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowHeadersWidth = 51;
            this.dgvCourses.RowTemplate.Height = 32;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(664, 743);
            this.dgvCourses.TabIndex = 5;
            // 
            // f_ManageCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1094, 888);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.cboFilterHocKy);
            this.Controls.Add(this.lblFilterHocKy);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_ManageCourse";
            this.Text = "Quản Lý Môn Học CRUD";
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblTitleInfo;
        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Label lblTenMonHoc;
        private System.Windows.Forms.TextBox txtTenMonHoc;
        private System.Windows.Forms.Label lblSoTinChi;
        private System.Windows.Forms.TextBox txtSoTinChi;
        private System.Windows.Forms.Label lblSoTuan;
        private System.Windows.Forms.TextBox txtSoTuan;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterHocKy;
        private System.Windows.Forms.ComboBox cboFilterHocKy;
        private System.Windows.Forms.DataGridView dgvCourses;
    }
}
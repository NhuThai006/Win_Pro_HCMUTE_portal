namespace QuanLySinhVien
{
    partial class f_EditDeleteStudent
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.picEditStudent = new System.Windows.Forms.PictureBox();
            this.lblHometown = new System.Windows.Forms.Label();
            this.txb_EditHometown = new System.Windows.Forms.TextBox();
            this.dtpEditDob = new System.Windows.Forms.DateTimePicker();
            this.lblTitleForm = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblHo = new System.Windows.Forms.Label();
            this.txb_EditFname = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txb_EditLname = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboEditGender = new System.Windows.Forms.ComboBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txb_EditPhone = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txb_EditAddress = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txb_EditEmail = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudents.ColumnHeadersHeight = 35;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dgvStudents.Location = new System.Drawing.Point(25, 30);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 32;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(751, 846);
            this.dgvStudents.TabIndex = 0;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.White;
            this.panelEdit.Controls.Add(this.picEditStudent);
            this.panelEdit.Controls.Add(this.lblHometown);
            this.panelEdit.Controls.Add(this.txb_EditHometown);
            this.panelEdit.Controls.Add(this.dtpEditDob);
            this.panelEdit.Controls.Add(this.lblTitleForm);
            this.panelEdit.Controls.Add(this.lblMSSV);
            this.panelEdit.Controls.Add(this.txtMSSV);
            this.panelEdit.Controls.Add(this.lblHo);
            this.panelEdit.Controls.Add(this.txb_EditFname);
            this.panelEdit.Controls.Add(this.lblTen);
            this.panelEdit.Controls.Add(this.txb_EditLname);
            this.panelEdit.Controls.Add(this.lblNgaySinh);
            this.panelEdit.Controls.Add(this.lblGioiTinh);
            this.panelEdit.Controls.Add(this.cboEditGender);
            this.panelEdit.Controls.Add(this.lblSDT);
            this.panelEdit.Controls.Add(this.txb_EditPhone);
            this.panelEdit.Controls.Add(this.lblDiaChi);
            this.panelEdit.Controls.Add(this.txb_EditAddress);
            this.panelEdit.Controls.Add(this.lblEmail);
            this.panelEdit.Controls.Add(this.txb_EditEmail);
            this.panelEdit.Controls.Add(this.btnUpdate);
            this.panelEdit.Controls.Add(this.btnDelete);
            this.panelEdit.Location = new System.Drawing.Point(782, 30);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(449, 846);
            this.panelEdit.TabIndex = 1;
            // 
            // picEditStudent
            // 
            this.picEditStudent.Location = new System.Drawing.Point(229, 62);
            this.picEditStudent.Name = "picEditStudent";
            this.picEditStudent.Size = new System.Drawing.Size(175, 230);
            this.picEditStudent.TabIndex = 22;
            this.picEditStudent.TabStop = false;
            // 
            // lblHometown
            // 
            this.lblHometown.AutoSize = true;
            this.lblHometown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHometown.ForeColor = System.Drawing.Color.Gray;
            this.lblHometown.Location = new System.Drawing.Point(28, 420);
            this.lblHometown.Name = "lblHometown";
            this.lblHometown.Size = new System.Drawing.Size(76, 20);
            this.lblHometown.TabIndex = 20;
            this.lblHometown.Text = "Quê quán";
            // 
            // txb_EditHometown
            // 
            this.txb_EditHometown.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txb_EditHometown.Location = new System.Drawing.Point(32, 443);
            this.txb_EditHometown.Name = "txb_EditHometown";
            this.txb_EditHometown.Size = new System.Drawing.Size(372, 30);
            this.txb_EditHometown.TabIndex = 21;
            // 
            // dtpEditDob
            // 
            this.dtpEditDob.CustomFormat = "dd/MM/yyyy";
            this.dtpEditDob.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.dtpEditDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEditDob.Location = new System.Drawing.Point(26, 261);
            this.dtpEditDob.Name = "dtpEditDob";
            this.dtpEditDob.Size = new System.Drawing.Size(171, 31);
            this.dtpEditDob.TabIndex = 19;
            // 
            // lblTitleForm
            // 
            this.lblTitleForm.AutoSize = true;
            this.lblTitleForm.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTitleForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(128)))));
            this.lblTitleForm.Location = new System.Drawing.Point(20, 15);
            this.lblTitleForm.Name = "lblTitleForm";
            this.lblTitleForm.Size = new System.Drawing.Size(220, 31);
            this.lblTitleForm.TabIndex = 0;
            this.lblTitleForm.Text = "Form sửa thông tin";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMSSV.ForeColor = System.Drawing.Color.Gray;
            this.lblMSSV.Location = new System.Drawing.Point(24, 60);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(49, 20);
            this.lblMSSV.TabIndex = 1;
            this.lblMSSV.Text = "MSSV";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtMSSV.Location = new System.Drawing.Point(24, 82);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(175, 30);
            this.txtMSSV.TabIndex = 2;
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHo.ForeColor = System.Drawing.Color.Gray;
            this.lblHo.Location = new System.Drawing.Point(28, 115);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(29, 20);
            this.lblHo.TabIndex = 3;
            this.lblHo.Text = "Họ";
            // 
            // txb_EditFname
            // 
            this.txb_EditFname.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txb_EditFname.Location = new System.Drawing.Point(24, 138);
            this.txb_EditFname.Name = "txb_EditFname";
            this.txb_EditFname.Size = new System.Drawing.Size(175, 30);
            this.txb_EditFname.TabIndex = 4;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTen.ForeColor = System.Drawing.Color.Gray;
            this.lblTen.Location = new System.Drawing.Point(24, 171);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(34, 20);
            this.lblTen.TabIndex = 5;
            this.lblTen.Text = "Tên";
            // 
            // txb_EditLname
            // 
            this.txb_EditLname.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txb_EditLname.Location = new System.Drawing.Point(24, 194);
            this.txb_EditLname.Name = "txb_EditLname";
            this.txb_EditLname.Size = new System.Drawing.Size(175, 30);
            this.txb_EditLname.TabIndex = 6;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Gray;
            this.lblNgaySinh.Location = new System.Drawing.Point(28, 227);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(79, 20);
            this.lblNgaySinh.TabIndex = 7;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.Gray;
            this.lblGioiTinh.Location = new System.Drawing.Point(28, 307);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(69, 20);
            this.lblGioiTinh.TabIndex = 9;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // cboEditGender
            // 
            this.cboEditGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEditGender.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboEditGender.FormattingEnabled = true;
            this.cboEditGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboEditGender.Location = new System.Drawing.Point(28, 330);
            this.cboEditGender.Name = "cboEditGender";
            this.cboEditGender.Size = new System.Drawing.Size(175, 31);
            this.cboEditGender.TabIndex = 10;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSDT.ForeColor = System.Drawing.Color.Gray;
            this.lblSDT.Location = new System.Drawing.Point(225, 307);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(37, 20);
            this.lblSDT.TabIndex = 11;
            this.lblSDT.Text = "SĐT";
            // 
            // txb_EditPhone
            // 
            this.txb_EditPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txb_EditPhone.Location = new System.Drawing.Point(225, 330);
            this.txb_EditPhone.Name = "txb_EditPhone";
            this.txb_EditPhone.Size = new System.Drawing.Size(175, 30);
            this.txb_EditPhone.TabIndex = 12;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.ForeColor = System.Drawing.Color.Gray;
            this.lblDiaChi.Location = new System.Drawing.Point(28, 364);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(56, 20);
            this.lblDiaChi.TabIndex = 13;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txb_EditAddress
            // 
            this.txb_EditAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txb_EditAddress.Location = new System.Drawing.Point(28, 387);
            this.txb_EditAddress.Name = "txb_EditAddress";
            this.txb_EditAddress.Size = new System.Drawing.Size(175, 30);
            this.txb_EditAddress.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(221, 364);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 20);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // txb_EditEmail
            // 
            this.txb_EditEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txb_EditEmail.Location = new System.Drawing.Point(225, 387);
            this.txb_EditEmail.Name = "txb_EditEmail";
            this.txb_EditEmail.Size = new System.Drawing.Size(175, 30);
            this.txb_EditEmail.TabIndex = 16;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(79, 479);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 42);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(256, 479);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 42);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // f_EditDeleteStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1243, 888);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.dgvStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_EditDeleteStudent";
            this.Text = "Sửa & Xóa Sinh Viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label lblTitleForm;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.TextBox txb_EditFname;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txb_EditLname;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboEditGender;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txb_EditPhone;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txb_EditAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txb_EditEmail;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dtpEditDob;
        private System.Windows.Forms.Label lblHometown;
        private System.Windows.Forms.TextBox txb_EditHometown;
        private System.Windows.Forms.PictureBox picEditStudent;
    }
}
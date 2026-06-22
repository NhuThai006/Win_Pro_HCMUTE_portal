namespace QuanLySinhVien
{
    partial class f_StudentScore
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlNhapDiem;
        private System.Windows.Forms.Panel pnlTongKet;
        private System.Windows.Forms.Label lblTitleNhapDiem;
        private System.Windows.Forms.Label lblSinhVien;
        private System.Windows.Forms.ComboBox cboSinhVien;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblDiemQT;
        private System.Windows.Forms.TextBox txtDiemQT;
        private System.Windows.Forms.Label lblDiemCK;
        private System.Windows.Forms.TextBox txtDiemCK;
        private System.Windows.Forms.Label lblDiemTK;
        private System.Windows.Forms.TextBox txtDiemTK;
        private System.Windows.Forms.Button btnLuuDiem;
        private System.Windows.Forms.Button btnXoaDiem;

        private System.Windows.Forms.Label lblTitleTongKet;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblTongTinChi;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.Button btnXuatWord;

        private System.Windows.Forms.DataGridView dgvBangDiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlNhapDiem = new System.Windows.Forms.Panel();
            this.btnXoaDiem = new System.Windows.Forms.Button();
            this.btnLuuDiem = new System.Windows.Forms.Button();
            this.txtDiemTK = new System.Windows.Forms.TextBox();
            this.lblDiemTK = new System.Windows.Forms.Label();
            this.txtDiemCK = new System.Windows.Forms.TextBox();
            this.lblDiemCK = new System.Windows.Forms.Label();
            this.txtDiemQT = new System.Windows.Forms.TextBox();
            this.lblDiemQT = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboSinhVien = new System.Windows.Forms.ComboBox();
            this.lblSinhVien = new System.Windows.Forms.Label();
            this.lblTitleNhapDiem = new System.Windows.Forms.Label();
            this.pnlTongKet = new System.Windows.Forms.Panel();
            this.btnXuatWord = new System.Windows.Forms.Button();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.lblTongTinChi = new System.Windows.Forms.Label();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblTitleTongKet = new System.Windows.Forms.Label();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.pnlNhapDiem.SuspendLayout();
            this.pnlTongKet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNhapDiem
            // 
            this.pnlNhapDiem.BackColor = System.Drawing.Color.White;
            this.pnlNhapDiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNhapDiem.Controls.Add(this.btnXoaDiem);
            this.pnlNhapDiem.Controls.Add(this.btnLuuDiem);
            this.pnlNhapDiem.Controls.Add(this.txtDiemTK);
            this.pnlNhapDiem.Controls.Add(this.lblDiemTK);
            this.pnlNhapDiem.Controls.Add(this.txtDiemCK);
            this.pnlNhapDiem.Controls.Add(this.lblDiemCK);
            this.pnlNhapDiem.Controls.Add(this.txtDiemQT);
            this.pnlNhapDiem.Controls.Add(this.lblDiemQT);
            this.pnlNhapDiem.Controls.Add(this.cboMonHoc);
            this.pnlNhapDiem.Controls.Add(this.lblMonHoc);
            this.pnlNhapDiem.Controls.Add(this.cboSinhVien);
            this.pnlNhapDiem.Controls.Add(this.lblSinhVien);
            this.pnlNhapDiem.Controls.Add(this.lblTitleNhapDiem);
            this.pnlNhapDiem.Location = new System.Drawing.Point(25, 25);
            this.pnlNhapDiem.Name = "pnlNhapDiem";
            this.pnlNhapDiem.Size = new System.Drawing.Size(340, 804);
            this.pnlNhapDiem.TabIndex = 0;
            // 
            // btnXoaDiem
            // 
            this.btnXoaDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnXoaDiem.FlatAppearance.BorderSize = 0;
            this.btnXoaDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDiem.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaDiem.ForeColor = System.Drawing.Color.White;
            this.btnXoaDiem.Location = new System.Drawing.Point(155, 440);
            this.btnXoaDiem.Name = "btnXoaDiem";
            this.btnXoaDiem.Size = new System.Drawing.Size(120, 42);
            this.btnXoaDiem.TabIndex = 12;
            this.btnXoaDiem.Text = "Xóa điểm";
            this.btnXoaDiem.UseVisualStyleBackColor = false;
            this.btnXoaDiem.Click += new System.EventHandler(this.btnXoaDiem_Click);
            // 
            // btnLuuDiem
            // 
            this.btnLuuDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(165)))), ((int)(((byte)(75)))));
            this.btnLuuDiem.FlatAppearance.BorderSize = 0;
            this.btnLuuDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDiem.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLuuDiem.ForeColor = System.Drawing.Color.White;
            this.btnLuuDiem.Location = new System.Drawing.Point(20, 440);
            this.btnLuuDiem.Name = "btnLuuDiem";
            this.btnLuuDiem.Size = new System.Drawing.Size(120, 42);
            this.btnLuuDiem.TabIndex = 11;
            this.btnLuuDiem.Text = "Lưu điểm";
            this.btnLuuDiem.UseVisualStyleBackColor = false;
            this.btnLuuDiem.Click += new System.EventHandler(this.btnLuuDiem_Click);
            // 
            // txtDiemTK
            // 
            this.txtDiemTK.BackColor = System.Drawing.Color.White;
            this.txtDiemTK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtDiemTK.Location = new System.Drawing.Point(20, 320);
            this.txtDiemTK.Name = "txtDiemTK";
            this.txtDiemTK.ReadOnly = true;
            this.txtDiemTK.Size = new System.Drawing.Size(135, 32);
            this.txtDiemTK.TabIndex = 10;
            // 
            // lblDiemTK
            // 
            this.lblDiemTK.AutoSize = true;
            this.lblDiemTK.ForeColor = System.Drawing.Color.Gray;
            this.lblDiemTK.Location = new System.Drawing.Point(20, 295);
            this.lblDiemTK.Name = "lblDiemTK";
            this.lblDiemTK.Size = new System.Drawing.Size(58, 16);
            this.lblDiemTK.TabIndex = 13;
            this.lblDiemTK.Text = "Điểm TK";
            // 
            // txtDiemCK
            // 
            this.txtDiemCK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDiemCK.Location = new System.Drawing.Point(180, 240);
            this.txtDiemCK.Name = "txtDiemCK";
            this.txtDiemCK.Size = new System.Drawing.Size(135, 32);
            this.txtDiemCK.TabIndex = 8;
            // 
            // lblDiemCK
            // 
            this.lblDiemCK.AutoSize = true;
            this.lblDiemCK.ForeColor = System.Drawing.Color.Gray;
            this.lblDiemCK.Location = new System.Drawing.Point(180, 215);
            this.lblDiemCK.Name = "lblDiemCK";
            this.lblDiemCK.Size = new System.Drawing.Size(58, 16);
            this.lblDiemCK.TabIndex = 14;
            this.lblDiemCK.Text = "Điểm CK";
            // 
            // txtDiemQT
            // 
            this.txtDiemQT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDiemQT.Location = new System.Drawing.Point(20, 240);
            this.txtDiemQT.Name = "txtDiemQT";
            this.txtDiemQT.Size = new System.Drawing.Size(135, 32);
            this.txtDiemQT.TabIndex = 6;
            // 
            // lblDiemQT
            // 
            this.lblDiemQT.AutoSize = true;
            this.lblDiemQT.ForeColor = System.Drawing.Color.Gray;
            this.lblDiemQT.Location = new System.Drawing.Point(20, 215);
            this.lblDiemQT.Name = "lblDiemQT";
            this.lblDiemQT.Size = new System.Drawing.Size(60, 16);
            this.lblDiemQT.TabIndex = 15;
            this.lblDiemQT.Text = "Điểm QT";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMonHoc.Location = new System.Drawing.Point(20, 165);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(295, 31);
            this.cboMonHoc.TabIndex = 4;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.ForeColor = System.Drawing.Color.Gray;
            this.lblMonHoc.Location = new System.Drawing.Point(20, 140);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(58, 16);
            this.lblMonHoc.TabIndex = 16;
            this.lblMonHoc.Text = "Môn học";
            // 
            // cboSinhVien
            // 
            this.cboSinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSinhVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSinhVien.Location = new System.Drawing.Point(20, 90);
            this.cboSinhVien.Name = "cboSinhVien";
            this.cboSinhVien.Size = new System.Drawing.Size(295, 31);
            this.cboSinhVien.TabIndex = 2;
            // 
            // lblSinhVien
            // 
            this.lblSinhVien.AutoSize = true;
            this.lblSinhVien.ForeColor = System.Drawing.Color.Gray;
            this.lblSinhVien.Location = new System.Drawing.Point(20, 65);
            this.lblSinhVien.Name = "lblSinhVien";
            this.lblSinhVien.Size = new System.Drawing.Size(61, 16);
            this.lblSinhVien.TabIndex = 17;
            this.lblSinhVien.Text = "Sinh viên";
            // 
            // lblTitleNhapDiem
            // 
            this.lblTitleNhapDiem.AutoSize = true;
            this.lblTitleNhapDiem.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleNhapDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.lblTitleNhapDiem.Location = new System.Drawing.Point(15, 15);
            this.lblTitleNhapDiem.Name = "lblTitleNhapDiem";
            this.lblTitleNhapDiem.Size = new System.Drawing.Size(133, 31);
            this.lblTitleNhapDiem.TabIndex = 18;
            this.lblTitleNhapDiem.Text = "Nhập điểm";
            // 
            // pnlTongKet
            // 
            this.pnlTongKet.BackColor = System.Drawing.Color.White;
            this.pnlTongKet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongKet.Controls.Add(this.btnXuatWord);
            this.pnlTongKet.Controls.Add(this.lblXepLoai);
            this.pnlTongKet.Controls.Add(this.lblTongTinChi);
            this.pnlTongKet.Controls.Add(this.lblDiemTB);
            this.pnlTongKet.Controls.Add(this.lblTitleTongKet);
            this.pnlTongKet.Location = new System.Drawing.Point(395, 25);
            this.pnlTongKet.Name = "pnlTongKet";
            this.pnlTongKet.Size = new System.Drawing.Size(818, 157);
            this.pnlTongKet.TabIndex = 1;
            // 
            // btnXuatWord
            // 
            this.btnXuatWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(115)))), ((int)(((byte)(185)))));
            this.btnXuatWord.FlatAppearance.BorderSize = 0;
            this.btnXuatWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatWord.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatWord.ForeColor = System.Drawing.Color.White;
            this.btnXuatWord.Location = new System.Drawing.Point(30, 100);
            this.btnXuatWord.Name = "btnXuatWord";
            this.btnXuatWord.Size = new System.Drawing.Size(200, 33);
            this.btnXuatWord.TabIndex = 4;
            this.btnXuatWord.Text = "Xuất bảng điểm Word";
            this.btnXuatWord.UseVisualStyleBackColor = false;
            this.btnXuatWord.Click += new System.EventHandler(this.btnXuatWord_Click);
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.lblXepLoai.Location = new System.Drawing.Point(465, 60);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(135, 30);
            this.lblXepLoai.TabIndex = 3;
            this.lblXepLoai.Text = "Xếp loại: ---";
            // 
            // lblTongTinChi
            // 
            this.lblTongTinChi.AutoSize = true;
            this.lblTongTinChi.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTongTinChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.lblTongTinChi.Location = new System.Drawing.Point(245, 60);
            this.lblTongTinChi.Name = "lblTongTinChi";
            this.lblTongTinChi.Size = new System.Drawing.Size(161, 30);
            this.lblTongTinChi.TabIndex = 2;
            this.lblTongTinChi.Text = "Tổng tín chỉ: 0";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDiemTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.lblDiemTB.Location = new System.Drawing.Point(25, 60);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(157, 30);
            this.lblDiemTB.TabIndex = 1;
            this.lblDiemTB.Text = "Điểm TB: 0.00";
            // 
            // lblTitleTongKet
            // 
            this.lblTitleTongKet.AutoSize = true;
            this.lblTitleTongKet.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleTongKet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.lblTitleTongKet.Location = new System.Drawing.Point(15, 15);
            this.lblTitleTongKet.Name = "lblTitleTongKet";
            this.lblTitleTongKet.Size = new System.Drawing.Size(230, 31);
            this.lblTitleTongKet.TabIndex = 0;
            this.lblTitleTongKet.Text = "Tổng kết bảng điểm";
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvBangDiem.ColumnHeadersHeight = 35;
            this.dgvBangDiem.Location = new System.Drawing.Point(395, 190);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.RowHeadersWidth = 51;
            this.dgvBangDiem.Size = new System.Drawing.Size(818, 639);
            this.dgvBangDiem.TabIndex = 2;
            // 
            // f_StudentScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1225, 841);
            this.Controls.Add(this.dgvBangDiem);
            this.Controls.Add(this.pnlTongKet);
            this.Controls.Add(this.pnlNhapDiem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "f_StudentScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Điểm Sinh Viên";
            this.Load += new System.EventHandler(this.f_StudentScore_Load);
            this.pnlNhapDiem.ResumeLayout(false);
            this.pnlNhapDiem.PerformLayout();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlTongKet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
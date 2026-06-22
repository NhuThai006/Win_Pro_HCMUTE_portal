namespace QuanLySinhVien
{
    partial class f_OTP
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_Verify = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Resend = new Guna.UI2.WinForms.Guna2Button();
            this.txt_Code = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lbl_Timer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(125, 30);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(232, 51);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "XÁC THỰC OTP";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Gray;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(40, 80);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(370, 45);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Mã xác thực đã được gửi đến Email của bạn.<br>Vui lòng kiểm tra và nhập vào bên d" +
    "ưới.";
            // 
            // btn_Verify
            // 
            this.btn_Verify.BorderRadius = 10;
            this.btn_Verify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Verify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Verify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Verify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Verify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Verify.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Verify.ForeColor = System.Drawing.Color.White;
            this.btn_Verify.Location = new System.Drawing.Point(50, 230);
            this.btn_Verify.Name = "btn_Verify";
            this.btn_Verify.Size = new System.Drawing.Size(160, 45);
            this.btn_Verify.TabIndex = 2;
            this.btn_Verify.Text = "Xác nhận";
            this.btn_Verify.Click += new System.EventHandler(this.btn_Verify_Click);
            // 
            // btn_Resend
            // 
            this.btn_Resend.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btn_Resend.BorderRadius = 10;
            this.btn_Resend.BorderThickness = 1;
            this.btn_Resend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Resend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Resend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Resend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Resend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Resend.FillColor = System.Drawing.Color.Transparent;
            this.btn_Resend.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_Resend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btn_Resend.Location = new System.Drawing.Point(240, 230);
            this.btn_Resend.Name = "btn_Resend";
            this.btn_Resend.Size = new System.Drawing.Size(170, 45);
            this.btn_Resend.TabIndex = 3;
            this.btn_Resend.Text = "Gửi lại mã";
            this.btn_Resend.Click += new System.EventHandler(this.btn_Resend_Click);
            // 
            // txt_Code
            // 
            this.txt_Code.BorderRadius = 8;
            this.txt_Code.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Code.DefaultText = "";
            this.txt_Code.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Code.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Code.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Code.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Code.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Code.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.txt_Code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Code.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Code.Location = new System.Drawing.Point(100, 145);
            this.txt_Code.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txt_Code.MaxLength = 6;
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.PlaceholderText = "******";
            this.txt_Code.SelectedText = "";
            this.txt_Code.Size = new System.Drawing.Size(250, 60);
            this.txt_Code.TabIndex = 4;
            this.txt_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.Transparent;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Timer.Font = new System.Drawing.Font("Segoe Fluent Icons", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Timer.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_Timer.Location = new System.Drawing.Point(50, 282);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(102, 19);
            this.lbl_Timer.TabIndex = 5;
            this.lbl_Timer.Text = "guna2HtmlLabel3";
            // 
            // f_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.lbl_Timer);
            this.Controls.Add(this.txt_Code);
            this.Controls.Add(this.btn_Resend);
            this.Controls.Add(this.btn_Verify);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_OTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác thực OTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btn_Verify;
        private Guna.UI2.WinForms.Guna2Button btn_Resend;
        private Guna.UI2.WinForms.Guna2TextBox txt_Code;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Timer;
    }
}
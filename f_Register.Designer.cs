namespace QuanLySinhVien
{
    partial class f_Register
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
            this.txb_Pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txb_ID = new Guna.UI2.WinForms.Guna2TextBox();
            this.lb_StudentID = new System.Windows.Forms.Label();
            this.lb_Password = new System.Windows.Forms.Label();
            this.bt_Register = new Guna.UI2.WinForms.Guna2Button();
            this.txb_Fname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txb_Lname = new Guna.UI2.WinForms.Guna2TextBox();
            this.lb_Fname = new System.Windows.Forms.Label();
            this.lb_Lname = new System.Windows.Forms.Label();
            this.txb_User = new Guna.UI2.WinForms.Guna2TextBox();
            this.lb_Username = new System.Windows.Forms.Label();
            this.txb_Email = new Guna.UI2.WinForms.Guna2TextBox();
            this.lb_Email = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_RoleText = new System.Windows.Forms.Label();
            this.cbo_Role = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ptb_Picture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lb_YourPicture = new System.Windows.Forms.Label();
            this.lb_Register = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txb_Pass
            // 
            this.txb_Pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_Pass.DefaultText = "";
            this.txb_Pass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_Pass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_Pass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Pass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Pass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.txb_Pass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txb_Pass.ForeColor = System.Drawing.Color.Black;
            this.txb_Pass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_Pass.Location = new System.Drawing.Point(30, 310);
            this.txb_Pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_Pass.Name = "txb_Pass";
            this.txb_Pass.PasswordChar = '●';
            this.txb_Pass.PlaceholderText = "Nhập mật khẩu an toàn...";
            this.txb_Pass.SelectedText = "";
            this.txb_Pass.Size = new System.Drawing.Size(400, 40);
            this.txb_Pass.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txb_Pass.TabIndex = 5;
            // 
            // txb_ID
            // 
            this.txb_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_ID.DefaultText = "";
            this.txb_ID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_ID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_ID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_ID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_ID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.txb_ID.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txb_ID.ForeColor = System.Drawing.Color.Black;
            this.txb_ID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_ID.Location = new System.Drawing.Point(30, 100);
            this.txb_ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_ID.Name = "txb_ID";
            this.txb_ID.PlaceholderText = "Nhập mã người dùng...";
            this.txb_ID.SelectedText = "";
            this.txb_ID.Size = new System.Drawing.Size(185, 40);
            this.txb_ID.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txb_ID.TabIndex = 0;
            // 
            // lb_StudentID
            // 
            this.lb_StudentID.AutoSize = true;
            this.lb_StudentID.BackColor = System.Drawing.Color.Transparent;
            this.lb_StudentID.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_StudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_StudentID.Location = new System.Drawing.Point(30, 75);
            this.lb_StudentID.Name = "lb_StudentID";
            this.lb_StudentID.Size = new System.Drawing.Size(133, 23);
            this.lb_StudentID.TabIndex = 4;
            this.lb_StudentID.Text = "Mã Người dùng";
            // 
            // lb_Password
            // 
            this.lb_Password.AutoSize = true;
            this.lb_Password.BackColor = System.Drawing.Color.Transparent;
            this.lb_Password.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_Password.Location = new System.Drawing.Point(30, 285);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(84, 23);
            this.lb_Password.TabIndex = 5;
            this.lb_Password.Text = "Mật khẩu";
            // 
            // bt_Register
            // 
            this.bt_Register.Animated = true;
            this.bt_Register.BorderRadius = 22;
            this.bt_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Register.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_Register.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_Register.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_Register.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_Register.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.bt_Register.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Register.ForeColor = System.Drawing.Color.White;
            this.bt_Register.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.bt_Register.Location = new System.Drawing.Point(490, 430);
            this.bt_Register.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Register.Name = "bt_Register";
            this.bt_Register.Size = new System.Drawing.Size(200, 45);
            this.bt_Register.TabIndex = 8;
            this.bt_Register.Text = "ĐĂNG KÝ";
            this.bt_Register.Click += new System.EventHandler(this.bt_Register_Click);
            // 
            // txb_Fname
            // 
            this.txb_Fname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_Fname.DefaultText = "";
            this.txb_Fname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_Fname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_Fname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Fname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Fname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.txb_Fname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txb_Fname.ForeColor = System.Drawing.Color.Black;
            this.txb_Fname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_Fname.Location = new System.Drawing.Point(30, 170);
            this.txb_Fname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_Fname.Name = "txb_Fname";
            this.txb_Fname.PlaceholderText = "Ví dụ: Nguyễn Văn";
            this.txb_Fname.SelectedText = "";
            this.txb_Fname.Size = new System.Drawing.Size(185, 40);
            this.txb_Fname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txb_Fname.TabIndex = 2;
            // 
            // txb_Lname
            // 
            this.txb_Lname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_Lname.DefaultText = "";
            this.txb_Lname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_Lname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_Lname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Lname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Lname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.txb_Lname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txb_Lname.ForeColor = System.Drawing.Color.Black;
            this.txb_Lname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_Lname.Location = new System.Drawing.Point(235, 170);
            this.txb_Lname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_Lname.Name = "txb_Lname";
            this.txb_Lname.PlaceholderText = "Ví dụ: Anh";
            this.txb_Lname.SelectedText = "";
            this.txb_Lname.Size = new System.Drawing.Size(195, 40);
            this.txb_Lname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txb_Lname.TabIndex = 3;
            // 
            // lb_Fname
            // 
            this.lb_Fname.AutoSize = true;
            this.lb_Fname.BackColor = System.Drawing.Color.Transparent;
            this.lb_Fname.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Fname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_Fname.Location = new System.Drawing.Point(30, 145);
            this.lb_Fname.Name = "lb_Fname";
            this.lb_Fname.Size = new System.Drawing.Size(107, 23);
            this.lb_Fname.TabIndex = 12;
            this.lb_Fname.Text = "Họ và đệm *";
            // 
            // lb_Lname
            // 
            this.lb_Lname.AutoSize = true;
            this.lb_Lname.BackColor = System.Drawing.Color.Transparent;
            this.lb_Lname.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Lname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_Lname.Location = new System.Drawing.Point(235, 145);
            this.lb_Lname.Name = "lb_Lname";
            this.lb_Lname.Size = new System.Drawing.Size(48, 23);
            this.lb_Lname.TabIndex = 13;
            this.lb_Lname.Text = "Tên *";
            // 
            // txb_User
            // 
            this.txb_User.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_User.DefaultText = "";
            this.txb_User.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_User.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_User.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_User.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_User.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.txb_User.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txb_User.ForeColor = System.Drawing.Color.Black;
            this.txb_User.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_User.Location = new System.Drawing.Point(30, 240);
            this.txb_User.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_User.Name = "txb_User";
            this.txb_User.PlaceholderText = "Tên tài khoản duy nhất...";
            this.txb_User.SelectedText = "";
            this.txb_User.Size = new System.Drawing.Size(400, 40);
            this.txb_User.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txb_User.TabIndex = 4;
            // 
            // lb_Username
            // 
            this.lb_Username.AutoSize = true;
            this.lb_Username.BackColor = System.Drawing.Color.Transparent;
            this.lb_Username.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_Username.Location = new System.Drawing.Point(30, 215);
            this.lb_Username.Name = "lb_Username";
            this.lb_Username.Size = new System.Drawing.Size(124, 23);
            this.lb_Username.TabIndex = 15;
            this.lb_Username.Text = "Tên đăng nhập";
            // 
            // txb_Email
            // 
            this.txb_Email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_Email.DefaultText = "";
            this.txb_Email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_Email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_Email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_Email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.txb_Email.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txb_Email.ForeColor = System.Drawing.Color.Black;
            this.txb_Email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_Email.Location = new System.Drawing.Point(30, 380);
            this.txb_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txb_Email.Name = "txb_Email";
            this.txb_Email.PlaceholderText = "nhanvien@student.hcmute.edu.vn...";
            this.txb_Email.SelectedText = "";
            this.txb_Email.Size = new System.Drawing.Size(400, 40);
            this.txb_Email.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txb_Email.TabIndex = 6;
            // 
            // lb_Email
            // 
            this.lb_Email.AutoSize = true;
            this.lb_Email.BackColor = System.Drawing.Color.Transparent;
            this.lb_Email.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_Email.Location = new System.Drawing.Point(30, 355);
            this.lb_Email.Name = "lb_Email";
            this.lb_Email.Size = new System.Drawing.Size(51, 23);
            this.lb_Email.TabIndex = 20;
            this.lb_Email.Text = "Email";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lb_RoleText);
            this.panel1.Controls.Add(this.cbo_Role);
            this.panel1.Controls.Add(this.ptb_Picture);
            this.panel1.Controls.Add(this.lb_YourPicture);
            this.panel1.Controls.Add(this.lb_Email);
            this.panel1.Controls.Add(this.txb_Email);
            this.panel1.Controls.Add(this.lb_Username);
            this.panel1.Controls.Add(this.txb_User);
            this.panel1.Controls.Add(this.lb_Lname);
            this.panel1.Controls.Add(this.lb_Fname);
            this.panel1.Controls.Add(this.txb_Lname);
            this.panel1.Controls.Add(this.txb_Fname);
            this.panel1.Controls.Add(this.lb_Register);
            this.panel1.Controls.Add(this.bt_Register);
            this.panel1.Controls.Add(this.lb_Password);
            this.panel1.Controls.Add(this.lb_StudentID);
            this.panel1.Controls.Add(this.txb_ID);
            this.panel1.Controls.Add(this.txb_Pass);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 500);
            this.panel1.TabIndex = 0;
            // 
            // lb_RoleText
            // 
            this.lb_RoleText.AutoSize = true;
            this.lb_RoleText.BackColor = System.Drawing.Color.Transparent;
            this.lb_RoleText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_RoleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_RoleText.Location = new System.Drawing.Point(490, 345);
            this.lb_RoleText.Name = "lb_RoleText";
            this.lb_RoleText.Size = new System.Drawing.Size(155, 23);
            this.lb_RoleText.TabIndex = 24;
            this.lb_RoleText.Text = "Vai trò người dùng";
            // 
            // cbo_Role
            // 
            this.cbo_Role.BackColor = System.Drawing.Color.Transparent;
            this.cbo_Role.BorderRadius = 4;
            this.cbo_Role.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Role.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.cbo_Role.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.cbo_Role.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbo_Role.ForeColor = System.Drawing.Color.Black;
            this.cbo_Role.ItemHeight = 30;
            this.cbo_Role.Items.AddRange(new object[] {
            "Sinh viên",
            "HR"});
            this.cbo_Role.Location = new System.Drawing.Point(490, 370);
            this.cbo_Role.Name = "cbo_Role";
            this.cbo_Role.Size = new System.Drawing.Size(200, 36);
            this.cbo_Role.StartIndex = 0;
            this.cbo_Role.TabIndex = 7;
            // 
            // ptb_Picture
            // 
            this.ptb_Picture.BorderRadius = 8;
            this.ptb_Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptb_Picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_Picture.ImageRotate = 0F;
            this.ptb_Picture.Location = new System.Drawing.Point(490, 100);
            this.ptb_Picture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptb_Picture.Name = "ptb_Picture";
            this.ptb_Picture.Size = new System.Drawing.Size(200, 220);
            this.ptb_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_Picture.TabIndex = 21;
            this.ptb_Picture.TabStop = false;
            this.ptb_Picture.Click += new System.EventHandler(this.ptb_Picture_Click);
            // 
            // lb_YourPicture
            // 
            this.lb_YourPicture.AutoSize = true;
            this.lb_YourPicture.BackColor = System.Drawing.Color.Transparent;
            this.lb_YourPicture.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_YourPicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_YourPicture.Location = new System.Drawing.Point(490, 75);
            this.lb_YourPicture.Name = "lb_YourPicture";
            this.lb_YourPicture.Size = new System.Drawing.Size(156, 23);
            this.lb_YourPicture.TabIndex = 22;
            this.lb_YourPicture.Text = "Ảnh thẻ sinh viên *";
            // 
            // lb_Register
            // 
            this.lb_Register.AutoSize = false;
            this.lb_Register.BackColor = System.Drawing.Color.Transparent;
            this.lb_Register.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lb_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.lb_Register.Location = new System.Drawing.Point(30, 15);
            this.lb_Register.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_Register.Name = "lb_Register";
            this.lb_Register.Size = new System.Drawing.Size(615, 45);
            this.lb_Register.TabIndex = 6;
            this.lb_Register.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // guna2ColorTransition1
            // 
            this.guna2ColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // f_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "f_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống QLSV - Đăng ký";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Register_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f_Register_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txb_Pass;
        private Guna.UI2.WinForms.Guna2TextBox txb_ID;
        private System.Windows.Forms.Label lb_StudentID;
        private System.Windows.Forms.Label lb_Password;
        private Guna.UI2.WinForms.Guna2Button bt_Register;
        private Guna.UI2.WinForms.Guna2TextBox txb_Fname;
        private Guna.UI2.WinForms.Guna2TextBox txb_Lname;
        private System.Windows.Forms.Label lb_Fname;
        private System.Windows.Forms.Label lb_Lname;
        private Guna.UI2.WinForms.Guna2TextBox txb_User;
        private System.Windows.Forms.Label lb_Username;
        private Guna.UI2.WinForms.Guna2TextBox txb_Email;
        private System.Windows.Forms.Label lb_Email;
        private Guna.UI2.WinForms.Guna2PictureBox ptb_Picture;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Register;
        private System.Windows.Forms.Label lb_YourPicture;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_Role;
        private System.Windows.Forms.Label lb_RoleText;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
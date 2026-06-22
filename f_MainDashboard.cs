using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using QuanLySinhVien.UI;


namespace QuanLySinhVien
{
    public partial class f_MainDashboard : Form
    {
        private Form currentChildForm = null;
        private ChatBubbleButton _chatBubble;
        private ChatPanel _chatPanel;

        // 🟢 SỬA TẠI ĐÂY: Đổi tham số đầu tiên 'userId' từ int sang string để đồng bộ NVARCHAR(20)
        public f_MainDashboard(string userId, int position, string username, string email)
        {
            InitializeComponent();

            // Thiết lập thông tin người dùng đăng nhập toàn cục dạng chuỗi ký tự
            Globals.SetGlobalUserInfo(userId, username, position, email);

            RegisterNavigationEvents();
        }

        private void RegisterNavigationEvents()
        {
            this.Load += f_MainDashboard_Load;
            this.Resize += f_MainDashboard_Resize;

            // Đăng ký sự kiện an toàn chặn luồng chạy ngầm khi người dùng nhấn nút dấu X góc màn hình
            this.FormClosing += f_MainDashboard_FormClosing;

            btnDashboard.Click += (s, e) =>
            {
                OpenChildForm(new f_StaticStudent());
            };

            btnSinhVien.Click += (s, e) =>
            {
                if (HasPermission(0, 2))
                    OpenChildForm(new f_ListStudent());
            };

            btnMonHoc.Click += (s, e) =>
            {
                if (HasPermission(0))
                    OpenChildForm(new f_ManageCourse());
            };

            btnDiem.Click += (s, e) =>
            {
                if (HasPermission(0, 2))
                    OpenChildForm(new f_StudentScore());
            };

            btnTaiKhoan.Click += (s, e) =>
            {
                if (HasPermission(0))
                    OpenChildForm(new f_AccountManage());
            };

            btnHR.Click += (s, e) =>
            {
                if (HasPermission(0))
                    OpenChildForm(new f_HRAssign());
            };

            btnDanhBa.Click += (s, e) =>
            {
                OpenChildForm(new f_ContactManage());
            };

            btnBaoCao.Click += (s, e) =>
            {
                if (HasPermission(0, 2))
                {
                    OpenChildForm(new f_ReportExport());
                }
            };

            btnCaiDat.Click += (s, e) =>
            {
                if (HasPermission(0))
                {
                    MessageBox.Show(
                        "Chức năng cấu hình hệ thống đang được phát triển!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            };
        }

        private void f_MainDashboard_Load(object sender, EventArgs e)
        {
            ApplyRoleBasedSecurity();

            string apiKey = GetApiKey();
            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("Không tìm thấy API Key trong appsettings.json. Vui lòng cấu hình để sử dụng ChatBox.", "Thiếu API Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Khởi tạo ChatPanel
                _chatPanel = new ChatPanel(apiKey);
                _chatPanel.Visible = false;
                _chatPanel.CloseClicked += (s, args) => _chatPanel.Visible = false;
                this.Controls.Add(_chatPanel);

                // Khởi tạo ChatBubbleButton
                _chatBubble = new ChatBubbleButton();
                _chatBubble.BubbleClicked += (s, args) =>
                {
                    _chatPanel.Visible = !_chatPanel.Visible;
                    if (_chatPanel.Visible) _chatPanel.BringToFront();
                };
                this.Controls.Add(_chatBubble);

                PositionChatControls();
            }

            btnDashboard.PerformClick();
        }

        private void f_MainDashboard_Resize(object sender, EventArgs e)
        {
            PositionChatControls();
        }

        private void PositionChatControls()
        {
            if (_chatBubble != null)
            {
                _chatBubble.Location = new Point(this.ClientSize.Width - _chatBubble.Width - 20,
                                                 this.ClientSize.Height - _chatBubble.Height - 20);
                _chatBubble.BringToFront();
            }

            if (_chatPanel != null)
            {
                _chatPanel.Location = new Point(this.ClientSize.Width - _chatPanel.Width - 20,
                                                this.ClientSize.Height - _chatBubble.Height - _chatPanel.Height - 30);
            }
        }

        private string GetApiKey()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    JObject config = JObject.Parse(json);
                    return config["GeminiApiKey"]?.ToString();
                }
            }
            catch (Exception)
            {
                // Log lỗi
            }
            return null;
        }

        /// <summary>
        /// Xử lý giải phóng bộ nhớ và kết thúc tiến trình chạy ngầm khi thoát Form chính
        /// </summary>
        private void f_MainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất và thoát khỏi hệ thống không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy lệnh đóng
            }
            else
            {
                if (currentChildForm != null)
                {
                    currentChildForm.Dispose();
                }

                this.FormClosing -= f_MainDashboard_FormClosing;
                Application.Exit(); // Kill toàn bộ tiến trình chạy ngầm vật lý
            }
        }

        private void ApplyRoleBasedSecurity()
        {
            int position = Globals.GlobalUserRole;

            if (position == 0)
            {
                lblUserRole.Text = "Hệ thống: Administrator";
                lblUserRole.BackColor = Color.DarkRed;
            }
            else if (position == 1)
            {
                lblUserRole.Text = "Học vụ: Sinh viên";
                lblUserRole.BackColor = Color.DarkGreen;
            }
            else if (position == 2)
            {
                lblUserRole.Text = "Cán bộ: Giảng viên / HR";
                lblUserRole.BackColor = Color.FromArgb(27, 79, 128);
            }

            btnDashboard.Visible = true;
            btnSinhVien.Visible = true;
            btnMonHoc.Visible = true;
            btnDiem.Visible = true;
            btnTaiKhoan.Visible = true;
            btnHR.Visible = true;
            btnDanhBa.Visible = true;
            btnBaoCao.Visible = true;
            btnCaiDat.Visible = true;
        }

        private bool HasPermission(params int[] allowedRoles)
        {
            int currentRole = Globals.GlobalUserRole;

            foreach (int role in allowedRoles)
            {
                if (currentRole == role)
                    return true;
            }

            MessageBox.Show(
                "Bạn không có quyền sử dụng chức năng này!",
                "Từ chối truy cập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private void OpenChildForm(Form childForm)
        {
            if (childForm == null)
                return;

            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            lblTitleMain.Text = childForm.Text;
            lblTitleSub.Text = "Hệ thống Quản lý Sinh viên -> " + childForm.Name;

            panelContent.Controls.Clear();
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;

            childForm.Show();
            childForm.BringToFront();
        }
    }
}
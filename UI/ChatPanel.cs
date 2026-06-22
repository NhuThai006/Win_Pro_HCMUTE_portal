using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLySinhVien.Services;

namespace QuanLySinhVien.UI
{
    public class ChatPanel : UserControl
    {
        private Panel _headerPanel;
        private Label _lblTitle;
        private Button _btnClose;
        private RichTextBox _rtbMessages;
        private Panel _inputPanel;
        private TextBox _txtInput;
        private Button _btnSend;
        private Label _lblStatus;
        
        private GeminiApiService _geminiService;
        public event EventHandler CloseClicked;

        public ChatPanel(string apiKey)
        {
            _geminiService = new GeminiApiService(apiKey);
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(350, 480);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            _headerPanel = new Panel { Height = 40, Dock = DockStyle.Top, BackColor = ColorTranslator.FromHtml("#003087") };
            _lblTitle = new Label { Text = "🎓 Hỗ trợ tư vấn HCMUTE", ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true, Location = new Point(10, 10) };
            _btnClose = new Button { Text = "X", ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(30, 30), Location = new Point(this.Width - 35, 5), Cursor = Cursors.Hand };
            _btnClose.FlatAppearance.BorderSize = 0;
            _btnClose.Click += (s, e) => CloseClicked?.Invoke(this, EventArgs.Empty);

            _headerPanel.Controls.Add(_lblTitle);
            _headerPanel.Controls.Add(_btnClose);

            _inputPanel = new Panel { Height = 50, Dock = DockStyle.Bottom, BackColor = Color.WhiteSmoke };
            _txtInput = new TextBox { Multiline = true, Size = new Size(270, 30), Location = new Point(10, 10), Font = new Font("Segoe UI", 9) };
            _txtInput.KeyDown += TxtInput_KeyDown;

            _btnSend = new Button { Text = "Gửi", Size = new Size(50, 30), Location = new Point(290, 10), BackColor = ColorTranslator.FromHtml("#003087"), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            _btnSend.Click += BtnSend_Click;

            _inputPanel.Controls.Add(_txtInput);
            _inputPanel.Controls.Add(_btnSend);

            _lblStatus = new Label { Text = "Đang trả lời...", Dock = DockStyle.Bottom, ForeColor = Color.Gray, Font = new Font("Segoe UI", 8, FontStyle.Italic), AutoSize = false, Height = 20, TextAlign = ContentAlignment.MiddleLeft, Visible = false };
            _rtbMessages = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, BackColor = Color.White, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 10), ScrollBars = RichTextBoxScrollBars.Vertical };

            this.Controls.Add(_rtbMessages);
            this.Controls.Add(_lblStatus);
            this.Controls.Add(_inputPanel);
            this.Controls.Add(_headerPanel);
            
            AppendMessage("Bot", "Xin chào! Mình là trợ lý ảo của trường Đại học Sư phạm Kỹ thuật TP.HCM (HCMUTE). Mình có thể giúp gì cho bạn?", ColorTranslator.FromHtml("#F5F5F5"), HorizontalAlignment.Left);
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                _btnSend.PerformClick();
            }
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string userMessage = _txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userMessage)) return;

            AppendMessage("Bạn", userMessage, ColorTranslator.FromHtml("#E3F2FD"), HorizontalAlignment.Right);
            _txtInput.Clear();

            _txtInput.Enabled = false;
            _btnSend.Enabled = false;
            _lblStatus.Visible = true;

            try
            {
                string botReply = await _geminiService.SendMessageAsync(userMessage);

                if (botReply.Contains("\"intent\": \"lookup_lecturer_info\"") || botReply.Contains("\"intent\":\"lookup_lecturer_info\""))
                {
                    try
                    {
                        string jsonStr = botReply;
                        if (botReply.Contains("```json"))
                        {
                            int startIndex = botReply.IndexOf("```json") + 7;
                            int endIndex = botReply.IndexOf("```", startIndex);
                            if (endIndex > startIndex)
                            {
                                jsonStr = botReply.Substring(startIndex, endIndex - startIndex).Trim();
                            }
                        }
                        else if (botReply.Contains("{") && botReply.Contains("}"))
                        {
                            int startIndex = botReply.IndexOf("{");
                            int endIndex = botReply.LastIndexOf("}");
                            if (endIndex > startIndex)
                            {
                                jsonStr = botReply.Substring(startIndex, endIndex - startIndex + 1).Trim();
                            }
                        }

                        var json = Newtonsoft.Json.Linq.JObject.Parse(jsonStr);
                        string messageToUser = json["message_to_user"]?.ToString();

                        this.Invoke((MethodInvoker)delegate { AppendMessage("Bot", messageToUser ?? "Đang tra cứu hệ thống...", ColorTranslator.FromHtml("#F5F5F5"), HorizontalAlignment.Left); });

                        var data = json["extracted_data"];
                        string lecturerName = data?["lecturer_name"]?.ToString();
                        string courseName = data?["course_name"]?.ToString();
                        string semester = data?["semester"]?.ToString();

                        string queryResult = "";
                        using (System.Data.SqlClient.SqlConnection conn = new My_DB().getConnection)
                        {
                            string sql = "SELECT DISTINCT lecturers.name, lecturers.email, lecturers.office, lecturers.schedule FROM lecturers ";
                            bool joinCourse = (!string.IsNullOrEmpty(courseName) && courseName != "[]") || (!string.IsNullOrEmpty(semester) && semester != "[]");
                            if (joinCourse)
                            {
                                sql += "JOIN course_lecturer ON lecturers.lecturer_id = course_lecturer.lecturer_id JOIN courses ON course_lecturer.course_id = courses.course_id ";
                            }

                            sql += "WHERE 1=1 ";

                            if (!string.IsNullOrEmpty(lecturerName) && lecturerName != "[]")
                                sql += "AND lecturers.name LIKE @name ";
                            if (!string.IsNullOrEmpty(courseName) && courseName != "[]")
                                sql += "AND courses.course_name LIKE @course ";
                            if (!string.IsNullOrEmpty(semester) && semester != "[]")
                                sql += "AND course_lecturer.semester LIKE @semester ";

                            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                            {
                                if (!string.IsNullOrEmpty(lecturerName) && lecturerName != "[]") cmd.Parameters.AddWithValue("@name", "%" + lecturerName + "%");
                                if (!string.IsNullOrEmpty(courseName) && courseName != "[]") cmd.Parameters.AddWithValue("@course", "%" + courseName + "%");
                                if (!string.IsNullOrEmpty(semester) && semester != "[]") cmd.Parameters.AddWithValue("@semester", "%" + semester + "%");

                                conn.Open();
                                using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    bool hasResult = false;
                                    while (reader.Read())
                                    {
                                        hasResult = true;
                                        queryResult += $"- Giảng viên: {reader["name"]}\n";
                                        try { if (reader["email"] != DBNull.Value) queryResult += $"  Email: {reader["email"]}\n"; } catch {}
                                        try { if (reader["office"] != DBNull.Value) queryResult += $"  Phòng: {reader["office"]}\n"; } catch {}
                                        try { if (reader["schedule"] != DBNull.Value) queryResult += $"  Lịch tiếp SV: {reader["schedule"]}\n"; } catch {}
                                        queryResult += "\n";
                                    }
                                    if (!hasResult) queryResult = "Không tìm thấy thông tin giảng viên phù hợp với yêu cầu của bạn.";
                                }
                            }
                        }

                        this.Invoke((MethodInvoker)delegate { AppendMessage("Bot", "Kết quả tra cứu:\n" + queryResult.Trim(), ColorTranslator.FromHtml("#F5F5F5"), HorizontalAlignment.Left); });
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate { AppendMessage("Hệ thống", "Lỗi tra cứu CSDL: " + ex.Message, Color.LightCoral, HorizontalAlignment.Left); });
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate { AppendMessage("Bot", botReply, ColorTranslator.FromHtml("#F5F5F5"), HorizontalAlignment.Left); });
                }
            }
            catch (Exception)
            {
                this.Invoke((MethodInvoker)delegate { AppendMessage("Hệ thống", "⚠️ Lỗi kết nối. Vui lòng thử lại.", Color.LightCoral, HorizontalAlignment.Center); });
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate { _txtInput.Enabled = true; _btnSend.Enabled = true; _lblStatus.Visible = false; _txtInput.Focus(); });
            }
        }

        private void AppendMessage(string sender, string message, Color bgColor, HorizontalAlignment alignment)
        {
            _rtbMessages.SelectionStart = _rtbMessages.TextLength;
            _rtbMessages.SelectionLength = 0;
            _rtbMessages.SelectionAlignment = alignment;
            _rtbMessages.SelectionBackColor = bgColor;
            _rtbMessages.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            _rtbMessages.AppendText($"[{sender}]\n");
            _rtbMessages.SelectionFont = new Font("Segoe UI", 9, FontStyle.Regular);
            _rtbMessages.AppendText($"{message}\n\n");
            _rtbMessages.SelectionBackColor = _rtbMessages.BackColor; 
            _rtbMessages.SelectionAlignment = HorizontalAlignment.Left;
            _rtbMessages.ScrollToCaret();
        }
    }
}

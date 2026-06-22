using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLySinhVien.UI
{
    public class ChatBubbleButton : UserControl
    {
        public event EventHandler BubbleClicked;

        public ChatBubbleButton()
        {
            this.Size = new Size(60, 60);
            this.Cursor = Cursors.Hand;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color mainColor = ColorTranslator.FromHtml("#003087");
            using (SolidBrush brush = new SolidBrush(mainColor))
            {
                g.FillEllipse(brush, 0, 0, this.Width - 1, this.Height - 1);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                using (Font font = new Font("Segoe UI", 24))
                {
                    g.DrawString("💬", font, Brushes.White, new Rectangle(0, 0, this.Width, this.Height), sf);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            BubbleClicked?.Invoke(this, e);
        }
    }
}

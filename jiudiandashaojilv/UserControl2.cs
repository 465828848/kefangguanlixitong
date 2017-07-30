using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace jiudiandashaojilv
{
    public partial class UserControl2 : UserControl
    {
        
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Paint(object sender, PaintEventArgs e)
        {
            //投影文字
            Graphics g = this.CreateGraphics();
            Font newFont = new Font("宋体", 12);
            SolidBrush colorBrush = new SolidBrush(Color.BlueViolet);
            Pen p = new Pen(Color.FromArgb(102,153,204), 2);
            //设置文本输出质量
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            //g.FillEllipse(myBrush, new Rectangle(10, 18, 4, 4));
            //g.FillEllipse(myBrush, new Rectangle(40, 18, 4, 4));
            g.DrawRectangle(p, 0, 0, 340, 40);
            p = new Pen(Color.Yellow, 3);
            g.DrawLine(p, new Point(20, 20), new Point(60, 20));
            g.DrawString("在店数量", newFont, colorBrush, new PointF(80, 12));
            p = new Pen(Color.WhiteSmoke, 3);
            g.DrawLine(p, new Point(170, 20), new Point(210, 20));
            g.DrawString("新入住数量", newFont, colorBrush, new PointF(230, 12));
        }
    }
}

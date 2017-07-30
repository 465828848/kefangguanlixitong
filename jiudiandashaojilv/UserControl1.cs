using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jiudiandashaojilv
{
    public partial class UserControl1 : UserControl
    {
        DrawComman cc=new DrawComman();
        Pen squarePen = new Pen(Color.Brown);
        Pen linePen = new Pen(Color.Yellow);
        SolidBrush sbrush = new SolidBrush(Color.Yellow);
        Pen coordinatesLinePen = new Pen(Color.Red);    //坐标线的pen
        Pen pointPen = new Pen(Color.Yellow); 

        public UserControl1()
        {
            InitializeComponent();
            cc.init_squareValue(30, 30, 34, 20);  //参数分别为：beginx,beginy,intervalx,intervaly
            cc.init_coordinatesValue("日", "度", 0, 1);   //参数分别为xunit, yunit,beginyvalue,everyYvalue
            cc.initPen(squarePen, linePen, sbrush, coordinatesLinePen, pointPen);
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            cc.DrawSquare(g); //画方格
            cc.DrawCoordinatesValues(g,1,1);  //画出坐标值
            cc.DrawCoordinateLine(g);   //画坐标轴
            cc.DrawTitle(g);  //画标题
            cc.linePen = new Pen(Color.Yellow);
            cc.DrawEveryPoint(g, MyComman.mylist, cc.linePen, true, 3);
            cc.DrawLinkPoint(g, MyComman.mylist, cc.linePen);
            cc.linePen = new Pen(Color.WhiteSmoke);
            cc.DrawEveryPoint(g, MyComman.mylist2, cc.linePen, true, 3);
            cc.DrawLinkPoint(g, MyComman.mylist2, cc.linePen);
        }

        private void UserControl1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height == 0 || this.Width == 0)
                return;
            cc.NumHorLine = (this.Height - cc.BeginY) / cc.IntervalY-1;   //调节x轴与下边缘距离，可以在这里增加或者减少numhorline
            cc.NumVerLine = (this.Width - cc.BeginX * 2) / cc.IntervalX;
            this.Refresh();
        }
     
    }
}

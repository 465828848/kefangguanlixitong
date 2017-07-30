using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace jiudiandashaojilv
{
    class DrawComman
    {
        #region 初始化各个参数变量
        public void init_squareValue(int beginx, int beginy, int intervalx, int intervaly)
        {
            this.beginX = beginx;
            this.beginY = beginy;
            this.intervalX = intervalx;
            this.intervalY = intervaly;
        }
        public void init_coordinatesValue(string xunit, string yunit, float beginyvalue, float everyYvalue)
        {
            this.xUnit = xunit;
            this.yUnit = yunit;
            this.beginYCoordinatesValues = beginyvalue;
            this.every_Yvalue = everyYvalue;
        }

        public void initPen(Pen squarepen, Pen linepen, SolidBrush covaluesolidbrush, Pen coLinepen, Pen pointpen)
        {
            //Pen分别为： 方格，折线，坐标值，坐标线，每一个点
            this.squarePen = squarepen;
            this.linePen = linepen;
            this.coordinatesValueBrush = covaluesolidbrush;
            this.coordinatesLinePen = coLinepen;
            this.pointPen = pointpen;
        }
        #endregion

        #region 方格有关设置

        int beginX, beginY;
        [Description("初始X坐标")]
        public int BeginX
        {
            get { return beginX; }
            set { beginX = value; }
        }

        [Description("初始Y坐标")]
        public int BeginY
        {
            get { return beginY; }
            set { beginY = value; }
        }

        Pen squarePen = new Pen(Color.Brown);

        Color squareColor = Color.Brown;
        [Description("方格线的颜色"), Category("方格设置"), Browsable(true)]
        public Color SquareColor
        {
            get { return squareColor; }
            set { squareColor = value; }
        }

        int intervalX = 30;
        [Description("每个小方格的宽度,即X坐标的单位长度"), Category("方格设置"), Browsable(true)]
        public int IntervalX
        {
            get { return intervalX; }
            set { intervalX = value; }
        }


        int intervalY = 19;
        [Description("每个小方格的高度,即Y坐标的单位长度"), Category("方格设置"), Browsable(true)]
        public int IntervalY
        {
            get { return intervalY; }
            set { intervalY = value; }
        }


        int numVerLine;
        [Description("竖线的个数"), Category("方格设置"), Browsable(false)]
        public int NumVerLine
        {
            get { return numVerLine; }
            set { numVerLine = value; }
        }
        int numHorLine;
        [Description("横线的个数"), Category("方格设置"), Browsable(false)]
        public int NumHorLine
        {
            get { return numHorLine; }
            set { numHorLine = value; }
        }

        #endregion

        #region 坐标轴设置
        string xName = "X";
        [Description("X轴名字"), Category("坐标轴设置"), Browsable(true)]
        public string XName
        {
            get { return xName; }
            set { xName = value; }
        }
        string xUnit = "";
        [Description("X轴单位"), Category("坐标轴设置"), Browsable(true)]
        public string XUnit
        {
            get { return xUnit; }
            set { xUnit = value; }
        }
        string yName = "Y";
        [Description("X轴名字"), Category("坐标轴设置"), Browsable(true)]
        public string YName
        {
            get { return yName; }
            set { yName = value; }
        }
        string yUnit = "";
        [Description("Y轴单位"), Category("坐标轴设置"), Browsable(true)]
        public string YUnit
        {
            get { return yUnit; }
            set { yUnit = value; }
        }

        double beginXCoordinatesValues = 1;
        [Description("X坐标起始值"), Category("坐标轴设置"), Browsable(true)]
        public double BeginXCoordinatesValues
        {
            get { return beginXCoordinatesValues; }
            set { beginXCoordinatesValues = value; }
        }
        float beginYCoordinatesValues = 20;
        [Description("Y坐标起始值"), Category("坐标轴设置"), Browsable(true)]
        public float BeginYCoordinatesValues
        {
            get { return beginYCoordinatesValues; }
            set { beginYCoordinatesValues = value; }
        }

        int every_Xvalue = 1;
        [Description("一个X的坐标的值"), Category("坐标轴设置"), Browsable(true)]
        public int Every_Xvalue
        {
            get { return every_Xvalue; }
            set { every_Xvalue = value; }
        }
        float every_Yvalue = 0.02f;
        [Description("一个Y的坐标的值"), Category("坐标轴设置"), Browsable(true)]
        public float Every_Yvalue
        {
            get { return every_Yvalue; }
            set { every_Yvalue = value; }
        }

        Pen coordinatesLinePen = new Pen(Color.Red);
        [Description("坐标轴线pen"), Category("坐标轴设置"), Browsable(true)]

        SolidBrush coordinatesValueBrush = new SolidBrush(Color.Red);
        [Description("坐标轴值Brush"), Category("坐标轴设置"), Browsable(true)]

        #endregion

        #region 折线及每一个点设置

        public Pen pointPen = new Pen(Color.Black);
        Color pointColor = Color.Black;
        [Description("折线上点的颜色"), Category("折线设置"), Browsable(true)]
        public Color PointColor
        {
            get { return pointColor; }
            set { pointColor = value; pointPen.Color = pointColor; }
        }

        public Pen linePen = new Pen(Color.Yellow);
        Color lineColor = Color.Yellow;
        [Description("折线的颜色"), Category("折线设置"), Browsable(true)]
        public Color LineColor
        {

            get { return lineColor; }
            set { lineColor = value; linePen.Color = lineColor; }
        }
        #endregion

        #region 标题设置
        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        Font titleFont = new Font("黑体", 12);
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; }
        }
        #endregion

        #region 画坐标线
        public void DrawCoordinateLine(Graphics g)
        {
            coordinatesLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//恢复实线  
            coordinatesLinePen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;//定义线尾的样式为箭头  
            g.DrawLine(coordinatesLinePen, beginX, beginY + intervalY * numHorLine, beginX, beginY - intervalY);//画纵坐标
            g.DrawLine(coordinatesLinePen, beginX, beginY + intervalY * numHorLine, beginX + intervalX * numVerLine + 20, beginY + intervalY * numHorLine);
        }
        #endregion

        #region 画方格函数
        public void DrawSquare(Graphics g)
        {
            //画横向线
            for (int i = 0; i <= numHorLine; i++)
                g.DrawLine(squarePen, new Point(beginX, beginY + i * intervalY), new Point(beginX + numVerLine * intervalX, beginY + i * intervalY));
            //画竖线
            for (int i = 0; i <= numVerLine; i++)
                g.DrawLine(squarePen, new Point(beginX + i * intervalX, beginY), new Point(beginX + i * intervalX, beginY + numHorLine * intervalY));
        }
        #endregion

        #region 画出坐标值
        public void DrawCoordinatesValues(Graphics g, int interval_xv, int interval_yv)  //每隔interval_xv格横坐标值显示，每隔interval_yv纵坐标显示
        {
            StringFormat drawFormat = new StringFormat();
            int font_size;
            string showvlue = "";
            //画横坐标值
            font_size = 8;
            drawFormat.Alignment = StringAlignment.Center;//水平对齐方式
            drawFormat.LineAlignment = StringAlignment.Near;//垂直对齐方 
            double xv = 0;
            for (int i = 0; i <=numVerLine; i++)
            {
                if (i % interval_xv == 0)
                {
                    showvlue = xv + beginXCoordinatesValues + " ";
                    g.DrawString(showvlue, new Font("宋体", font_size), coordinatesValueBrush, new PointF(beginX + (i) * intervalX, beginY + numHorLine * intervalY), drawFormat);
                }
                xv += every_Xvalue;
            }
           
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Far;
            g.DrawString(xName + "/" + "日", new Font("宋体", font_size), coordinatesValueBrush, new PointF(beginX + numVerLine * intervalX + 10, beginY + numHorLine * intervalY), drawFormat);
            //画纵坐标
            drawFormat.Alignment = StringAlignment.Far;
            drawFormat.LineAlignment = StringAlignment.Center;
            double yv = 0;
            for (float j = 0; j <= numHorLine; j++)
            {
                if (j % interval_yv == 0)
                {
                    showvlue = yv + beginYCoordinatesValues + "";
                    g.DrawString(showvlue, new Font("宋体", font_size), coordinatesValueBrush, new PointF(beginX, beginY + (numHorLine - j) * intervalY), drawFormat);
                }
                yv += every_Yvalue;
            }
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(yName + "/" + "间", new Font("宋体", font_size), coordinatesValueBrush, new PointF(beginX, beginY - 1 * intervalY), drawFormat);
        }
        #endregion

        #region 画标题
        public void DrawTitle(Graphics g)
        {
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;//水平对齐方式
            drawFormat.LineAlignment = StringAlignment.Center;//垂直对齐方式
            g.DrawString(title, titleFont, new SolidBrush(Color.Black), new PointF(beginX + numVerLine * intervalX / 2, beginY - intervalY), drawFormat);
        }
        #endregion

        #region 画每一个点
        public void DrawCircle(Graphics g, float fx, float fy, int r, Pen pointPen, bool full = false)
        {
            if (full == false)
                g.DrawEllipse(pointPen, fx - r, fy - r, 2 * r, 2 * r);
            else
            {
                SolidBrush pBrush = new SolidBrush(pointPen.Color);
                g.FillEllipse(pBrush, fx - r, fy - r, 2 * r, 2 * r);
            }
        }
        public void DrawEveryPoint(Graphics g, List<float> list_point, Pen pointPen, bool full = false, int pointR = 2)
        {
            float x, y;
            Point p;
            if (list_point.Count <= numVerLine && list_point.Count > 0)
            {
                for (int i = 0; i < list_point.Count; i++)
                {
                    p = new Point();
                    x = beginX + i * intervalX;
                    y = beginY + (numHorLine - (list_point[i] - beginYCoordinatesValues) / every_Yvalue) * intervalY;
                    p.X = Convert.ToInt32(x);
                    p.Y = Convert.ToInt32(y);
                    DrawCircle(g, x, y, pointR, pointPen, full);
                }
            }
            else if (list_point.Count > numVerLine)
            {
                int temp = list_point.Count - numVerLine - 1;
                for (int i = 0; i <= numVerLine; i++)
                {
                    p = new Point();
                    x = beginX + i * intervalX;
                    y = beginY + (numHorLine - (list_point[i + temp] - beginYCoordinatesValues) / every_Yvalue) * intervalY + (list_point[i] - Convert.ToInt32(list_point[i]));
                    p.X = Convert.ToInt32(x);
                    p.Y = Convert.ToInt32(y);
                    DrawCircle(g, x, y, pointR, pointPen, full);
                }
            }
        }
        #endregion

        #region 画折线
        public void DrawLinkPoint(Graphics g, List<float> list_point, Pen linePen)
        {
            if (list_point.Count > 1 && list_point.Count <= numVerLine)
            {
                for (int i = 0; i + 1 < list_point.Count; i++)
                {
                    g.DrawLine(linePen, beginX + i * intervalX, beginY + (numHorLine - (list_point[i] - beginYCoordinatesValues) / every_Yvalue) * intervalY,
                        beginX + (i + 1) * intervalX, beginY + (numHorLine - (list_point[i + 1] - beginYCoordinatesValues) / every_Yvalue) * intervalY);
                }
            }
            else if (list_point.Count > numVerLine)
            {
                int temp = list_point.Count - numVerLine - 1;
                for (int i = 0; i < numVerLine; i++)
                {
                    g.DrawLine(linePen, beginX + i * intervalX, beginY + (numHorLine - (list_point[i + temp] - beginYCoordinatesValues) / every_Yvalue) * intervalY, beginX + (i + 1) * intervalX, beginY + (numHorLine - (list_point[i + 1 + temp] - beginYCoordinatesValues) / every_Yvalue) * intervalY);
                }
            }
        }
        #endregion
    }
}

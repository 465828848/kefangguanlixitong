using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace jiudiandashaojilv
{
    public partial class First : Form
    {
        public static bool jihuo = true;
        static bool qjbc = true;
        string year = "2017年";
        string mon = "1月";
        string day = "上旬";
        int combox1=0,combox2=0,combox3=0;
        string[] datatext = new string[12];
        int tianshu = 0;//0为初始，1为31天，2为30天，3为29天，4为28天 
        public First()
        {
            InitializeComponent();
            //comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            string[] items = {"2017年", "2016年", "2015年", "2018年", };
            comboBox1.Items.AddRange(items);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // 将comboBox1中的项目居中显示！
        /*private void comboBox1_DrawItem(object sender,DrawItemEventArgs e)
        {
            string s = this.comboBox1.Items[e.Index].ToString();
            // 计算字符串尺寸（以像素为单位）
            SizeF ss = e.Graphics.MeasureString(s, e.Font);
            // 水平居中
            float left = (float)(e.Bounds.Width - ss.Width) / 2;
            if (left < 0) left = 0f;
            float top = (float)(e.Bounds.Height - ss.Height) / 2;
            // 垂直居中
            if (top < 0) top = 0f;
            top = top + this.comboBox1.ItemHeight * e.Index;
            // 输出
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(s,e.Font,new SolidBrush(e.ForeColor),left, top);
        }*/

        private void comboxup()
        {
            if (comboBox1.SelectedIndex >= 0)
                combox1 = comboBox1.SelectedIndex;
            if (comboBox2.SelectedIndex >= 0)
                combox2 = comboBox2.SelectedIndex;
            if (comboBox3.SelectedIndex >= 0)
                combox3 = comboBox3.SelectedIndex;
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "update combox set year = " + combox1 + "\nupdate combox set mon = " + combox2 + "\nupdate combox set day = " + combox3 + "\n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag >= 1)
            {
                //成功
                //MessageBox.Show(""+combox1+","+combox2+","+combox3);
            }
            else
            {
                MessageBox.Show("combox保存出现错误，请联系管理员");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = comboBox1.SelectedItem.ToString();
            comboxup();
            btn_duqushuju_Click(sender, e);
        }
        private void updateData()
        {
            int linshimon = int.Parse(mon.Replace("月", ""));
            int linshiyear = int.Parse(year.Replace("年", ""));
            if (linshimon == 1 || linshimon == 3 || linshimon == 5 || linshimon == 7 || linshimon == 8 || linshimon == 10 || linshimon == 12)
            {
                tianshu = 1;
            }
            else if (linshimon == 4 || linshimon == 6 || linshimon == 9 || linshimon == 11)
            {
                tianshu = 2;
            }
            else if (linshimon == 2)
            {
                if ((linshiyear / 4 == 0 && linshiyear / 100 != 0) || linshiyear / 400 == 0)
                {
                    tianshu = 3;
                }
                else
                {
                    tianshu = 4;
                }
            }
            else
            {
                MessageBox.Show("出现出错，请联系管理员！错误代码：天数系数=" + tianshu);
            }
            if ("上旬".Equals(day))
            {
                this.Height = 505;
                label1.Text = year + mon + "1日:";
                label2.Text = year + mon + "2日:";
                label3.Text = year + mon + "3日:";
                label4.Text = year + mon + "4日:";
                label5.Text = year + mon + "5日:";
                label6.Text = year + mon + "6日:";
                label7.Text = year + mon + "7日:";
                label8.Text = year + mon + "8日:";
                label9.Text = year + mon + "9日:";
                label10.Text = year + mon + "10日:";
                label11.Text = "不可用";
                this.Height = 505;
                this.label9.Visible = true;
                this.zaidianshuliang9.Visible = true;
                this.xinruzhushuliang9.Visible = true;
                this.zhongdianfangshuliang9.Visible = true;
                this.heji9.Visible = true;
                this.ruzhulu9.Visible = true;
                this.dashaoshuliang9.Visible = true;
                this.zaidiandashaoshuliang9.Visible = true;
                this.dangrizhongjine9.Visible = true;
                this.btn_bc9.Visible = true;

                this.label10.Visible = true;
                this.zaidianshuliang10.Visible = true;
                this.xinruzhushuliang10.Visible = true;
                this.zhongdianfangshuliang10.Visible = true;
                this.heji10.Visible = true;
                this.ruzhulu10.Visible = true;
                this.dashaoshuliang10.Visible = true;
                this.zaidiandashaoshuliang10.Visible = true;
                this.dangrizhongjine10.Visible = true;
                this.btn_bc10.Visible = true;

                this.label11.Visible = false;
                this.zaidianshuliang11.Visible = false;
                this.xinruzhushuliang11.Visible = false;
                this.zhongdianfangshuliang11.Visible = false;
                this.heji11.Visible = false;
                this.ruzhulu11.Visible = false;
                this.dashaoshuliang11.Visible = false;
                this.zaidiandashaoshuliang11.Visible = false;
                this.dangrizhongjine11.Visible = false;
                this.btn_bc11.Visible = false;
            }
            if ("中旬".Equals(day))
            {
                this.Height = 505;
                label1.Text = year + mon + "11日:";
                label2.Text = year + mon + "12日:";
                label3.Text = year + mon + "13日:";
                label4.Text = year + mon + "14日:";
                label5.Text = year + mon + "15日:";
                label6.Text = year + mon + "16日:";
                label7.Text = year + mon + "17日:";
                label8.Text = year + mon + "18日:";
                label9.Text = year + mon + "19日:";
                label10.Text = year + mon + "20日:";
                label11.Text = "不可用";
                this.Height = 505;
                this.label9.Visible = true;
                this.zaidianshuliang9.Visible = true;
                this.xinruzhushuliang9.Visible = true;
                this.zhongdianfangshuliang9.Visible = true;
                this.heji9.Visible = true;
                this.ruzhulu9.Visible = true;
                this.dashaoshuliang9.Visible = true;
                this.zaidiandashaoshuliang9.Visible = true;
                this.dangrizhongjine9.Visible = true;
                this.btn_bc9.Visible = true;

                this.label10.Visible = true;
                this.zaidianshuliang10.Visible = true;
                this.xinruzhushuliang10.Visible = true;
                this.zhongdianfangshuliang10.Visible = true;
                this.heji10.Visible = true;
                this.ruzhulu10.Visible = true;
                this.dashaoshuliang10.Visible = true;
                this.zaidiandashaoshuliang10.Visible = true;
                this.dangrizhongjine10.Visible = true;
                this.btn_bc10.Visible = true;

                this.label11.Visible = false;
                this.zaidianshuliang11.Visible = false;
                this.xinruzhushuliang11.Visible = false;
                this.zhongdianfangshuliang11.Visible = false;
                this.heji11.Visible = false;
                this.ruzhulu11.Visible = false;
                this.dashaoshuliang11.Visible = false;
                this.zaidiandashaoshuliang11.Visible = false;
                this.dangrizhongjine11.Visible = false;
                this.btn_bc11.Visible = false;
            }
            if ("下旬".Equals(day))
            {
                label1.Text = year + mon + "21日:";
                label2.Text = year + mon + "22日:";
                label3.Text = year + mon + "23日:";
                label4.Text = year + mon + "24日:";
                label5.Text = year + mon + "25日:";
                label6.Text = year + mon + "26日:";
                label7.Text = year + mon + "27日:";
                label8.Text = year + mon + "28日:";
                if (tianshu == 1)
                {
                    label9.Text = year + mon + "29日:";
                    label10.Text = year + mon + "30日:";
                    label11.Text = year + mon + "31日:";
                    this.Height = 550;
                    this.label9.Visible = true;
                    this.zaidianshuliang9.Visible = true;
                    this.xinruzhushuliang9.Visible = true;
                    this.zhongdianfangshuliang9.Visible = true;
                    this.heji9.Visible = true;
                    this.ruzhulu9.Visible = true;
                    this.dashaoshuliang9.Visible = true;
                    this.zaidiandashaoshuliang9.Visible = true;
                    this.dangrizhongjine9.Visible = true;
                    this.btn_bc9.Visible = true;

                    this.label10.Visible = true;
                    this.zaidianshuliang10.Visible = true;
                    this.xinruzhushuliang10.Visible = true;
                    this.zhongdianfangshuliang10.Visible = true;
                    this.heji10.Visible = true;
                    this.ruzhulu10.Visible = true;
                    this.dashaoshuliang10.Visible = true;
                    this.zaidiandashaoshuliang10.Visible = true;
                    this.dangrizhongjine10.Visible = true;
                    this.btn_bc10.Visible = true;

                    this.label11.Visible = true;
                    this.zaidianshuliang11.Visible = true;
                    this.xinruzhushuliang11.Visible = true;
                    this.zhongdianfangshuliang11.Visible = true;
                    this.heji11.Visible = true;
                    this.ruzhulu11.Visible = true;
                    this.dashaoshuliang11.Visible = true;
                    this.zaidiandashaoshuliang11.Visible = true;
                    this.dangrizhongjine11.Visible = true;
                    this.btn_bc11.Visible = true;
                }
                if (tianshu == 2)
                {
                    label9.Text = year + mon + "29日:";
                    label10.Text = year + mon + "30日:";
                    label11.Text = "不可用";
                    this.Height = 505;
                    this.label9.Visible = true;
                    this.zaidianshuliang9.Visible = true;
                    this.xinruzhushuliang9.Visible = true;
                    this.zhongdianfangshuliang9.Visible = true;
                    this.heji9.Visible = true;
                    this.ruzhulu9.Visible = true;
                    this.dashaoshuliang9.Visible = true;
                    this.zaidiandashaoshuliang9.Visible = true;
                    this.dangrizhongjine9.Visible = true;
                    this.btn_bc9.Visible = true;

                    this.label10.Visible = true;
                    this.zaidianshuliang10.Visible = true;
                    this.xinruzhushuliang10.Visible = true;
                    this.zhongdianfangshuliang10.Visible = true;
                    this.heji10.Visible = true;
                    this.ruzhulu10.Visible = true;
                    this.dashaoshuliang10.Visible = true;
                    this.zaidiandashaoshuliang10.Visible = true;
                    this.dangrizhongjine10.Visible = true;
                    this.btn_bc10.Visible = true;

                    this.label11.Visible = false;
                    this.zaidianshuliang11.Visible = false;
                    this.xinruzhushuliang11.Visible = false;
                    this.zhongdianfangshuliang11.Visible = false;
                    this.heji11.Visible = false;
                    this.ruzhulu11.Visible = false;
                    this.dashaoshuliang11.Visible = false;
                    this.zaidiandashaoshuliang11.Visible = false;
                    this.dangrizhongjine11.Visible = false;
                    this.btn_bc11.Visible = false;
                }
                else if (tianshu == 3)
                {
                    label9.Text = year + mon + "29日:";
                    label10.Text = "不可用";
                    label11.Text = "不可用";
                    this.Height = 475;
                    this.label9.Visible = true;
                    this.zaidianshuliang9.Visible = true;
                    this.xinruzhushuliang9.Visible = true;
                    this.zhongdianfangshuliang9.Visible = true;
                    this.heji9.Visible = true;
                    this.ruzhulu9.Visible = true;
                    this.dashaoshuliang9.Visible = true;
                    this.zaidiandashaoshuliang9.Visible = true;
                    this.dangrizhongjine9.Visible = true;
                    this.btn_bc9.Visible = true;

                    this.label10.Visible = false;
                    this.zaidianshuliang10.Visible = false;
                    this.xinruzhushuliang10.Visible = false;
                    this.zhongdianfangshuliang10.Visible = false;
                    this.heji10.Visible = false;
                    this.ruzhulu10.Visible = false;
                    this.dashaoshuliang10.Visible = false;
                    this.zaidiandashaoshuliang10.Visible = false;
                    this.dangrizhongjine10.Visible = false;
                    this.btn_bc10.Visible = false;

                    this.label11.Visible = false;
                    this.zaidianshuliang11.Visible = false;
                    this.xinruzhushuliang11.Visible = false;
                    this.zhongdianfangshuliang11.Visible = false;
                    this.heji11.Visible = false;
                    this.ruzhulu11.Visible = false;
                    this.dashaoshuliang11.Visible = false;
                    this.zaidiandashaoshuliang11.Visible = false;
                    this.dangrizhongjine11.Visible = false;
                    this.btn_bc11.Visible = false;
                }
                else if (tianshu == 4)
                {
                    label9.Text = "不可用";
                    label10.Text = "不可用";
                    label11.Text = "不可用";
                    this.Height = 435;
                    this.label9.Visible = false;
                    this.zaidianshuliang9.Visible = false;
                    this.xinruzhushuliang9.Visible = false;
                    this.zhongdianfangshuliang9.Visible = false;
                    this.heji9.Visible = false;
                    this.ruzhulu9.Visible = false;
                    this.dashaoshuliang9.Visible = false;
                    this.zaidiandashaoshuliang9.Visible = false;
                    this.dangrizhongjine9.Visible = false;
                    this.btn_bc9.Visible = false;

                    this.label10.Visible = false;
                    this.zaidianshuliang10.Visible = false;
                    this.xinruzhushuliang10.Visible = false;
                    this.zhongdianfangshuliang10.Visible = false;
                    this.heji10.Visible = false;
                    this.ruzhulu10.Visible = false;
                    this.dashaoshuliang10.Visible = false;
                    this.zaidiandashaoshuliang10.Visible = false;
                    this.dangrizhongjine10.Visible = false;
                    this.btn_bc10.Visible = false;

                    this.label11.Visible = false;
                    this.zaidianshuliang11.Visible = false;
                    this.xinruzhushuliang11.Visible = false;
                    this.zhongdianfangshuliang11.Visible = false;
                    this.heji11.Visible = false;
                    this.ruzhulu11.Visible = false;
                    this.dashaoshuliang11.Visible = false;
                    this.zaidiandashaoshuliang11.Visible = false;
                    this.dangrizhongjine11.Visible = false;
                    this.btn_bc11.Visible = false;
                }
            }
            this.Location = new Point(
                (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
                );
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mon = comboBox2.SelectedItem.ToString();
            comboxup();
            btn_duqushuju_Click(sender, e);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            day = comboBox3.SelectedItem.ToString();
            comboxup();
            btn_duqushuju_Click(sender, e);
        }
        //不允许textbox输入非数字
        private void zaidianshuliang1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }  
        }
        //读取数据按钮
        private void btn_duqushuju_Click(object sender, EventArgs e)
        {

            updateData();//更新记录日期列表
            read();//读取时间数据
            Getshuju0();
            Getshuju1();
            Getshuju2();
            Getshuju3();
            Getshuju4();
            Getshuju5();
            Getshuju6();
            Getshuju7();
            Getshuju8();
            Getshuju9();
            Getshuju10();
        }
        //读取数据
        private void read()
        {
            datatext[0] = label1.Text.ToString();
            datatext[1] = label2.Text.ToString();
            datatext[2] = label3.Text.ToString();
            datatext[3] = label4.Text.ToString();
            datatext[4] = label5.Text.ToString();
            datatext[5] = label6.Text.ToString();
            datatext[6] = label7.Text.ToString();
            datatext[7] = label8.Text.ToString();
            datatext[8] = label9.Text.ToString();
            datatext[9] = label10.Text.ToString();
            datatext[10] = label11.Text.ToString();
            for (int i = 0; i <= 10; i++) 
            {
                if (datatext[i].Equals("不可用")) 
                {
                    continue;
                }
                datatext[i] = datatext[i].Replace("年", "-");
                datatext[i] = datatext[i].Replace("月", "-");
                datatext[i] = datatext[i].Substring(0, datatext[i].Length - 2);
            }
                       
        }
        private void Getshuju0()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[0] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang1.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang1.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang1.Text = dr["zdfsl"].ToString();
                this.heji1.Text = ((int.Parse(zaidianshuliang1.Text)) + (int.Parse(xinruzhushuliang1.Text)) + (int.Parse(zhongdianfangshuliang1.Text))).ToString();
                this.ruzhulu1.Text = (Math.Round((double.Parse(heji1.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang1.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang1.Text = dr["zddssl"].ToString();
                this.dangrizhongjine1.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang1.Clear();
                this.xinruzhushuliang1.Clear();
                this.zhongdianfangshuliang1.Clear();
                this.heji1.Clear();
                this.ruzhulu1.Clear();
                this.dashaoshuliang1.Clear();
                this.zaidiandashaoshuliang1.Clear();
                this.dangrizhongjine1.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju1()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[1] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang2.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang2.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang2.Text = dr["zdfsl"].ToString();
                this.heji2.Text = ((int.Parse(zaidianshuliang2.Text)) + (int.Parse(xinruzhushuliang2.Text)) + (int.Parse(zhongdianfangshuliang2.Text))).ToString();
                this.ruzhulu2.Text = (Math.Round((double.Parse(heji2.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang2.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang2.Text = dr["zddssl"].ToString();
                this.dangrizhongjine2.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang2.Clear();
                this.xinruzhushuliang2.Clear();
                this.zhongdianfangshuliang2.Clear();
                this.heji2.Clear();
                this.ruzhulu2.Clear();
                this.dashaoshuliang2.Clear();
                this.zaidiandashaoshuliang2.Clear();
                this.dangrizhongjine2.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju2()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[2] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang3.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang3.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang3.Text = dr["zdfsl"].ToString();
                this.heji3.Text = ((int.Parse(zaidianshuliang3.Text)) + (int.Parse(xinruzhushuliang3.Text)) + (int.Parse(zhongdianfangshuliang3.Text))).ToString();
                this.ruzhulu3.Text = (Math.Round((double.Parse(heji3.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang3.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang3.Text = dr["zddssl"].ToString();
                this.dangrizhongjine3.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang3.Clear();
                this.xinruzhushuliang3.Clear();
                this.zhongdianfangshuliang3.Clear();
                this.heji3.Clear();
                this.ruzhulu3.Clear();
                this.dashaoshuliang3.Clear();
                this.zaidiandashaoshuliang3.Clear();
                this.dangrizhongjine3.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju3()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[3] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang4.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang4.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang4.Text = dr["zdfsl"].ToString();
                this.heji4.Text = ((int.Parse(zaidianshuliang4.Text)) + (int.Parse(xinruzhushuliang4.Text)) + (int.Parse(zhongdianfangshuliang4.Text))).ToString();
                this.ruzhulu4.Text = (Math.Round((double.Parse(heji4.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang4.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang4.Text = dr["zddssl"].ToString();
                this.dangrizhongjine4.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang4.Clear();
                this.xinruzhushuliang4.Clear();
                this.zhongdianfangshuliang4.Clear();
                this.heji4.Clear();
                this.ruzhulu4.Clear();
                this.dashaoshuliang4.Clear();
                this.zaidiandashaoshuliang4.Clear();
                this.dangrizhongjine4.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju4()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[4] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang5.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang5.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang5.Text = dr["zdfsl"].ToString();
                this.heji5.Text = ((int.Parse(zaidianshuliang5.Text)) + (int.Parse(xinruzhushuliang5.Text)) + (int.Parse(zhongdianfangshuliang5.Text))).ToString();
                this.ruzhulu5.Text = (Math.Round((double.Parse(heji5.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang5.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang5.Text = dr["zddssl"].ToString();
                this.dangrizhongjine5.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang5.Clear();
                this.xinruzhushuliang5.Clear();
                this.zhongdianfangshuliang5.Clear();
                this.heji5.Clear();
                this.ruzhulu5.Clear();
                this.dashaoshuliang5.Clear();
                this.zaidiandashaoshuliang5.Clear();
                this.dangrizhongjine5.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju5()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[5] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang6.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang6.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang6.Text = dr["zdfsl"].ToString();
                this.heji6.Text = ((int.Parse(zaidianshuliang6.Text)) + (int.Parse(xinruzhushuliang6.Text)) + (int.Parse(zhongdianfangshuliang6.Text))).ToString();
                this.ruzhulu6.Text = (Math.Round((double.Parse(heji6.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang6.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang6.Text = dr["zddssl"].ToString();
                this.dangrizhongjine6.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang6.Clear();
                this.xinruzhushuliang6.Clear();
                this.zhongdianfangshuliang6.Clear();
                this.heji6.Clear();
                this.ruzhulu6.Clear();
                this.dashaoshuliang6.Clear();
                this.zaidiandashaoshuliang6.Clear();
                this.dangrizhongjine6.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju6()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[6] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang7.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang7.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang7.Text = dr["zdfsl"].ToString();
                this.heji7.Text = ((int.Parse(zaidianshuliang7.Text)) + (int.Parse(xinruzhushuliang7.Text)) + (int.Parse(zhongdianfangshuliang7.Text))).ToString();
                this.ruzhulu7.Text = (Math.Round((double.Parse(heji7.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang7.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang7.Text = dr["zddssl"].ToString();
                this.dangrizhongjine7.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang7.Clear();
                this.xinruzhushuliang7.Clear();
                this.zhongdianfangshuliang7.Clear();
                this.heji7.Clear();
                this.ruzhulu7.Clear();
                this.dashaoshuliang7.Clear();
                this.zaidiandashaoshuliang7.Clear();
                this.dangrizhongjine7.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju7()
        {
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[7] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang8.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang8.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang8.Text = dr["zdfsl"].ToString();
                this.heji8.Text = ((int.Parse(zaidianshuliang8.Text)) + (int.Parse(xinruzhushuliang8.Text)) + (int.Parse(zhongdianfangshuliang8.Text))).ToString();
                this.ruzhulu8.Text = (Math.Round((double.Parse(heji8.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang8.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang8.Text = dr["zddssl"].ToString();
                this.dangrizhongjine8.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang8.Clear();
                this.xinruzhushuliang8.Clear();
                this.zhongdianfangshuliang8.Clear();
                this.heji8.Clear();
                this.ruzhulu8.Clear();
                this.dashaoshuliang8.Clear();
                this.zaidiandashaoshuliang8.Clear();
                this.dangrizhongjine8.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju8()
        {
            if (label9.Text.Equals("不可用"))
            {
                this.zaidianshuliang9.Clear();
                this.xinruzhushuliang9.Clear();
                this.zhongdianfangshuliang9.Clear();
                this.heji9.Clear();
                this.ruzhulu9.Clear();
                this.dashaoshuliang9.Clear();
                this.zaidiandashaoshuliang9.Clear();
                this.dangrizhongjine9.Clear();
                return;
            }
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[8] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang9.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang9.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang9.Text = dr["zdfsl"].ToString();
                this.heji9.Text = ((int.Parse(zaidianshuliang9.Text)) + (int.Parse(xinruzhushuliang9.Text)) + (int.Parse(zhongdianfangshuliang9.Text))).ToString();
                this.ruzhulu9.Text = (Math.Round((double.Parse(heji9.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang9.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang9.Text = dr["zddssl"].ToString();
                this.dangrizhongjine9.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang9.Clear();
                this.xinruzhushuliang9.Clear();
                this.zhongdianfangshuliang9.Clear();
                this.heji9.Clear();
                this.ruzhulu9.Clear();
                this.dashaoshuliang9.Clear();
                this.zaidiandashaoshuliang9.Clear();
                this.dangrizhongjine9.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju9()
        {
            if (label10.Text.Equals("不可用"))
            {
                this.zaidianshuliang10.Clear();
                this.xinruzhushuliang10.Clear();
                this.zhongdianfangshuliang10.Clear();
                this.heji10.Clear();
                this.ruzhulu10.Clear();
                this.dashaoshuliang10.Clear();
                this.zaidiandashaoshuliang10.Clear();
                this.dangrizhongjine10.Clear();
                return;
            }
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[9] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang10.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang10.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang10.Text = dr["zdfsl"].ToString();
                this.heji10.Text = ((int.Parse(zaidianshuliang10.Text)) + (int.Parse(xinruzhushuliang10.Text)) + (int.Parse(zhongdianfangshuliang10.Text))).ToString();
                this.ruzhulu10.Text = (Math.Round((double.Parse(heji10.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang10.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang10.Text = dr["zddssl"].ToString();
                this.dangrizhongjine10.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang10.Clear();
                this.xinruzhushuliang10.Clear();
                this.zhongdianfangshuliang10.Clear();
                this.heji10.Clear();
                this.ruzhulu10.Clear();
                this.dashaoshuliang10.Clear();
                this.zaidiandashaoshuliang10.Clear();
                this.dangrizhongjine10.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void Getshuju10()
        {
            if (label11.Text.Equals("不可用"))
            {
                this.zaidianshuliang11.Clear();
                this.xinruzhushuliang11.Clear();
                this.zhongdianfangshuliang11.Clear();
                this.heji11.Clear();
                this.ruzhulu11.Clear();
                this.dashaoshuliang11.Clear();
                this.zaidiandashaoshuliang11.Clear();
                this.dangrizhongjine11.Clear();
                return;
            }
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "select * from dashaojilu where jlrq = '" + datatext[10] + "' ; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.zaidianshuliang11.Text = dr["zdsl"].ToString();
                this.xinruzhushuliang11.Text = dr["xrzsl"].ToString();
                this.zhongdianfangshuliang11.Text = dr["zdfsl"].ToString();
                this.heji11.Text = ((int.Parse(zaidianshuliang11.Text)) + (int.Parse(xinruzhushuliang11.Text)) + (int.Parse(zhongdianfangshuliang11.Text))).ToString();
                this.ruzhulu11.Text = (Math.Round((double.Parse(heji11.Text) / 0.26), 2)).ToString() + "%";
                this.dashaoshuliang11.Text = dr["dssl"].ToString();
                this.zaidiandashaoshuliang11.Text = dr["zddssl"].ToString();
                this.dangrizhongjine11.Text = dr["drzje"].ToString();
            }
            else
            {
                this.zaidianshuliang11.Clear();
                this.xinruzhushuliang11.Clear();
                this.zhongdianfangshuliang11.Clear();
                this.heji11.Clear();
                this.ruzhulu11.Clear();
                this.dashaoshuliang11.Clear();
                this.zaidiandashaoshuliang11.Clear();
                this.dangrizhongjine11.Clear();
            }
            dr.Close();
            conn.Close();
        }
        private void btn_bc1_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang1.TextLength<=0)&&(xinruzhushuliang1.TextLength<=0)&&(zhongdianfangshuliang1.TextLength<=0)&&(dashaoshuliang1.TextLength<=0)&&(zaidiandashaoshuliang1.TextLength<=0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang1.Text.ToString()))
            {
                zaidianshuliang1.Text = "0";
            }
            if ("".Equals(xinruzhushuliang1.Text.ToString()))
            {
                xinruzhushuliang1.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang1.Text.ToString()))
            {
                zhongdianfangshuliang1.Text = "0";
            }
            if ("".Equals(dashaoshuliang1.Text.ToString()))
            {
                dashaoshuliang1.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang1.Text.ToString()))
            {
                zaidiandashaoshuliang1.Text = "0";
            }
            dangrizhongjine1.Text = (int.Parse(dashaoshuliang1.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang1.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[0] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang1.Text.ToString() + ",xrzsl = " + xinruzhushuliang1.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang1.Text.ToString() + ",dssl=" + dashaoshuliang1.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang1.Text.ToString() + ",drzje=" + dangrizhongjine1.Text.ToString() + " where jlrq = '" + datatext[0] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[0] + "'," + zaidianshuliang1.Text.ToString() + "," + xinruzhushuliang1.Text.ToString() + "," + zhongdianfangshuliang1.Text.ToString() + "," + dashaoshuliang1.Text.ToString() + "," + zaidiandashaoshuliang1.Text.ToString() + "," + dangrizhongjine1.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label1.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label1.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc2_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang2.TextLength <= 0) && (xinruzhushuliang2.TextLength <= 0) && (zhongdianfangshuliang2.TextLength <= 0) && (dashaoshuliang2.TextLength <= 0) && (zaidiandashaoshuliang2.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang2.Text.ToString()))
            {
                zaidianshuliang2.Text = "0";
            }
            if ("".Equals(xinruzhushuliang2.Text.ToString()))
            {
                xinruzhushuliang2.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang2.Text.ToString()))
            {
                zhongdianfangshuliang2.Text = "0";
            }
            if ("".Equals(dashaoshuliang2.Text.ToString()))
            {
                dashaoshuliang2.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang2.Text.ToString()))
            {
                zaidiandashaoshuliang2.Text = "0";
            }
            dangrizhongjine2.Text = (int.Parse(dashaoshuliang2.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang2.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[1] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang2.Text.ToString() + ",xrzsl = " + xinruzhushuliang2.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang2.Text.ToString() + ",dssl=" + dashaoshuliang2.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang2.Text.ToString() + ",drzje=" + dangrizhongjine2.Text.ToString() + " where jlrq = '" + datatext[1] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[1] + "'," + zaidianshuliang2.Text.ToString() + "," + xinruzhushuliang2.Text.ToString() + "," + zhongdianfangshuliang2.Text.ToString() + "," + dashaoshuliang2.Text.ToString() + "," + zaidiandashaoshuliang2.Text.ToString() + "," + dangrizhongjine2.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label2.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label2.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc3_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang3.TextLength <= 0) && (xinruzhushuliang3.TextLength <= 0) && (zhongdianfangshuliang3.TextLength <= 0) && (dashaoshuliang3.TextLength <= 0) && (zaidiandashaoshuliang3.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang3.Text.ToString()))
            {
                zaidianshuliang3.Text = "0";
            }
            if ("".Equals(xinruzhushuliang3.Text.ToString()))
            {
                xinruzhushuliang3.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang3.Text.ToString()))
            {
                zhongdianfangshuliang3.Text = "0";
            }
            if ("".Equals(dashaoshuliang3.Text.ToString()))
            {
                dashaoshuliang3.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang3.Text.ToString()))
            {
                zaidiandashaoshuliang3.Text = "0";
            }
            dangrizhongjine3.Text = (int.Parse(dashaoshuliang3.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang3.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[2] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang3.Text.ToString() + ",xrzsl = " + xinruzhushuliang3.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang3.Text.ToString() + ",dssl=" + dashaoshuliang3.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang3.Text.ToString() + ",drzje=" + dangrizhongjine3.Text.ToString() + " where jlrq = '" + datatext[2] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[2] + "'," + zaidianshuliang3.Text.ToString() + "," + xinruzhushuliang3.Text.ToString() + "," + zhongdianfangshuliang3.Text.ToString() + "," + dashaoshuliang3.Text.ToString() + "," + zaidiandashaoshuliang3.Text.ToString() + "," + dangrizhongjine3.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label3.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label3.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc4_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang4.TextLength <= 0) && (xinruzhushuliang4.TextLength <= 0) && (zhongdianfangshuliang4.TextLength <= 0) && (dashaoshuliang4.TextLength <= 0) && (zaidiandashaoshuliang4.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang4.Text.ToString()))
            {
                zaidianshuliang4.Text = "0";
            }
            if ("".Equals(xinruzhushuliang4.Text.ToString()))
            {
                xinruzhushuliang4.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang4.Text.ToString()))
            {
                zhongdianfangshuliang4.Text = "0";
            }
            if ("".Equals(dashaoshuliang4.Text.ToString()))
            {
                dashaoshuliang4.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang4.Text.ToString()))
            {
                zaidiandashaoshuliang4.Text = "0";
            }
            if (dangrizhongjine4.TextLength <= 0)
            {
                dangrizhongjine4.Text = "0";
            }
            dangrizhongjine4.Text = (int.Parse(dashaoshuliang4.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang4.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[3] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang4.Text.ToString() + ",xrzsl = " + xinruzhushuliang4.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang4.Text.ToString() + ",dssl=" + dashaoshuliang4.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang4.Text.ToString() + ",drzje=" + dangrizhongjine4.Text.ToString() + " where jlrq = '" + datatext[3] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[3] + "'," + zaidianshuliang4.Text.ToString() + "," + xinruzhushuliang4.Text.ToString() + "," + zhongdianfangshuliang4.Text.ToString() + "," + dashaoshuliang4.Text.ToString() + "," + zaidiandashaoshuliang4.Text.ToString() + "," + dangrizhongjine4.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label4.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label4.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc5_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang5.TextLength <= 0) && (xinruzhushuliang5.TextLength <= 0) && (zhongdianfangshuliang5.TextLength <= 0) && (dashaoshuliang5.TextLength <= 0) && (zaidiandashaoshuliang5.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang5.Text.ToString()))
            {
                zaidianshuliang5.Text = "0";
            }
            if ("".Equals(xinruzhushuliang5.Text.ToString()))
            {
                xinruzhushuliang5.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang5.Text.ToString()))
            {
                zhongdianfangshuliang5.Text = "0";
            }
            if ("".Equals(dashaoshuliang5.Text.ToString()))
            {
                dashaoshuliang5.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang5.Text.ToString()))
            {
                zaidiandashaoshuliang5.Text = "0";
            }
            dangrizhongjine5.Text = (int.Parse(dashaoshuliang5.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang5.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[4] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang5.Text.ToString() + ",xrzsl = " + xinruzhushuliang5.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang5.Text.ToString() + ",dssl=" + dashaoshuliang5.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang5.Text.ToString() + ",drzje=" + dangrizhongjine5.Text.ToString() + " where jlrq = '" + datatext[4] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[4] + "'," + zaidianshuliang5.Text.ToString() + "," + xinruzhushuliang5.Text.ToString() + "," + zhongdianfangshuliang5.Text.ToString() + "," + dashaoshuliang5.Text.ToString() + "," + zaidiandashaoshuliang5.Text.ToString() + "," + dangrizhongjine5.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label5.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label5.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc6_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang6.TextLength <= 0) && (xinruzhushuliang6.TextLength <= 0) && (zhongdianfangshuliang6.TextLength <= 0) && (dashaoshuliang6.TextLength <= 0) && (zaidiandashaoshuliang6.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang6.Text.ToString()))
            {
                zaidianshuliang6.Text = "0";
            }
            if ("".Equals(xinruzhushuliang6.Text.ToString()))
            {
                xinruzhushuliang6.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang6.Text.ToString()))
            {
                zhongdianfangshuliang6.Text = "0";
            }
            if ("".Equals(dashaoshuliang6.Text.ToString()))
            {
                dashaoshuliang6.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang6.Text.ToString()))
            {
                zaidiandashaoshuliang6.Text = "0";
            }
            dangrizhongjine6.Text = (int.Parse(dashaoshuliang6.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang6.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[5] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang6.Text.ToString() + ",xrzsl = " + xinruzhushuliang6.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang6.Text.ToString() + ",dssl=" + dashaoshuliang6.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang6.Text.ToString() + ",drzje=" + dangrizhongjine6.Text.ToString() + " where jlrq = '" + datatext[5] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[5] + "'," + zaidianshuliang6.Text.ToString() + "," + xinruzhushuliang6.Text.ToString() + "," + zhongdianfangshuliang6.Text.ToString() + "," + dashaoshuliang6.Text.ToString() + "," + zaidiandashaoshuliang6.Text.ToString() + "," + dangrizhongjine6.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label6.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label6.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc7_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang7.TextLength <= 0) && (xinruzhushuliang7.TextLength <= 0) && (zhongdianfangshuliang7.TextLength <= 0) && (dashaoshuliang7.TextLength <= 0) && (zaidiandashaoshuliang7.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang7.Text.ToString()))
            {
                zaidianshuliang7.Text = "0";
            }
            if ("".Equals(xinruzhushuliang7.Text.ToString()))
            {
                xinruzhushuliang7.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang7.Text.ToString()))
            {
                zhongdianfangshuliang7.Text = "0";
            }
            if ("".Equals(dashaoshuliang7.Text.ToString()))
            {
                dashaoshuliang7.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang7.Text.ToString()))
            {
                zaidiandashaoshuliang7.Text = "0";
            }
            dangrizhongjine7.Text = (int.Parse(dashaoshuliang7.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang7.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[6] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang7.Text.ToString() + ",xrzsl = " + xinruzhushuliang7.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang7.Text.ToString() + ",dssl=" + dashaoshuliang7.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang7.Text.ToString() + ",drzje=" + dangrizhongjine7.Text.ToString() + " where jlrq = '" + datatext[6] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[6] + "'," + zaidianshuliang7.Text.ToString() + "," + xinruzhushuliang7.Text.ToString() + "," + zhongdianfangshuliang7.Text.ToString() + "," + dashaoshuliang7.Text.ToString() + "," + zaidiandashaoshuliang7.Text.ToString() + "," + dangrizhongjine7.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label7.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label7.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc8_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang8.TextLength <= 0) && (xinruzhushuliang8.TextLength <= 0) && (zhongdianfangshuliang8.TextLength <= 0) && (dashaoshuliang8.TextLength <= 0) && (zaidiandashaoshuliang8.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang8.Text.ToString()))
            {
                zaidianshuliang8.Text = "0";
            }
            if ("".Equals(xinruzhushuliang8.Text.ToString()))
            {
                xinruzhushuliang8.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang8.Text.ToString()))
            {
                zhongdianfangshuliang8.Text = "0";
            }
            if ("".Equals(dashaoshuliang8.Text.ToString()))
            {
                dashaoshuliang8.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang8.Text.ToString()))
            {
                zaidiandashaoshuliang8.Text = "0";
            }
            dangrizhongjine8.Text = (int.Parse(dashaoshuliang8.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang8.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[7] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang8.Text.ToString() + ",xrzsl = " + xinruzhushuliang8.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang8.Text.ToString() + ",dssl=" + dashaoshuliang8.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang8.Text.ToString() + ",drzje=" + dangrizhongjine8.Text.ToString() + " where jlrq = '" + datatext[7] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[7] + "'," + zaidianshuliang8.Text.ToString() + "," + xinruzhushuliang8.Text.ToString() + "," + zhongdianfangshuliang8.Text.ToString() + "," + dashaoshuliang8.Text.ToString() + "," + zaidiandashaoshuliang8.Text.ToString() + "," + dangrizhongjine8.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label8.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label8.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc9_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang9.TextLength <= 0) && (xinruzhushuliang9.TextLength <= 0) && (zhongdianfangshuliang9.TextLength <= 0) && (dashaoshuliang9.TextLength <= 0) && (zaidiandashaoshuliang9.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang9.Text.ToString()))
            {
                zaidianshuliang9.Text = "0";
            }
            if ("".Equals(xinruzhushuliang9.Text.ToString()))
            {
                xinruzhushuliang9.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang9.Text.ToString()))
            {
                zhongdianfangshuliang9.Text = "0";
            }
            if ("".Equals(dashaoshuliang9.Text.ToString()))
            {
                dashaoshuliang9.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang9.Text.ToString()))
            {
                zaidiandashaoshuliang9.Text = "0";
            }
            dangrizhongjine9.Text = (int.Parse(dashaoshuliang9.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang9.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[8] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang9.Text.ToString() + ",xrzsl = " + xinruzhushuliang9.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang9.Text.ToString() + ",dssl=" + dashaoshuliang9.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang9.Text.ToString() + ",drzje=" + dangrizhongjine9.Text.ToString() + " where jlrq = '" + datatext[8] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[8] + "'," + zaidianshuliang9.Text.ToString() + "," + xinruzhushuliang9.Text.ToString() + "," + zhongdianfangshuliang9.Text.ToString() + "," + dashaoshuliang9.Text.ToString() + "," + zaidiandashaoshuliang9.Text.ToString() + "," + dangrizhongjine9.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label9.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label9.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void btn_bc10_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang10.TextLength <= 0) && (xinruzhushuliang10.TextLength <= 0) && (zhongdianfangshuliang10.TextLength <= 0) && (dashaoshuliang10.TextLength <= 0) && (zaidiandashaoshuliang10.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang10.Text.ToString()))
            {
                zaidianshuliang10.Text = "0";
            }
            if ("".Equals(xinruzhushuliang10.Text.ToString()))
            {
                xinruzhushuliang10.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang10.Text.ToString()))
            {
                zhongdianfangshuliang10.Text = "0";
            }
            if ("".Equals(dashaoshuliang10.Text.ToString()))
            {
                dashaoshuliang10.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang10.Text.ToString()))
            {
                zaidiandashaoshuliang10.Text = "0";
            }
            dangrizhongjine10.Text = (int.Parse(dashaoshuliang10.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang10.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[9] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang10.Text.ToString() + ",xrzsl = " + xinruzhushuliang10.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang10.Text.ToString() + ",dssl=" + dashaoshuliang10.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang10.Text.ToString() + ",drzje=" + dangrizhongjine10.Text.ToString() + " where jlrq = '" + datatext[9] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[9] + "'," + zaidianshuliang10.Text.ToString() + "," + xinruzhushuliang10.Text.ToString() + "," + zhongdianfangshuliang10.Text.ToString() + "," + dashaoshuliang10.Text.ToString() + "," + zaidiandashaoshuliang10.Text.ToString() + "," + dangrizhongjine10.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label10.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label10.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }
        private void btn_bc11_Click(object sender, EventArgs e)
        {
            if ((zaidianshuliang11.TextLength <= 0) && (xinruzhushuliang11.TextLength <= 0) && (zhongdianfangshuliang11.TextLength <= 0) && (dashaoshuliang11.TextLength <= 0) && (zaidiandashaoshuliang11.TextLength <= 0))
            {
                MessageBox.Show("当前列未录入数据，无法保存，请输入数据后重新尝试！");
                return;
            }
            if ("".Equals(zaidianshuliang11.Text.ToString()))
            {
                zaidianshuliang11.Text = "0";
            }
            if ("".Equals(xinruzhushuliang11.Text.ToString()))
            {
                xinruzhushuliang11.Text = "0";
            }
            if ("".Equals(zhongdianfangshuliang11.Text.ToString()))
            {
                zhongdianfangshuliang11.Text = "0";
            }
            if ("".Equals(dashaoshuliang11.Text.ToString()))
            {
                dashaoshuliang11.Text = "0";
            }
            if ("".Equals(zaidiandashaoshuliang11.Text.ToString()))
            {
                zaidiandashaoshuliang11.Text = "0";
            }
            dangrizhongjine11.Text = (int.Parse(dashaoshuliang11.Text.ToString()) * 2 + int.Parse(zaidiandashaoshuliang11.Text.ToString())).ToString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql = "if exists(select 1 from dashaojilu where jlrq = '" + datatext[10] + "' ) \n"
                + "begin \n"
                + "update dashaojilu set zdsl = " + zaidianshuliang11.Text.ToString() + ",xrzsl = " + xinruzhushuliang11.Text.ToString() + ",zdfsl = " + zhongdianfangshuliang11.Text.ToString() + ",dssl=" + dashaoshuliang11.Text.ToString() + ",zddssl=" + zaidiandashaoshuliang11.Text.ToString() + ",drzje=" + dangrizhongjine11.Text.ToString() + " where jlrq = '" + datatext[10] + "' \n"
                + "end \n"
                + "else \n"
                + "begin \n"
                + "insert into dashaojilu values ('" + datatext[10] + "'," + zaidianshuliang11.Text.ToString() + "," + xinruzhushuliang11.Text.ToString() + "," + zhongdianfangshuliang11.Text.ToString() + "," + dashaoshuliang11.Text.ToString() + "," + zaidiandashaoshuliang11.Text.ToString() + "," + dangrizhongjine11.Text.ToString() + ") \n"
                + "end \n";
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag == 1)
            {
                if (qjbc)
                    MessageBox.Show(label11.Text.ToString() + "保存成功");
            }
            else
            {
                MessageBox.Show(label11.Text.ToString() + "保存出现错误，请联系管理员");
            }
            conn.Close();
        }

        private void zaidianshuliang1_TextChanged(object sender, EventArgs e)
        {

            //heji1.Text = (int.Parse(zaidianshuliang1.Text) + int.Parse(xinruzhushuliang1.Text) + int.Parse(zhongdianfangshuliang1.Text)).ToString();

        }

        private void btn_dangqianyue_Click(object sender, EventArgs e)
        {
            string data1 = "2017-01-01", data2 = "2017-01-01";
            int tian=0;
            //tianshu = 0;//0为初始，1为31天，2为30天，3为29天，4为28天 
            if(tianshu == 1)
            {
                data1 = year + mon + "1";
                data2 = year + mon + "31";
                tian = 31;
            }
            else if(tianshu == 2)
            {
                data1 = year + mon + "1";
                data2 = year + mon + "30";
                tian = 30;
            }
            else if(tianshu == 3)
            {
                data1 = year + mon + "1";
                data2 = year + mon + "29";
                tian = 29;
            }
            else if(tianshu == 4)
            {
                data1 = year + mon + "1";
                data2 = year + mon + "28";
                tian = 28;
            }
            data1 = data1.Replace("年", "-");
            data1 = data1.Replace("月", "-");
            data2 = data2.Replace("年", "-");
            data2 = data2.Replace("月", "-");
            MyComman.mylist.Clear();
            MyComman.mylist2.Clear();
            Count1 c1 = new Count1(data1, data2, tian);
            c1.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭按钮
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SqlConnection conna = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sqla = "select year,mon,day from combox where zhu = '001'";
            SqlCommand cmd = new SqlCommand(sqla, conna);
            conna.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                combox1 = dr.GetInt32(0);
                combox2 = dr.GetInt32(1);
                combox3 = dr.GetInt32(2);
                
            }
            comboBox1.SelectedIndex = combox1;
            comboBox2.SelectedIndex = combox2;
            comboBox3.SelectedIndex = combox3;
            btn_duqushuju_Click(null, null);
            Thread th = new Thread(thread.Threadupdate)
            {Name="Threadupdate",IsBackground=true};
            th.Start();
            Thread th2 = new Thread(thread.ThreadIP) 
            { Name = "ThreadIP", IsBackground = true };
            th2.Start();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            jihuo = true;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            jihuo = false;
        }

        private void button1_Click(object sender, EventArgs e) //全部保存
        {   //有bug，没写会提示未正确录入数据，无法保存，请输入数据后重新尝试！
            //button1保存
            if (!((zaidianshuliang1.TextLength <= 0) && (xinruzhushuliang1.TextLength <= 0) && (zhongdianfangshuliang1.TextLength <= 0) && (dashaoshuliang1.TextLength <= 0) && (zaidiandashaoshuliang1.TextLength <= 0)))
            {
                if ((zaidianshuliang1.TextLength > 0) && (xinruzhushuliang1.TextLength > 0) && (zhongdianfangshuliang1.TextLength > 0) && (dashaoshuliang1.TextLength > 0) && (zaidiandashaoshuliang1.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc1_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label1.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button2保存
            if (!((zaidianshuliang2.TextLength <= 0) && (xinruzhushuliang2.TextLength <= 0) && (zhongdianfangshuliang2.TextLength <= 0) && (dashaoshuliang2.TextLength <= 0) && (zaidiandashaoshuliang2.TextLength <= 0)))
            {
                if ((zaidianshuliang2.TextLength > 0) && (xinruzhushuliang2.TextLength > 0) && (zhongdianfangshuliang2.TextLength > 0) && (dashaoshuliang2.TextLength > 0) && (zaidiandashaoshuliang2.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc2_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label2.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button3保存
            if (!((zaidianshuliang3.TextLength <= 0) && (xinruzhushuliang3.TextLength <= 0) && (zhongdianfangshuliang3.TextLength <= 0) && (dashaoshuliang3.TextLength <= 0) && (zaidiandashaoshuliang3.TextLength <= 0)))
            {
                if ((zaidianshuliang3.TextLength > 0) && (xinruzhushuliang3.TextLength > 0) && (zhongdianfangshuliang3.TextLength > 0) && (dashaoshuliang3.TextLength > 0) && (zaidiandashaoshuliang3.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc3_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label3.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button4保存
            if (!((zaidianshuliang4.TextLength <= 0) && (xinruzhushuliang4.TextLength <= 0) && (zhongdianfangshuliang4.TextLength <= 0) && (dashaoshuliang4.TextLength <= 0) && (zaidiandashaoshuliang4.TextLength <= 0)))
            {
                if ((zaidianshuliang4.TextLength > 0) && (xinruzhushuliang4.TextLength > 0) && (zhongdianfangshuliang4.TextLength > 0) && (dashaoshuliang4.TextLength > 0) && (zaidiandashaoshuliang4.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc4_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label4.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button5保存
            if (!((zaidianshuliang5.TextLength <= 0) && (xinruzhushuliang5.TextLength <= 0) && (zhongdianfangshuliang5.TextLength <= 0) && (dashaoshuliang5.TextLength <= 0) && (zaidiandashaoshuliang5.TextLength <= 0)))
            {
                if ((zaidianshuliang5.TextLength > 0) && (xinruzhushuliang5.TextLength > 0) && (zhongdianfangshuliang5.TextLength > 0) && (dashaoshuliang5.TextLength > 0) && (zaidiandashaoshuliang5.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc5_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label5.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button6保存
            if (!((zaidianshuliang6.TextLength <= 0) && (xinruzhushuliang6.TextLength <= 0) && (zhongdianfangshuliang6.TextLength <= 0) && (dashaoshuliang6.TextLength <= 0) && (zaidiandashaoshuliang6.TextLength <= 0)))
            {
                if ((zaidianshuliang6.TextLength > 0) && (xinruzhushuliang6.TextLength > 0) && (zhongdianfangshuliang6.TextLength > 0) && (dashaoshuliang6.TextLength > 0) && (zaidiandashaoshuliang6.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc6_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label6.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button7保存
            if (!((zaidianshuliang7.TextLength <= 0) && (xinruzhushuliang7.TextLength <= 0) && (zhongdianfangshuliang7.TextLength <= 0) && (dashaoshuliang7.TextLength <= 0) && (zaidiandashaoshuliang7.TextLength <= 0)))
            {
                if ((zaidianshuliang7.TextLength > 0) && (xinruzhushuliang7.TextLength > 0) && (zhongdianfangshuliang7.TextLength > 0) && (dashaoshuliang7.TextLength > 0) && (zaidiandashaoshuliang7.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc7_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label7.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button8保存
            if (!((zaidianshuliang8.TextLength <= 0) && (xinruzhushuliang8.TextLength <= 0) && (zhongdianfangshuliang8.TextLength <= 0) && (dashaoshuliang8.TextLength <= 0) && (zaidiandashaoshuliang8.TextLength <= 0)))
            {
                if ((zaidianshuliang8.TextLength > 0) && (xinruzhushuliang8.TextLength > 0) && (zhongdianfangshuliang8.TextLength > 0) && (dashaoshuliang8.TextLength > 0) && (zaidiandashaoshuliang8.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc8_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label8.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button9保存
            if (!((zaidianshuliang9.TextLength <= 0) && (xinruzhushuliang9.TextLength <= 0) && (zhongdianfangshuliang9.TextLength <= 0) && (dashaoshuliang9.TextLength <= 0) && (zaidiandashaoshuliang9.TextLength <= 0)))
            {
                if ((zaidianshuliang9.TextLength > 0) && (xinruzhushuliang9.TextLength > 0) && (zhongdianfangshuliang9.TextLength > 0) && (dashaoshuliang9.TextLength > 0) && (zaidiandashaoshuliang9.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc9_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label9.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button10保存
            if (!((zaidianshuliang10.TextLength <= 0) && (xinruzhushuliang10.TextLength <= 0) && (zhongdianfangshuliang10.TextLength <= 0) && (dashaoshuliang10.TextLength <= 0) && (zaidiandashaoshuliang10.TextLength <= 0)))
            {
                if ((zaidianshuliang10.TextLength > 0) && (xinruzhushuliang10.TextLength > 0) && (zhongdianfangshuliang10.TextLength > 0) && (dashaoshuliang10.TextLength > 0) && (zaidiandashaoshuliang10.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc10_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label10.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }

            //button11保存
            if (!((zaidianshuliang11.TextLength <= 0) && (xinruzhushuliang11.TextLength <= 0) && (zhongdianfangshuliang11.TextLength <= 0) && (dashaoshuliang11.TextLength <= 0) && (zaidiandashaoshuliang11.TextLength <= 0)))
            {
                if ((zaidianshuliang11.TextLength > 0) && (xinruzhushuliang11.TextLength > 0) && (zhongdianfangshuliang11.TextLength > 0) && (dashaoshuliang11.TextLength > 0) && (zaidiandashaoshuliang11.TextLength > 0))
                {
                    qjbc = false;
                    btn_bc11_Click(null, null);
                }
                else
                {
                    qjbc = true;
                    MessageBox.Show(label11.Text.ToString() + "未正确录入数据，无法保存，请尝试重新输入数据！");
                    return;
                }
            }
            qjbc = true;
            btn_duqushuju_Click(null, null);    //重新读取数据
            MessageBox.Show("全部保存成功!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Count2 count2 = new Count2();
            count2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Management fm1 = new Management();
            //fm1.Show();
        }

        private void ToolStripMenuItem301_Click(object sender, EventArgs e)
        {
            update up = new update();
            up.ShowDialog();
        }
    }
}

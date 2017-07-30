using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace jiudiandashaojilv
{
    public partial class Count1 : Form
    {
        DateTime dt1,dt2;
        public Count1(string data1, string data2, int tianshu)
        {
            InitializeComponent();
            timer1.Start();
            dt1 = Convert.ToDateTime(data1);
            dt2 = Convert.ToDateTime(data2);
            tjksrq.Text = data1;
            tjjsrq.Text = data2;
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");

            string sql1 = "select SUM(dashaojilu.zdsl) from dashaojilu where dashaojilu.jlrq >= '" + data1 + "' and dashaojilu.jlrq <= '" + data2 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string count_zdsl = cmd1.ExecuteScalar().ToString();
            zaidianshuliang1.Text = count_zdsl;

            string sql2 = "select SUM(dashaojilu.xrzsl) from dashaojilu where dashaojilu.jlrq >= '" + data1 + "' and dashaojilu.jlrq <= '" + data2 + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            string count_xrzsl = cmd2.ExecuteScalar().ToString();
            xinruzhushuliang1.Text = count_xrzsl;

            string sql3 = "select SUM(dashaojilu.zdfsl) from dashaojilu where dashaojilu.jlrq >= '" + data1 + "' and dashaojilu.jlrq <= '" + data2 + "'";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            string count_zdfsl = cmd3.ExecuteScalar().ToString();
            zhongdianfangshuliang1.Text = count_zdfsl;

            if ("".Equals(zaidianshuliang1.Text.ToString()) || "".Equals(xinruzhushuliang1.Text.ToString()) || "".Equals(zhongdianfangshuliang1.Text.ToString()))
            {
                heji1.Text = "";
                ruzhulu1.Text = "";
            }
            else
            {
                heji1.Text = (int.Parse(zaidianshuliang1.Text.ToString()) + int.Parse(xinruzhushuliang1.Text.ToString()) + int.Parse(zhongdianfangshuliang1.Text.ToString())).ToString();
                ruzhulu1.Text = (Math.Round((double.Parse(heji1.Text) / (0.26 * tianshu)), 3)).ToString() + "%";
            }

            string sql4 = "select SUM(dashaojilu.dssl) from dashaojilu where dashaojilu.jlrq >= '" + data1 + "' and dashaojilu.jlrq <= '" + data2 + "'";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            string count_dssl = cmd4.ExecuteScalar().ToString();
            dashaoshuliang1.Text = count_dssl;

            string sql5 = "select SUM(dashaojilu.zddssl) from dashaojilu where dashaojilu.jlrq >= '" + data1 + "' and dashaojilu.jlrq <= '" + data2 + "'";
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            string count_zddssl = cmd5.ExecuteScalar().ToString();
            zaidiandashaoshuliang1.Text = count_zddssl;

            if ("".Equals(dashaoshuliang1.Text.ToString()) || "".Equals(zaidiandashaoshuliang1.Text.ToString()))
            {
                zhongjine1.Text = "";
            }
            else
            {
                zhongjine1.Text = ((int.Parse(dashaoshuliang1.Text.ToString()) * 2) + (int.Parse(zaidiandashaoshuliang1.Text.ToString()))).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            dt1 = dt1.AddDays(1);
            if (dt1.Date > dt2.Date)
            {
                timer1.Stop();
            }
            string data = dt1.Date.ToShortDateString();
            SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
            string sql1 = "select dashaojilu.zdsl from dashaojilu where dashaojilu.jlrq = '" + data + "'";
            string sql2 = "select dashaojilu.xrzsl from dashaojilu where dashaojilu.jlrq = '" + data + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            a = int.Parse(cmd1.ExecuteScalar() != null ? cmd1.ExecuteScalar().ToString() : "0");
            b = int.Parse(cmd2.ExecuteScalar() != null ? cmd2.ExecuteScalar().ToString() : "0");
            conn.Close();
            MyComman.mylist.Add(a);
            MyComman.mylist2.Add(b);
            Refresh();
        }


        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}

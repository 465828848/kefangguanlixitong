using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace jiudiandashaojilv
{
    public partial class Count2 : Form
    {
        string data1 = "1900-00-00", data2 = "1900-00-00";
        int tianshu = 1;
        public Count2()
        {
            InitializeComponent();
        }

        private void Count2_Shown(object sender, EventArgs e)
        {
            dateTimePicker1.Text = "2017年1月1日";
            count();
        }

        private void Count2_Load(object sender, EventArgs e)
        {

        }

        private void count()
        {
            data1 = dateTimePicker1.Text.ToString();
            data2 = dateTimePicker2.Text.ToString();
            data1 = data1.Replace("年", "-");
            data1 = data1.Replace("月", "-");
            data1 = data1.Replace("日", "");
            data2 = data2.Replace("年", "-");
            data2 = data2.Replace("月", "-");
            data2 = data2.Replace("日", "");
            DateTime dt1 = dateTimePicker1.Value;

            DateTime dt2 = dateTimePicker2.Value;

            TimeSpan ts = dt2 - dt1;

            tianshu = ts.Days;
            //tianshu = int.Parse(s.Substring(0, s.Length - 9));
            //MessageBox.Show(data1 + "," + data2 + "," + s);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            count();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            count();
        }
    }
}

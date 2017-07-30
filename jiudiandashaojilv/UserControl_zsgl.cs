using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using jiudiandashaojilv.cms_kyf;
using jiudiandashaojilv.cms_yrz;

namespace jiudiandashaojilv
{
    public partial class UserControl_zsgl : UserControl
    {
        SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
        public static ArrayList list = new ArrayList() { "100", "101", "102", "103", "106", "107", "108", "109", "110", "111", 
            "201", "202", "203", "205", "206", "207", "208", "209", "210", "211", "212", "213", "215", "216", "217", "218", "219" };
        ListViewGroup lvg1 = new ListViewGroup();
        ListViewGroup lvg2 = new ListViewGroup();
        MainForm mform;
        int height, width;
        public UserControl_zsgl(MainForm form,int h,int w)
        {
            InitializeComponent();
            mform = form;
            height = h;
            width = w;
            listView1.Groups.Clear();
            listView1.Items.Clear();
            lvg1.Name = "lvg1";
            lvg1.Header = "1楼";
            lvg1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listView1.Groups.Add(lvg1);
            lvg2.Name = "lvg2";
            lvg2.Header = "2楼";
            lvg2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listView1.Groups.Add(lvg2);
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            ListViewItem item;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            int i = 0;
            for (; i < 10; i++)
            {
                try
                {
                    string sql = "select * from room where roomno = '" + list[i].ToString() + "'; ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        item = new ListViewItem(dr["roomno"].ToString(), int.Parse(dr["roomstatus"].ToString()), lvg1);
                        item.ToolTipText = "房间编号：" + dr["roomno"].ToString() + "\n房间类型：" + dr["roomtype"].ToString() + "\n房间价格：" + dr["roomprice"].ToString() + "\n房间状态：" + Getroomstatus(int.Parse(dr["roomstatus"].ToString()));
                        listView1.Items.Add(item);
                    }
                    dr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("出错！请联系管理员。\n" + e.ToString());
                }
            }
            for (; i < list.Count; i++)
            {
                try
                {
                    string sql = "select * from room where roomno = '" + list[i].ToString() + "'; ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        item = new ListViewItem(dr["roomno"].ToString(), int.Parse(dr["roomstatus"].ToString()), lvg2);
                        item.ToolTipText = "房间编号：" + dr["roomno"].ToString() + "\n房间类型：" + dr["roomtype"].ToString() + "\n房间价格：" + dr["roomprice"].ToString() + "\n房间状态：" + Getroomstatus(int.Parse(dr["roomstatus"].ToString()));
                        listView1.Items.Add(item);
                    }
                    dr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("出错！请联系管理员。\n" + e.ToString());
                }
            }
            conn.Close();
            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void UserControl_zsgl_Load(object sender, EventArgs e)
        {
            this.Height = height;
            this.Width = width;
        }

        public static string Getroomstatus(int n)
        {
            switch (n)
            {
                case 0: return "可用房";
                case 1: return "已入住";
                case 2: return "打扫房";
                case 3: return "预订房";
                case 4: return "维修房";
                default: return "出错";
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    
                    int a=5;
                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                        a = item.ImageIndex;
                    }
                    ListViewItem xy = listView1.GetItemAt(e.X, e.Y);
                    if (xy != null)
                    {
                        Point point = this.PointToClient(listView1.PointToScreen(new Point(e.X, e.Y)));
                        switch (a)
                        {
                            case 0: this.cms_krz.Show(this, point); break;
                            case 1: this.cms_yrz.Show(this, point); break;
                            case 2: this.cms_dsf.Show(this, point); break;
                            case 3: this.cms_ydf.Show(this, point); break;
                            case 4: this.cms_wxf.Show(this, point); break;
                            default: break;
                        }
                    }
                }
            }
        }

        private void 入住该房间_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                Form_rzgfj fr = new Form_rzgfj(mform, item.Text);
                fr.ShowDialog();
                break;
            }
        }

        private void 退房_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                Form_tf ft = new Form_tf(mform, item.Text);
                ft.ShowDialog();
                break;
            }
        }

        private void 续费_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                Form_xf fx = new Form_xf(mform, item.Text);
                fx.ShowDialog();
                break;
            }
        }
    }
}

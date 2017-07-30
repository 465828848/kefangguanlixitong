using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace jiudiandashaojilv.cms_yrz
{
    public partial class Form_tf : Form
    {
        SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
        MainForm mform;
        string roomno = "000";
        string numbill = "";
        string yingfan = "";
        int dgv_width = 0;
        string yinghuanwupin = "";
        string koufeibianhao = "";
        string koufeizongjine = "";
        string isjianyi = "0";
        int qianyitian = 0;
        DateTime dt1;
        public Form_tf(MainForm a,string id)
        {
            InitializeComponent();
            roomno = id;
            mform = a;
        }

        private void Form_tf_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = "declare @num char(14) set @num = (select numbill from room where roomno = '" + roomno + "') select ruzushijian,qianyitian,@num as numbill from housing where numbill = @num";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    numbill = dr["numbill"].ToString();
                    DateTime dt3 = Convert.ToDateTime(dr["ruzushijian"].ToString());
                    qianyitian = int.Parse(dr["qianyitian"].ToString());
                    dt1 = Convert.ToDateTime(dt3.Year.ToString() + "-" + dt3.Month.ToString() + "-" + dt3.Day.ToString());
                }
                dr.Close();
                DateTime dt2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                TimeSpan span = dt2.Subtract(dt1);
                int dayDiff = span.Days;
                if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18 && (dayDiff >= 1 || 1 == qianyitian))
                {
                    isjianyi = "1";
                    comboBox_kflb.SelectedIndex = 2;
                    label_csqk.Text = "超时情况：\n  超时" + Math.Round(((DateTime.Now.Hour - 12.0) * 60.0 + DateTime.Now.Minute) / 60.0, 2).ToString() + "小时";
                }
                else
                {
                    comboBox_kflb.SelectedIndex = 0;
                    if (DateTime.Now.Hour >= 18 && (dayDiff >= 1 || 1 == qianyitian))
                    {
                        label_csqk.Text = "超时情况：\n  已是全天";
                    }
                }
                string sql2 = "declare @rzsj datetime,@tianshu smallint,@num char(14),@qsts smallint set @num = '" + numbill + "' set @tianshu = 0 set @qsts = 0 set @rzsj = (select ruzushijian from housing where numbill = @num) set @tianshu = @tianshu + (select qianyitian from housing where numbill = @num) if(" + dayDiff.ToString() + "=0 and (select qianyitian from housing where numbill = @num) = 0) begin set @qsts =1 end if(DATENAME(hour,GETDATE())>12 and (" + dayDiff.ToString() + " >= 1 or (select qianyitian from housing where numbill = @num) = 1)) begin set @tianshu = @tianshu +1 end update housing set yizhutianshu = @qsts + @tianshu + datediff(day,Datename(year,@rzsj)+'-'+Datename(month,@rzsj)+'-'+Datename(day,@rzsj),Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())) where numbill = @num";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                int flag = cmd2.ExecuteNonQuery();
                if (flag != 1)
                {
                    MessageBox.Show("数据库更新不正确，请联系管理员,出错位置：更新已住天数");
                }
                conn.Close();
                this.dataGridView1.RowTemplate.Height = 35;
                this.dataGridView2.RowTemplate.Height = 35;
                this.dataGridView1.Height = 72;
                this.housingTableAdapter.Fill(this.jiudiandashaojiluDataSet.housing, isjianyi,numbill);
                //标题栏内容居中
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("出错！请联系管理员。\n" + ex.Message);
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = "select jieyongwupin,koufeibianhao,(select isnull(sum(koufeijine),0) from koufei where koufeibianhao = (select koufeibianhao from housing where numbill = '" + numbill + "')) as kfzje from housing where numbill = '" + numbill + "';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    yinghuanwupin = dr["jieyongwupin"].ToString();
                    koufeibianhao = dr["koufeibianhao"].ToString();
                    koufeizongjine = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                }
                dr.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("出错！请联系管理员。\n" + ex.Message);
            }
            if (yinghuanwupin.Length < 1)
            {
                yinghuanwupin = "无";
            }
            label2.Text = "应返物品：" + yinghuanwupin;
            if (dataGridView1.Rows.Count>0)
            {
                yingfan = this.dataGridView1.Rows[0].Cells["yingfanjine"].Value.ToString();
                label1.Text = koufeizongjine + "    应返金额：￥" + yingfan + "元";
            }
            else
            {
                label1.Text = koufeizongjine + "    应返金额：￥0.00元";
            }
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                dgv_width = dgv_width + this.dataGridView1.Columns[i].HeaderCell.Size.Width;
            }
            if (dgv_width != 0)
            {
                this.Width = dgv_width + 9;
                this.dataGridView1.Width = dgv_width;
            }
            this.koufeiTableAdapter.Fill(this.jiudiandashaojiluDataSet1.koufei, koufeibianhao);
            //窗体居中
            int height = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            int width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int formheight = this.Size.Height;
            int formwidth = this.Size.Width;
            int newformx = width / 2 - formwidth / 2;
            int newformy = height / 2 - formheight / 2;
            this.SetDesktopLocation(newformx, newformy);
        }

        private void btn_tf_Click(object sender, EventArgs e)
        {
            try
            {
                string shijituifangshijian = DateTime.Now.ToString();
                string sql = "update housing set shijituifangshijian = GETDATE(),yingfanjine = " + yingfan + " where numbill = '" + numbill + "';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //MessageBox.Show(sql);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int flag = cmd.ExecuteNonQuery();
                if (flag == 1)
                {
                    //成功
                    string sql2 = "update room set roomstatus = 0,numbill = null where roomno = '" + roomno + "';";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    //MessageBox.Show(sql2);
                    int flag2 = cmd2.ExecuteNonQuery();
                    
                    if (flag2 == 1)
                    {
                        //成功
                        mform.btn_zsgl_Click(sender, e);
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                        this.Dispose();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("出错！请联系管理员。\n出错位置:退房更改房间状态信息操作返回影响行数不等于1");
                    }
                }
                else
                {
                    MessageBox.Show("出错！请联系管理员。\n出错位置:退房更新订单号信息操作返回影响行数不等于1");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void first()
        {
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView2.RowTemplate.Height = 35;
            this.dataGridView1.Height = 72;
            this.housingTableAdapter.Fill(this.jiudiandashaojiluDataSet.housing, isjianyi, numbill);
            //标题栏内容居中
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dataGridView1.Rows.Count > 0)
            {
                yingfan = this.dataGridView1.Rows[0].Cells["yingfanjine"].Value.ToString();
                label1.Text = koufeizongjine + "    应返金额：￥" + yingfan + "元";
            }
            else
            {
                label1.Text = koufeizongjine + "    应返金额：￥0.00元";
            }
            dgv_width = 0;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                dgv_width = dgv_width + this.dataGridView1.Columns[i].HeaderCell.Size.Width;
            }
            if (dgv_width != 0)
            {
                this.Width = dgv_width + 9;
                this.dataGridView1.Width = dgv_width;
            }
            this.koufeiTableAdapter.Fill(this.jiudiandashaojiluDataSet1.koufei, koufeibianhao);
            //窗体居中
            int height = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            int width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int formheight = this.Size.Height;
            int formwidth = this.Size.Width;
            int newformx = width / 2 - formwidth / 2;
            int newformy = height / 2 - formheight / 2;
            this.SetDesktopLocation(newformx, newformy);
        }

        private void btn_zjje_Click(object sender, EventArgs e)
        {
            if (comboBox_kflb.Text.Length > 0)
            {
                if (textBox_kcje.TextLength < 1)
                {
                    MessageBox.Show("金额不可为空！");
                }
                else
                {
                    try
                    {
                        double jiage = double.Parse(textBox_kcje.Text);
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        string sql = "if(exists (select * from koufei where koufeibianhao = '" + koufeibianhao + "' and koufeileibie = '" + comboBox_kflb.Text.ToString() + "')) begin update koufei set koufeijine = koufeijine + " + textBox_kcje.Text.ToString() + " where koufeibianhao = '" + koufeibianhao + "' and koufeileibie = '" + comboBox_kflb.Text.ToString() + "' end else begin insert into koufei(koufeibianhao,koufeileibie,koufeijine) values('" + koufeibianhao + "','" + comboBox_kflb.Text.ToString() + "'," + textBox_kcje.Text.ToString() + ") end select isnull(sum(koufeijine),0) as kfzje from koufei where koufeibianhao = '" + koufeibianhao + "';";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            koufeizongjine = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                        }
                        dr.Close();
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
                    }
                    conn.Close();
                    textBox_kcje.Text = "";
                    first();
                }
            }
            else
            {
                MessageBox.Show("类别不可为空!");
            }
        }

        private void btn_jsje_Click(object sender, EventArgs e)
        {
            if (comboBox_kflb.Text.Length > 0)
            {
                if (textBox_kcje.TextLength < 1)
                {
                    MessageBox.Show("金额不可为空！");
                }
                else
                {
                    try
                    {
                        double jiage = double.Parse(textBox_kcje.Text);
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        string sql = "if(exists (select * from koufei where koufeibianhao = '" + koufeibianhao + "' and koufeileibie = '" + comboBox_kflb.Text.ToString() + "')) begin update koufei set koufeijine = koufeijine - " + textBox_kcje.Text.ToString() + " where koufeibianhao = '" + koufeibianhao + "' and koufeileibie = '" + comboBox_kflb.Text.ToString() + "' end else begin insert into koufei(koufeibianhao,koufeileibie,koufeijine) values('" + koufeibianhao + "','" + comboBox_kflb.Text.ToString() + "',-" + textBox_kcje.Text.ToString() + ") end select isnull(sum(koufeijine),0) as kfzje from koufei where koufeibianhao = '" + koufeibianhao + "';";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            koufeizongjine = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                        }
                        dr.Close();
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
                    }
                    conn.Close();
                    textBox_kcje.Text = "";
                    first();
                }
            }
            else
            {
                MessageBox.Show("类别不可为空!");
            }
        }

        private void btn_qlje_Click(object sender, EventArgs e)
        {
            if (comboBox_kflb.Text.Length > 0)
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string sql = "if(exists (select * from koufei where koufeibianhao = '" + koufeibianhao + "' and koufeileibie = '" + comboBox_kflb.Text.ToString() + "')) begin delete from koufei where koufeibianhao = '" + koufeibianhao + "' and koufeileibie = '" + comboBox_kflb.Text.ToString() + "' end select isnull(sum(koufeijine),0) as kfzje from koufei where koufeibianhao = '" + koufeibianhao + "';";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        koufeizongjine = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                    }
                    dr.Close();
                }
                catch (Exception a)
                {
                    MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
                }
                conn.Close();
                textBox_kcje.Text = "";
                first();
            }
            else
            {
                MessageBox.Show("类别不可为空!");
            }
        }

        private void Form_tf_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}

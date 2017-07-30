using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace jiudiandashaojilv.cms_kyf
{
    public partial class Form_rzgfj : Form
    {
        SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123411;database=jiudiandashaojilu");
        int day = 1;
        string SelectValues = "";
        MainForm mform;
        int dgv_width = 0;
        string koufeibianhao = DateTime.Now.ToString("yyyyMMddHHmmss");
        string roomno = "000";
        public Form_rzgfj(MainForm a, string id)
        {
            InitializeComponent();
            roomno = id;
            mform = a;
            label_fjh.Text = "房间号：" + roomno;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = "select CAST(roomjkje as int) as roomjkje,CAST(roomprice as int) as roomprice from room where roomno = '" + roomno + "';";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    numd_jkje.Value = int.Parse(dr["roomjkje"].ToString());
                    comboBox_fj.Text = dr["roomprice"].ToString();
                }
                dr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("出错！请联系管理员。\n" + e.ToString());
            }
            conn.Close();
            if (comboBox_fj.Text.ToString().Length > 1)
            {
                if (comboBox_fj.Text.ToString().IndexOf('.') != -1)
                {
                    comboBox_fj.Text = comboBox_fj.Text.ToString().Substring(0, comboBox_fj.Text.IndexOf('.'));
                }
            }
            numd_yj.Value = int.Parse(numd_jkje.Value.ToString()) - (int.Parse(comboBox_fj.Text) * int.Parse(numd_rzts.Value.ToString()));
            dtp_rzsj.Value = DateTime.Now;
            dtp_ylsj.Value = new DateTime(dtp_rzsj.Value.AddDays(day).Year, dtp_rzsj.Value.AddDays(day).Month, dtp_rzsj.Value.AddDays(day).Day, 12, 0, 0);
        }

        private void Form_rzgfj_Load(object sender, EventArgs e)
        {
            this.koufeiTableAdapter.Fill(this.jiudiandashaojiluDataSet1.koufei, koufeibianhao);
            if (DateTime.Now.Hour < 6)
            {
                this.listBox1.SelectedIndex = 1;
            }
            else
            {
                this.listBox1.SelectedIndex = 0;
            }
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                dgv_width = dgv_width + this.dataGridView1.Columns[i].HeaderCell.Size.Width;
            }
            if (dgv_width != 0)
            {
                this.dataGridView1.Width = dgv_width + 3;
            }
            comboBox_kflb.SelectedIndex = 0;
        }

        private void numd_rzts_ValueChanged(object sender, EventArgs e)
        {
            if (numd_rzts.Value.ToString().IndexOf('.') == -1)
            {
                day = int.Parse(numd_rzts.Value.ToString());
            }
            else
            {
                day = int.Parse(numd_rzts.Value.ToString().Substring(0, numd_rzts.Value.ToString().IndexOf('.')));
                numd_rzts.Value = day;
            }
            //凌晨来房间的，不能加一天
            int i = day;
            if (this.listBox1.SelectedIndex == 1)
            {
                i = i - 1;
            }
            dtp_ylsj.Value = new DateTime(dtp_rzsj.Value.AddDays(i).Year, dtp_rzsj.Value.AddDays(i).Month, dtp_rzsj.Value.AddDays(i).Day, 12, 0, 0);
            if (comboBox_fj.Text.ToString().Length > 1)
            {
                numd_yj.Value = int.Parse(numd_jkje.Value.ToString()) - (int.Parse(comboBox_fj.Text) * int.Parse(numd_rzts.Value.ToString()));
            }
        }

        private void comboBox_fj_KeyPress(object sender, KeyPressEventArgs e) //只能输入数字
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//只能输入数字和小数点
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox_kcje.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox_kcje.Text, out oldf);
                    b2 = float.TryParse(textBox_kcje.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void numd_jkje_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox_fj.Text.Length > 0)
                numd_yj.Value = int.Parse(numd_jkje.Value.ToString()) - (int.Parse(comboBox_fj.Text) * int.Parse(numd_rzts.Value.ToString()));
        }

        private void comboBox_fj_TextChanged(object sender, EventArgs e)
        {
            if(comboBox_fj.Text.Length>0)
                numd_yj.Value = int.Parse(numd_jkje.Value.ToString()) - (int.Parse(comboBox_fj.Text) * int.Parse(numd_rzts.Value.ToString()));
        }

        private void dtp_rzsj_ValueChanged(object sender, EventArgs e)
        {
            //凌晨来房间的，不能加一天
            int i = day;
            if (this.listBox1.SelectedIndex == 1)
            {
                i = i - 1;
            }
            if (numd_rzts.Value.ToString().IndexOf('.') == -1)
            {
                day = int.Parse(numd_rzts.Value.ToString());
            }
            else
            {
                day = int.Parse(numd_rzts.Value.ToString().Substring(0, numd_rzts.Value.ToString().IndexOf('.')));
                numd_rzts.Value = day;
            }
            dtp_ylsj.Value = new DateTime(dtp_rzsj.Value.AddDays(i).Year, dtp_rzsj.Value.AddDays(i).Month, dtp_rzsj.Value.AddDays(i).Day, 12, 0, 0);
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
                            label_kcje.Text = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                        }
                        dr.Close();
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
                    }
                    conn.Close();
                    textBox_kcje.Text = "";
                    this.koufeiTableAdapter.Fill(this.jiudiandashaojiluDataSet1.koufei, koufeibianhao);
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
                            label_kcje.Text = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                        }
                        dr.Close();
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
                    }
                    conn.Close();
                    textBox_kcje.Text = "";
                    this.koufeiTableAdapter.Fill(this.jiudiandashaojiluDataSet1.koufei, koufeibianhao);
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
                        label_kcje.Text = "扣费总金额：" + dr["kfzje"].ToString() + "元";
                    }
                    dr.Close();
                }
                catch (Exception a)
                {
                    MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
                }
                conn.Close();
                textBox_kcje.Text = "";
                this.koufeiTableAdapter.Fill(this.jiudiandashaojiluDataSet1.koufei, koufeibianhao);
            }
            else
            {
                MessageBox.Show("类别不可为空!");
            }
        }

        private void numd_jkje_KeyUp(object sender, KeyEventArgs e)
        {
            if (comboBox_fj.Text.Length > 0)
            {
                if (Equals(numd_rzts.Value.ToString().Equals("")))
                {
                    numd_rzts.Value = 1;
                }
                if (Equals(numd_jkje.Value.ToString().Equals("")))
                {
                    numd_jkje.Value = 0;
                }
                numd_yj.Value = int.Parse(numd_jkje.Value.ToString()) - (int.Parse(comboBox_fj.Text) * int.Parse(numd_rzts.Value.ToString()));
            }
            //凌晨来房间的，不能加一天
            if (numd_rzts.Value.ToString().IndexOf('.') == -1)
            {
                day = int.Parse(numd_rzts.Value.ToString());
            }
            else
            {
                day = int.Parse(numd_rzts.Value.ToString().Substring(0, numd_rzts.Value.ToString().IndexOf('.')));
                numd_rzts.Value = day;
            }
            int i = day;
            if (this.listBox1.SelectedIndex == 1)
            {
                i = i - 1;
            }
            dtp_ylsj.Value = new DateTime(dtp_rzsj.Value.AddDays(i).Year, dtp_rzsj.Value.AddDays(i).Month, dtp_rzsj.Value.AddDays(i).Day, 12, 0, 0);
        }

        private void btn_qrrz_Click(object sender, EventArgs e)
        {
            try
            {
                string dingdanhao = DateTime.Now.ToString("yyyyMMddHHmmss");
                string sql = "insert into housing(numbill,roomno,ruzujiage,jiaokuanshu,ruzutianshu,yajinshu,ruzushijian,yulishijian,yizhutianshu,koufeibianhao,qianyitian,jieyongwupin) VALUES('" + dingdanhao + "','" + roomno + "'," + comboBox_fj.Text.ToString() + "," + numd_jkje.Value.ToString() + "," + numd_rzts.Value.ToString() + "," + numd_yj.Value.ToString() + ",'" + dtp_rzsj.Value.ToString() + "','" + dtp_ylsj.Value.ToString() + "',1," + koufeibianhao + "," + this.listBox1.SelectedIndex.ToString() + ",'" + SelectValues + textBox_qita.Text.ToString() + "');";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //MessageBox.Show(sql);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int flag = cmd.ExecuteNonQuery();
                if (flag == 1)
                {
                    //成功
                    string sql2 = "update room set roomstatus = 1,numbill = '" + dingdanhao + "' where roomno = '" + roomno + "';";
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
                        MessageBox.Show("出错！请联系管理员。\n出错位置:入住，更改房间状态信息操作返回影响行数不等于1");
                    }
                }
                else
                {
                    MessageBox.Show("出错！请联系管理员。\n出错位置:入住，添加订单号信息操作返回影响行数不等于1");
                }
                if(conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("出错！请联系管理员。\n" + a.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numd_rzts.Value.ToString().IndexOf('.') == -1)
            {
                day = int.Parse(numd_rzts.Value.ToString());
            }
            else
            {
                day = int.Parse(numd_rzts.Value.ToString().Substring(0, numd_rzts.Value.ToString().IndexOf('.')));
                numd_rzts.Value = day;
            }
            //凌晨来房间的，不能加一天
            int i = day;
            if (this.listBox1.SelectedIndex == 1)
            {
                i = i - 1;
            }
            dtp_ylsj.Value = new DateTime(dtp_rzsj.Value.AddDays(i).Year, dtp_rzsj.Value.AddDays(i).Month, dtp_rzsj.Value.AddDays(i).Day, 12, 0, 0);
        }

        private void checkedListBox_jywp_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void checkedListBox_jywp_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectValues = "";

            foreach (var item in checkedListBox_jywp.CheckedItems)
            {
                SelectValues += item.ToString() + ",";
            }
        }

        private void Form_rzgfj_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace jiudiandashaojilv
{
    public partial class Management : Form
    {
        
        string[] price = new string[7] { "40", "50", "60", "70", "80", "90", "100" };
        string[] state = new string[5] { "可用房", "已住房", "打扫房", "维修房", "预订房" };//0-4
        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            begin();//初始化
            int res100 = accesscon.selroominfo(100);
            if (res100 == 2)
            {
                roomstate100.SelectedIndex = res100;
                isruzhu100.Checked = true;
                isxinruzhu100.Checked = true;
            }
        }
        /// <summary>
        /// isruzhu100-219checkedchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isruzhu100_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu100.CheckState == CheckState.Checked)
            {
                isruzhu100.Text = "已入住";
                isxinruzhu100.Enabled = true;
                comboBox100.Enabled = true;
                comboBox100.Items.Clear();
                comboBox100.Items.AddRange(price);
                comboBox100.SelectedIndex = 1;
            }
            else if (isruzhu100.CheckState == CheckState.Unchecked)
            {
                isruzhu100.Text = "未入住";
                isxinruzhu100.Enabled = false;
                comboBox100.Items.Clear();
                comboBox100.Text = "";
                comboBox100.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }

        private void isruzhu101_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu101.CheckState == CheckState.Checked)
            {
                comboBox101.Enabled = true;
                comboBox101.SelectedIndex = 1;
            }
            else if (isruzhu101.CheckState == CheckState.Unchecked)
            {
                comboBox101.Text = "";
                comboBox101.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu103_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu103.CheckState == CheckState.Checked)
            {
                comboBox103.Enabled = true;
                comboBox103.SelectedIndex = 3;
            }
            else if (isruzhu103.CheckState == CheckState.Unchecked)
            {
                comboBox103.Text = "";
                comboBox103.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu106_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu106.CheckState == CheckState.Checked)
            {
                comboBox106.Enabled = true;
                comboBox106.SelectedIndex = 1;
            }
            else if (isruzhu106.CheckState == CheckState.Unchecked)
            {
                comboBox106.Text = "";
                comboBox106.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu107_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu107.CheckState == CheckState.Checked)
            {
                comboBox107.Enabled = true;
                comboBox107.SelectedIndex = 3;
            }
            else if (isruzhu107.CheckState == CheckState.Unchecked)
            {
                comboBox107.Text = "";
                comboBox107.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu108_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu108.CheckState == CheckState.Checked)
            {
                comboBox108.Enabled = true;
                comboBox108.SelectedIndex = 1;
            }
            else if (isruzhu108.CheckState == CheckState.Unchecked)
            {
                comboBox108.Text = "";
                comboBox108.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu109_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu109.CheckState == CheckState.Checked)
            {
                comboBox109.Enabled = true;
                comboBox109.SelectedIndex = 3;
            }
            else if (isruzhu109.CheckState == CheckState.Unchecked)
            {
                comboBox109.Text = "";
                comboBox109.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu110_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu110.CheckState == CheckState.Checked)
            {
                comboBox110.Enabled = true;
                comboBox110.SelectedIndex = 3;
            }
            else if (isruzhu110.CheckState == CheckState.Unchecked)
            {
                comboBox110.Text = "";
                comboBox110.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu111_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu111.CheckState == CheckState.Checked)
            {
                comboBox111.Enabled = true;
                comboBox111.SelectedIndex = 3;
            }
            else if (isruzhu111.CheckState == CheckState.Unchecked)
            {
                comboBox111.Text = "";
                comboBox111.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu201_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu201.CheckState == CheckState.Checked)
            {
                comboBox201.Enabled = true;
                comboBox201.SelectedIndex = 4;
            }
            else if (isruzhu201.CheckState == CheckState.Unchecked)
            {
                comboBox201.Text = "";
                comboBox201.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu202_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu202.CheckState == CheckState.Checked)
            {
                comboBox202.Enabled = true;
                comboBox202.SelectedIndex = 4;
            }
            else if (isruzhu202.CheckState == CheckState.Unchecked)
            {
                comboBox202.Text = "";
                comboBox202.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu203_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu203.CheckState == CheckState.Checked)
            {
                comboBox203.Enabled = true;
                comboBox203.SelectedIndex = 2;
            }
            else if (isruzhu203.CheckState == CheckState.Unchecked)
            {
                comboBox203.Text = "";
                comboBox203.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu205_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu205.CheckState == CheckState.Checked)
            {
                comboBox205.Enabled = true;
                comboBox205.SelectedIndex = 4;
            }
            else if (isruzhu205.CheckState == CheckState.Unchecked)
            {
                comboBox205.Text = "";
                comboBox205.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu206_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu206.CheckState == CheckState.Checked)
            {
                comboBox206.Enabled = true;
                comboBox206.SelectedIndex = 3;
            }
            else if (isruzhu206.CheckState == CheckState.Unchecked)
            {
                comboBox206.Text = "";
                comboBox206.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu207_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu207.CheckState == CheckState.Checked)
            {
                comboBox207.Enabled = true;
                comboBox207.SelectedIndex = 2;
            }
            else if (isruzhu207.CheckState == CheckState.Unchecked)
            {
                comboBox207.Text = "";
                comboBox207.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu208_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu208.CheckState == CheckState.Checked)
            {
                comboBox208.Enabled = true;
                comboBox208.SelectedIndex = 3;
            }
            else if (isruzhu208.CheckState == CheckState.Unchecked)
            {
                comboBox208.Text = "";
                comboBox208.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu209_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu209.CheckState == CheckState.Checked)
            {
                comboBox209.Enabled = true;
                comboBox209.SelectedIndex = 6;
            }
            else if (isruzhu209.CheckState == CheckState.Unchecked)
            {
                comboBox209.Text = "";
                comboBox209.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu210_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu210.CheckState == CheckState.Checked)
            {
                comboBox210.Enabled = true;
                comboBox210.SelectedIndex = 4;
            }
            else if (isruzhu210.CheckState == CheckState.Unchecked)
            {
                comboBox210.Text = "";
                comboBox210.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu211_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu211.CheckState == CheckState.Checked)
            {
                comboBox211.Enabled = true;
                comboBox211.SelectedIndex = 3;
            }
            else if (isruzhu211.CheckState == CheckState.Unchecked)
            {
                comboBox211.Text = "";
                comboBox211.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu212_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu212.CheckState == CheckState.Checked)
            {
                comboBox212.Enabled = true;
                comboBox212.SelectedIndex = 2;
            }
            else if (isruzhu212.CheckState == CheckState.Unchecked)
            {
                comboBox212.Text = "";
                comboBox212.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu213_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu213.CheckState == CheckState.Checked)
            {
                comboBox213.Enabled = true;
                comboBox213.SelectedIndex = 2;
            }
            else if (isruzhu213.CheckState == CheckState.Unchecked)
            {
                comboBox213.Text = "";
                comboBox213.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu215_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu215.CheckState == CheckState.Checked)
            {
                comboBox215.Enabled = true;
                comboBox215.SelectedIndex = 3;
            }
            else if (isruzhu215.CheckState == CheckState.Unchecked)
            {
                comboBox215.Text = "";
                comboBox215.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu216_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu216.CheckState == CheckState.Checked)
            {
                comboBox216.Enabled = true;
                comboBox216.SelectedIndex = 2;
            }
            else if (isruzhu216.CheckState == CheckState.Unchecked)
            {
                comboBox216.Text = "";
                comboBox216.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu217_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu217.CheckState == CheckState.Checked)
            {
                comboBox217.Enabled = true;
                comboBox217.SelectedIndex = 6;
            }
            else if (isruzhu217.CheckState == CheckState.Unchecked)
            {
                comboBox217.Text = "";
                comboBox217.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu218_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu218.CheckState == CheckState.Checked)
            {
                comboBox218.Enabled = true;
                comboBox218.SelectedIndex = 6;
            }
            else if (isruzhu218.CheckState == CheckState.Unchecked)
            {
                comboBox218.Text = "";
                comboBox218.Enabled = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        private void isruzhu219_CheckedChanged(object sender, EventArgs e)
        {
            if (isruzhu219.CheckState == CheckState.Checked)
            {
                comboBox219.Enabled = true;
                comboBox219.SelectedIndex = 6;
            }
            else if (isruzhu219.CheckState == CheckState.Unchecked)
            {
                comboBox219.Enabled = false;
                comboBox219.Text = "";
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }
        /// <summary>
        /// isxinruzhu100-219,CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isxinruzhu100_CheckedChanged(object sender, EventArgs e)
        {
            if (isxinruzhu100.CheckState == CheckState.Checked)
            {

            }
            else if (isxinruzhu100.CheckState == CheckState.Unchecked)
            {

            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
        }

        private void isxinruzhu101_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu103_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu106_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu107_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu108_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu109_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu110_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu111_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu201_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu202_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu203_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu205_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu206_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu207_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu208_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu209_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu210_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu211_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu212_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu213_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu215_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu216_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu217_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu218_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isxinruzhu219_CheckedChanged(object sender, EventArgs e)
        {

        }


        void begin()
        {
            comboBox100.Items.Clear();
            comboBox100.Items.AddRange(price);
            comboBox101.Items.Clear();
            comboBox101.Items.AddRange(price);
            comboBox103.Items.Clear();
            comboBox103.Items.AddRange(price);
            comboBox106.Items.Clear();
            comboBox106.Items.AddRange(price);
            comboBox107.Items.Clear();
            comboBox107.Items.AddRange(price);
            comboBox108.Items.Clear();
            comboBox108.Items.AddRange(price);
            comboBox109.Items.Clear();
            comboBox109.Items.AddRange(price);
            comboBox110.Items.Clear();
            comboBox110.Items.AddRange(price);
            comboBox111.Items.Clear();
            comboBox111.Items.AddRange(price);
            comboBox201.Items.Clear();
            comboBox201.Items.AddRange(price);
            comboBox202.Items.Clear();
            comboBox202.Items.AddRange(price);
            comboBox203.Items.Clear();
            comboBox203.Items.AddRange(price);
            comboBox205.Items.Clear();
            comboBox205.Items.AddRange(price);
            comboBox206.Items.Clear();
            comboBox206.Items.AddRange(price);
            comboBox207.Items.Clear();
            comboBox207.Items.AddRange(price);
            comboBox208.Items.Clear();
            comboBox208.Items.AddRange(price);
            comboBox209.Items.Clear();
            comboBox209.Items.AddRange(price);
            comboBox210.Items.Clear();
            comboBox210.Items.AddRange(price);
            comboBox211.Items.Clear();
            comboBox211.Items.AddRange(price);
            comboBox212.Items.Clear();
            comboBox212.Items.AddRange(price);
            comboBox213.Items.Clear();
            comboBox213.Items.AddRange(price);
            comboBox215.Items.Clear();
            comboBox215.Items.AddRange(price);
            comboBox216.Items.Clear();
            comboBox216.Items.AddRange(price);
            comboBox217.Items.Clear();
            comboBox217.Items.AddRange(price);
            comboBox218.Items.Clear();
            comboBox218.Items.AddRange(price);
            comboBox219.Items.Clear();
            comboBox219.Items.AddRange(price);
            comboBox100.Text = "";
            comboBox101.Text = "";
            comboBox103.Text = "";
            comboBox106.Text = "";
            comboBox107.Text = "";
            comboBox108.Text = "";
            comboBox109.Text = "";
            comboBox110.Text = "";
            comboBox111.Text = "";
            comboBox201.Text = "";
            comboBox202.Text = "";
            comboBox203.Text = "";
            comboBox205.Text = "";
            comboBox206.Text = "";
            comboBox207.Text = "";
            comboBox208.Text = "";
            comboBox209.Text = "";
            comboBox210.Text = "";
            comboBox211.Text = "";
            comboBox212.Text = "";
            comboBox213.Text = "";
            comboBox215.Text = "";
            comboBox216.Text = "";
            comboBox217.Text = "";
            comboBox218.Text = "";
            comboBox219.Text = "";
            roomstate100.Items.Clear();
            roomstate100.Items.AddRange(state);
        }
    }
}

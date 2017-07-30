using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jiudiandashaojilv
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_fjgl_Click(object sender, EventArgs e)
        {
            panel_fjgl.Visible = true;
            panel_hj.Visible = false;
            panel_xtsz.Visible = false;
        }

        private void btn_hj_Click(object sender, EventArgs e)
        {
            panel_fjgl.Visible = false;
            panel_hj.Visible = true;
            panel_xtsz.Visible = false;
        }

        private void btn_xtsz_Click(object sender, EventArgs e)
        {
            panel_fjgl.Visible = false;
            panel_hj.Visible = false;
            panel_xtsz.Visible = true;
        }

        public void btn_zsgl_Click(object sender, EventArgs e)
        {
            var view = new UserControl_zsgl(this,panel1.Height,panel1.Width);
            panel_show(view);
        }

        private void btn_dsgl_Click(object sender, EventArgs e)
        {
            First formf = new First();
            formf.Show();
        }

        protected void panel_show(UserControl view)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(view);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btn_zsgl_Click(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认关闭程序吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            else
            {
                this.Dispose();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Close();
                
            }
        }
    }
}

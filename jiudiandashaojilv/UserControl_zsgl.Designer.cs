namespace jiudiandashaojilv
{
    partial class UserControl_zsgl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_zsgl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cms_krz = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.入住该房间 = new System.Windows.Forms.ToolStripMenuItem();
            this.预定该房间 = new System.Windows.Forms.ToolStripMenuItem();
            this.转为打扫房 = new System.Windows.Forms.ToolStripMenuItem();
            this.转为维修房 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_yrz = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退房 = new System.Windows.Forms.ToolStripMenuItem();
            this.续费 = new System.Windows.Forms.ToolStripMenuItem();
            this.在店更换房间 = new System.Windows.Forms.ToolStripMenuItem();
            this.查看详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ydf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.预定入住该房间 = new System.Windows.Forms.ToolStripMenuItem();
            this.取消预定 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dsf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.转为可用房 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_wxf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.维修转为可用房 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cms_krz.SuspendLayout();
            this.cms_yrz.SuspendLayout();
            this.cms_ydf.SuspendLayout();
            this.cms_dsf.SuspendLayout();
            this.cms_wxf.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "普通视图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(742, 402);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "可用房.ico");
            this.imageList1.Images.SetKeyName(1, "已入住.ico");
            this.imageList1.Images.SetKeyName(2, "打扫房.ico");
            this.imageList1.Images.SetKeyName(3, "预订房.ico");
            this.imageList1.Images.SetKeyName(4, "维修房.ico");
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(748, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "详细信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cms_krz
            // 
            this.cms_krz.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入住该房间,
            this.预定该房间,
            this.转为打扫房,
            this.转为维修房});
            this.cms_krz.Name = "cms_krz";
            this.cms_krz.Size = new System.Drawing.Size(137, 92);
            this.cms_krz.Text = "可用房菜单";
            // 
            // 入住该房间
            // 
            this.入住该房间.Name = "入住该房间";
            this.入住该房间.Size = new System.Drawing.Size(136, 22);
            this.入住该房间.Text = "入住该房间";
            this.入住该房间.Click += new System.EventHandler(this.入住该房间_Click);
            // 
            // 预定该房间
            // 
            this.预定该房间.Name = "预定该房间";
            this.预定该房间.Size = new System.Drawing.Size(136, 22);
            this.预定该房间.Text = "预定该房间";
            // 
            // 转为打扫房
            // 
            this.转为打扫房.Name = "转为打扫房";
            this.转为打扫房.Size = new System.Drawing.Size(136, 22);
            this.转为打扫房.Text = "转为打扫房";
            // 
            // 转为维修房
            // 
            this.转为维修房.Name = "转为维修房";
            this.转为维修房.Size = new System.Drawing.Size(136, 22);
            this.转为维修房.Text = "转为维修房";
            // 
            // cms_yrz
            // 
            this.cms_yrz.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退房,
            this.续费,
            this.在店更换房间,
            this.查看详细信息ToolStripMenuItem});
            this.cms_yrz.Name = "cms_yrz";
            this.cms_yrz.Size = new System.Drawing.Size(153, 114);
            this.cms_yrz.Text = "已入住菜单";
            // 
            // 退房
            // 
            this.退房.Name = "退房";
            this.退房.Size = new System.Drawing.Size(152, 22);
            this.退房.Text = "退房";
            this.退房.Click += new System.EventHandler(this.退房_Click);
            // 
            // 续费
            // 
            this.续费.Name = "续费";
            this.续费.Size = new System.Drawing.Size(152, 22);
            this.续费.Text = "续费";
            this.续费.Click += new System.EventHandler(this.续费_Click);
            // 
            // 在店更换房间
            // 
            this.在店更换房间.Name = "在店更换房间";
            this.在店更换房间.Size = new System.Drawing.Size(152, 22);
            this.在店更换房间.Text = "在店更换房间";
            // 
            // 查看详细信息ToolStripMenuItem
            // 
            this.查看详细信息ToolStripMenuItem.Name = "查看详细信息ToolStripMenuItem";
            this.查看详细信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看详细信息ToolStripMenuItem.Text = "查看详细信息";
            // 
            // cms_ydf
            // 
            this.cms_ydf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.预定入住该房间,
            this.取消预定});
            this.cms_ydf.Name = "cms_ydf";
            this.cms_ydf.Size = new System.Drawing.Size(137, 48);
            this.cms_ydf.Text = "预订房菜单";
            // 
            // 预定入住该房间
            // 
            this.预定入住该房间.Name = "预定入住该房间";
            this.预定入住该房间.Size = new System.Drawing.Size(136, 22);
            this.预定入住该房间.Text = "入住该房间";
            // 
            // 取消预定
            // 
            this.取消预定.Name = "取消预定";
            this.取消预定.Size = new System.Drawing.Size(136, 22);
            this.取消预定.Text = "取消预定";
            // 
            // cms_dsf
            // 
            this.cms_dsf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.转为可用房});
            this.cms_dsf.Name = "cms_dsf";
            this.cms_dsf.Size = new System.Drawing.Size(137, 26);
            this.cms_dsf.Text = "打扫房菜单";
            // 
            // 转为可用房
            // 
            this.转为可用房.Name = "转为可用房";
            this.转为可用房.Size = new System.Drawing.Size(136, 22);
            this.转为可用房.Text = "转为可用房";
            // 
            // cms_wxf
            // 
            this.cms_wxf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.维修转为可用房});
            this.cms_wxf.Name = "cms_wxf";
            this.cms_wxf.Size = new System.Drawing.Size(137, 26);
            this.cms_wxf.Text = "维修房菜单";
            // 
            // 维修转为可用房
            // 
            this.维修转为可用房.Name = "维修转为可用房";
            this.维修转为可用房.Size = new System.Drawing.Size(136, 22);
            this.维修转为可用房.Text = "转为可用房";
            // 
            // UserControl_zsgl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_zsgl";
            this.Size = new System.Drawing.Size(756, 434);
            this.Load += new System.EventHandler(this.UserControl_zsgl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cms_krz.ResumeLayout(false);
            this.cms_yrz.ResumeLayout(false);
            this.cms_ydf.ResumeLayout(false);
            this.cms_dsf.ResumeLayout(false);
            this.cms_wxf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cms_krz;
        private System.Windows.Forms.ToolStripMenuItem 入住该房间;
        private System.Windows.Forms.ToolStripMenuItem 预定该房间;
        private System.Windows.Forms.ToolStripMenuItem 转为打扫房;
        private System.Windows.Forms.ToolStripMenuItem 转为维修房;
        private System.Windows.Forms.ContextMenuStrip cms_yrz;
        private System.Windows.Forms.ToolStripMenuItem 退房;
        private System.Windows.Forms.ToolStripMenuItem 续费;
        private System.Windows.Forms.ToolStripMenuItem 在店更换房间;
        private System.Windows.Forms.ContextMenuStrip cms_ydf;
        private System.Windows.Forms.ToolStripMenuItem 预定入住该房间;
        private System.Windows.Forms.ToolStripMenuItem 取消预定;
        private System.Windows.Forms.ContextMenuStrip cms_dsf;
        private System.Windows.Forms.ToolStripMenuItem 转为可用房;
        private System.Windows.Forms.ContextMenuStrip cms_wxf;
        private System.Windows.Forms.ToolStripMenuItem 维修转为可用房;
        private System.Windows.Forms.ToolStripMenuItem 查看详细信息ToolStripMenuItem;

    }
}

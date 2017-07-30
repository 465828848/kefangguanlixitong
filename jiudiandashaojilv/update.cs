using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace jiudiandashaojilv
{
    public partial class update : Form
    {
        static int lastbuild = 10, build = 0;
        string url = "", lastupdatetime="",newfunction="",softname="",version="";
        string path = System.Environment.CurrentDirectory;
        public update()
        {
            InitializeComponent();
        }

        private void update_Load(object sender, EventArgs e)
        {
            
        }

        private void getxml()
        {
            try
            {
                label2.Text = "开始准备检查更新........";
                DateTime dt8 = DateTime.Now;
                while ((DateTime.Now - dt8).TotalMilliseconds < 2000)
                {
                    Application.DoEvents();
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(http.HttpGet("http://www.gebreka.com:9000", ""));
                XmlNodeList xnList = xmlDoc.SelectNodes("AutoUpdater");
                //Console.WriteLine("共有{0}个节点", xnList.Count);//输出xnList中节点个数。  
                foreach (XmlNode xn in xnList)
                {
                    //无法使用xn["ActivityId"].InnerText  
                    url = (xn.SelectSingleNode("url")).InnerText;
                    lastupdatetime = xn.SelectSingleNode("lastupdatetime").InnerText;
                    newfunction = xn.SelectSingleNode("newfunction").InnerText;
                    softname = xn.SelectSingleNode("softname").InnerText;
                    version = xn.SelectSingleNode("version").InnerText;
                    build = int.Parse(xn.SelectSingleNode("build").InnerText);
                }
            }
            catch (Exception e)
            {
                //显示错误信息
                DateTime dt7 = DateTime.Now;
                while ((DateTime.Now - dt7).TotalMilliseconds < 30000)
                {
                    label2.Text = "出错，请联系作者。\n出错原因：" + e.Message.ToString() + "\n" + Math.Round(30.0 - ((DateTime.Now - dt7).TotalMilliseconds / 1000.0), 1).ToString() + "秒后将放弃更新。";
                    Application.DoEvents();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void update_Shown(object sender, EventArgs e)
        {
            getxml();
            if (build > lastbuild)
            {
                label2.Text = "发现新版本，准备开始下载";
                DateTime dt6 = DateTime.Now;
                while ((DateTime.Now - dt6).TotalMilliseconds < 2000)
                {
                    Application.DoEvents();
                }
                download();
            }
            else 
            {
                label2.Text = "当前已是最新版.";
                DateTime dt9 = DateTime.Now;
                while ((DateTime.Now - dt9).TotalMilliseconds < 2000)
                {
                    Application.DoEvents();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void download()
        {
            FileInfo fi = new FileInfo(this.GetType().Assembly.Location);
            fi.MoveTo(Path.Combine(path + "\\版本备份" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".bak"));
            //MessageBox.Show(path);
            if (File.Exists(path + "\\" + softname))
            {
                try
                {
                    //存在
                    File.Delete(path + "\\" + softname);
                }
                catch(Exception e)
                {
                    DateTime dt2 = DateTime.Now;
                    while ((DateTime.Now - dt2).TotalMilliseconds < 30000)
                    {
                        label2.Text = "出错，请联系作者。\n出错原因:"+ e.Message.ToString()+ "\n" + Math.Round(30.0 - ((DateTime.Now - dt2).TotalMilliseconds / 1000.0), 1).ToString() + "秒后将放弃更新。";
                        Application.DoEvents();
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            label2.Text = "下载中，请稍等.........";
            DateTime dt1 = DateTime.Now;
            while ((DateTime.Now - dt1).TotalMilliseconds < 2000)
            {
                Application.DoEvents();
            }
            string res = http.HttpDownloadFile(url+softname, path+"\\"+softname);
            if ("下载出错".Equals(res))
            {
                DateTime dt2 = DateTime.Now;
                while ((DateTime.Now - dt2).TotalMilliseconds < 30000)
                {
                    label2.Text = "更新下载出错，请联系作者。\n" + Math.Round(30.0 - ((DateTime.Now - dt2).TotalMilliseconds / 1000.0), 1).ToString() + "秒后将放弃更新。";
                    Application.DoEvents();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            label2.Text = "新版本下载完成";
            dt1 = DateTime.Now;
            while ((DateTime.Now - dt1).TotalMilliseconds < 2000)
            {
                Application.DoEvents();
            }
            //判断某文件是否存在,需要引用命名空间using System.IO; 
            if(File.Exists(path+"\\"+softname)) 
            { 
                //存在
                if (File.Exists(path+"\\autoupdate.exe"))
                {
                    
                    Process.Start(path + "\\autoupdate.exe");
                    System.Environment.Exit(0);
                }
                else
                {
                    //不存在
                    string res2 = http.HttpDownloadFile("http://www.gebreka.com:9000/download/autoupdate/autoupdate.exe", path + "\\autoupdate.exe");
                    if ("下载出错".Equals(res2))
                    {
                        DateTime dt3 = DateTime.Now;
                        while ((DateTime.Now - dt3).TotalMilliseconds < 30000)
                        {
                            label2.Text = "更新下载出错，请联系作者。\n" + Math.Round(30.0 - ((DateTime.Now - dt3).TotalMilliseconds / 1000.0), 1).ToString() + "秒后将放弃更新。";
                            Application.DoEvents();
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else 
            {
                //不存在
                DateTime dt4 = DateTime.Now;
                while ((DateTime.Now - dt4).TotalMilliseconds < 30000)
                {
                    label2.Text = "更新下载出错，请联系作者。\n" + Math.Round(30.0 - ((DateTime.Now - dt4).TotalMilliseconds / 1000.0), 1).ToString() + "秒后将放弃更新。";
                    Application.DoEvents();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (File.Exists(path + "\\autoupdate.exe"))
            {
                Process.Start(path + "\\autoupdate.exe");
                System.Environment.Exit(0);
            }
            else
            {
                DateTime dt5 = DateTime.Now;
                while ((DateTime.Now - dt5).TotalMilliseconds < 30000)
                {
                    label2.Text = "更新下载出错，请联系作者。\n" + Math.Round(30.0 - ((DateTime.Now - dt5).TotalMilliseconds / 1000.0), 1).ToString() + "秒后将放弃更新。";
                    Application.DoEvents();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

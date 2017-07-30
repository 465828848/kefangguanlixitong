using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace jiudiandashaojilv
{
    class thread
    {
        public static void Threadupdate()
        {
            string path = System.Environment.CurrentDirectory;
            while (true)
            {
                if (DateTime.Now.Hour == 3 && First.jihuo == false)
                {
                    update up = new update();
                    up.ShowDialog();
                }
                Thread.Sleep(2000000);
            }
        }
        public static void ThreadIP() 
        {
            while (true)
            {
                http.HttpGet("http://www.gebreka.com/ip.php", "");
                Thread.Sleep(60000);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jiudiandashaojilv.cms_yrz
{
    public partial class Form_xf : Form
    {
        MainForm mform;
        string roomno = "000";
        public Form_xf(MainForm a, string id)
        {
            InitializeComponent();
            roomno = id;
            mform = a;
        }
    }
}

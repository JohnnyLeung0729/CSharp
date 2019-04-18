using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace u2ec_example.subwindows
{
    public partial class FrmAboutMe : Form
    {
        public FrmAboutMe()
        {
            InitializeComponent();
            label1.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\n";
        }
    }
}

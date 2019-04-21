using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace small_ant.subwindows
{
    public partial class FrmListP : Form
    {
        public FrmListP(System.Diagnostics.Process[] gp)
        {
            InitializeComponent();

            for (int i = 0; i < gp.Length; i++)
            {
                lb_main.Items.Add(gp[i].ProcessName);
            }
        }
    }
}

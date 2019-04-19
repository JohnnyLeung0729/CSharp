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
    public partial class FrmSetDelay : Form
    {
        Label tbs = null;

        public FrmSetDelay(Label tb)
        {
            InitializeComponent();
            //MessageBox.Show(tb.Text);
            if (tb.Text != null) {
                textBox1.Text = tb.Text;
                tbs = tb;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbs != null) {
                tbs.Text = textBox1.Text;
                OPini oi = new OPini(Environment.CurrentDirectory + "\\config.ini");
                oi.WriteString("DELAY", "time", tbs.Text);

                MessageBox.Show("延迟时间已经修改更新！", "更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}

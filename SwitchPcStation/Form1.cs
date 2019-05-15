using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchPcStation
{
    public partial class Form1 : Form
    {
        USB ezUSB = new USB();
        public Form1()
        {
            InitializeComponent();
        }

        private void USBEventHandler(object sender, EventArrivedEventArgs e)
        {
            //throw new NotImplementedException();

            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                this.SetText("USB插入时间：" + DateTime.Now + "\r\n");
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
            {
                this.SetText("USB拔出时间：" + DateTime.Now + "\r\n");
            }

            foreach (USBControllerDevice Device in USB.WhoUSBControllerDevice(e))
            {
                this.SetText("\tAntecedent：" + Device.Antecedent + "\r\n");
                this.SetText("\tDependent：" + Device.Dependent + "\r\n");
            }

        }


        private void SetText(String text)
        {
            if (this.textBox1.InvokeRequired)
            {
                this.textBox1.BeginInvoke(new Action<String>((msg) =>
                {
                    this.textBox1.AppendText(msg);
                }), text);
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ezUSB.RemoveUSBEventWatcher();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ezUSB.AddUSBEventWatcher(USBEventHandler, USBEventHandler, new TimeSpan(0, 0, 3));
        }
    }


}

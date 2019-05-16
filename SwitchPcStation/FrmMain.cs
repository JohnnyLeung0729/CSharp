using IniOpLibs.sln;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchPcStation
{
    public partial class FrmMain : Form
    {
        USB ezUSB = new USB();
        SPS sps;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void USBEventHandler(object sender, EventArrivedEventArgs e)
        {
            //throw new NotImplementedException();
            int flagtype = 0;

            foreach (USBControllerDevice Device in USB.WhoUSBControllerDevice(e))
            {
                this.SetText("\tAntecedent：" + Device.Antecedent + "\r\n");
                this.SetText("\tDependent：" + Device.Dependent + "\r\n");
                String s = Device.Dependent;
                String[] ss = s.Split('\\');
                if (ss.Length == 5)
                {
                    Console.WriteLine(ss[2]);
                    String[] sss = ss[2].Split('&');
                    if (sss.Length == 2)
                    {
                        Console.WriteLine(sss[0]);
                    }
                    else if (sss.Length == 4)
                    {
                        String deviceName = sss[1] + sss[2];
                        if (deviceName.Equals("VEN_AISINOPROD_JSP_SHUIKONG"))
                        {
                            flagtype = 1;
                        }
                        else if (deviceName.Equals("VEN_NISECPROD_TCG-01"))
                        {
                            flagtype = 2;
                        }

                        if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
                        {
                            this.SetStatText("USB插入时间：" + DateTime.Now + ";" + gettypename(flagtype) + "\r\n");
                            startApps();
                        }
                        else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
                        {
                            this.SetStatText("USB拔出时间：" + DateTime.Now + ";" + gettypename(flagtype) + "\r\n");
                            closeApps();
                        }
                    }
                }
            }
        }

        private void startApps() {
            for (int j = 0; j < sps.Process.S.Count; j++)
            {
                try
                {
                    String filepathname = sps.Process.S["s-" + j.ToString()];
                    String[] stemp = filepathname.Split('.');
                    if (stemp.Length > 1)
                    {
                        if (stemp[1].Equals("lnk"))
                        {
                            //Process.Start(filepathname);
                            Thread threadC = new Thread(closeApp);
                            threadC.Start(filepathname);
                        }
                        else
                        {
                            Thread threadC = new Thread(closeApp);
                            threadC.Start(sps.Process.S["s-" + j.ToString()]);
                        }
                    }
                    else
                    {
                        Thread threadC = new Thread(closeApp);
                        threadC.Start(filepathname);
                    }
                }
                catch (KeyNotFoundException ex)
                {
                    Console.Write(ex.Message);
                }
                catch (NullReferenceException ne)
                {
                    Console.Write(ne.Message);
                }
            }
        }

        private void closeApps() {
            for (int j = 0; j < sps.Process.P.Count; j++)
            {
                try
                {
                    //if (listBoxlog.Items.Count > 400) listBoxlog.Items.Clear();
                    //listBoxlog.Items.Add(licf.Ic.Process.P["p-" + j.ToString()]);
                    System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName(sps.Process.P["p-" + j.ToString()]);
                    foreach (System.Diagnostics.Process p in ps)
                    {
                        p.Kill();
                    }
                }
                catch (KeyNotFoundException enfx)
                {
                    Console.Write(enfx.Message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private String gettypename(int ty)
        {
            switch (ty)
            {
                case 1:
                    return "航信税控盘";
                case 2:
                    return "百旺税控盘";
            }
            return "未知设备";
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
        private void SetStatText(String text)
        {
            stats_lblAction.Text = text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ezUSB.RemoveUSBEventWatcher();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_console.Text += "系统启动...  ...\r\n";
            ezUSB.AddUSBEventWatcher(USBEventHandler, USBEventHandler, new TimeSpan(0, 0, 3));

            Control.CheckForIllegalCrossThreadCalls = false;

            SPSinitFileLoad sfl = new SPSinitFileLoad(Environment.CurrentDirectory + "\\config.ini");
            sfl.init_get_inifile();
            sps = sfl.Sps;
            txt_console.Text += "调用配置文件成功\r\n";
            
            closeApps();
            txt_console.Text += "清空任务池\r\n";

            Thread threadstart = new Thread(startOnce);
            threadstart.Start();  // 只要使用Start方法，线程才会运行  
            txt_console.Text += "系统启动成功\r\n";
        }

        private void startOnce() {
            PnPEntityInfo[] who = USB.AllUsbDevices;
            foreach (PnPEntityInfo ist in who)
            {
                Match match = Regex.Match(ist.DeviceID, "VEN_[A-Z]{0,20}&PROD_[A-Z|-]{0,20}[0-9]{0,10}");
                if (match.Success) {
                    String stist = ist.DeviceID;
                    String infos=stist.Split('=')[1];
                    String[] infosplit = infos.Split('&');
                    String pantype = infosplit[1] + infosplit[2];
                    Thread.Sleep(3000);
                    if (pantype.Equals("VEN_AISINOPROD_JSP_SHUIKONG")|| pantype.Equals("VEN_NISECPROD_TCG-01"))
                    {
                        startApps();
                    }
                    break;
                }
            }
        }


        private void closeApp(object dic)
        {
            Console.WriteLine(Convert.ToString(dic));
            Thread.Sleep(flushDelayTime());
            try
            {
                System.Diagnostics.Process.Start(Convert.ToString(dic));
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("通常这个问题是因为配置文件中需要启动的程序路径不正确导致，请检查配置文件，若仍然无法解决，请联系开发者！", "启动故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int flushDelayTime()
        {
            return sps.Delay.Time * 1000;
        }

        private void ctButtonCheckhw_Click(object sender, EventArgs e)
        {
            startOnce();
        }

        private void tbtn_close_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }


}

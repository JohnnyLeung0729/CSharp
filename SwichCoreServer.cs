using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;
using u2ec_example.socket;
using small_ant.config;

namespace u2ec_example
{
    public partial class SwitchCoreServer : Form
    {
        /// <summary>
        /// Port端口状态变化激活监听管理
        /// </summary>
        public event u2ec.OnChangeDevList MyCall;
        
        List<String> lssharedport = new List<string>();
        private TreeView TreeViewServer = new TreeView();
        private TreeNode node = new TreeNode();
        //private Dictionary<String, String> dictionary;
        private Heartbeat heartbeat;

        private String syspath;
        LoadIniConfigFile licf;

        public SwitchCoreServer()
        {
            InitializeComponent();

            MyCall += new u2ec.OnChangeDevList(SwitchCoreServer_MyCall);
            u2ec.SetCallBackOnChangeDevList(MyCall);

            syspath = Environment.CurrentDirectory + "\\config.ini";
            licf = new LoadIniConfigFile(syspath);
            Trace.WriteLine("Load Syspath configpath.ini file status is:--- --- " + licf.initConfig().ToString());

            heartbeat = new Heartbeat(licf.Ic.Heartbeat.Hbpath);

            //获取所有的共享设备
            showshared();
            //判断是否有共享的设备，如果没有共享的设备，则判断是否配置文件有配置端口，如果有则开放该接口共享
            if (lssharedport.Count < 1)
            {
                if (!licf.Ic.Server.Port.Equals(0))
                {
                    u2ec.ClientAddRemoteDevManually(licf.Ic.Server.Port.ToString());
                    showshared();
                    int SelectedIndex = 0;
                    u2ec.ClientStartRemoteDev(HandleClient, SelectedIndex, true, "");
                }
                else
                {
                    MessageBox.Show("connect error,system config is null");
                }
            }
            txt_port_stat.Text = "没有监听的接口状态";
            for (int i = 0; i < lssharedport.Count; i++)
            {
                if (getPortStat(i).Split('/')[1].Equals(licf.Ic.Server.Port.ToString()))
                {
                    txt_port_stat.Text = getPortStat(i);
                    txt_connectcontext.Text = lssharedport[i];
                }
            }

            //进入正常运行，判断端口状态
            //监控程序运行

            SwitchCoreServer_MyCall();

            Console.WriteLine("System start finished in" + DateTime.Now.ToString());
            Trace.WriteLine("System start finished in" + DateTime.Now.ToString());



        }

        void SwitchCoreServer_MyCall()
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            TreeViewServer.Nodes.Clear();
            CreateServer();
            TreeViewServer_AfterSelect(this, null);
            showshared();
        }

        private void CreateServer()
        {
            HandleServer = (IntPtr)0;
            toolStripStatusLbl.Text = "有设备变动" + DateTime.Now.ToLongTimeString();
            if (u2ec.ServerCreateEnumUsbDev(out HandleServer))
                EnumHubToList(HandleServer, HandleServer, TreeViewServer.Nodes.Add("USB list device"));
        }

        private void EnumHubToList(IntPtr Context, IntPtr HubContext, TreeNode Parent)
        {
            node = Parent;
            if (Context != HubContext)
            {
                object strName = null;
                u2ec.ServerGetUsbDevName(Context, HubContext, out strName);
                node = Parent.Nodes.Add(strName.ToString());
                node.Tag = HubContext;
            }


            IntPtr HandleDev = (IntPtr)0;
            for (int index = 0; u2ec.ServerGetUsbDevFromHub(Context, HubContext, index, out HandleDev); ++index)
                if (u2ec.ServerUsbDevIsHub(Context, HandleDev))
                    EnumHubToList(Context, HandleDev, node);
                else
                    node.Nodes.Add(BuildServerDevName(Context, HandleDev)).Tag = HandleDev;
            node.ExpandAll();
            FlushDevListToBox();
        }

        private void FlushDevListToBox()
        {
            listBoxDev.Items.Clear();
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                listBoxDev.Items.Add(node.Nodes[i].Text);
            }
        }


        private string BuildServerDevName(IntPtr Context, IntPtr HandleDev)
        {
            object strName = null;
            u2ec.ServerGetUsbDevName(Context, HandleDev, out strName);
            string devName = strName.ToString();

            object Connect = null;
            int state = 0;

            if (u2ec.ServerGetUsbDevStatus(Context, HandleDev, out state, out Connect) &&
                u2ec.ServerGetSharedUsbDevNetSettings(Context, HandleDev, out strName))
            {
                string name = strName.ToString();
                devName = devName + " / Shared - " + (name.Contains(':') ? "callback:" : "") + name;
                if (Connect.ToString().Length > 0 && state == u2ec.STATE_CONNECTED)
                    devName = devName + " / Connected to " + Connect.ToString();
            }

            return devName;
        }

        private IntPtr HandleServer;
        private IntPtr HandleClient;

        private void SwichCoreServer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SocketTL stlc = new SocketTL();
            stlc.sent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //开启新的线程测试，暂时关闭KC
            //Control.CheckForIllegalCrossThreadCalls = false;
            //Thread thread = new Thread(setrecive);
            //thread.IsBackground = true;
            //thread.Start(); 

            //测试一个关于心跳post的代码
            string req = HttpGP.HttpPost(@"http://tcis.bjzsxx.com/tcis/dt/heartBeat/updateListenTaxControlPanelHeartBeat", "nsrsbh=91440300319797090X&kjh=0&status=1");
            MessageBox.Show(req);
        }

        private void setrecive()
        {
            SocketTL stl = new SocketTL();
            stl.connectwait();
        }

        private void showshared()
        {
            //ListBoxClient.Items.Clear();

            if (HandleClient != (IntPtr)0)
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);

            if (u2ec.ClientEnumAvailRemoteDev(out HandleClient))
                EnumRemoteDev(HandleClient);

            for (int i = 0; i < lssharedport.Count; i++)
            {
                if (getPortStat(i).Split('/')[1].Equals(licf.Ic.Server.Port.ToString()))
                {
                    txt_port_stat.Text = getPortStat(i);
                    String tempstr = txt_connectcontext.Text;
                    txt_connectcontext.Text = lssharedport[i];

                    if (tempstr.Split('/').Length < lssharedport[i].Split('/').Length)
                    {
                        //连接设备
                        if (lssharedport[i].Split('/').Length > 2)
                        {
                            //连接设备发送设备连接心跳码
                            heartbeat.postHeartbeat(heartbeat.genDataStr01(licf.Ic.Heartbeat.Nsrsbh, licf.Ic.Heartbeat.Kjh, "0"));
                            for (int j = 0; j < 5; j++)
                            {
                                try
                                {
                                    String filepathname = licf.Ic.Process.S["s-" + j.ToString()];
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
                                            threadC.Start(licf.Ic.Process.S["s-" + j.ToString()]);
                                        }
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
                    }
                    else if (tempstr.Split('/').Length > lssharedport[i].Split('/').Length)
                    {
                        //断开设备
                        //断开设备发送设备连接心跳码
                        heartbeat.postHeartbeat(heartbeat.genDataStr01(licf.Ic.Heartbeat.Nsrsbh, licf.Ic.Heartbeat.Kjh, "3"));
                        for (int j = 0; j < 5; j++)
                        {
                            try
                            {
                                if (listBoxlog.Items.Count > 400) listBoxlog.Items.Clear();
                                listBoxlog.Items.Add(licf.Ic.Process.P["p-" + j.ToString()]);
                                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName(licf.Ic.Process.P["p-" + j.ToString()]);
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
                    else
                    {
                        //没有啥变化
                    }
                }
            }
        }

        private void EnumRemoteDev(IntPtr Handle)
        {
            lssharedport.Clear();
            int sumport = 0;
            object Name = null;
            for (int index = 0; BuildClientName(Handle, index, out Name); ++index)
            {
                Console.WriteLine(Name);
                lssharedport.Add(Convert.ToString(Name));
                sumport += 1;
            }

            txt_portnum.Text = sumport.ToString();

            //MessageBox.Show(Name.ToString());   
            //ListBoxClient.Items.Add(Name);
            //ListBoxClient_SelectedIndexChanged(this, null);
        }

        private bool BuildClientName(IntPtr Context, int Index, out object Name)
        {
            object strName = null;

            if (!u2ec.ClientGetRemoteDevName(HandleClient, Index, out strName))
            {
                Name = null;
                return false;
            }

            string name = strName.ToString();
            string strNetSettings;
            if (name.Length == 0)
                name = "Unknown";
            object NetSettings = null;
            u2ec.ClientGetRemoteDevNetSettings(HandleClient, Index, out NetSettings);
            object Host = null;
            int State = 0;
            strNetSettings = NetSettings.ToString();

            name = name + "/";
            if ((NetSettings.ToString().Contains("RDP")) == false && (strNetSettings.Contains(':')) == false)
            {
                name = name + "callback:";

            }
            name = name + strNetSettings;

            if (u2ec.ClientGetStateRemoteDev(HandleClient, Index, out State, out Host))
            {
                if (State == u2ec.STATE_CONNECTED && strNetSettings.Length > 0)
                    name = name + "/connected to " + strNetSettings;
            }
            Name = name;
            return true;
        }

        private void btn_addport_Click(object sender, EventArgs e)
        {
            u2ec.ClientAddRemoteDevManually(licf.Ic.Server.Port.ToString());
            //ListBoxClient_SelectedIndexChanged(this, null);
            showshared();
        }

        private void btn_getstat_Click(object sender, EventArgs e)
        {
            //int index = ListBoxClient.SelectedIndex;
            int index = 0;
            int State = 0;
            object Host = null;
            object NetSettings = null;

            if (u2ec.ClientGetRemoteDevNetSettings(HandleClient, index, out NetSettings))
            {
                u2ec.ClientGetStateRemoteDev(HandleClient, index, out State, out Host);

                string result;
                if (u2ec.STATE_CONNECTED == State)
                    result = "connected";
                else if (u2ec.STATE_WAITING == State)
                    result = "connecting";
                else
                    result = "added";

                result = result + "/" + NetSettings.ToString();
                if (u2ec.STATE_CONNECTED == State)
                    result = result + "/" + Host.ToString();
                MessageBox.Show(result);

            }


        }

        private String getPortStat(int indexs)
        {
            int State = 0;
            object Host = null;
            object NetSettings = null;

            if (u2ec.ClientGetRemoteDevNetSettings(HandleClient, indexs, out NetSettings))
            {
                u2ec.ClientGetStateRemoteDev(HandleClient, indexs, out State, out Host);

                string result;
                if (u2ec.STATE_CONNECTED == State)
                    result = "connected";
                else if (u2ec.STATE_WAITING == State)
                    result = "connecting";
                else
                    result = "added";

                result = result + "/" + NetSettings.ToString();
                if (u2ec.STATE_CONNECTED == State)
                    result = result + "/" + Host.ToString();
                return result;

            }
            return "null";
        }


        private void btn_connect_Click(object sender, EventArgs e)
        {
            int SelectedIndex = 0;
            u2ec.ClientStartRemoteDev(HandleClient, SelectedIndex, true, "");
            //ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            //int SelectedIndex = 0;
            //u2ec.ClientStopRemoteDev(HandleClient, SelectedIndex);
            ////ListBoxClient_SelectedIndexChanged(this, null);

            int index = 0;
            u2ec.ClientRemoveRemoteDev(HandleClient, index);
            object Name = null;
            //if (BuildClientName(HandleClient, index, out Name))
            //    ListBoxClient.Items[index] = Name;

            //ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void TreeViewServer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeViewServer.SelectedNode == null)
            {
                //ServerShare.Enabled = ServerUnshare.Enabled = ServerState.Enabled = false;
                return;
            }

            if (TreeViewServer.SelectedNode.Tag == null)
            {
                //ServerShare.Enabled = ServerUnshare.Enabled = ServerState.Enabled = false;
                return;
            }

            IntPtr DevHandle = (IntPtr)TreeViewServer.SelectedNode.Tag;

            bool shared = u2ec.ServerUsbDevIsShared(HandleServer, DevHandle);
            //ServerShare.Enabled = !shared && DevHandle != (IntPtr)0 && !u2ec.ServerUsbDevIsHub(HandleServer, DevHandle);

            //ServerUnshare.Enabled = ServerState.Enabled = shared;
        }

        private void btn_removeport_Click(object sender, EventArgs e)
        {
            int index = 0; //ListBoxClient.SelectedIndex;
            u2ec.ClientRemoveRemoteDev(HandleClient, index);
            object Name = null;
            if (BuildClientName(HandleClient, index, out Name))
                Console.WriteLine(Name);
            //ListBoxClient.Items[index] = Name;

            //ListBoxClient_SelectedIndexChanged(this, null);
            showshared();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadIniConfigFile licf = new LoadIniConfigFile(Environment.CurrentDirectory + "\\config.ini");
            MessageBox.Show(licf.initConfig().ToString());
            MessageBox.Show(licf.Ic.Heartbeat.Hbpath);

            //OPini.InitSystem();

            //MessageBox.Show(this.node.Nodes.Count.ToString());

            //SwitchCoreServer_MyCall();

            //showshared();

            //try
            //{
            //    MessageBox.Show(dictionary["s-0"]);
            //    MessageBox.Show(dictionary["s-1"]);
            //    MessageBox.Show(dictionary["s-2"]);
            //}
            //catch (KeyNotFoundException ex) {
            //    Console.Write(ex.Message);
            //}

            //Process[] procs = Process.GetProcesses();
            //listBoxP.Items.Clear();
            //for (int i = 0; i < procs.Length; i++)
            //{
            //    Process q = procs[i];
            //    listBoxP.Items.Add(q.ProcessName);
            //}



            //Process p = procs[0];
            //int procId = p.Id;
            //Process p2 = Process.GetProcessById(procId);

            //String sn = dictionary["s-0"];
            //String[] spi = sn.Split('\\');
            //if (spi.Length > 1)
            //{
            //    MessageBox.Show(spi[1]);
            //}

            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            //p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            //p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息
            //p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            //p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            //p.Start();//启动程序

            ////向cmd窗口发送输入信息
            //p.StandardInput.WriteLine(dictionary["s-0"]);

            //p.StandardInput.AutoFlush = true;
            ////p.StandardInput.WriteLine("exit");
            ////向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            ////同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            ////获取cmd窗口的输出信息
            ////string output = p.StandardOutput.ReadToEnd();

            ////StreamReader reader = p.StandardOutput;
            ////string line=reader.ReadLine();
            ////while (!reader.EndOfStream)
            ////{
            ////    str += line + "  ";
            ////    line = reader.ReadLine();
            ////}

            //p.WaitForExit();//等待程序执行完退出进程
            //p.Close();

            //MessageBox.Show(output);
            //Console.WriteLine(output);

            //MessageBox.Show(dictionary["s-0"]);
            //Process.Start(@"C:\Users\BJZS\Desktop\startup - 快捷方式.lnk");

            //try
            //{
            //    System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName(dictionary["p-0"]);
            //    foreach (System.Diagnostics.Process p in ps)
            //    {
            //        p.Kill();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            //Process.Start(dictionary["s-0"]);

            //Thread threadC = new Thread(closeApp);
            //threadC.Start(dictionary);

        }

        private void ShowRemoveDev_Click(object sender, EventArgs e)
        {
            //ListBoxClient.Items.Clear();

            if (HandleClient != (IntPtr)0)
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);

            if (u2ec.ClientEnumAvailRemoteDev(out HandleClient))
                EnumRemoteDev(HandleClient);
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
            return licf.Ic.Delay.Time * 1000;
        }

        public static void RunCmdWithoutResult(string file, string command, bool wait)
        {
            //创建实例
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //设定调用的程序名，不是系统目录的需要完整路径
            p.StartInfo.FileName = file;
            //传入执行参数
            p.StartInfo.Arguments = " " + command;
            p.StartInfo.UseShellExecute = false;
            //是否重定向标准输入
            p.StartInfo.RedirectStandardInput = false;
            //是否重定向标准转出
            p.StartInfo.RedirectStandardOutput = false;
            //是否重定向错误
            p.StartInfo.RedirectStandardError = false;
            //执行时是不是显示窗口
            p.StartInfo.CreateNoWindow = true;
            //启动
            p.Start();
            if (wait)
            {
                //是不是需要等待结束
                p.WaitForExit();
            }
            p.Close();
        }

        private void menuItem_SetDelay_Click(object sender, EventArgs e)
        {
            subwindows.FrmSetDelay fsd = new subwindows.FrmSetDelay(txt_kpDelay);
            fsd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Process.Start(@"C:\Users\lineb\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Accessories\Notepad");
            Thread threadC = new Thread(closeApp);
            threadC.Start(@"C:\Users\lineb\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Accessories\Notepad");
        }

        private void menuAboutMe_Click(object sender, EventArgs e)
        {
            subwindows.FrmAboutMe fam = new subwindows.FrmAboutMe();
            fam.ShowDialog();
        }

        //启动服务端
        Socket SocketUdp;
        Socket SocketTcp;
        delegate void SetTextCallBack(string text);

        private void btn_listen_Click(object sender, EventArgs e)
        {
            //socket.StartForm sf = new socket.StartForm();
            //sf.Hide();


            //TCP类型
            SocketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint ep = new IPEndPoint(IPAddress.Any, 3000);
            SocketTcp.Bind(ep);
            SocketTcp.Listen(3000);
            Thread th = new Thread(new ThreadStart(ReceiveMsg));
            th.IsBackground = true;
            th.Start();
            label2.Text = "服务器已启动";
            button1.Enabled = false;


        }


        public void ReceiveMsg()
        {
            //while (true)
            //{
            //    byte[] buffer = new byte[5555];
            //    EndPoint ep = new IPEndPoint(IPAddress.Any, 3000);
            //    int lea = SocketUdp.ReceiveFrom(buffer, ref ep);//接收远程;
            //    string msg = Encoding.Unicode.GetString(buffer, 0, lea);
            //    SetText(msg);
            //}


            while (true)
            {
                Socket client = SocketTcp.Accept();
                byte[] buffer = new byte[1024];
                int lea = client.Receive(buffer);//接收远程;
                string msg = Encoding.UTF8.GetString(buffer, 0, lea);
                SetText(msg);
                client.Close();
            }
        }

        public void SetText(string text)
        {
            //在这里，我强调一下，为什么我会用invoke呢，或许很多人对此不太了解，如果不用的话，会报错。我会另外抽时间给大家讲解下invoke,beigninvoke，多线程，委托与事件之间的联系的，反正大家先这么写着。
            if (rtxt_resmsg.InvokeRequired)
            {
                SetTextCallBack st = new SetTextCallBack(SetText);
                this.Invoke(st, new object[] { text });

            }
            else
            {
                rtxt_resmsg.Text += DateTime.Now.ToString() + "\n" + text + "\n" + "abcdefgBJZSXX";
            }
        }






    }
}

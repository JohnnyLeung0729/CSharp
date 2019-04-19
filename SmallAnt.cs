using small_ant.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using u2ec_example.socket;
using u2ec_example.subwindows;

namespace small_ant
{
    public partial class SmallAnt : Form
    {
        /// <summary>
        /// NetWork管理器入口
        /// </summary>
        public event u2ec.OnChangeDevList MyCall;

        #region   检查设备需要的树目录
        List<String> lssharedport = new List<string>();
        private TreeView TreeViewServer = new TreeView();
        private TreeNode node = new TreeNode();
        #endregion

        #region   心跳机制，系统路径，以及配置文件管理类
        private Heartbeat heartbeat;
        private String syspath;
        LoadIniConfigFile licf;
        #endregion

        //保持连接状态锁
        bool connectingLock;
        string prestatus = "";
        string statusfull = "";

        private IntPtr HandleServer;
        private IntPtr HandleClient;

        public SmallAnt()
        {
            InitializeComponent();

            //绑定设备变化监控操作过程接口
            MyCall += new u2ec.OnChangeDevList(OnChangeDevList_MyCall);
            u2ec.SetCallBackOnChangeDevList(MyCall);

            //设置本地系统配置文件路径
            syspath = Environment.CurrentDirectory + "\\config.ini";
            //加载系统配置文件
            licf = new LoadIniConfigFile(syspath);
            Trace.WriteLine("Load Syspath configpath.ini file status is:--- " + DateTime.Now.ToString() + " --- " + licf.initConfig().ToString());

            //端口在这里，还是单机单端口版本
            lbl_confport.Text = licf.Ic.Server.Port.ToString();
            //初始化其余端口状态数值
            lbl_kpDelay.Text = licf.Ic.Delay.Time.ToString();
            lbl_listenport.Text = licf.Ic.Listen.Port.ToString();
            this.Text = this.Text + "【" + licf.Ic.Heartbeat.Nsrsbh + ":" + licf.Ic.Heartbeat.Kjh + "】";
            connectingLock = cb_waitclock.Checked;

            //心跳机制
            heartbeat = new Heartbeat(licf.Ic.Heartbeat.Hbpath);

            //刷新显示目前所有共享设备状态
            showshared();

            ///
            /// 判断是否有共享的设备，如果没有共享的设备，则判断是否配置文件有配置端口
            /// 如果有端口则开放该端口进行共享
            /// 这里有逻辑问题！！！！！！
            /// 
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
                    Trace.WriteLine("init connect error,system config ini file is has null value");
                    MessageBox.Show(small_ant.Properties.Resources.iniPortError, small_ant.Properties.Resources.errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            lbl_port_stat.Text = "没有监听的接口状态";
            for (int i = 0; i < lssharedport.Count; i++)
            {
                btn_getstatus_Click(i, null);
                if (statusfull.Split('/')[1].Equals(licf.Ic.Server.Port.ToString()))
                {
                    lbl_port_stat.Text = statusfull;
                    lbl_connectcontext.Text = lssharedport[i];
                }
            }


            //进入正常运行，判断端口状态
            //监控程序运行

            OnChangeDevList_MyCall();
        }

        void OnChangeDevList_MyCall()
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            TreeViewServer.Nodes.Clear();
            CreateServer();
            TreeViewServer_AfterSelect(this, null);
            showshared();

            btn_getstatus_Click(null, null);
        }

        /// <summary>
        /// 建立本地服务器基础信息，方便后面列出本机usb设备树
        /// </summary>
        private void CreateServer()
        {
            HandleServer = (IntPtr)0;
            tssl1.Text = small_ant.Properties.Resources.hasDevChangeStatus + DateTime.Now.ToLongTimeString();
            if (u2ec.ServerCreateEnumUsbDev(out HandleServer))
                EnumHubToList(HandleServer, HandleServer, TreeViewServer.Nodes.Add("USB list device"));
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

        private void showshared()
        {
            //ListBoxClient.Items.Clear();

            if (HandleClient != (IntPtr)0)
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);

            if (u2ec.ClientEnumAvailRemoteDev(out HandleClient))
                EnumRemoteDev(HandleClient);   //枚举远程连接设备，本机作为客户端

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

        /// <summary>
        /// 枚举获取设备信息
        /// </summary>
        /// <param name="Handle">客户端指针</param>
        private void EnumRemoteDev(IntPtr Handle)
        {
            lssharedport.Clear();   //清除客户端开放端口列表队列信息
            int sumport = 0;   //初始化队列指针为0
            object Name = null;   //设备名称
            for (int index = 0; BuildClientName(Handle, index, out Name); ++index)
            {
                Trace.WriteLine(small_ant.Properties.Resources.catchportstatus + "--- ---" + Name);
                lssharedport.Add(Convert.ToString(Name));   //EG:  Unknown/callback:20000
                sumport += 1;
            }

            lbl_portnum.Text = sumport.ToString();   //刷新获取的接口数量


            //ListBoxClient.Items.Add(Name);
            //ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void closeApp(object dic)
        {
            Trace.WriteLine("Start job path ::"+Convert.ToString(dic));
            Thread.Sleep(licf.Ic.Delay.Time * 1000);
            try
            {
                System.Diagnostics.Process.Start(Convert.ToString(dic));
            }
            catch (Win32Exception ex)
            {
                Trace.WriteLine("Start job has error ::"+ex.Message);
                MessageBox.Show("通常这个问题是因为配置文件中需要启动的程序路径不正确导致，请检查配置文件，若仍然无法解决，请联系开发者！", "启动故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// 在listBoxDev控件中展示当前服务器USB设备信息
        /// </summary>
        private void FlushDevListToBox()
        {
            listBoxDev.Items.Clear();
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                listBoxDev.Items.Add(node.Nodes[i].Text);
            }
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

        private void btn_getstatus_Click(object sender, EventArgs e)
        {
            //int index = ListBoxClient.SelectedIndex;
            int index = 0;
            int State = 0;
            object Host = null;
            object NetSettings = null;

            //在这里进行判断是否将index参数变成活动参数
            if (sender != null)
            {
                if (sender.GetType().Equals(1.GetType()))
                {
                    index = Convert.ToInt32(sender);
                }
            }

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

                String tmp = result;//记录新刷出状态

                result = result + "/" + NetSettings.ToString();
                if (u2ec.STATE_CONNECTED == State)
                    result = result + "/" + Host.ToString();
                statusfull = result;
                if (e != null) MessageBox.Show(result);

                //对状态进行操作，根据连接锁和状态进行判断，是否保持连接状态
                if (!tmp.Equals(prestatus))
                {
                    if (cb_waitclock.Checked)
                    {
                        //如果没有连接，就打开连接，但是要勾选连接锁
                        if (tmp.Equals("added")) tbtn_connect_Click(null, null);
                        prestatus = tmp;
                    }
                    if (tmp.Equals("connected"))//设备连接事件
                    {
                        //连接设备发送设备连接心跳码
                        heartbeat.postHeartbeat(heartbeat.genDataStr01(licf.Ic.Heartbeat.Nsrsbh, licf.Ic.Heartbeat.Kjh, "0"));
                        //遍历开启应用信息
                        int applen = licf.Ic.Process.S.Count;
                        for (int j = 0; j < applen; j++)
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
                                        //threadC.Start(licf.Ic.Process.S["s-" + j.ToString()]);
                                        threadC.Start(filepathname);
                                    }
                                }
                                else
                                {
                                    Thread threadC = new Thread(closeApp);
                                    //threadC.Start(licf.Ic.Process.S["s-" + j.ToString()]);
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
                    else if (prestatus.Equals("connected"))//设备中断事件
                    {
                        //断开设备
                        //断开设备发送设备连接心跳码
                        heartbeat.postHeartbeat(heartbeat.genDataStr01(licf.Ic.Heartbeat.Nsrsbh, licf.Ic.Heartbeat.Kjh, "3"));
                        int prolen = licf.Ic.Process.P.Count;
                        for (int j = 0; j < prolen; j++)
                        {
                            try
                            {
                                if (listBoxPlog.Items.Count > 400) listBoxPlog.Items.Clear();
                                listBoxPlog.Items.Add(licf.Ic.Process.P["p-" + j.ToString()]);
                                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName(licf.Ic.Process.P["p-" + j.ToString()]);
                                foreach (System.Diagnostics.Process p in ps)
                                {
                                    Trace.WriteLine("Find and kill P name is:" + p.ProcessName);
                                    p.Kill();
                                }
                            }
                            catch (KeyNotFoundException enfx)
                            {
                                Trace.WriteLine(enfx.Message);
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex.Message);
                                throw ex;
                            }
                        }
                    }
                }
                prestatus = tmp;
                Trace.WriteLine("Change Dev Status:" + result);

            }
        }

        private void tbtn_disconnect_Click(object sender, EventArgs e)
        {
            int SelectedIndex = 0;
            u2ec.ClientStopRemoteDev(HandleClient, SelectedIndex);
            ////ListBoxClient_SelectedIndexChanged(this, null);

            //int index = 0;
            //u2ec.ClientRemoveRemoteDev(HandleClient, index);
            object Name = null;
            //if (BuildClientName(HandleClient, index, out Name))
            //    ListBoxClient.Items[index] = Name;

            //ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void tbtn_removeport_Click(object sender, EventArgs e)
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

        private void tbtn_addport_Click(object sender, EventArgs e)
        {
            u2ec.ClientAddRemoteDevManually(licf.Ic.Server.Port.ToString());
            //ListBoxClient_SelectedIndexChanged(this, null);
            showshared();
        }

        private void tbtn_connect_Click(object sender, EventArgs e)
        {
            int SelectedIndex = 0;
            u2ec.ClientStartRemoteDev(HandleClient, SelectedIndex, true, "");
            //ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void lbl_textshow_Click(object sender, EventArgs e)
        {
            Label se = (Label)sender;
            MessageBox.Show(se.Text);
        }

        private void tbtn_aboutme_Click(object sender, EventArgs e)
        {
            FrmAboutMe fam = new FrmAboutMe();
            fam.ShowDialog();
        }

        private void menuItem_SetDelay_Click(object sender, EventArgs e)
        {
            u2ec_example.subwindows.FrmSetDelay fsd = new u2ec_example.subwindows.FrmSetDelay(lbl_kpDelay);
            fsd.ShowDialog();
        }

        private void btn_softreset_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(btn_softreset.GetType()))
            {
                MessageBox.Show(small_ant.Properties.Resources.softstartcontext,small_ant.Properties.Resources.softstarttitle,MessageBoxButtons.OK,MessageBoxIcon.Information);

                cb_waitclock.Checked = false;
                Button bsr = (Button)sender;
                bsr.Enabled = false;

                Thread.Sleep(2000);
                tbtn_disconnect_Click(null, null);


                Thread.Sleep(8000);
                btn_getstatus_Click(null, null);
                tbtn_removeport_Click(null, null);


                Thread.Sleep(2000);
                tbtn_addport_Click(null, null);


                Thread.Sleep(2000);
                tbtn_connect_Click(null, null);
                btn_getstatus_Click(null, null);

                bsr.Enabled = true;
                cb_waitclock.Checked = true;
            }
        }
    }
}

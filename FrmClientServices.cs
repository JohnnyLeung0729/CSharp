using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace u2ec_example
{
    public partial class FrmClientServices : Form
    {
        public event u2ec.OnChangeDevList MyCall;


        public FrmClientServices()
        {
            InitializeComponent();



            MyCall += new u2ec.OnChangeDevList(Form1_MyCall);
            u2ec.SetCallBackOnChangeDevList(MyCall);

            //u2ec.SetCallBackOnChangeDevList(this.ChangeDevList);

        }

        void Form1_MyCall()
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            treeViewServer.Nodes.Clear();
            CreateServer();
            treeViewServer_AfterSelect(this, null);
        }

        private IntPtr HandleServer;
        private IntPtr HandleClient;

        private void CreateServer()
        {
            HandleServer = (IntPtr)0;
            if (u2ec.ServerCreateEnumUsbDev(out HandleServer))
                EnumHubToList(HandleServer, HandleServer, treeViewServer.Nodes.Add("USB list device"));
        }

        private void EnumHubToList(IntPtr Context, IntPtr HubContext, TreeNode Parent)
        {
            TreeNode node = Parent;
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

        private void listBoxdevs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool ret = listBoxdevs.SelectedIndex != -1;

            int State = 0;
            object Host;

            if (ret)
            {
                ret = u2ec.ClientGetStateRemoteDev(HandleClient, listBoxdevs.SelectedIndex, out State, out Host);
                //ClientAddDev.Enabled = !ret;
                //ClientState.Enabled = ClientRemoteDev.Enabled = ret;
                //ClientConnect.Enabled = ret && !(State > 0);
                //ClientDisconnect.Enabled = ret && (State > 0);
            }
            //else
                //ClientAddDev.Enabled = ClientRemoteDev.Enabled =
                    //ClientConnect.Enabled = ClientDisconnect.Enabled =
                    //ClientState.Enabled = false;
        }

        private void treeViewServer_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void FrmClientServices_Load(object sender, EventArgs e)
        {
            HandleClient = (IntPtr)0;
            CreateServer();
            u2ec.SetCallBackOnChangeDevList(OnChangeDevList);
        }

        public void OnChangeDevList()
        {
            Button1_Click(null, null);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            treeViewServer.Nodes.Clear();
            CreateServer();
            treeViewServer_AfterSelect(this, null);
        }

        private void btn_flushDevSev_Click(object sender, EventArgs e)
        {
            listBoxdevs.Items.Clear();

            if (HandleClient != (IntPtr)0)
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);

            if (u2ec.ClientEnumAvailRemoteDev(out HandleClient))
                EnumRemoteDev(HandleClient);
        }

        private void EnumRemoteDev(IntPtr Handle)
        {
            object Name = null;
            for (int index = 0; BuildClientName(Handle, index, out Name); ++index)
                listBoxdevs.Items.Add(Name);
            listBoxdevs_SelectedIndexChanged(this, null);
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

            name = name + " / ";
            if ((NetSettings.ToString().Contains("RDP")) == false && (strNetSettings.Contains(':')) == false)
            {
                name = name + "callback:";

            }
            name = name + strNetSettings;

            if (u2ec.ClientGetStateRemoteDev(HandleClient, Index, out State, out Host))
            {
                if (State == u2ec.STATE_CONNECTED && strNetSettings.Length > 0)
                    name = name + " / connected to " + strNetSettings;
            }
            Name = name;
            return true;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            u2ec.ClientStartRemoteDev(HandleClient, listBoxdevs.SelectedIndex, true, "");
            listBoxdevs_SelectedIndexChanged(this, null);
        }

        private void btn_clientstate_Click(object sender, EventArgs e)
        {
            int index = listBoxdevs.SelectedIndex;
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


    }
}

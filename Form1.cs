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
    
    
    
    public partial class Form1 : Form
    {
        public event u2ec.OnChangeDevList MyCall;
        
        public Form1()
        {
            InitializeComponent();
            
            

            MyCall += new u2ec.OnChangeDevList(Form1_MyCall);
            u2ec.SetCallBackOnChangeDevList(MyCall);

            //u2ec.SetCallBackOnChangeDevList(this.ChangeDevList);
        }

        public void Test()
        {
            MyCall();
        
        }

        void Form1_MyCall()
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            TreeViewServer.Nodes.Clear();
            CreateServer();
            TreeViewServer_AfterSelect(this, null);
        }        
        
        

        //**********************
        public void ChangeDevList()
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            TreeViewServer.Nodes.Clear();
            CreateServer();
            TreeViewServer_AfterSelect(this, null);            
        
        }

        private IntPtr HandleServer;
        private IntPtr HandleClient;

        private void Button1_Click(object sender, EventArgs e)
        {
            u2ec.ServerRemoveEnumUsbDev(HandleServer);
            TreeViewServer.Nodes.Clear();
            CreateServer();
            TreeViewServer_AfterSelect(this, null);
        }

        private void CreateServer()
        {
            HandleServer = (IntPtr)0;
            if (u2ec.ServerCreateEnumUsbDev(out HandleServer))
                EnumHubToList(HandleServer, HandleServer, TreeViewServer.Nodes.Add("USB list device"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HandleClient = (IntPtr)0;
            CreateServer();
            u2ec.SetCallBackOnChangeDevList(OnChangeDevList);
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

        private void ServerState_Click(object sender, EventArgs e)
        {
            int State = 0;
            object Host, NetSettings;
            IntPtr devHandle = (IntPtr)TreeViewServer.SelectedNode.Tag;
            u2ec.ServerGetUsbDevStatus(HandleServer, devHandle, out State, out Host);
            u2ec.ServerGetSharedUsbDevNetSettings(HandleServer, devHandle, out NetSettings);

            string result = "";
            if (State == u2ec.STATE_CONNECTED)
                result = "connected / " + NetSettings.ToString() + " / " + Host.ToString();
            else if (State == u2ec.STATE_WAITING)
                result = "waiting for connection / " + NetSettings.ToString();

            MessageBox.Show(result);
        }

        private void ServerUnshare_Click(object sender, EventArgs e)
        {
            IntPtr devHandle = (IntPtr)TreeViewServer.SelectedNode.Tag;
            u2ec.ServerUnshareUsbDev(HandleServer, devHandle);
            TreeViewServer.SelectedNode.Text = BuildServerDevName(HandleServer, devHandle);
        }

        private void TreeViewServer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeViewServer.SelectedNode == null)
            {
                ServerShare.Enabled = ServerUnshare.Enabled = ServerState.Enabled = false;
                return;
            }

            if (TreeViewServer.SelectedNode.Tag == null)
            {
                ServerShare.Enabled = ServerUnshare.Enabled = ServerState.Enabled = false;
                return;
            }

            IntPtr DevHandle = (IntPtr)TreeViewServer.SelectedNode.Tag;

            bool shared = u2ec.ServerUsbDevIsShared(HandleServer, DevHandle);
            ServerShare.Enabled = !shared && DevHandle != (IntPtr)0 && !u2ec.ServerUsbDevIsHub(HandleServer, DevHandle);

            ServerUnshare.Enabled = ServerState.Enabled = shared;
        }

        private void ServerShare_Click(object sender, EventArgs e)
        {
            IntPtr Handle = (IntPtr)TreeViewServer.SelectedNode.Tag;
            u2ec.ServerShareUsbDev(HandleServer, Handle, TextBoxServerTcp.Text, TextBoxDesc.Text, false, "", false, false);
            TreeViewServer.SelectedNode.Text = BuildServerDevName(HandleServer, Handle);
            TreeViewServer_AfterSelect(this, null);
        }

        private void ClientFind_Click(object sender, EventArgs e)
        {
            ListBoxClient.Items.Clear();

            if (HandleClient != (IntPtr)0)
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);

            if (u2ec.ClientEnumAvailRemoteDevOnServer(TextBoxFindServer.Text, out HandleClient))
                EnumRemoteDev(HandleClient);

            ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void ListBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool ret = ListBoxClient.SelectedIndex != -1;

            int State = 0;
            object Host;

            if (ret)
            {
                ret = u2ec.ClientGetStateRemoteDev(HandleClient, ListBoxClient.SelectedIndex, out State, out Host);
                ClientAddDev.Enabled = !ret;
                ClientState.Enabled = ClientRemoteDev.Enabled = ret;
                ClientConnect.Enabled = ret && !(State > 0);
                ClientDisconnect.Enabled = ret && (State > 0);
            }
            else
                ClientAddDev.Enabled = ClientRemoteDev.Enabled =
                    ClientConnect.Enabled = ClientDisconnect.Enabled =
                    ClientState.Enabled = false;
        }

        private void EnumRemoteDev(IntPtr Handle)
        {
            object Name = null;
            for (int index = 0; BuildClientName(Handle, index, out Name); ++index)
                ListBoxClient.Items.Add(Name);
            ListBoxClient_SelectedIndexChanged(this, null);
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

        private void ClientAddDev_Click(object sender, EventArgs e)
        {
            object Name = null;
            int selected = ListBoxClient.SelectedIndex;
            u2ec.ClientAddRemoteDev(HandleClient, selected);
            if (BuildClientName(HandleClient, selected, out Name))
                ListBoxClient.Items[selected] = Name;
            ListBoxClient_SelectedIndexChanged(this, null);
        }


        //*****************************ShowRemoveDev********************************
        private void ShowRemoveDev_Click(object sender, EventArgs e)
        {
            ListBoxClient.Items.Clear();

            if (HandleClient != (IntPtr)0)
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);

            if (u2ec.ClientEnumAvailRemoteDev(out HandleClient))
                EnumRemoteDev(HandleClient);
        }



        private void ClientRemoteDev_Click(object sender, EventArgs e)
        {
            int index = ListBoxClient.SelectedIndex;
            u2ec.ClientRemoveRemoteDev(HandleClient, index);
            object Name = null;
            if (BuildClientName(HandleClient, index, out Name))
                ListBoxClient.Items[index] = Name;

            ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void ClientConnect_Click(object sender, EventArgs e)
        {
            u2ec.ClientStartRemoteDev(HandleClient, ListBoxClient.SelectedIndex, true, "");
            ListBoxClient_SelectedIndexChanged(this, null);
        }

        private void ClientDisconnect_Click(object sender, EventArgs e)
        {
            u2ec.ClientStopRemoteDev(HandleClient, ListBoxClient.SelectedIndex);
            ListBoxClient_SelectedIndexChanged(this, null);
        }

        //*********************ClientState***************************************************
        private void ClientState_Click(object sender, EventArgs e)
        {
            int index = ListBoxClient.SelectedIndex;
            int State = 0;
            object Host = null;
            object NetSettings = null;

            if (u2ec.ClientGetRemoteDevNetSettings(HandleClient, index, out NetSettings))
            {
                u2ec.ClientGetStateRemoteDev(HandleClient, index, out State, out Host);

                string result;
                if(u2ec.STATE_CONNECTED == State)
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

        private void CleintAddManual_Click(object sender, EventArgs e)
        {
            u2ec.ClientAddRemoteDevManually(TextBoxClinetTcp.Text);
            ListBoxClient_SelectedIndexChanged(this, null);
        }

        public void OnChangeDevList()
        {
            Button1_Click(null, null);
        }


        //********************ShowRemoveDev2******************************************
        private void ShowRemoveDev2_Click(object sender, EventArgs e)
        {
            ListBoxClient.Items.Clear();

            if (HandleClient != (IntPtr)0)
            {
                u2ec.ClientRemoveEnumOfRemoteDev(HandleClient);
                HandleClient = (IntPtr)0;
            }

            if (u2ec.ClientEnumRemoteDevOverRdp(out HandleClient))
                EnumRemoteDev(HandleClient);

        }
    }
   
}

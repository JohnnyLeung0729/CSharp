namespace u2ec_example
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label9 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.TextBoxServerTcp = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ClientState = new System.Windows.Forms.Button();
            this.ClientRemoteDev = new System.Windows.Forms.Button();
            this.ClientDisconnect = new System.Windows.Forms.Button();
            this.ClientConnect = new System.Windows.Forms.Button();
            this.ServerShare = new System.Windows.Forms.Button();
            this.TextBoxDesc = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ListBoxClient = new System.Windows.Forms.ListBox();
            this.ShowRemoveDev = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.ClientFind = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxFindServer = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ClientAddDev = new System.Windows.Forms.Button();
            this.ServerState = new System.Windows.Forms.Button();
            this.ServerUnshare = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.CleintAddManual = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBoxClinetTcp = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TreeViewServer = new System.Windows.Forms.TreeView();
            this.label10 = new System.Windows.Forms.Label();
            this.ShowRemoveDev2 = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(238, 437);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(23, 13);
            this.Label9.TabIndex = 43;
            this.Label9.Text = "OR";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.TextBoxServerTcp);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Location = new System.Drawing.Point(3, 207);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(399, 92);
            this.GroupBox3.TabIndex = 37;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "TCP and callback settings";
            // 
            // TextBoxServerTcp
            // 
            this.TextBoxServerTcp.Location = new System.Drawing.Point(9, 63);
            this.TextBoxServerTcp.Name = "TextBoxServerTcp";
            this.TextBoxServerTcp.Size = new System.Drawing.Size(382, 20);
            this.TextBoxServerTcp.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(6, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(385, 44);
            this.Label1.TabIndex = 3;
            this.Label1.Text = resources.GetString("Label1.Text");
            // 
            // ClientState
            // 
            this.ClientState.Enabled = false;
            this.ClientState.Location = new System.Drawing.Point(407, 592);
            this.ClientState.Name = "ClientState";
            this.ClientState.Size = new System.Drawing.Size(75, 23);
            this.ClientState.TabIndex = 36;
            this.ClientState.Text = "Get status";
            this.ClientState.UseVisualStyleBackColor = true;
            this.ClientState.Click += new System.EventHandler(this.ClientState_Click);
            // 
            // ClientRemoteDev
            // 
            this.ClientRemoteDev.Enabled = false;
            this.ClientRemoteDev.Location = new System.Drawing.Point(3, 592);
            this.ClientRemoteDev.Name = "ClientRemoteDev";
            this.ClientRemoteDev.Size = new System.Drawing.Size(99, 23);
            this.ClientRemoteDev.TabIndex = 33;
            this.ClientRemoteDev.Text = "Remove device";
            this.ClientRemoteDev.UseVisualStyleBackColor = true;
            this.ClientRemoteDev.Click += new System.EventHandler(this.ClientRemoteDev_Click);
            // 
            // ClientDisconnect
            // 
            this.ClientDisconnect.Enabled = false;
            this.ClientDisconnect.Location = new System.Drawing.Point(322, 592);
            this.ClientDisconnect.Name = "ClientDisconnect";
            this.ClientDisconnect.Size = new System.Drawing.Size(75, 23);
            this.ClientDisconnect.TabIndex = 35;
            this.ClientDisconnect.Text = "Disconnect";
            this.ClientDisconnect.UseVisualStyleBackColor = true;
            this.ClientDisconnect.Click += new System.EventHandler(this.ClientDisconnect_Click);
            // 
            // ClientConnect
            // 
            this.ClientConnect.Enabled = false;
            this.ClientConnect.Location = new System.Drawing.Point(241, 592);
            this.ClientConnect.Name = "ClientConnect";
            this.ClientConnect.Size = new System.Drawing.Size(75, 23);
            this.ClientConnect.TabIndex = 34;
            this.ClientConnect.Text = "Connect";
            this.ClientConnect.UseVisualStyleBackColor = true;
            this.ClientConnect.Click += new System.EventHandler(this.ClientConnect_Click);
            // 
            // ServerShare
            // 
            this.ServerShare.Enabled = false;
            this.ServerShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerShare.Location = new System.Drawing.Point(408, 252);
            this.ServerShare.Name = "ServerShare";
            this.ServerShare.Size = new System.Drawing.Size(75, 47);
            this.ServerShare.TabIndex = 26;
            this.ServerShare.Text = "Share";
            this.ServerShare.UseVisualStyleBackColor = true;
            this.ServerShare.Click += new System.EventHandler(this.ServerShare_Click);
            // 
            // TextBoxDesc
            // 
            this.TextBoxDesc.Location = new System.Drawing.Point(157, 181);
            this.TextBoxDesc.Name = "TextBoxDesc";
            this.TextBoxDesc.Size = new System.Drawing.Size(325, 20);
            this.TextBoxDesc.TabIndex = 42;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(2, 184);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(145, 13);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "Additional device description:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(2, 33);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(87, 13);
            this.Label8.TabIndex = 40;
            this.Label8.Text = "USB devices list:";
            // 
            // Label6
            // 
            this.Label6.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Label6.BackColor = System.Drawing.Color.LightBlue;
            this.Label6.Location = new System.Drawing.Point(-13, 311);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(525, 23);
            this.Label6.TabIndex = 39;
            this.Label6.Text = "Connect to remote shared USB devices (client connection)";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label5
            // 
            this.Label5.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Label5.BackColor = System.Drawing.Color.LightBlue;
            this.Label5.Location = new System.Drawing.Point(-13, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(525, 23);
            this.Label5.TabIndex = 38;
            this.Label5.Text = "Share local USB devices  (server connection)";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListBoxClient
            // 
            this.ListBoxClient.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ListBoxClient.FormattingEnabled = true;
            this.ListBoxClient.Location = new System.Drawing.Point(3, 461);
            this.ListBoxClient.Name = "ListBoxClient";
            this.ListBoxClient.Size = new System.Drawing.Size(480, 121);
            this.ListBoxClient.TabIndex = 32;
            this.ListBoxClient.SelectedIndexChanged += new System.EventHandler(this.ListBoxClient_SelectedIndexChanged);
            // 
            // ShowRemoveDev
            // 
            this.ShowRemoveDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowRemoveDev.Location = new System.Drawing.Point(45, 432);
            this.ShowRemoveDev.Name = "ShowRemoveDev";
            this.ShowRemoveDev.Size = new System.Drawing.Size(177, 23);
            this.ShowRemoveDev.TabIndex = 31;
            this.ShowRemoveDev.Text = "Show added remote devices";
            this.ShowRemoveDev.UseVisualStyleBackColor = true;
            this.ShowRemoveDev.Click += new System.EventHandler(this.ShowRemoveDev_Click);
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(7, 44);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(341, 27);
            this.Label7.TabIndex = 13;
            this.Label7.Text = "Note: enter server name and press find. Choose one device from list and click \"Ad" +
                "d device\"";
            // 
            // ClientFind
            // 
            this.ClientFind.Location = new System.Drawing.Point(369, 15);
            this.ClientFind.Name = "ClientFind";
            this.ClientFind.Size = new System.Drawing.Size(82, 23);
            this.ClientFind.TabIndex = 2;
            this.ClientFind.Text = "Find";
            this.ClientFind.UseVisualStyleBackColor = true;
            this.ClientFind.Click += new System.EventHandler(this.ClientFind_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.ClientFind);
            this.GroupBox1.Controls.Add(this.TextBoxFindServer);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.ClientAddDev);
            this.GroupBox1.Location = new System.Drawing.Point(2, 346);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(480, 78);
            this.GroupBox1.TabIndex = 29;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Find shared devices on remote server";
            // 
            // TextBoxFindServer
            // 
            this.TextBoxFindServer.Location = new System.Drawing.Point(91, 18);
            this.TextBoxFindServer.Name = "TextBoxFindServer";
            this.TextBoxFindServer.Size = new System.Drawing.Size(257, 20);
            this.TextBoxFindServer.TabIndex = 1;
            this.TextBoxFindServer.Text = "localhost";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(79, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Remote server:";
            // 
            // ClientAddDev
            // 
            this.ClientAddDev.Enabled = false;
            this.ClientAddDev.Location = new System.Drawing.Point(368, 44);
            this.ClientAddDev.Name = "ClientAddDev";
            this.ClientAddDev.Size = new System.Drawing.Size(83, 23);
            this.ClientAddDev.TabIndex = 12;
            this.ClientAddDev.Text = "Add device";
            this.ClientAddDev.UseVisualStyleBackColor = true;
            this.ClientAddDev.Click += new System.EventHandler(this.ClientAddDev_Click);
            // 
            // ServerState
            // 
            this.ServerState.Enabled = false;
            this.ServerState.Location = new System.Drawing.Point(311, 28);
            this.ServerState.Name = "ServerState";
            this.ServerState.Size = new System.Drawing.Size(83, 23);
            this.ServerState.TabIndex = 28;
            this.ServerState.Text = "Get status";
            this.ServerState.UseVisualStyleBackColor = true;
            this.ServerState.Click += new System.EventHandler(this.ServerState_Click);
            // 
            // ServerUnshare
            // 
            this.ServerUnshare.Enabled = false;
            this.ServerUnshare.Location = new System.Drawing.Point(400, 28);
            this.ServerUnshare.Name = "ServerUnshare";
            this.ServerUnshare.Size = new System.Drawing.Size(83, 23);
            this.ServerUnshare.TabIndex = 27;
            this.ServerUnshare.Text = "Unshare";
            this.ServerUnshare.UseVisualStyleBackColor = true;
            this.ServerUnshare.Click += new System.EventHandler(this.ServerUnshare_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(222, 28);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(83, 23);
            this.Button1.TabIndex = 25;
            this.Button1.Text = "Refresh";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // CleintAddManual
            // 
            this.CleintAddManual.Location = new System.Drawing.Point(379, 18);
            this.CleintAddManual.Name = "CleintAddManual";
            this.CleintAddManual.Size = new System.Drawing.Size(95, 50);
            this.CleintAddManual.TabIndex = 2;
            this.CleintAddManual.Text = "Add device manually";
            this.CleintAddManual.UseVisualStyleBackColor = true;
            this.CleintAddManual.Click += new System.EventHandler(this.CleintAddManual_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.CleintAddManual);
            this.GroupBox2.Controls.Add(this.TextBoxClinetTcp);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Location = new System.Drawing.Point(3, 630);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(480, 77);
            this.GroupBox2.TabIndex = 30;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Add remote device manually (in case client PC cannot see server)";
            // 
            // TextBoxClinetTcp
            // 
            this.TextBoxClinetTcp.Location = new System.Drawing.Point(8, 48);
            this.TextBoxClinetTcp.Name = "TextBoxClinetTcp";
            this.TextBoxClinetTcp.Size = new System.Drawing.Size(365, 20);
            this.TextBoxClinetTcp.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(6, 18);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(367, 30);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Input server PC address and port (to connect to remote shared device) or specify " +
                "just a port number to listen for incoming connections (callback)";
            // 
            // TreeViewServer
            // 
            this.TreeViewServer.FullRowSelect = true;
            this.TreeViewServer.HideSelection = false;
            this.TreeViewServer.Location = new System.Drawing.Point(3, 55);
            this.TreeViewServer.Name = "TreeViewServer";
            this.TreeViewServer.Size = new System.Drawing.Size(480, 116);
            this.TreeViewServer.TabIndex = 24;
            this.TreeViewServer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewServer_AfterSelect);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 436);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "OR";
            // 
            // ShowRemoveDev2
            // 
            this.ShowRemoveDev2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowRemoveDev2.Location = new System.Drawing.Point(276, 431);
            this.ShowRemoveDev2.Name = "ShowRemoveDev2";
            this.ShowRemoveDev2.Size = new System.Drawing.Size(177, 23);
            this.ShowRemoveDev2.TabIndex = 45;
            this.ShowRemoveDev2.Text = "Show RDP remote devices";
            this.ShowRemoveDev2.UseVisualStyleBackColor = true;
            this.ShowRemoveDev2.Click += new System.EventHandler(this.ShowRemoveDev2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 718);
            this.Controls.Add(this.ShowRemoveDev2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.ClientState);
            this.Controls.Add(this.ClientRemoteDev);
            this.Controls.Add(this.ClientDisconnect);
            this.Controls.Add(this.ClientConnect);
            this.Controls.Add(this.ServerShare);
            this.Controls.Add(this.TextBoxDesc);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.ListBoxClient);
            this.Controls.Add(this.ShowRemoveDev);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ServerState);
            this.Controls.Add(this.ServerUnshare);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.TreeViewServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "C# U2EC Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.TextBox TextBoxServerTcp;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button ClientState;
        internal System.Windows.Forms.Button ClientRemoteDev;
        internal System.Windows.Forms.Button ClientDisconnect;
        internal System.Windows.Forms.Button ClientConnect;
        internal System.Windows.Forms.Button ServerShare;
        internal System.Windows.Forms.TextBox TextBoxDesc;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ListBox ListBoxClient;
        internal System.Windows.Forms.Button ShowRemoveDev;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button ClientFind;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBoxFindServer;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button ClientAddDev;
        internal System.Windows.Forms.Button ServerState;
        internal System.Windows.Forms.Button ServerUnshare;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button CleintAddManual;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox TextBoxClinetTcp;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TreeView TreeViewServer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ShowRemoveDev2;

    }

    
}


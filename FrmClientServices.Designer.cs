namespace u2ec_example
{
    partial class FrmClientServices
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
            this.listBoxdevs = new System.Windows.Forms.ListBox();
            this.treeViewServer = new System.Windows.Forms.TreeView();
            this.btn_flushDevSev = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_clientstate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxdevs
            // 
            this.listBoxdevs.FormattingEnabled = true;
            this.listBoxdevs.Location = new System.Drawing.Point(58, 214);
            this.listBoxdevs.Name = "listBoxdevs";
            this.listBoxdevs.Size = new System.Drawing.Size(528, 199);
            this.listBoxdevs.TabIndex = 0;
            this.listBoxdevs.SelectedIndexChanged += new System.EventHandler(this.listBoxdevs_SelectedIndexChanged);
            // 
            // treeViewServer
            // 
            this.treeViewServer.Location = new System.Drawing.Point(58, 42);
            this.treeViewServer.Name = "treeViewServer";
            this.treeViewServer.Size = new System.Drawing.Size(528, 97);
            this.treeViewServer.TabIndex = 1;
            this.treeViewServer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewServer_AfterSelect);
            // 
            // btn_flushDevSev
            // 
            this.btn_flushDevSev.Location = new System.Drawing.Point(58, 497);
            this.btn_flushDevSev.Name = "btn_flushDevSev";
            this.btn_flushDevSev.Size = new System.Drawing.Size(159, 23);
            this.btn_flushDevSev.TabIndex = 2;
            this.btn_flushDevSev.Text = "显示监听端口刷新";
            this.btn_flushDevSev.UseVisualStyleBackColor = true;
            this.btn_flushDevSev.Click += new System.EventHandler(this.btn_flushDevSev_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(272, 497);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "连接监听";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_clientstate
            // 
            this.btn_clientstate.Location = new System.Drawing.Point(475, 497);
            this.btn_clientstate.Name = "btn_clientstate";
            this.btn_clientstate.Size = new System.Drawing.Size(111, 23);
            this.btn_clientstate.TabIndex = 4;
            this.btn_clientstate.Text = "端口监听状态";
            this.btn_clientstate.UseVisualStyleBackColor = true;
            this.btn_clientstate.Click += new System.EventHandler(this.btn_clientstate_Click);
            // 
            // FrmClientServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 632);
            this.Controls.Add(this.btn_clientstate);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_flushDevSev);
            this.Controls.Add(this.treeViewServer);
            this.Controls.Add(this.listBoxdevs);
            this.Name = "FrmClientServices";
            this.Text = "FrmClientServices";
            this.Load += new System.EventHandler(this.FrmClientServices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxdevs;
        private System.Windows.Forms.TreeView treeViewServer;
        private System.Windows.Forms.Button btn_flushDevSev;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_clientstate;
    }
}
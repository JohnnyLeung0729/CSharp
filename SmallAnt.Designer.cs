namespace small_ant
{
    partial class SmallAnt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallAnt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_SetDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.设定指令监听端口PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出系统XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试系统TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_removeport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_addport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_connect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_aboutme = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_portnum = new System.Windows.Forms.Label();
            this.lbl_confport = new System.Windows.Forms.Label();
            this.lbl_port_stat = new System.Windows.Forms.Label();
            this.lbl_connectcontext = new System.Windows.Forms.Label();
            this.lbl_kpDelay = new System.Windows.Forms.Label();
            this.lbl_listenport = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxPlog = new System.Windows.Forms.ListBox();
            this.listBoxDev = new System.Windows.Forms.ListBox();
            this.btn_getstatus = new System.Windows.Forms.Button();
            this.cb_waitclock = new System.Windows.Forms.CheckBox();
            this.btn_softreset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtn_viewP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "监听端口数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "指令监听端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "开票系统延迟：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "连接设备信息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "监听端口状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "监听端口：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 33);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_SetDelay,
            this.设定指令监听端口PToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出系统XToolStripMenuItem});
            this.系统SToolStripMenuItem.Name = "系统SToolStripMenuItem";
            this.系统SToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.系统SToolStripMenuItem.Text = "系统(&S)";
            // 
            // menuItem_SetDelay
            // 
            this.menuItem_SetDelay.Name = "menuItem_SetDelay";
            this.menuItem_SetDelay.Size = new System.Drawing.Size(305, 30);
            this.menuItem_SetDelay.Text = "设定开票系统延迟时间(&T)";
            this.menuItem_SetDelay.Click += new System.EventHandler(this.menuItem_SetDelay_Click);
            // 
            // 设定指令监听端口PToolStripMenuItem
            // 
            this.设定指令监听端口PToolStripMenuItem.Name = "设定指令监听端口PToolStripMenuItem";
            this.设定指令监听端口PToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.设定指令监听端口PToolStripMenuItem.Text = "设定指令监听端口(P)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(302, 6);
            // 
            // 退出系统XToolStripMenuItem
            // 
            this.退出系统XToolStripMenuItem.Name = "退出系统XToolStripMenuItem";
            this.退出系统XToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.退出系统XToolStripMenuItem.Text = "退出系统(&X)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试系统TToolStripMenuItem,
            this.toolStripSeparator2,
            this.tbtn_aboutme});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // 测试系统TToolStripMenuItem
            // 
            this.测试系统TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_disconnect,
            this.tbtn_removeport,
            this.tbtn_addport,
            this.tbtn_connect,
            this.toolStripSeparator3,
            this.tbtn_viewP});
            this.测试系统TToolStripMenuItem.Name = "测试系统TToolStripMenuItem";
            this.测试系统TToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.测试系统TToolStripMenuItem.Text = "测试系统(&T)";
            // 
            // tbtn_disconnect
            // 
            this.tbtn_disconnect.Name = "tbtn_disconnect";
            this.tbtn_disconnect.Size = new System.Drawing.Size(210, 30);
            this.tbtn_disconnect.Text = "断开连接(&D)";
            this.tbtn_disconnect.Click += new System.EventHandler(this.tbtn_disconnect_Click);
            // 
            // tbtn_removeport
            // 
            this.tbtn_removeport.Name = "tbtn_removeport";
            this.tbtn_removeport.Size = new System.Drawing.Size(210, 30);
            this.tbtn_removeport.Text = "移除端口(&R)";
            this.tbtn_removeport.Click += new System.EventHandler(this.tbtn_removeport_Click);
            // 
            // tbtn_addport
            // 
            this.tbtn_addport.Name = "tbtn_addport";
            this.tbtn_addport.Size = new System.Drawing.Size(210, 30);
            this.tbtn_addport.Text = "添加端口(&A)";
            this.tbtn_addport.Click += new System.EventHandler(this.tbtn_addport_Click);
            // 
            // tbtn_connect
            // 
            this.tbtn_connect.Name = "tbtn_connect";
            this.tbtn_connect.Size = new System.Drawing.Size(210, 30);
            this.tbtn_connect.Text = "建立连接(&C)";
            this.tbtn_connect.Click += new System.EventHandler(this.tbtn_connect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // tbtn_aboutme
            // 
            this.tbtn_aboutme.Name = "tbtn_aboutme";
            this.tbtn_aboutme.Size = new System.Drawing.Size(210, 30);
            this.tbtn_aboutme.Text = "关于系统(&I)";
            this.tbtn_aboutme.Click += new System.EventHandler(this.tbtn_aboutme_Click);
            // 
            // lbl_portnum
            // 
            this.lbl_portnum.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_portnum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_portnum.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_portnum.Location = new System.Drawing.Point(170, 54);
            this.lbl_portnum.Name = "lbl_portnum";
            this.lbl_portnum.Size = new System.Drawing.Size(205, 25);
            this.lbl_portnum.TabIndex = 7;
            this.lbl_portnum.Click += new System.EventHandler(this.lbl_textshow_Click);
            // 
            // lbl_confport
            // 
            this.lbl_confport.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_confport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_confport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_confport.Location = new System.Drawing.Point(170, 98);
            this.lbl_confport.Name = "lbl_confport";
            this.lbl_confport.Size = new System.Drawing.Size(205, 25);
            this.lbl_confport.TabIndex = 8;
            this.lbl_confport.Click += new System.EventHandler(this.lbl_textshow_Click);
            // 
            // lbl_port_stat
            // 
            this.lbl_port_stat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_port_stat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_port_stat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_port_stat.Location = new System.Drawing.Point(170, 142);
            this.lbl_port_stat.Name = "lbl_port_stat";
            this.lbl_port_stat.Size = new System.Drawing.Size(205, 25);
            this.lbl_port_stat.TabIndex = 9;
            this.lbl_port_stat.Click += new System.EventHandler(this.lbl_textshow_Click);
            // 
            // lbl_connectcontext
            // 
            this.lbl_connectcontext.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_connectcontext.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_connectcontext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_connectcontext.Location = new System.Drawing.Point(170, 186);
            this.lbl_connectcontext.Name = "lbl_connectcontext";
            this.lbl_connectcontext.Size = new System.Drawing.Size(205, 25);
            this.lbl_connectcontext.TabIndex = 10;
            this.lbl_connectcontext.Click += new System.EventHandler(this.lbl_textshow_Click);
            // 
            // lbl_kpDelay
            // 
            this.lbl_kpDelay.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_kpDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_kpDelay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_kpDelay.Location = new System.Drawing.Point(170, 230);
            this.lbl_kpDelay.Name = "lbl_kpDelay";
            this.lbl_kpDelay.Size = new System.Drawing.Size(205, 25);
            this.lbl_kpDelay.TabIndex = 11;
            this.lbl_kpDelay.Click += new System.EventHandler(this.lbl_textshow_Click);
            // 
            // lbl_listenport
            // 
            this.lbl_listenport.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_listenport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_listenport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_listenport.Location = new System.Drawing.Point(170, 274);
            this.lbl_listenport.Name = "lbl_listenport";
            this.lbl_listenport.Size = new System.Drawing.Size(205, 25);
            this.lbl_listenport.TabIndex = 12;
            this.lbl_listenport.Click += new System.EventHandler(this.lbl_textshow_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 30);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl1
            // 
            this.tssl1.Name = "tssl1";
            this.tssl1.Size = new System.Drawing.Size(126, 25);
            this.tssl1.Text = "系统初始化中";
            // 
            // listBoxPlog
            // 
            this.listBoxPlog.FormattingEnabled = true;
            this.listBoxPlog.ItemHeight = 20;
            this.listBoxPlog.Location = new System.Drawing.Point(393, 377);
            this.listBoxPlog.Name = "listBoxPlog";
            this.listBoxPlog.Size = new System.Drawing.Size(373, 124);
            this.listBoxPlog.TabIndex = 14;
            // 
            // listBoxDev
            // 
            this.listBoxDev.FormattingEnabled = true;
            this.listBoxDev.ItemHeight = 20;
            this.listBoxDev.Location = new System.Drawing.Point(393, 247);
            this.listBoxDev.Name = "listBoxDev";
            this.listBoxDev.Size = new System.Drawing.Size(373, 124);
            this.listBoxDev.TabIndex = 15;
            // 
            // btn_getstatus
            // 
            this.btn_getstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_getstatus.Location = new System.Drawing.Point(25, 436);
            this.btn_getstatus.Name = "btn_getstatus";
            this.btn_getstatus.Size = new System.Drawing.Size(119, 65);
            this.btn_getstatus.TabIndex = 16;
            this.btn_getstatus.Text = "端口状态";
            this.btn_getstatus.UseVisualStyleBackColor = true;
            this.btn_getstatus.Click += new System.EventHandler(this.btn_getstatus_Click);
            // 
            // cb_waitclock
            // 
            this.cb_waitclock.AutoSize = true;
            this.cb_waitclock.Checked = true;
            this.cb_waitclock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_waitclock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_waitclock.Location = new System.Drawing.Point(170, 316);
            this.cb_waitclock.Name = "cb_waitclock";
            this.cb_waitclock.Size = new System.Drawing.Size(131, 26);
            this.cb_waitclock.TabIndex = 18;
            this.cb_waitclock.Text = "等待状态锁";
            this.cb_waitclock.UseVisualStyleBackColor = true;
            // 
            // btn_softreset
            // 
            this.btn_softreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_softreset.Location = new System.Drawing.Point(170, 436);
            this.btn_softreset.Name = "btn_softreset";
            this.btn_softreset.Size = new System.Drawing.Size(119, 65);
            this.btn_softreset.TabIndex = 19;
            this.btn_softreset.Text = "软重启键";
            this.btn_softreset.UseVisualStyleBackColor = true;
            this.btn_softreset.Click += new System.EventHandler(this.btn_softreset_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 65);
            this.button1.TabIndex = 20;
            this.button1.Text = "网络测试";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(170, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 65);
            this.button2.TabIndex = 21;
            this.button2.Text = "升级系统";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // tbtn_viewP
            // 
            this.tbtn_viewP.Name = "tbtn_viewP";
            this.tbtn_viewP.Size = new System.Drawing.Size(210, 30);
            this.tbtn_viewP.Text = "查看进程(&V)";
            this.tbtn_viewP.Click += new System.EventHandler(this.tbtn_viewP_Click);
            // 
            // SmallAnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_softreset);
            this.Controls.Add(this.cb_waitclock);
            this.Controls.Add(this.btn_getstatus);
            this.Controls.Add(this.listBoxDev);
            this.Controls.Add(this.listBoxPlog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_listenport);
            this.Controls.Add(this.lbl_kpDelay);
            this.Controls.Add(this.lbl_connectcontext);
            this.Controls.Add(this.lbl_port_stat);
            this.Controls.Add(this.lbl_confport);
            this.Controls.Add(this.lbl_portnum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SmallAnt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器共享交换核心";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SetDelay;
        private System.Windows.Forms.ToolStripMenuItem 设定指令监听端口PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出系统XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbtn_aboutme;
        private System.Windows.Forms.Label lbl_portnum;
        private System.Windows.Forms.Label lbl_confport;
        private System.Windows.Forms.Label lbl_port_stat;
        private System.Windows.Forms.Label lbl_connectcontext;
        private System.Windows.Forms.Label lbl_kpDelay;
        private System.Windows.Forms.Label lbl_listenport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
        private System.Windows.Forms.ListBox listBoxPlog;
        private System.Windows.Forms.ListBox listBoxDev;
        private System.Windows.Forms.Button btn_getstatus;
        private System.Windows.Forms.ToolStripMenuItem 测试系统TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbtn_disconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tbtn_removeport;
        private System.Windows.Forms.ToolStripMenuItem tbtn_addport;
        private System.Windows.Forms.ToolStripMenuItem tbtn_connect;
        private System.Windows.Forms.CheckBox cb_waitclock;
        private System.Windows.Forms.Button btn_softreset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tbtn_viewP;
    }
}
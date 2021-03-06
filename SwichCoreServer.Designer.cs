﻿namespace u2ec_example
{
    partial class SwitchCoreServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchCoreServer));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_addport = new System.Windows.Forms.Button();
            this.btn_getstat = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_removeport = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_portnum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_confport = new System.Windows.Forms.TextBox();
            this.statusStriplbl = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxDev = new System.Windows.Forms.ListBox();
            this.txt_port_stat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_connectcontext = new System.Windows.Forms.TextBox();
            this.listBoxP = new System.Windows.Forms.ListBox();
            this.listBoxlog = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_SetDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.设定指令监听端口PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_kpDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_listenport = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_listen = new System.Windows.Forms.Button();
            this.rtxt_resmsg = new System.Windows.Forms.RichTextBox();
            this.lbl_kpDelay = new System.Windows.Forms.Label();
            this.statusStriplbl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 418);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 462);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_addport
            // 
            this.btn_addport.Location = new System.Drawing.Point(18, 506);
            this.btn_addport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_addport.Name = "btn_addport";
            this.btn_addport.Size = new System.Drawing.Size(112, 34);
            this.btn_addport.TabIndex = 3;
            this.btn_addport.Text = "添加端口";
            this.btn_addport.UseVisualStyleBackColor = true;
            this.btn_addport.Click += new System.EventHandler(this.btn_addport_Click);
            // 
            // btn_getstat
            // 
            this.btn_getstat.Location = new System.Drawing.Point(140, 375);
            this.btn_getstat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_getstat.Name = "btn_getstat";
            this.btn_getstat.Size = new System.Drawing.Size(152, 34);
            this.btn_getstat.TabIndex = 4;
            this.btn_getstat.Text = "获取端口状态";
            this.btn_getstat.UseVisualStyleBackColor = true;
            this.btn_getstat.Click += new System.EventHandler(this.btn_getstat_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(18, 375);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(112, 34);
            this.btn_connect.TabIndex = 5;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(18, 418);
            this.btn_disconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(112, 34);
            this.btn_disconnect.TabIndex = 6;
            this.btn_disconnect.Text = "断开连接";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_removeport
            // 
            this.btn_removeport.Location = new System.Drawing.Point(18, 462);
            this.btn_removeport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_removeport.Name = "btn_removeport";
            this.btn_removeport.Size = new System.Drawing.Size(112, 34);
            this.btn_removeport.TabIndex = 7;
            this.btn_removeport.Text = "移除端口";
            this.btn_removeport.UseVisualStyleBackColor = true;
            this.btn_removeport.Click += new System.EventHandler(this.btn_removeport_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 506);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "读写INI";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "对外监听端口数量：";
            // 
            // txt_portnum
            // 
            this.txt_portnum.Location = new System.Drawing.Point(528, 64);
            this.txt_portnum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_portnum.Name = "txt_portnum";
            this.txt_portnum.ReadOnly = true;
            this.txt_portnum.Size = new System.Drawing.Size(204, 26);
            this.txt_portnum.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "配置接收监听端口：";
            // 
            // txt_confport
            // 
            this.txt_confport.Location = new System.Drawing.Point(528, 104);
            this.txt_confport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_confport.Name = "txt_confport";
            this.txt_confport.ReadOnly = true;
            this.txt_confport.Size = new System.Drawing.Size(204, 26);
            this.txt_confport.TabIndex = 13;
            // 
            // statusStriplbl
            // 
            this.statusStriplbl.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStriplbl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLbl});
            this.statusStriplbl.Location = new System.Drawing.Point(0, 706);
            this.statusStriplbl.Name = "statusStriplbl";
            this.statusStriplbl.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStriplbl.Size = new System.Drawing.Size(753, 30);
            this.statusStriplbl.TabIndex = 14;
            // 
            // toolStripStatusLbl
            // 
            this.toolStripStatusLbl.Name = "toolStripStatusLbl";
            this.toolStripStatusLbl.Size = new System.Drawing.Size(88, 25);
            this.toolStripStatusLbl.Text = "启动完毕";
            // 
            // listBoxDev
            // 
            this.listBoxDev.FormattingEnabled = true;
            this.listBoxDev.ItemHeight = 20;
            this.listBoxDev.Location = new System.Drawing.Point(351, 398);
            this.listBoxDev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxDev.Name = "listBoxDev";
            this.listBoxDev.Size = new System.Drawing.Size(380, 124);
            this.listBoxDev.TabIndex = 15;
            // 
            // txt_port_stat
            // 
            this.txt_port_stat.Location = new System.Drawing.Point(528, 142);
            this.txt_port_stat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_port_stat.Name = "txt_port_stat";
            this.txt_port_stat.ReadOnly = true;
            this.txt_port_stat.Size = new System.Drawing.Size(204, 26);
            this.txt_port_stat.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "监听端口状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "连接设备内容：";
            // 
            // txt_connectcontext
            // 
            this.txt_connectcontext.Location = new System.Drawing.Point(528, 183);
            this.txt_connectcontext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_connectcontext.Name = "txt_connectcontext";
            this.txt_connectcontext.ReadOnly = true;
            this.txt_connectcontext.Size = new System.Drawing.Size(204, 26);
            this.txt_connectcontext.TabIndex = 19;
            // 
            // listBoxP
            // 
            this.listBoxP.FormattingEnabled = true;
            this.listBoxP.ItemHeight = 20;
            this.listBoxP.Location = new System.Drawing.Point(18, 64);
            this.listBoxP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxP.Name = "listBoxP";
            this.listBoxP.Size = new System.Drawing.Size(271, 124);
            this.listBoxP.TabIndex = 20;
            // 
            // listBoxlog
            // 
            this.listBoxlog.FormattingEnabled = true;
            this.listBoxlog.ItemHeight = 20;
            this.listBoxlog.Location = new System.Drawing.Point(18, 549);
            this.listBoxlog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxlog.Name = "listBoxlog";
            this.listBoxlog.Size = new System.Drawing.Size(714, 124);
            this.listBoxlog.TabIndex = 21;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(753, 35);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_SetDelay,
            this.设定指令监听端口PToolStripMenuItem});
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
            this.设定指令监听端口PToolStripMenuItem.Text = "设定指令监听端口(&P)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAboutMe});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // menuAboutMe
            // 
            this.menuAboutMe.Name = "menuAboutMe";
            this.menuAboutMe.Size = new System.Drawing.Size(215, 30);
            this.menuAboutMe.Text = "关于系统（&I）";
            this.menuAboutMe.Click += new System.EventHandler(this.menuAboutMe_Click);
            // 
            // txt_kpDelay
            // 
            this.txt_kpDelay.Location = new System.Drawing.Point(528, 222);
            this.txt_kpDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_kpDelay.Name = "txt_kpDelay";
            this.txt_kpDelay.ReadOnly = true;
            this.txt_kpDelay.Size = new System.Drawing.Size(204, 26);
            this.txt_kpDelay.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "开票系统延迟：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(178, 216);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 25;
            this.button4.Text = "调试短指令";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_listenport
            // 
            this.txt_listenport.Location = new System.Drawing.Point(528, 284);
            this.txt_listenport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_listenport.Name = "txt_listenport";
            this.txt_listenport.ReadOnly = true;
            this.txt_listenport.Size = new System.Drawing.Size(204, 26);
            this.txt_listenport.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 288);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "指令监听端口：";
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(18, 216);
            this.btn_listen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(112, 34);
            this.btn_listen.TabIndex = 29;
            this.btn_listen.Text = "调试监听";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // rtxt_resmsg
            // 
            this.rtxt_resmsg.Location = new System.Drawing.Point(18, 267);
            this.rtxt_resmsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxt_resmsg.Name = "rtxt_resmsg";
            this.rtxt_resmsg.Size = new System.Drawing.Size(271, 97);
            this.rtxt_resmsg.TabIndex = 30;
            this.rtxt_resmsg.Text = "";
            // 
            // lbl_kpDelay
            // 
            this.lbl_kpDelay.AutoSize = true;
            this.lbl_kpDelay.Location = new System.Drawing.Point(340, 256);
            this.lbl_kpDelay.Name = "lbl_kpDelay";
            this.lbl_kpDelay.Size = new System.Drawing.Size(51, 20);
            this.lbl_kpDelay.TabIndex = 31;
            this.lbl_kpDelay.Text = "label7";
            // 
            // SwitchCoreServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(753, 736);
            this.Controls.Add(this.lbl_kpDelay);
            this.Controls.Add(this.rtxt_resmsg);
            this.Controls.Add(this.btn_listen);
            this.Controls.Add(this.txt_listenport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txt_kpDelay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxlog);
            this.Controls.Add(this.listBoxP);
            this.Controls.Add(this.txt_connectcontext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_port_stat);
            this.Controls.Add(this.listBoxDev);
            this.Controls.Add(this.statusStriplbl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txt_confport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_portnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_removeport);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_getstat);
            this.Controls.Add(this.btn_addport);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwitchCoreServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器共享交换核心";
            this.Load += new System.EventHandler(this.SwichCoreServer_Load);
            this.statusStriplbl.ResumeLayout(false);
            this.statusStriplbl.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_addport;
        private System.Windows.Forms.Button btn_getstat;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_removeport;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_portnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_confport;
        private System.Windows.Forms.StatusStrip statusStriplbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
        private System.Windows.Forms.ListBox listBoxDev;
        private System.Windows.Forms.TextBox txt_port_stat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_connectcontext;
        private System.Windows.Forms.ListBox listBoxP;
        private System.Windows.Forms.ListBox listBoxlog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SetDelay;
        private System.Windows.Forms.TextBox txt_kpDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAboutMe;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txt_listenport;
        private System.Windows.Forms.Label label6;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.ToolStripMenuItem 设定指令监听端口PToolStripMenuItem;
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.RichTextBox rtxt_resmsg;
        private System.Windows.Forms.Label lbl_kpDelay;
    }
}
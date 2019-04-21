namespace small_ant.subwindows
{
    partial class FrmListP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListP));
            this.lb_main = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_main
            // 
            this.lb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_main.FormattingEnabled = true;
            this.lb_main.ItemHeight = 20;
            this.lb_main.Location = new System.Drawing.Point(0, 0);
            this.lb_main.Name = "lb_main";
            this.lb_main.Size = new System.Drawing.Size(378, 244);
            this.lb_main.TabIndex = 0;
            // 
            // FrmListP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 244);
            this.Controls.Add(this.lb_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进程查看";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_main;
    }
}
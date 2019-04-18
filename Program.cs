using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace u2ec_example
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Trace.Listeners.Clear();
            Trace.Listeners.Add(new coresys.LogTraceListener());

            //Application.Run(new Form1());
            //Application.Run(new FrmClientServices());
            //SwitchCoreServer scs = new SwitchCoreServer();
            //scs.ShowDialog();
            Application.Run(new SwitchCoreServer());
        }
    }
}

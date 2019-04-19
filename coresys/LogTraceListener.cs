using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace u2ec_example.coresys
{
    class LogTraceListener : TraceListener
    {
        String logpath = Environment.CurrentDirectory + "\\";

        public override void Write(string message)
        {
            File.AppendAllText("d:\\log.log", message);
        }

        public override void WriteLine(string message)
        {
            File.AppendAllText(logpath+DateTime.Now.ToShortDateString()+".log", "Jonny Speak To You At " + DateTime.Now.ToString() + "::" + message + Environment.NewLine);
        }
    }
}

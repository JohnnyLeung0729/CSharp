using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace u2ec_example.coresys
{
    class LogTraceListener:TraceListener
    {
        public override void Write(string message)
        {
            File.AppendAllText("d:\\log.log", message);
        }

        public override void WriteLine(string message)
        {
            File.AppendAllText("d:\\log.log", message+Environment.NewLine);
        }
    }
}

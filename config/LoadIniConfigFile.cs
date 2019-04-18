using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using u2ec_example;

namespace small_ant.config
{
    class LoadIniConfigFile
    {
        String filepath = null;
        IniConf ic = new IniConf();

        public LoadIniConfigFile(String filepath)
        {
            this.filepath = filepath;
        }

        internal IniConf Ic
        {
            get
            {
                return ic;
            }

            set
            {
                ic = value;
            }
        }

        public bool initConfig()
        {
            OPini oi = new OPini(this.filepath);

            if (Ic.Server == null) Ic.Server = new Server();
            try { Ic.Server.Port = Convert.ToInt32(oi.ReadString("SERVER", "port", "0")); } catch { Ic.Server.Port = 0; }
            if (Ic.Delay == null) Ic.Delay = new Delay();
            try { Ic.Delay.Time = Convert.ToInt32(oi.ReadString("DELAY", "time", "1")); } catch { Ic.Delay.Time = 1; }
            if (Ic.Listen == null) Ic.Listen = new Listen();
            try { Ic.Listen.Port = Convert.ToInt32(oi.ReadString("LISTEN", "port", "0")); } catch { Ic.Listen.Port = 0; }
            if (Ic.Heartbeat == null) Ic.Heartbeat = new HeartBeat();
            try { Ic.Heartbeat.Hbpath = oi.ReadString("HEARTBEAT", "hbpath", "null"); } catch { Ic.Heartbeat.Hbpath = "null"; }
            try { Ic.Heartbeat.Nsrsbh = oi.ReadString("HEARTBEAT", "nsrsbh", "null"); } catch { Ic.Heartbeat.Nsrsbh = "null"; }
            try { Ic.Heartbeat.Kjh = oi.ReadString("HEARTBEAT", "kjh", "0"); } catch { Ic.Heartbeat.Kjh = "0"; }
            if (ic.Process == null) ic.Process = new Process(); ic.Process.P = new Dictionary<string, string>(); ic.Process.S = new Dictionary<string, string>(); ic.Process.E = new Dictionary<string, string>();
            int countnum = 0;
            bool flag = true;
            while (flag)
            {
                String temps = oi.ReadString("PROCESS", "p-" + countnum.ToString(), "null");
                if (!temps.Equals("null")) { ic.Process.P.Add("p-" + countnum.ToString(), temps); countnum += 1; } else { countnum = 0; flag = false; }
            }
            flag = true;
            while (flag)
            {
                String temps = oi.ReadString("PROCESS", "s-" + countnum.ToString(), "null");
                if (!temps.Equals("null")) { ic.Process.S.Add("s-" + countnum.ToString(), temps); countnum += 1; } else { countnum = 0; flag = false; }
            }
            flag = true;
            while (flag)
            {
                String temps = oi.ReadString("PROCESS", "e-" + countnum.ToString(), "null");
                if (!temps.Equals("null")) { ic.Process.E.Add("e-" + countnum.ToString(), temps); countnum += 1; } else { countnum = 0; flag = false; }
            }

            return true;
        }
    }
}

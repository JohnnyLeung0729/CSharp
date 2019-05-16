using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniOpLibs.sln
{
    public class SPSinitFileLoad
    {
        String filename;

        SPS sps=new SPS();
        public SPSinitFileLoad(String fullfilename) {
            filename = fullfilename;
        }

        public SPS Sps
        {
            get
            {
                return sps;
            }

            set
            {
                sps = value;
            }
        }

        public bool init_get_inifile() {
            INIfile inifile = new INIfile(filename);
            if (sps.Delay == null) sps.Delay = new SPSDelay();
            try { sps.Delay.Time = Convert.ToInt32(inifile.ReadString("DELAY", "time", "1")); } catch { sps.Delay.Time = 1; }
            if (sps.Process == null) sps.Process = new SPSprocess(); sps.Process.P = new Dictionary<string, string>(); sps.Process.S = new Dictionary<string, string>(); sps.Process.E = new Dictionary<string, string>();
            int countnum = 0;
            bool flag = true;
            while (flag)
            {
                String temps = inifile.ReadString("PROCESS", "p-" + countnum.ToString(), "null");
                if (!temps.Equals("null")) { sps.Process.P.Add("p-" + countnum.ToString(), temps); countnum += 1; } else { countnum = 0; flag = false; }
            }
            flag = true;
            while (flag)
            {
                String temps = inifile.ReadString("PROCESS", "s-" + countnum.ToString(), "null");
                if (!temps.Equals("null")) { sps.Process.S.Add("s-" + countnum.ToString(), temps); countnum += 1; } else { countnum = 0; flag = false; }
            }
            flag = true;
            while (flag)
            {
                String temps = inifile.ReadString("PROCESS", "e-" + countnum.ToString(), "null");
                if (!temps.Equals("null")) { sps.Process.E.Add("e-" + countnum.ToString(), temps); countnum += 1; } else { countnum = 0; flag = false; }
            }
            return true;
        }
    }
}

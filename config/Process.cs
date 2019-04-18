using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace small_ant.config
{
    class Process
    {
        Dictionary<String, String> p;
        Dictionary<String, String> s;
        Dictionary<String, String> e;

        public Dictionary<string, string> P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }

        public Dictionary<string, string> S
        {
            get
            {
                return s;
            }

            set
            {
                s = value;
            }
        }

        public Dictionary<string, string> E
        {
            get
            {
                return e;
            }

            set
            {
                e = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniOpLibs.sln
{
    public class SPS
    {
        SPSprocess process;
        SPSDelay delay;

        public SPSprocess Process
        {
            get
            {
                return process;
            }

            set
            {
                process = value;
            }
        }

        public SPSDelay Delay
        {
            get
            {
                return delay;
            }

            set
            {
                delay = value;
            }
        }
    }
}

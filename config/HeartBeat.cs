using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace small_ant.config
{
    class HeartBeat
    {
        String hbpath;
        String nsrsbh;
        String kjh;

        public string Hbpath
        {
            get
            {
                return hbpath;
            }

            set
            {
                hbpath = value;
            }
        }

        public string Nsrsbh
        {
            get
            {
                return nsrsbh;
            }

            set
            {
                nsrsbh = value;
            }
        }

        public string Kjh
        {
            get
            {
                return kjh;
            }

            set
            {
                kjh = value;
            }
        }
    }
}

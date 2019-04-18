using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace u2ec_example.socket
{
    public class Heartbeat
    {
        string httppath_;
        public Heartbeat(string httppath) {
            httppath_ = httppath;
        }

        public string postHeartbeat(string postdata) {
            return HttpGP.HttpPost(httppath_, postdata);
        }

        public string genDataStr01(string nsrsbh,string kjh,string status) {
            return "nsrsbh="+nsrsbh+"&kjh="+kjh+"&status="+status;
        }
    }
}

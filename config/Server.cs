using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace small_ant.config
{
    class Server
    {
        int port;

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace small_ant.config
{
    class IniConf
    {
        Server server;
        Process process;
        Delay delay;
        Listen listen;
        HeartBeat heartbeat;

        bool datalock=false;

        internal Server Server
        {
            get
            {
                return server;
            }

            set
            {
                server = value;
            }
        }

        internal Process Process
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

        internal Delay Delay
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

        internal Listen Listen
        {
            get
            {
                return listen;
            }

            set
            {
                listen = value;
            }
        }

        internal HeartBeat Heartbeat
        {
            get
            {
                return heartbeat;
            }

            set
            {
                heartbeat = value;
            }
        }

        public bool Datalock
        {
            get
            {
                return datalock;
            }

            set
            {
                datalock = value;
            }
        }
    }
}

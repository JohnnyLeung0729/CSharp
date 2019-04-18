using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace u2ec_example.socket
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

                socket.SoServer ss = new socket.SoServer();
        }
    }
}

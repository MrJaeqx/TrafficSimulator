using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TrafficMessageReceiver
{
    public partial class PoliceForm : Form
    {
        // proxy om de TrafficMessageService te gebruiken
        private TrafficMessageService.TrafficMessageClient myTrafficMessageProxy;
        
        public PoliceForm()
        {
            InitializeComponent();
            myTrafficMessageProxy = new TrafficMessageReceiver.TrafficMessageService.TrafficMessageClient();

            ServerLbl.Text = myTrafficMessageProxy.GetServerName();

        }

        private void RetrieveMessage_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = myTrafficMessageProxy.RetrieveMessage();
        }
    }
}

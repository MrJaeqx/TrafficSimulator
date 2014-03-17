using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficMessageSender
{
    public partial class MessageSenderForm : Form
    {
        // proxy om de TrafficMessageService te gebruiken
        private TrafficMessageService.TrafficMessageClient myTrafficMessageProxy;

        private Random r;
        
        public MessageSenderForm()
        {
            InitializeComponent();
            myTrafficMessageProxy = new TrafficMessageService.TrafficMessageClient();
            r = new Random();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myTrafficMessageProxy.SendRedLight(r.Next(1, 999), r.Next(1, 999), RandomDate());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myTrafficMessageProxy.SendSpeeding(r.Next(1, 999), r.Next(1, 250), RandomDate());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myTrafficMessageProxy.SendAccident(r.Next(1, 999), RandomDate());
        }

        private DateTime RandomDate()
        {
            return new DateTime(r.Next(1900, 2015), r.Next(1, 12), r.Next(1, 28), r.Next(1, 24), r.Next(1, 60), r.Next(1, 60));
        }
    }
}

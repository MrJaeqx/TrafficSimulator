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
        
        public MessageSenderForm()
        {
            InitializeComponent();
            myTrafficMessageProxy = new TrafficMessageService.TrafficMessageClient();

        }

        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            // VOEG ZELF TOE 
            // code om de message in messageTextBox te versturen via web service TrafficMessageService als de user op de button klikt
            // na afloop moet de TextBox weer leeg zijn

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficMessageReceiver
{
    public partial class SettingsForm : Form
    {

        public string ServerName { get; private set; }
        public string ServerPort { get; private set; }

        public SettingsForm(string servername, string serverport)
        {
            InitializeComponent();
            this.ServerName = servername;
            this.ServerPort = serverport;
            textBoxServer.Text = servername;
            textBoxPort.Text = serverport;
        }

        private void textChanged(object sender, EventArgs e)
        {
            ServerName = textBoxServer.Text;
            ServerPort = textBoxPort.Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

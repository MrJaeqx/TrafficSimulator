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
        public bool AutoRefresh { get; private set; }
        public int RefreshTime { get; private set; }

        public SettingsForm(string servername, string serverport, bool autorefresh, int refreshtime)
        {
            InitializeComponent();
            this.ServerName = servername;
            this.ServerPort = serverport;
            this.AutoRefresh = autorefresh;
            this.RefreshTime = refreshtime;

            textBoxServer.Text = servername;
            textBoxPort.Text = serverport;
            checkBoxRefresh.Checked = autorefresh;
            comboBoxRefresh.SelectedIndex = refreshtime;
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

        private void checkBoxRefresh_CheckedChanged(object sender, EventArgs e)
        {
            AutoRefresh = checkBoxRefresh.Checked;

            if (checkBoxRefresh.Checked)
            {
                comboBoxRefresh.Enabled = true;
            }
            else
            {
                comboBoxRefresh.Enabled = false;
            }
        }

        private void comboBoxRefresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTime = comboBoxRefresh.SelectedIndex;
        }
    }
}

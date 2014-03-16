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
        /// <summary>
        /// IP of naam van de server.
        /// </summary>
        public string ServerName { get; private set; }
        /// <summary>
        /// Poort nummer van de server.
        /// </summary>
        public string ServerPort { get; private set; }
        /// <summary>
        /// Automatisch vernieuwen.
        /// </summary>
        public bool AutoRefresh { get; private set; }
        /// <summary>
        /// Interval voor automatisch vernieuwen.
        /// </summary>
        public int RefreshTime { get; private set; }

        /// <summary>
        /// SettingsForm.
        /// </summary>
        /// <param name="servername">Ip of naam van de server.</param>
        /// <param name="serverport">Poort nummer van de server.</param>
        /// <param name="autorefresh">Automatisch vernieuwen.</param>
        /// <param name="refreshtime">Interval voor automatisch vernieuwen.</param>
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

        /// <summary>
        /// De juiste properties bijwerken als de waarde van de server naam of port zijn aangepast.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void textChanged(object sender, EventArgs e)
        {
            ServerName = textBoxServer.Text;
            ServerPort = textBoxPort.Text;
        }

        /// <summary>
        /// Event voor het sluiten van het venster. Werkt alleen indien de ESC toets is ingedrukt.
        /// </summary>
        /// <param name="msg">Niet gebruikt.</param>
        /// <param name="keyData">Ingedrukte toets.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Event voor het bijwerken van de ComboBox en juiste property indien de CheckBox veranderd.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
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

        /// <summary>
        /// Event indien de ComboBox voor automatisch vernieuwen interval wordt bijgewerkt. Werkt de juiste property bij.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void comboBoxRefresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTime = comboBoxRefresh.SelectedIndex;
        }
    }
}

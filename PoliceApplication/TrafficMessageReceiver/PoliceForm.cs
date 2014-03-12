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
    public partial class PoliceForm : Form
    {

        private int currentMode = 0;
        private string servername = "10.0.2.15";
        private string serverport = "8000";
        private PoliceData data;
        private List<ListViewItem> listItems;

        public PoliceForm()
        {
            InitializeComponent();
            toggleViewEvent(buttonOverview, null);
        }

        private void updateList()
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();
            switch (currentMode)
            {
                case 0:
                    listView1.Columns.AddRange(ListViewColumns.Overview);
                    //startBackgroundServerConenction();
                    break;
                case 1:
                    listView1.Columns.AddRange(ListViewColumns.Speedings);
                    startBackgroundServerConenction();
                    break;
                case 2:
                    listView1.Columns.AddRange(ListViewColumns.RedLight);
                    startBackgroundServerConenction();
                    break;
                case 3:
                    listView1.Columns.AddRange(ListViewColumns.Accident);
                    startBackgroundServerConenction();
                    break;
            }
        }

        private void toggleViewEvent(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == buttonOverview.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonHighlight;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                currentMode = 0;
                updateList();
            }
            else if (button.Name == buttonSpeedings.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonHighlight;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                currentMode = 1;
                updateList();
            }
            else if (button.Name == buttonRedlight.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonHighlight;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                currentMode = 2;
                updateList();
            }
            else if (button.Name == buttonAccident.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonHighlight;
                currentMode = 3;
                updateList();
            }
        }

        private void refreshEvent(object sender, EventArgs e)
        {
            updateList();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
                   }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(servername, serverport);
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                servername = settingsForm.ServerName;
                serverport = settingsForm.ServerPort;
            }

        }

        private void startBackgroundServerConenction()
        {
            labelStatus.Text = "Server: " + servername + ":" + serverport;
            progressBar.Visible = true;
            this.Enabled = false;
            backgroundServerConnection.RunWorkerAsync();
        }

        private void backgroundServerConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            listItems = new List<ListViewItem>();
            data = new PoliceData(servername, serverport);
            switch (currentMode)
            {
                case 0:
                    break;
                case 1:
                    List<Speeding> speedings = data.GetSpeedings();
                    foreach (Speeding speeding in speedings)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", "00-00-000", speeding.timeToString(), speeding.carID.ToString(), speeding.carSpeed.ToString() });
                        listItems.Add(item);
                    }
                    break;
                case 2:
                    List<RedLight> redlights = data.GetRedLights();
                    foreach (RedLight redlight in redlights)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", "00-00-000", redlight.timeToString(), redlight.carID.ToString(), redlight.trafficLightID.ToString() });
                        listItems.Add(item);
                    }
                    break;
                case 3:
                    List<Accident> accidents = data.GetAccidents();
                    foreach (Accident accident in accidents)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", "00-00-000", accident.timeToString(), accident.junctionID.ToString() });
                        listItems.Add(item);
                    }
                    break;
            }
        }

        private void backgroundServerConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listView1.Items.AddRange(listItems.ToArray());
            progressBar.Visible = false;
            this.Enabled = true;
        }

    }
}

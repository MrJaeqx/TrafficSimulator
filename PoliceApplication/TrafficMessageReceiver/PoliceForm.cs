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

        public PoliceForm()
        {
            InitializeComponent();
            data = new PoliceData(servername, serverport);
            toggleViewEvent(buttonOverview, null);
        }

        private void updateList()
        {
            listView1.Clear();
            data.GetAccidents();
            switch (currentMode)
            {
                case 0:
                    listView1.Columns.AddRange(ListViewColumns.Overview);
                    break;
                case 1:
                    listView1.Columns.AddRange(ListViewColumns.Speedings);
                    List<Speeding> speedings = data.GetSpeedings();
                    foreach (Speeding speeding in speedings)
                    {
                        ListViewItem item = new ListViewItem(new[] {"0", "00-00-000", speeding.timeToString(), speeding.carID.ToString(), speeding.carSpeed.ToString()});
                        listView1.Items.Add(item);
                    }
                    break;
                case 2:
                    listView1.Columns.AddRange(ListViewColumns.RedLight);
                    List<RedLight> redlights = data.GetRedLights();
                    foreach (RedLight redlight in redlights)
                    {
                        ListViewItem item = new ListViewItem(new[] {"0", "00-00-000", redlight.timeToString(), redlight.carID.ToString(), redlight.trafficLightID.ToString()});
                        listView1.Items.Add(item);
                    }
                    break;
                case 3:
                    listView1.Columns.AddRange(ListViewColumns.Accident);
                    List<Accident> accidents = data.GetAccidents();
                    foreach (Accident accident in accidents)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", "00-00-000", accident.timeToString(), accident.junctionID.ToString() });
                        listView1.Items.Add(item);
                    }
                    break;
            }
            
        }

        private void toggleViewEvent(object sender, EventArgs e)
        {

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

    }
}

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
        private string serverUrl = "10.0.2.15";
        private string serverPort = "8000";
        private PoliceData data;

        public PoliceForm()
        {
            InitializeComponent();
            data = new PoliceData(serverUrl, serverPort);
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
                    
                    break;
                case 2:
                    listView1.Columns.AddRange(ListViewColumns.RedLight);
                    break;
                case 3:
                    listView1.Columns.AddRange(ListViewColumns.Accident);
                    break;
            }
            
        }

        private void toggleViewEvent(object sender, EventArgs e)
        {
            Button button = (Button) sender;
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

        private void saveXmlDataEvent(object sender, EventArgs e)
        {

        }

        private void printListDataEvent(object sender, EventArgs e)
        {

        }

        private void openSettingsEvent(object sender, EventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

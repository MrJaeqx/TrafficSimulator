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
            //data = new PoliceData(serverUrl, serverPort);
            toggleViewEvent(buttonOverview, null);
        }

        private void updateList()
        {
            listView1.Clear();
            //data.GetAccidents();
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

        }

        private void refreshEvent(object sender, EventArgs e)
        {
            updateList();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
                   }

    }
}

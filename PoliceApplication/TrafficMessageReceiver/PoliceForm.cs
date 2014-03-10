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

        private int currentMode = 0;
        
        public PoliceForm()
        {
            InitializeComponent();
            toggleViewEvent(buttonOverview, null);
        }

        private void updateList()
        {
            listView1.Clear();
            
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
                updateList();
            }
            else if (button.Name == buttonSpeedings.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonHighlight;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                updateList();
            }
            else if (button.Name == buttonRedlight.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonHighlight;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                updateList();
            }
            else if (button.Name == buttonAccident.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonHighlight;
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

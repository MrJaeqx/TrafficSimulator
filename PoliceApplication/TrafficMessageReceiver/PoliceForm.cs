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
        
        public PoliceForm()
        {
            InitializeComponent();
            toggleViewButtonEvent(buttonOverview, null);
        }

        private void updateList(int mode)
        {
            listView1.Clear();
            
        }

        private void toggleViewButtonEvent(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            if (button.Name == buttonOverview.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonHighlight;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                updateList(0);
            }
            else if (button.Name == buttonSpeedings.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonHighlight;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                updateList(1);
            }
            else if (button.Name == buttonRedlight.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonHighlight;
                buttonAccident.BackColor = SystemColors.ButtonFace;
                updateList(2);
            }
            else if (button.Name == buttonAccident.Name)
            {
                buttonOverview.BackColor = SystemColors.ButtonFace;
                buttonSpeedings.BackColor = SystemColors.ButtonFace;
                buttonRedlight.BackColor = SystemColors.ButtonFace;
                buttonAccident.BackColor = SystemColors.ButtonHighlight;
                updateList(3);
            }
        }
    }
}

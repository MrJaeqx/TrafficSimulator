using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.IO;


namespace TrafficMessageReceiver
{
    public partial class PoliceForm : Form
    {

        private int currentMode = 0;
        private int lastMode = 0;
        private string settingsPath = "./settings.ini";
        private string servername = "localhost";
        private string serverport = "8000";
        private PoliceData data;
        private List<ListViewItem> listItems;

        public PoliceForm()
        {
            InitializeComponent();
            readSettings();
            toggleViewEvent(buttonOverview, null);
        }

        private void readSettings()
        {
            if (!File.Exists(settingsPath))
            {
                storeSettings();
            }
            else
            {
                using (StreamReader sr = File.OpenText(settingsPath))
                {
                    try
                    {
                        servername = sr.ReadLine();
                        serverport = sr.ReadLine();
                    }
                    catch (NullReferenceException exc)
                    {
                        storeSettings();
                    }
                }
            }
        }

        private void storeSettings()
        {
            using (StreamWriter sw = File.CreateText(settingsPath))
            {
                sw.WriteLine(servername);
                sw.WriteLine(serverport);
            }
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            readSettings();
            SettingsForm settingsForm = new SettingsForm(servername, serverport);
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                servername = settingsForm.ServerName;
                serverport = settingsForm.ServerPort;
                storeSettings();
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lastMode = currentMode;
                currentMode = 4;
                startBackgroundServerConenction();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            
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
            try
            {
                data = new PoliceData(servername, serverport);
            }
            catch (EndpointNotFoundException exc)
            {
                MessageBox.Show(exc.ToString(), "Kon geen verbinding maken met de server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                case 4:
                    currentMode = lastMode;
                    try
                    {
                        data.SaveXML(saveFileDialog.FileName);
                    }
                    catch (XmlException exc)
                    {
                        MessageBox.Show(exc.ToString(), "Fout bij het opslaan van het XML bestand", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void bringToFrontEvent(object sender, EventArgs e)
        {
            this.Activate();
            this.BringToFront();
        }

        private void closeFormEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

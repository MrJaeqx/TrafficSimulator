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

        private bool error = false;

        // Field voor geselecteerde waarde uit het hoofdmenu.
        private int currentMode = 0;
        private int lastMode = 0;

        // Instellingen fields met standaard instellingen.
        private string settingsPath = "./settings.ini";
        private string servername = "localhost";
        private string serverport = "8000";
        private bool autorefresh = false;
        private int refreshtime = 3;

        // Class die de communicatie met de server regeld.
        private PoliceData data;

        // Lijst met de inhoud voor de ListView.
        private List<ListViewItem> listItems;

        public PoliceForm()
        {
            InitializeComponent();
            readSettings();
            toggleViewEvent(buttonOverview, null);
            if (autorefresh) refreshTimer.Start();
        }

        /// <summary>
        /// Instellingen uit het instellingen bestand uitlezen.
        /// Indien het bestand nog niet bestaat wordt het aangemaakt met de standaard instellingen.
        /// </summary>
        private void readSettings()
        {
            // Controle of het instellingen bestand al bestaat.
            // Zo niet? Maak het.
            if (!File.Exists(settingsPath))
            {
                storeSettings();
            }
            else
            {
                // Instellingen uitlezen.
                using (StreamReader sr = File.OpenText(settingsPath))
                {
                    try
                    {
                        // Fields bijwerken.
                        servername = sr.ReadLine();
                        serverport = sr.ReadLine();
                        autorefresh = sr.ReadLine().Equals("1");
                        refreshtime = Convert.ToInt32(sr.ReadLine());

                        // Labels bijwerken
                        labelServer.Text = "Server: " + servername + ":" + serverport;
                        labelRefresh.Text = "Automatisch vernieuwen: " + (autorefresh ? "aan" : "uit");

                        // Automatisch vernieuwen aan of uit zetten
                        if (autorefresh)
                        {
                            refreshTimer.Start();
                        }
                        else
                        {
                            refreshTimer.Stop();
                        }

                        // Automatisch vernieuwen interval aanpassen.
                        switch (refreshtime)
                        {
                            case 0:
                                refreshTimer.Interval = 10000;
                                break;
                            case 1:
                                refreshTimer.Interval = 30000;
                                break;
                            case 2:
                                refreshTimer.Interval = 60000;
                                break;
                            case 3:
                                refreshTimer.Interval = 120000;
                                break;
                            case 4:
                                refreshTimer.Interval = 300000;
                                break;
                            case 5:
                                refreshTimer.Interval = 600000;
                                break;
                        }
                    }
                    catch (NullReferenceException exc)
                    {
                        storeSettings();
                    }
                }
            }
        }
        /// <summary>
        /// Sla alle instellingen op in het instellingen bestand. Bestaande inhoud wordt overschreven.
        /// Hierna worden de instellingen opnieuw ingelezen en toegepast.
        /// </summary>
        private void storeSettings()
        {
            using (StreamWriter sw = File.CreateText(settingsPath))
            {
                sw.WriteLine(servername);
                sw.WriteLine(serverport);
                sw.WriteLine(autorefresh ? 1 : 0);
                sw.WriteLine(refreshtime);
            }

            readSettings();
        }

        /// <summary>
        /// Lijst met items bijwerken.
        /// Hierbij wordt gebruik gemaakt van de mode variabelen of de inhoud te bepalen.
        /// </summary>
        private void updateList()
        {
            // Items en kolommen in de lijst wissen.
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Lijst vullen met kolommen en controleren op nieuwe items.
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

        /// <summary>
        /// Schakeld de modus om en vernieuwd de lijst.
        /// </summary>
        /// <param name="sender">Button waarheen moet worden geschakeld.</param>
        /// <param name="e">Niet gebruikt.</param>
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

        /// <summary>
        /// Actie om de lijst te vernieuwen.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void refreshEvent(object sender, EventArgs e)
        {
            updateList();
        }

        /// <summary>
        /// Event voor de settings button.
        /// Leest alle instellingen uit en start het SettingsForm met de uitgelezen instellingen.
        /// Werkt de instellingen bij indien het DialogResult OK is.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            // Stop het vernieuwen.
            refreshTimer.Stop();

            // Lees de instellingen uit.
            readSettings();

            // Open het SettingsForm en werk de instellingen bij indien het resultaat OK is.
            SettingsForm settingsForm = new SettingsForm(servername, serverport, autorefresh, refreshtime);
            if (settingsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                servername = settingsForm.ServerName;
                serverport = settingsForm.ServerPort;
                autorefresh = settingsForm.AutoRefresh;
                refreshtime = settingsForm.RefreshTime;
                storeSettings();
            }

        }

        /// <summary>
        /// Event voor de opslaan knop.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lastMode = currentMode;
                currentMode = 4;
                startBackgroundServerConenction();
            }
        }

        /// <summary>
        /// Event voor de print button.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // TODO Printen
        }

        /// <summary>
        /// Voorbereidingen voor het starten van de server backgroundworker.
        /// Blokkeerd de UI.
        /// </summary>
        private void startBackgroundServerConenction()
        {
            labelStatus.Text = "Bijwerken...";
            progressBar.Style = ProgressBarStyle.Marquee;
            panel1.Enabled = false;
            refreshTimer.Stop();
            backgroundServerConnection.RunWorkerAsync();
        }

        /// <summary>
        /// Background worker voor server communicatie.
        /// Werkt de lijst met items bij.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void backgroundServerConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            listItems = new List<ListViewItem>();

            // Verbinding met de server openen.
            // Indien dit mislukt een MessageBox weergeven.
            try
            {
                data = new PoliceData(servername, serverport);
            }
            catch (EndpointNotFoundException exc)
            {
                autorefresh = false;
                error = true;
                MessageBox.Show(exc.ToString(), "Kon geen verbinding maken met de server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gegevens ophalen op basis van de geselecteerde weergave via het hoofdmenu.
            switch (currentMode)
            {
                case 0:
                    break;
                case 1:
                    List<Speeding> speedings = data.GetSpeedings();
                    foreach (Speeding speeding in speedings)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", speeding.time.ToShortDateString(), speeding.time.ToShortTimeString(), speeding.carID.ToString(), speeding.carSpeed.ToString() });
                        listItems.Add(item);
                    }
                    break;
                case 2:
                    List<RedLight> redlights = data.GetRedLights();
                    foreach (RedLight redlight in redlights)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", redlight.time.ToShortDateString(), redlight.time.ToShortTimeString(), redlight.carID.ToString(), redlight.trafficLightID.ToString() });
                        listItems.Add(item);
                    }
                    break;
                case 3:
                    List<Accident> accidents = data.GetAccidents();
                    foreach (Accident accident in accidents)
                    {
                        ListViewItem item = new ListViewItem(new[] { "0", accident.time.ToShortDateString(), accident.time.ToShortTimeString(), accident.junctionID.ToString() });
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

            error = false;
        }

        /// <summary>
        /// Event dat wordt uigevoerd als de server backgroundworker voltooit is.
        /// Schakeld de UI weer in en werkt de ListView bij.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void backgroundServerConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            storeSettings();
            labelStatus.Text = (error ? "Fout bij het verbinden met de server." : ("Bijgewerkt op " + DateTime.Now.ToString("HH:mm:ss tt")));
            listView1.Items.AddRange(listItems.ToArray());
            progressBar.Style = ProgressBarStyle.Blocks;
            panel1.Enabled = true;
            if (autorefresh) refreshTimer.Start();
        }

        /// <summary>
        /// Event om het Form weer naar de voorgrond te brengen.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void bringToFrontEvent(object sender, EventArgs e)
        {
            // TODO ToFront
            this.Activate();
            this.BringToFront();
        }

        /// <summary>
        /// Event om het Form te sluiten.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void closeFormEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

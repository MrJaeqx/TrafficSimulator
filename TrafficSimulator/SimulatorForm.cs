using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using TrafficSimulatorUi;
using ArduinoLib;
using System.ServiceModel;
using System.IO;

namespace TrafficSimulator
{
    public partial class SimulatorForm : Form
    {
        /// <summary>
        /// List to keep track of all road users.
        /// You can put roadusers on intersections to make them appear there.
        /// </summary>
        private List<LogicControl> logicControls;
        private List<IntersectionControl> intersections;

        private Arduino arduino;
        private LogicControlRail railIntersection;
        private bool enableArduino = false;
        private bool enableMessageServer = false;

        private RandomRoadUsers randomRoadUsers;

        private Timer progressTimer = new Timer();
        private Timer trafficLightTimer = new Timer();
        private Timer randomSpawnTimer = new Timer();

        private const int trafficLightInterval = 5000;
        private const int statsUpdateInterval = 250;

        public SimulatorForm()
        {
            InitializeComponent();

            progressTimer.Interval = 40;
            progressTimer.Tick += progressTimer_Tick;

            trafficLightTimer.Interval = trafficLightInterval;
            trafficLightTimer.Tick += trafficlightTimer_Tick;

            randomSpawnTimer.Tick += randomSpawnTimer_Tick;
            randomSpawnTimer.Interval = Convert.ToInt32(toolStripTextBoxSpawnInterval.Text);
            randomSpawnTimer.Start();

            intersections = new List<IntersectionControl>();

            intersections.Add(intersectionControl1);
            intersections.Add(intersectionControl2);
            intersections.Add(intersectionControl3);
            intersections.Add(intersectionControl4);
            intersections.Add(intersectionControl5);
            intersections.Add(intersectionControl6);

            logicControls = new List<LogicControl>();

            railIntersection = new LogicControlRail(intersections);

            logicControls.Add(new LogicControlType1(intersections));
            logicControls.Add(new LogicControlType2(intersections));
            logicControls.Add(new LogicControlType3(intersections));
            logicControls.Add(new LogicControlType4(intersections));
            logicControls.Add(new LogicControlType5(intersections));
            logicControls.Add(railIntersection);

            randomRoadUsers = new RandomRoadUsers(intersections);

            progressTimer.Start();
            trafficLightTimer.Start();

            toolStripComboBoxCom.Items.Clear();
            toolStripComboBoxCom.Items.AddRange(SerialPort.GetPortNames());

            this.intersectionControl1.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            this.intersectionControl2.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            this.intersectionControl3.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            this.intersectionControl4.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            this.intersectionControl5.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            this.intersectionControl6.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
        }

        private void randomSpawnTimer_Tick(object sender, EventArgs e)
        {
            randomRoadUsers.SpawnRoadUser();
            try
            {
                toolStripStatusLabelID.Text = "ID: " + randomRoadUsers.StatsLastID.ToString();
                toolStripStatusLabelIC.Text = "IC: " + randomRoadUsers.StatsLastIType.ToString();
                toolStripStatusLabelSp.Text = "Sp: " + randomRoadUsers.StatsLastSpeed.ToString();
                toolStripStatusLabelRL.Text = "RL: " + randomRoadUsers.StatsLastRedlight.ToString();
            }
            catch (NullReferenceException) { }
        }

        private int totalRoadUsers()
        {
            int output = 0;
            foreach (IntersectionControl intersection in intersections)
            {
                output += intersection.RoadUsers.Count;
            }
            return output;
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorld();
        }

        private void UpdateWorld()
        {
            foreach (LogicControl LC in logicControls)
            {
                LC.HandleCollision();

                foreach (RoadUser roadUser in LC.Intersection.RoadUsers)
                {
                    roadUser.Move();
                    roadUser.Speed = roadUser.MaxSpeed;
                }

                LC.MakeTurn();
                LC.TransferCarsBetweenIntersections();
                LC.RemoveOutsideScreenRoadUser();
                LC.HandleTrafficLight();

                if (enableMessageServer)
                {
                    try
                    {
                        LC.CheckSpeed();
                        LC.CheckRedLight();
                    }
                    catch (EndpointNotFoundException)
                    {
                        messageServerToggle(null, null);
                        DialogResult result = MessageBox.Show("Kon geen verbinding maken met de berichten server.", "Geen verbinding", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                        if (result == System.Windows.Forms.DialogResult.Retry)
                        {
                            messageServerToggle(null, null);
                        }
                    }
                }

                LC.Intersection.Invalidate();
                toolStripStatusLabelTotal.Text = "Tot: " + totalRoadUsers();
            }
        }

        private void intersectionControl_TrafficLightClick(object sender, TrafficLightClickEventArgs e)
        {
            IntersectionControl intersection = (IntersectionControl)sender;
            TrafficLight trafficLight = intersection.GetTrafficLight(e.LaneId);
            if (trafficLight.State == SignalState.GO)
            {
                trafficLight.SwitchTo(SignalState.STOP);
            }
            else
            {
                trafficLight.SwitchTo(SignalState.GO);
            }
            
        }

        private void arduinoToggle(object sender, EventArgs e)
        {
            if (enableArduino)
            {
                arduino.Close();

                enableArduino = false;
                toolStripComboBoxCom.Items.Clear();
                toolStripComboBoxCom.Items.AddRange(SerialPort.GetPortNames());
                toolStripButtonArduino.Checked = false;
                toolStripComboBoxCom.Enabled = true;
                toolStripButtonSend.Enabled = false;
            }
            else
            {
                try
                {
                    arduino = new Arduino(toolStripComboBoxCom.Text, 9600);
                    arduino.trainIncomingEvent += railIntersection.TrainIncomingEvent;
                    arduino.trainPassedEvent += railIntersection.TrainPassedEvent;
                    arduino.Open();

                    enableArduino = true;
                    toolStripButtonArduino.Checked = true;
                    toolStripComboBoxCom.Enabled = false;
                    toolStripButtonSend.Enabled = true;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Ongeldige COM poort", "Arduino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException)
                {
                    MessageBox.Show("Verbindings fout.", "Arduino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void messageServerToggle(object sender, EventArgs e)
        {
            if (enableMessageServer)
            {
                enableMessageServer = false;
                toolStripButtonMS.Checked = false;
            }
            else
            {
                enableMessageServer = true;
                toolStripButtonMS.Checked = true;
            }
        }

        private void spawnerToggle(object sender, EventArgs e)
        {
            if (randomSpawnTimer.Enabled)
            {
                randomSpawnTimer.Stop();
                toolStripTextBoxSpawnInterval.Enabled = true;
                toolStripButtonSpawn.Checked = false;
            }
            else
            {
                try
                {
                    randomSpawnTimer.Interval = Convert.ToInt32(toolStripTextBoxSpawnInterval.Text);
                    randomSpawnTimer.Start();
                    toolStripTextBoxSpawnInterval.Enabled = false;
                    toolStripButtonSpawn.Checked = true;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ongeldige interval.", "Spawner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void trafficlightTimer_Tick(object sender, EventArgs e)
        {
            foreach (LogicControl LC in logicControls)
            {
                LC.HandleQueue();
            }

        }

        private void toolStripMenuItemClearAll_Click(object sender, EventArgs e)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                intersection.RoadUsers.Clear();
            }
        }
    }
}

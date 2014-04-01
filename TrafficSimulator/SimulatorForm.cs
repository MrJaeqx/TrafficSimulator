using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using TrafficSimulatorUi;
using ArduinoLib;
using System.ServiceModel;

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

        private Timer trafficLightTimer = new Timer();

        public SimulatorForm()
        {
            InitializeComponent();

            trafficLightTimer.Interval = 5000;
            trafficLightTimer.Tick += trafficlightTimer_Tick;
            trafficLightTimer.Enabled = true;

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

            //toolStripComboBoxArduinoCom.Items.Clear();
            //toolStripComboBoxArduinoCom.Items.AddRange(SerialPort.GetPortNames());

            //connectButtonClick(null, null);
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorld();
        }

        private void UpdateWorld()
        {
            foreach (LogicControl LC in logicControls)
            {
                foreach (RoadUser roadUser in LC.Intersection.RoadUsers)
                {
                    roadUser.Move();
                }

                LC.MakeTurn();
                LC.TransferCarsBetweenIntersections();
                LC.RemoveOutsideScreenRoadUser();
                LC.HandleHeadTailCollision();
                LC.HandleTrafficLight();

                if (enableMessageServer)
                {
                    try
                    {
                        LC.CheckSpeed();
                    }
                    catch (EndpointNotFoundException)
                    {
                        DialogResult result = MessageBox.Show("Kon geen verbinding maken met de berichten server.", "Geen verbinding", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                        if (result == System.Windows.Forms.DialogResult.Cancel)
                        {
                            enableMessageServer = false;
                        }
                    }
                }

                LC.Intersection.Invalidate();
            }
        }

        private void intersectionControl_TrafficLightClick(object sender, TrafficLightClickEventArgs e)
        {
            // Example code for interacting with traffic lights
            // Note: The goal of this example is to shows some code mechanics. Nothing more.
            //       Probably you want to remove most of it, because it does not do wat you want over here.
            //
            // The example code shows 
            // - How to handle TrafficLightClick events.
            // - How to get the state of a traffic light.
            // - How to set thet state of a traffic light.

            Debug.WriteLine("Clicked traffic light with lane id: " + e.LaneId + ", of intersection: ");
            IntersectionControl intersection = (IntersectionControl)sender;
            TrafficLight trafficLight = intersection.GetTrafficLight(e.LaneId);
            trafficLight.SwitchTo(SignalState.CLEAR_CROSSING);
        }

        private void intersectionControl1_TrafficLightClick(object sender, TrafficLightClickEventArgs e)
        {
            Debug.WriteLine("Clicked traffic light with lane id: " + e.LaneId + ", of intersection: ");
            IntersectionControl intersection = (IntersectionControl)sender;
            TrafficLight trafficLight = intersection.GetTrafficLight(e.LaneId);
            trafficLight.SwitchTo(SignalState.CLEAR_CROSSING);
        }

        private void connectButtonClick(object sender, EventArgs e)
        {
            if (enableArduino)
            {
                arduino.Close();
                enableArduino = false;
            }
            else
            {
                arduino = new Arduino("COM3", 9600);
                arduino.trainIncomingEvent += railIntersection.TrainIncomingEvent;
                arduino.trainPassedEvent += railIntersection.TrainPassedEvent;
                arduino.Open();
                enableArduino = true;
            }
        }

        private void trafficlightTimer_Tick(object sender, EventArgs e)
        {
            foreach (LogicControl LC in logicControls)
            {
                LC.HandleQueue();
            }
        }
    }
}

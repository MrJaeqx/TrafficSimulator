﻿using ArduinoLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using TrafficSimulatorUi;

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

        public SimulatorForm()
        {
            InitializeComponent();
            intersections = new List<IntersectionControl>();

            intersections.Add(intersectionControl1);
            intersections.Add(intersectionControl2);
            intersections.Add(intersectionControl3);
            intersections.Add(intersectionControl4);
            intersections.Add(intersectionControl5);
            intersections.Add(intersectionControl6);

            logicControls = new List<LogicControl>();

            //logicControls.Add(new LogicControlType1(intersections));
            logicControls.Add(new LogicControlType2(intersections));
            logicControls.Add(new LogicControlType3(intersections));
            //logicControls.Add(new LogicControlType4(intersections));
            //logicControls.Add(new LogicControlType5(intersections));
            //logicControls.Add(new LogicControlRail());

            RoadUser testCar0 = new BlueCar(new Point(156, -18), 2);
            testCar0.FaceTo(new Point(156, 400));
            intersectionControl4.AddRoadUser(testCar0);

            RoadUser testCar1 = new BlueSportsCar(new Point(-18, 244), 2);
            intersectionControl4.AddRoadUser(testCar1);

            RoadUser testCar2 = new GreenSportsCar(new Point(418, 156), 2);
            testCar2.FaceTo(new Point(0, 156));
            intersectionControl4.AddRoadUser(testCar2);

            RoadUser testCar3 = new GreenSportsCar(new Point(244, 418), 2);
            testCar3.FaceTo(new Point(244, 0));
            intersectionControl4.AddRoadUser(testCar3);

            progressTimer.Start();

            //toolStripComboBoxArduinoCom.Items.Clear();
            //toolStripComboBoxArduinoCom.Items.AddRange(SerialPort.GetPortNames());
            
        }

        /// <summary>
        /// Event voor een aankomende trein.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arduino_trainIncomingEvent(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Event voor een passerende trein.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arduino_trainPassedEvent(object sender, EventArgs e)
        {
            
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
            ToolStripButton button = (ToolStripButton)sender;

            if (button.Checked)
            {
                arduino.Close();
                button.Checked = false;
            }
            else
            {
                arduino = new Arduino(toolStripComboBoxArduinoCom.Text, 9600);
                arduino.trainIncomingEvent += arduino_trainIncomingEvent;
                arduino.trainPassedEvent += arduino_trainPassedEvent;
                arduino.Open();
                button.Checked = true;
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

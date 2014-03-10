using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private List<RoadUser> roadUsers;
        private List<IntersectionControl> ICs;

        public SimulatorForm()
        {
            InitializeComponent();
            roadUsers = new List<RoadUser>();
            ICs = new List<IntersectionControl>();

            ICs.Add(intersectionControl1);
            ICs.Add(intersectionControl2);
            ICs.Add(intersectionControl3);
            ICs.Add(intersectionControl4);

            progressTimer.Start();
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorld();

            //this is for testing
            if(intersectionControl1.RoadUsers.Count == 0)
            {
                RoadUser TestCar1 = new BlueCar(new Point(-32, 216), 2);
                RoadUser TestCar2 = new GreenSportsCar(new Point(-32, 244), 2);
                roadUsers.Clear();
                roadUsers.Add(TestCar1);
                roadUsers.Add(TestCar2);
                intersectionControl1.AddRoadUser(TestCar1);
                intersectionControl1.AddRoadUser(TestCar2);
            }
        }

        private void UpdateWorld()
        {
            foreach (RoadUser roadUser in roadUsers)
            {
                roadUser.Move();
            }

            foreach (IntersectionControl IC in ICs)
            {
                IC.MakeTurn();
                IC.RemoveEndOfLaneRoadUser();
                IC.Invalidate();
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
            trafficLight.SwitchTo(SignalState.STOP);
        }
    }
}

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

        public SimulatorForm()
        {
            InitializeComponent();
            roadUsers = new List<RoadUser>();

            // Just some code to show cars on the intersection
            // Feel free to modify to match your needs.
            // Hint: You should find a way to let cars / pedestrians travel
            //       from one intersection to the other....
            RoadUser blueCar = new BlueCar(new Point(30,216), 2);
            roadUsers.Add(blueCar);
            RoadUser greenSportsCar = new GreenSportsCar(new Point(155, 260), 0);
            roadUsers.Add(greenSportsCar);
            greenSportsCar.FaceTo(new Point(160, 260));
            intersectionControl1.AddRoadUser(roadUsers[0]);
            intersectionControl1.AddRoadUser(roadUsers[1]);

            progressTimer.Start();
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorld();
        }

        private void UpdateWorld()
        {
            foreach (RoadUser roadUser in roadUsers)
            {
                roadUser.Move();

                if (roadUser.Location.X == 400)
                {
                    intersectionControl1.RemoveRoadUser(roadUser);
                    intersectionControl2.AddRoadUser(roadUser);
                    
                    Point P = roadUser.Location;
                    P.X = 0;
                    roadUser.Location = P;
                }
            }

            // redraw all intersections
            intersectionControl1.Invalidate();
            intersectionControl2.Invalidate();
            intersectionControl3.Invalidate();
            intersectionControl4.Invalidate();
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

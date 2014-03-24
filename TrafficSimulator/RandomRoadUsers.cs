using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Windows.Forms;
using System.Drawing;

namespace TrafficSimulator
{
    class RandomRoadUsers
    {
        public List<IntersectionControl> Intersections { get; private set; }

        const int newRoadUserSpawnRate = 1000;

        Timer timer;

        public RandomRoadUsers(List<IntersectionControl> intersections)
        {
            Intersections = intersections;

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = newRoadUserSpawnRate;
            timer.Start();
        }

        private void timer_Tick(Object myObject, EventArgs myEventArgs)
        {
            Random randomIntersection = new Random();
            Random carType = new Random();
            Random whereToSpawn = new Random();

            IntersectionControl intersection = Intersections[randomIntersection.Next(0, 7)];

            if (intersection.IntersectionType == IntersectionType.TYPE_1)
            {

            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_2)
            {

            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_3)
            {

            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_4)
            {

            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_5)
            {

            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
            {

            }
        }
    }
}

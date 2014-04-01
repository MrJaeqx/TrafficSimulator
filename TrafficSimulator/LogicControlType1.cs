using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TrafficSimulator;
using TrafficSimulatorUi;

namespace TrafficSimulator
{
    public class LogicControlType1 : LogicControl
    {

        public override List<LaneId> Queue { get; protected set; }

        public LogicControlType1(List<IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_1)
                {
                    base.Intersection = intersection;
                }
            }
        }

        public override void MakeTurn()
        {
            foreach (RoadUser roadUser in Intersection.RoadUsers)
            {
                Point p = roadUser.Location;

                if (roadUser.Direction == 270)
                {

                }
                else if (roadUser.Direction == 180)
                {

                }
                else if (roadUser.Direction == 90)
                {

                }
                else if (roadUser.Direction == 0)
                {

                }
            }
        }

        public override void HandleTrafficLight()
        {
            
        }

        public override void HandleQueue()
        {
            
        }
    }
}

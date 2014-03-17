using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;

namespace TrafficSimulator
{
    class LogicControlType3 : LogicControl
    {

        public override List<LaneId> Queue { get; protected set; }

        public LogicControlType3(List<IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_3)
                {
                    base.Intersection = intersection;
                }
            }
        }

        public override void MakeTurn()
        {

        }

        public override void RemoveEndOFLaneRoadUser()
        {

        }

        public override void HandleTrafficLight()
        {

        }

        public override void HandleQueue()
        {

        }
    }
}

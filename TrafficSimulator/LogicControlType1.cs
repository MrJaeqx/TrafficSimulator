using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using TrafficSimulator;

namespace TrafficSimulator
{
    class LogicControlType1 : LogicControl
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
            throw new NotImplementedException();
        }

        public override void RemoveEndOFLaneRoadUser()
        {
            throw new NotImplementedException();
        }

        public override void HandleTrafficLight()
        {
            throw new NotImplementedException();
        }

        public override void HandleQueue()
        {
            throw new NotImplementedException();
        }
    }
}

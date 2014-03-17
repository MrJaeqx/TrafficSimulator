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
        public override IntersectionControl Intersection
        {
            get
            {
                throw new NotImplementedException();
            }
            protected set
            {
                throw new NotImplementedException();
            }
        }

        public override List<LaneId> Queue
        {
            get
            {
                throw new NotImplementedException();
            }
            protected set
            {
                throw new NotImplementedException();
            }
        }
        public LogicControlType1(List<IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_1)
                {
                    Intersection = intersection;
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

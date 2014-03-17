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
    }
}

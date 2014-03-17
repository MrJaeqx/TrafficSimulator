using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Windows.Forms;

namespace TrafficSimulator
{
    public abstract class LogicControl
    {
        public abstract IntersectionControl Intersection { get; protected set; }

        public abstract List<LaneId> Queue { get; protected set; }

        public LogicControl()
        {
            Queue = new List<LaneId>();
        }

        public abstract void MakeTurn();

        public abstract void RemoveEndOFLaneRoadUser();

        public abstract void HandleTrafficLight();

        public abstract void HandleHeadTailCollision();

        public abstract void HandleQueue();
    }
}

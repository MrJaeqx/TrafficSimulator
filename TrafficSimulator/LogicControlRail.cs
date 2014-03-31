using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Diagnostics;

namespace TrafficSimulator
{
    public class LogicControlRail : LogicControl
    {
        public bool Train
        {
            get;
            set;
        }
        public override List<LaneId> Queue { get; protected set; }

        public LogicControlRail(List<TrafficSimulatorUi.IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
                {
                    base.Intersection = intersection;
                }

                if (intersection.IntersectionType == IntersectionType.TYPE_5)
                {
                    base.IntersectionLeft = intersection;
                }

                base.IntersectionRight = null;
                base.IntersectionTop = null;
                base.IntersectionBottom = null;
            }
        }

        public override void MakeTurn()
        {
            //throw new NotImplementedException();
        }

        public override void HandleTrafficLight()
        {
            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                //WEST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT);

                //EAST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT);
            }
        }

        public override void HandleQueue()
        {
            
        }

        public void TrainIncomingEvent(object sender, EventArgs e)
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
            Train = true;
            Debug.WriteLine("TrainIncomingEvent");
        }

        public void TrainPassedEvent(object sender, EventArgs e)
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
            Train = false;
            Debug.WriteLine("TrainPassedEvent");
        }
    }
}
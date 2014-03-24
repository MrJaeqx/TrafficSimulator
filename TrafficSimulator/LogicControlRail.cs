using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;

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
            if (Queue.Count > 0)
            {
                if (Queue[0] == LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT)
                {
                    if (!Train)
                    {
                        base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                        Queue.RemoveAt(0);
                    }
                }
                else if (Queue[0] == LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT)
                {
                    if (!Train)
                    {
                        base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                        Queue.RemoveAt(0);
                    }
                }
            }
            //throw new NotImplementedException();
        }
    }
}
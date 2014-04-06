using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Diagnostics;
using TrafficSimulatorUi.Traffic;
using System.Drawing;

namespace TrafficSimulator
{
    public class LogicControlRail : LogicControl
    {
        public override List<LaneId> Queue { get; protected set; }

        private RoadUser lastTrain;

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

                HandleTrafficLightLane(roadUser, LaneId.EAST_PAVEMENT_LEFT);
                HandleTrafficLightLane(roadUser, LaneId.EAST_PAVEMENT_RIGHT);

                HandleTrafficLightLane(roadUser, LaneId.WEST_PAVEMENT_LEFT);
                HandleTrafficLightLane(roadUser, LaneId.WEST_PAVEMENT_RIGHT);
            }
        }

        public override void HandleQueue()
        {
            
        }

        public void TrainIncomingEvent(object sender, EventArgs e)
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);

            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);

            lastTrain = new GreenTrain(new Point(223, 418));
            lastTrain.FaceTo(new Point(223, 0));
            Intersection.AddRoadUser(lastTrain);
        }

        public void TrainPassedEvent(object sender, EventArgs e)
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);

            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);

            if (lastTrain != null)
            {
                if (Intersection.RoadUsers.Exists(x => x == lastTrain))
                {
                    Intersection.RemoveRoadUser(lastTrain);
                }
            }
        }
    }
}
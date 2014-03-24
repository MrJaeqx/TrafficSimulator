using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;

namespace TrafficSimulator
{
    class LogicControlType3 : LogicControl
    {

        private Random random;

        public override List<LaneId> Queue { get; protected set; }

        public LogicControlType3(List<IntersectionControl> intersections)
        {
            random = new Random();

            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_3)
                {
                    base.Intersection = intersection;
                    Intersection = intersection;
                }
            }
        }

        public override void MakeTurn()
        {

            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                Point P = roadUser.Location;

                //NORTH_INBOUND_LANE
                if (roadUser.Direction == 270)
                {
                    //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 156, 156, 0, 156);
                    //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 156, 182, 0, 182);

                    //LEFT_LANE allen eventueel links afslaan bij de tweede mogelijkheid, met een kans van 1 op 2
                    Type2Turn(roadUser, P, 184, 244, 400, 244);
                }
                    
                //EAST_INBOUND_LANE
                else if (roadUser.Direction == 180)
                {
                    //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 244, 156, 244, 0);
                    //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 216, 156, 216, 0);
                    //LEFT_LANE eerste mogelijkheid om links af te slaan, met een kans van 1 op 3

                    //LEFT_LANE allen eventueel links afslaan bij de tweede mogelijkheid, met een kans van 1 op 2
                    Type2Turn(roadUser, P, 156, 184, 156, 400);
                }

                //SOUTH_INBOUND_LANE
                else if (roadUser.Direction == 90)
                {
                    //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 244, 244, 400, 244);
                    //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 244, 216, 400, 216);

                    //LEFT_LANE allen eventueel links afslaan bij de tweede mogelijkheid, met een kans van 1 op 2
                    Type2Turn(roadUser, P, 216, 156, 0, 156);
                }

                //WEST_INBOUND_LANE
                else if (roadUser.Direction == 0)
                {
                    //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 156, 244, 156, 400);
                    //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 182, 244, 182, 400);

                    //LEFT_LANE allen eventueel links afslaan bij de tweede mogelijkheid, met een kans van 1 op 2
                    Type2Turn(roadUser, P, 244, 216, 244, 0);
                }
            }
        }

        public override void HandleTrafficLight()
        {
            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                //NORTH inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT);

                //EAST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT);

                //SOUTH inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT);

                //WEST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT);
            }
        }

        public override void HandleQueue()
        {
            if (Queue.Count > 0)
            {
                
                //WEST_LANE_RIGHT
                if (Queue[0] == LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT)
                {

                        base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                        base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                        base.Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                        base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                        Queue.RemoveAt(0);
                    
                }
                else if (Queue[0] == LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT)
                {
                    
                        base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                        base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                        base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                        base.Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                        Queue.RemoveAt(0);
                    
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TrafficSimulator;
using TrafficSimulatorUi;

namespace TrafficSimulator
{
    class LogicControlType2 : LogicControl
    {
        public override List<LaneId> Queue { get; protected set; }

        public LogicControlType2(List<IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                //toekennen van het eigen kruispunt
                if (intersection.IntersectionType == IntersectionType.TYPE_2)
                {
                    base.Intersection = intersection;
                }

                //toekennen van het kruispunt dat zich rechts van dit kruispunt bevind
                if (intersection.IntersectionType == IntersectionType.TYPE_5)
                {
                    base.IntersectionRight = intersection;
                }

                //toekennen van het kruispunt dat zich onder van dit kruispunt bevind
                if (intersection.IntersectionType == IntersectionType.TYPE_3)
                {
                    base.IntersectionBottom = intersection;
                }
            }

            base.IntersectionLeft = null;
            base.IntersectionTop = null;
        }

        public override void MakeTurn()
        {
            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                Point P = roadUser.Location;

                if (roadUser is Pedestrian)
                {
                    if (roadUser.Direction == 270)
                    {
                        //rechter baan bocht
                        Type4Turn(roadUser, P, 130, 130, 130, 0);
                        //linker baan bocht
                        Type4Turn(roadUser, P, 266, 130, 400, 130);
                    }
                    else if (roadUser.Direction == 180)
                    {
                        //rechter baan bocht
                        Type1Turn(roadUser, P, 266, 130, 266, 0);
                        //linker baan bocht
                        Type1Turn(roadUser, P, 266, 266, 266, 400);
                    }
                    else if (roadUser.Direction == 90)
                    {
                        //rechter baan bocht
                        Type4Turn(roadUser, P, 266, 266, 400, 266);
                        //linker baan bocht
                        Type4Turn(roadUser, P, 130, 266, 0, 266);
                    }
                    else if (roadUser.Direction == 0)
                    {
                        //rechter baan bocht
                        Type1Turn(roadUser, P, 130, 266, 130, 400);
                        //linker baan bocht
                        Type1Turn(roadUser, P, 130, 130, 130, 0);
                    }
                }
                else
                {
                    //NORTH_INBOUND_LANE
                    if (roadUser.Direction == 270)
                    {
                        //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                        Type1Turn(roadUser, P, 156, 156, 0, 156);
                        //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                        Type1Turn(roadUser, P, 156, 186, 0, 186);
                        //LEFT_LANE allen eventueel links afslaan bij de tweede mogelijkheid, met een kans van 1 op 2
                        Type2Turn(roadUser, P, 186, 244, 400, 244);
                    }

                    //EAST_INBOUND_LANE
                    else if (roadUser.Direction == 180)
                    {
                        //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                        Type1Turn(roadUser, P, 244, 156, 244, 0);
                        //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                        Type1Turn(roadUser, P, 216, 156, 216, 0);

                        //LEFT_LANE links af slaan aan het eind van de lane
                        if (P.X == 156 && P.Y == 186)
                        {
                            roadUser.FaceTo(new Point(156, 400));
                        }
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
                        Type1Turn(roadUser, P, 186, 244, 186, 400);

                        //LEFT_LANE links af slaan aan het eind van de lane
                        if (P.X == 244 && P.Y == 216)
                        {
                            roadUser.FaceTo(new Point(244, 0));
                        }
                    }
                }
            }
        }

        public override void HandleTrafficLight()
        {
           foreach (RoadUser roadUser in base.Intersection.RoadUsers)
           {
               //NORTH inbound LEFT AND RIGHT lane
               HandleTrafficLightLane(roadUser, LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT);

               //EAST inbound RIGHT lane
               HandleTrafficLightLane(roadUser, LaneId.EAST_INBOUND_ROAD_RIGHT);
               //EAST inbound LEFT lane
               HandleTrafficLightLane(roadUser, LaneId.EAST_INBOUND_ROAD_LEFT);

               //SOUTH inbound LEFT AND RIGHT lane
               HandleTrafficLightLane(roadUser, LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT);

               //WEST inbound RIGHT lane
               HandleTrafficLightLane(roadUser, LaneId.WEST_INBOUND_ROAD_RIGHT);
               //WEST inbound LEFT lane
               HandleTrafficLightLane(roadUser, LaneId.WEST_INBOUND_ROAD_LEFT);
           }
        }

        public override void HandleQueue()
        {
            if (Queue.Count > 0)
            {
                if (base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).State == SignalState.GO)
                {
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                }
                else if (Queue[0] == LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT)
                {
                    base.Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT)
                {
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.EAST_INBOUND_ROAD_LEFT)
                {
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.WEST_INBOUND_ROAD_LEFT)
                {
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.EAST_INBOUND_ROAD_RIGHT || Queue[0] == LaneId.WEST_INBOUND_ROAD_RIGHT)
                {
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.EAST_PAVEMENT_LEFT || Queue[0] == LaneId.EAST_PAVEMENT_RIGHT || 
                         Queue[0] == LaneId.WEST_PAVEMENT_LEFT || Queue[0] == LaneId.WEST_PAVEMENT_RIGHT)
                {
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
            }
        }
    }
}

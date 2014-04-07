using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrafficSimulatorUi;

namespace TrafficSimulator
{
    class LogicControlType4 : LogicControl
    {
        public override List<LaneId> Queue { get; protected set; }
        public LogicControlType4(List<IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_4)
                {
                    base.Intersection = intersection;
                }

                //toekennen van het kruispunt dat zich Links van dit kruispunt bevind
                if (intersection.IntersectionType == IntersectionType.TYPE_1)
                {
                    base.IntersectionLeft = intersection;
                }
            }

            base.IntersectionRight = null;
            base.IntersectionBottom = null;
            base.IntersectionTop = null;       
        }

        public override void MakeTurn()
        {
            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                Point P = roadUser.Location;

                if (roadUser is Pedestrian)
                {
                    if (roadUser.Direction == 180)
                    {
                        //rechter baan bocht
                        Type1Turn(roadUser, P, 266, 130, 266, 400);
                        //linker baan loop rechtdoor
                    }
                    else if (roadUser.Direction == 90)
                    {
                        //rechter baan bocht
                        Type1Turn(roadUser, P, 266, 266, 400, 266);
                        //linker baan bocht
                        Type1Turn(roadUser, P, 130, 266, 0, 266);

                        //boven aan een bocht maken
                        Type4Turn(roadUser, P, 266, 130, 0, 130);
                        Type4Turn(roadUser, P, 130, 130, 0, 130);
                    }
                    else if (roadUser.Direction == 0)
                    {
                        //rechter baan bocht
                        Type1Turn(roadUser, P, 130, 266, 130, 400);
                        //linker baan bocht
                        Type1Turn(roadUser, P, 130, 130, 130, 400);   
                    }
                }
                else
                {
                    //EAST_INBOUND_LANE
                    if (roadUser.Direction == 180)
                    {
                        //LEFT_LANE eerste mogelijkheid om links af te slaan, met een kans van 1 op 3
                        Type2Turn(roadUser, P, 186, 186, 186, 400);
                        //LEFT_LANE tweede mogelijkheid om links af te slaan, met een kans van 1 op 3
                        Type2Turn(roadUser, P, 156, 186, 156, 400);
                    }

                    //SOUTH_INBOUND_LANE
                    else if (roadUser.Direction == 90)
                    {
                        //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 2
                        Type1Turn(roadUser, P, 244, 244, 400, 244);
                        //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, moet afslaan
                        Type4Turn(roadUser, P, 244, 216, 400, 216);

                        //LEFT_LANE altijd links afslaan bij de tweede mogelijkheid
                        Type4Turn(roadUser, P, 216, 156, 0, 156);
                    }

                    //WEST_INBOUND_LANE
                    else if (roadUser.Direction == 0)
                    {
                        //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                        Type2Turn(roadUser, P, 156, 244, 156, 400);
                        //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                        Type2Turn(roadUser, P, 186, 244, 186, 400);
                    }
                }
            }
        }

        public override void HandleTrafficLight()
        {
            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                //EAST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT);

                //SOUTH inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT);

                //WEST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT);

                //EAST inbound PAVEMENT LEFT
                HandleTrafficLightLane(roadUser, LaneId.EAST_PAVEMENT_LEFT);

                //EAST inbound PAVEMENT RIGHT
                HandleTrafficLightLane(roadUser, LaneId.NORTH_PAVEMENT_RIGHT);

                //SOUTH inbound PAVEMENT LEFT
                HandleTrafficLightLane(roadUser, LaneId.SOUTH_PAVEMENT_LEFT);

                //SOUTH inbound PAVEMENT RIGHT
                HandleTrafficLightLane(roadUser, LaneId.SOUTH_PAVEMENT_RIGHT);

                //WEST inbound PAVEMENT LEFT
                HandleTrafficLightLane(roadUser, LaneId.NORTH_PAVEMENT_LEFT);

                //WEST inbound PAVEMENT RIGHT
                HandleTrafficLightLane(roadUser, LaneId.WEST_PAVEMENT_RIGHT);
            }
        }

        public override void HandleQueue()
        {
            if (Queue.Count > 0)
            {
                if (base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_RIGHT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_LEFT).State == SignalState.GO ||
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).State == SignalState.GO)
                {
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                }
            
                else if (Queue[0] == LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT)
                {
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    Queue.RemoveAt(0);
                }

                else if (Queue[0] == LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT)
                {

                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT)
                {

                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
                    Queue.RemoveAt(0);
                }
                else if (Queue[0] == LaneId.EAST_PAVEMENT_LEFT || Queue[0] == LaneId.NORTH_PAVEMENT_RIGHT ||
                         Queue[0] == LaneId.SOUTH_PAVEMENT_LEFT || Queue[0] == LaneId.SOUTH_PAVEMENT_RIGHT ||
                         Queue[0] == LaneId.NORTH_PAVEMENT_LEFT || Queue[0] == LaneId.WEST_PAVEMENT_RIGHT)
                {

                    base.Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
                    base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.SOUTH_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.NORTH_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
                    base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
                    Queue.RemoveAt(0);
                }
            }
        }

        protected override void Type4Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            if (P.X == X1 && P.Y <= Y1)
            {
                roadUser.FaceTo(new Point(X2, Y2));
            }
        }
    }
}

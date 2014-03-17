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
        public override IntersectionControl Intersection { get; protected set; }

        public override List<LaneId> Queue { get; protected set; }

        public LogicControlType2(List<IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_2)
                {
                    Intersection = intersection;
                }
            }
        }

        /// <summary>
        /// Bepalen om een bocht te maken met een kans van 1 op 3
        /// </summary>
        /// <param name="roadUser">de roaduser waar het om gaat</param>
        /// <param name="P"> het punt waar de roaduser zich bevind</param>
        /// <param name="X1"> de X van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="Y1"> de Y van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="X2"> de X van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        /// <param name="Y2"> de Y van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        private void Type1Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            Random random = new Random();

            if (P.X == X1 && P.Y == Y1)
            {
                if (random.Next(0, 3) == 1)
                {
                    roadUser.FaceTo(new Point(X2, Y2));
                }
            }
        }

        /// <summary>
        /// Bepalen om een bocht te maken met een kans van 1 op 2
        /// </summary>
        /// <param name="roadUser">de roaduser waar het om gaat</param>
        /// <param name="P"> het punt waar de roaduser zich bevind</param>
        /// <param name="X1"> de X van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="Y1"> de Y van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="X2"> de X van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        /// <param name="Y2"> de Y van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        private void Type2Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            Random random = new Random();

            if (P.X == X1 && P.Y == Y2)
            {
                if (random.Next(0, 10) == 1)
                {
                    roadUser.FaceTo(new Point(X2, Y2));
                }
            }
        }

        public override void MakeTurn()
        {
            foreach (RoadUser roadUser in Intersection.RoadUsers)
            {
                Point P = roadUser.Location;
                Random random = new Random();

                //NORTH_INBOUND_LANE
                if (roadUser.Direction == 270)
                {
                    //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 156, 156, 0, 156);
                    //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 156, 182, 0, 182);
                    //LEFT_LANE allen eventueel links afslaan bij de tweede mogelijkheid
                    Type2Turn(roadUser, P, 184, 244, 400, 244);
                }

                //EAST_INBOUND_LANE
                else if (roadUser.Direction == 180)
                {
                    //RIGHT_LANE
                    if (P.X == 244 && P.Y == 156)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(244, 0));
                        }
                    }
                    else if (P.X == 216 && P.Y == 156)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(216, 0));
                        } 
                    }
                    //LEFT_LANE
                    else if(P.X == 156 && P.Y == 182)
                    {
                        roadUser.FaceTo(new Point(156, 400));
                    }
                }

                //SOUTH_INBOUND_LANE
                else if (roadUser.Direction == 90)
                {
                    //RIGHT_LANE
                    if (P.X == 244 && P.Y == 244)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(400, 244));
                        }
                    }
                    else if(P.X == 244 && P.Y == 216)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(400, 216));
                        }
                    }
                    //LEFT_LANE
                    else if (P.X == 216 && P.Y == 156)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            roadUser.FaceTo(new Point(0, 156));
                        }
                    }
                }

                //WEST_INBOUND_LANE
                else if (roadUser.Direction == 0)
                {
                    //RIGHT_LANE
                    if (P.X == 156 && P.Y == 244)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(156, 400));
                        }
                    }
                    else if (P.X == 182 && P.Y == 244)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(182, 400));
                        }
                    }
                    //LEFT_LANE
                    else if (P.X == 244 && P.Y == 216)
                    {
                        roadUser.FaceTo(new Point(244, 0));
                    }
                }
            }
        }

        public override void RemoveEndOFLaneRoadUser()
        {
            if (Intersection.RoadUsers.Count > 0)
            {
                foreach (RoadUser roadUser in Intersection.RoadUsers)
                {
                    Point P = roadUser.Location;

                    if (P.X >= 400 || P.X <= -32)
                    {
                        Intersection.RemoveRoadUser(roadUser);
                        break;
                    }
                    else if (P.Y >= 400 || P.Y <= -32)
                    {
                        Intersection.RemoveRoadUser(roadUser);
                        break;
                    }
                }
            }
        }

        public override void HandleTrafficLight()
        {
           foreach (RoadUser roadUser in Intersection.RoadUsers)
           {
               //WEST inbound RIGHT lane
               if ((Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).State == SignalState.STOP 
                   || Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).State == SignalState.CLEAR_CROSSING)
                   && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(LaneId.WEST_INBOUND_ROAD_RIGHT).BoundingBox))
               {
                   roadUser.Speed = 0;
                   if(!Queue.Contains(LaneId.WEST_INBOUND_ROAD_RIGHT))
                   {
                    Queue.Add(LaneId.WEST_INBOUND_ROAD_RIGHT);
                   }
               }
               //WEST inbound LEFT lane
               else if ((Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).State == SignalState.STOP
                   || Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).State == SignalState.CLEAR_CROSSING)
                   && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(LaneId.WEST_INBOUND_ROAD_LEFT).BoundingBox))
               {
                   roadUser.Speed = 0;
                   if(!Queue.Contains(LaneId.WEST_INBOUND_ROAD_RIGHT))
                   {
                    Queue.Add(LaneId.WEST_INBOUND_ROAD_LEFT);
                   }
               }
               //NORTH inbound LEFT AND RIGHT lane
               else if ((Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.STOP
                   || Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.CLEAR_CROSSING)
                   && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).BoundingBox))
               {
                   roadUser.Speed = 0;
                   if(!Queue.Contains(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT))
                   {
                       Queue.Add(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT);
                   }
               }
           }
        }

        public override void HandleQueue()
        {
            if (Queue.Count > 0)
            {
                //WEST_LANE_RIGHT
                if (Queue[0] == LaneId.WEST_INBOUND_ROAD_RIGHT)
                {
                    if (Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.STOP
                        && Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT).State == SignalState.STOP
                        && Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.STOP)
                    {
                        Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).SwitchTo(SignalState.GO);
                        Queue.RemoveAt(0);
                    }
                }

                //WEST_LANE_LEFT
                else if (Queue[0] == LaneId.WEST_INBOUND_ROAD_LEFT)
                {
                    if (Intersection.GetTrafficLight(LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.STOP
                        && Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.STOP
                        && Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT).State == SignalState.STOP
                        && Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_RIGHT).State == SignalState.STOP)
                    {
                        Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.GO);
                        Queue.RemoveAt(0);
                    }
                }
            }
        }
    }
}

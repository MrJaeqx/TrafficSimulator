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

        public override void MakeTurn()
        {
            foreach (RoadUser roadUser in Intersection.RoadUsers)
            {
                Point P = roadUser.Location;
                Random random = new Random();

                //NORTH_INBOUND_LANE
                if (roadUser.Direction == 270)
                {
                    //RIGHT_LANE
                    if (P.X == 156 && P.Y == 156)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(0, 156));
                        }
                    }
                    else if (P.X == 156 && P.Y == 182)
                    {
                        if (random.Next(0, 3) == 1)
                        {
                            roadUser.FaceTo(new Point(0, 182));
                        }
                    }
                    //LEFT_LANE
                    else if (P.X == 184 && P.Y == 244)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            roadUser.FaceTo(new Point(400, 244));
                        }
                    }
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
                    else if (P.X == 182 && P.Y == 182)
                    {
                        if (random.Next(0, 2) == 1)
                        {
                            roadUser.FaceTo(new Point(182, 400));
                        }
                    }
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
                    if (P.X == 216 && P.Y == 216)
                    {;
                        if (random.Next(0, 2) == 1)
                        {
                            roadUser.FaceTo(new Point(216, 0));
                        }
                    }
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
               if (Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_RIGHT).State == SignalState.STOP 
                   && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(LaneId.WEST_INBOUND_ROAD_RIGHT).BoundingBox))
               {
                   roadUser.Speed = 0;
                   if(!Queue.Contains(LaneId.WEST_INBOUND_ROAD_RIGHT))
                   {
                    Queue.Add(LaneId.WEST_INBOUND_ROAD_RIGHT);
                   }
               }
               //WEST inbound LEFT lane
               else if (Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).State == SignalState.STOP
                   && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(LaneId.WEST_INBOUND_ROAD_LEFT).BoundingBox))
               {
                   roadUser.Speed = 0;
                   if(!Queue.Contains(LaneId.WEST_INBOUND_ROAD_RIGHT))
                   {
                    Queue.Add(LaneId.WEST_INBOUND_ROAD_LEFT);
                   }
               }
               //NORTH inbound LEFT AND RIGHT lane
               else if (Intersection.GetTrafficLight(LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT).State == SignalState.STOP
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

        public override void HandleHeadTailCollision()
        {
            foreach (RoadUser roadUser1 in Intersection.RoadUsers)
            {
                Rectangle boundBox = roadUser1.BoundingBox;

                //driving right
                if (roadUser1.Direction == 0)
                {
                    boundBox.Offset(new Point(4, 0));

                    foreach (RoadUser roadUser2 in Intersection.RoadUsers)
                    {
                        if (roadUser1 != roadUser2 && boundBox.IntersectsWith(roadUser2.BoundingBox))
                        {
                            roadUser1.Speed = 0;
                        }
                        else
                        {
                            roadUser1.Speed = 2;
                        }
                    }
                }
                //driving down
                else if (roadUser1.Direction == 90)
                {
                    boundBox.Offset(new Point(0, 4));

                    foreach (RoadUser roadUser2 in Intersection.RoadUsers)
                    {
                        if (roadUser1 != roadUser2 && boundBox.IntersectsWith(roadUser2.BoundingBox))
                        {
                            roadUser1.Speed = 0;
                        }
                        else
                        {
                            roadUser1.Speed = 2;
                        }
                    }
                }
                //driving left
                else if (roadUser1.Direction == 180)
                {
                    boundBox.Offset(new Point(-4, 0));

                    foreach (RoadUser roadUser2 in Intersection.RoadUsers)
                    {
                        if (roadUser1 != roadUser2 && boundBox.IntersectsWith(roadUser2.BoundingBox))
                        {
                            roadUser1.Speed = 0;
                        }
                        else
                        {
                            roadUser1.Speed = 2;
                        }
                    }
                }
                //driving up
                else if (roadUser1.Direction == 270)
                {
                    boundBox.Offset(new Point(0, 4));

                    foreach (RoadUser roadUser2 in Intersection.RoadUsers)
                    {
                        if (roadUser1 != roadUser2 && boundBox.IntersectsWith(roadUser2.BoundingBox))
                        {
                            roadUser1.Speed = 0;
                        }
                        else
                        {
                            roadUser1.Speed = 2;
                        }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Windows.Forms;
using System.Drawing;

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

        public void HandleHeadTailCollision()
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
            }
        }

        public abstract void HandleQueue();
    }
}

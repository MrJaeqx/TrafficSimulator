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
        public IntersectionControl Intersection { get; protected set; }

        public IntersectionControl IntersectionLeft { get; protected set; }
        public IntersectionControl IntersectionTop { get; protected set; }
        public IntersectionControl IntersectionRight { get; protected set; }
        public IntersectionControl IntersectionBottom { get; protected set; }

        public abstract List<LaneId> Queue { get; protected set; }

        public LogicControl()
        {
            Queue = new List<LaneId>();
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
        protected void Type1Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
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
        protected void Type2Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
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

        public abstract void MakeTurn();

        public void RemoveOutsideScreenRoadUser()
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

        protected bool AddToTrafficLightQueue(LaneId laneId, RoadUser roadUser)
        {
            return ((Intersection.GetTrafficLight(laneId).State == SignalState.STOP
                || Intersection.GetTrafficLight(laneId).State == SignalState.CLEAR_CROSSING)
                && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(laneId).BoundingBox));
        }

        protected void HandleTrafficLightLane(RoadUser roadUser, LaneId lane)
        {
            if (AddToTrafficLightQueue(lane, roadUser))
            {
                roadUser.Speed = 0;
                if (!Queue.Contains(lane))
                {
                    Queue.Add(lane);
                }
            }

        }

        public abstract void HandleTrafficLight();

        private void CheckCollision(RoadUser roadUser1, Rectangle boundBox)
        {
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

        public void HandleHeadTailCollision()
        {
            foreach (RoadUser roadUser1 in Intersection.RoadUsers)
            {
                Rectangle boundBox = roadUser1.BoundingBox;

                //driving right
                if (roadUser1.Direction == 0)
                {
                    boundBox.Offset(new Point(4, 0));
                    CheckCollision(roadUser1, boundBox);
                }
                //driving down
                else if (roadUser1.Direction == 270)
                {
                    boundBox.Offset(new Point(0, 4));
                    CheckCollision(roadUser1, boundBox);
                }
                //driving left
                else if (roadUser1.Direction == 180)
                {
                    boundBox.Offset(new Point(-4, 0));
                    CheckCollision(roadUser1, boundBox);
                }
                //driving up
                else if (roadUser1.Direction == 90)
                {
                    boundBox.Offset(new Point(0, 4));
                    CheckCollision(roadUser1, boundBox);
                }
            }
        }

        public abstract void HandleQueue();
    }
}

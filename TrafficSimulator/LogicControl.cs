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
        private Random random = new Random();

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
        /// Bepalen om een bocht te maken met een kans van 1 op 2
        /// </summary>
        /// <param name="roadUser">de roaduser waar het om gaat</param>
        /// <param name="P"> het punt waar de roaduser zich bevind</param>
        /// <param name="X1"> de X van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="Y1"> de Y van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="X2"> de X van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        /// <param name="Y2"> de Y van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        protected void Type1Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            if (P.X == X1 && P.Y == Y1)
            {
                if (random.Next(0, 1) == 1)
                {
                    roadUser.FaceTo(new Point(X2, Y2));
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
        protected void Type2Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            if (P.X == X1 && P.Y == Y1)
            {
                if (random.Next(0, 2) == 1)
                {
                    roadUser.FaceTo(new Point(X2, Y2));
                }
            }
        }

        /// <summary>
        /// Bepalen om een bocht te maken met een kans van 1 op 4
        /// </summary>
        /// <param name="roadUser">de roaduser waar het om gaat</param>
        /// <param name="P"> het punt waar de roaduser zich bevind</param>
        /// <param name="X1"> de X van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="Y1"> de Y van het punt waar de bocht moet plaatsvinden</param>
        /// <param name="X2"> de X van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        /// <param name="Y2"> de Y van het punt waar de auto naar toe moet wijzen indien hij een bocht maakt</param>
        protected void Type3Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            if (P.X == X1 && P.Y == Y1)
            {
                if (random.Next(0, 3) == 1)
                {
                    roadUser.FaceTo(new Point(X2, Y2));
                }
            }
        }
        /// <summary>
        /// Bepalen maakt een bocht op gegeven locatie
        /// </summary>
        /// <param name="roadUser"></param>de roaduser waar het om gaat</param>
        /// <param name="P"></param>het punt waar de roaduser zich bevind</param>
        /// <param name="X1"></param>de X van het punt waar de bocht plaatsvindt</param>
        /// <param name="Y1"></param>de Y van het punt waar de bocht plaatsvindt</param>
        /// <param name="X2"></param>de X van het punt waar de auto naar toe moet wijzen</param>
        /// <param name="Y2"></param>de Y van het punt waar de auto naar toe moet wijzen</param>

        protected virtual void Type4Turn(RoadUser roadUser, Point P, int X1, int Y1, int X2, int Y2)
        {
            if (P.X == X1 && P.Y == Y1)
            {                
                    roadUser.FaceTo(new Point(X2, Y2));                
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

                    if (P.X >= 418 || P.X <= -18)
                    {
                        Intersection.RemoveRoadUser(roadUser);
                        break;
                    }
                    else if (P.Y >= 418 || P.Y <= -18)
                    {
                        Intersection.RemoveRoadUser(roadUser);
                        break;
                    }
                }
            }
        }

        private RoadUser pickCorrectRoadUser(RoadUser roadUser, int spawnX, int spawnY)
        {
            double maxSpeed = roadUser.MaxSpeed;
            bool redlight = roadUser.RedLight;

            if (roadUser is BlueCar)
            {
                return new BlueCar(new Point(spawnX, spawnY), maxSpeed, redlight);
            }
            else if (roadUser is BlueSportsCar)
            {
                return new BlueSportsCar(new Point(spawnX, spawnY), maxSpeed, redlight);
            }
            else if (roadUser is GreenSportsCar)
            {
                return new GreenSportsCar(new Point(spawnX, spawnY), maxSpeed, redlight);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// methode die gebruikt wordt om roadUsers van het ene kruispunt naar het andere over te zetten
        /// </summary>
        /// <param name="roadUser">de roadUser waar het om gaat</param>
        /// <param name="leaveX">de X positie waar wordt gedetecteerd of een auto het kruispunt gaat verlaten</param>
        /// <param name="leaveY">de Y positie waar wordt gedetecteerd of een auto het kruispunt gaat verlaten</param>
        /// <param name="spawnX">de X positie waar de nieuwe roadUser wordt gemaakt</param>
        /// <param name="spawnY">de Y positie waar de nieuwe roadUser wordt gemaakt</param>
        /// <param name="faceToX">de X positie waarde nieuwe roadUser naar toe moet wijzen</param>
        /// <param name="faceToY">de Y positie waarde nieuwe roadUser naar toe moet wijzen</param>
        private void TransferCarMethod(RoadUser roadUser, int leaveX, int leaveY, int spawnX, int spawnY, int faceToX, int faceToY)
        {
            Point P = roadUser.Location;

            if (IntersectionBottom != null && P.X == leaveX && P.Y == 382)
            {
                RoadUser newRoadUser = pickCorrectRoadUser(roadUser, spawnX, spawnY);

                if (newRoadUser != null)
                {
                    newRoadUser.FaceTo(new Point(faceToX, faceToY));
                    IntersectionBottom.AddRoadUser(newRoadUser);
                }
            }
            else if (IntersectionLeft != null && P.X == 18 && P.Y == leaveY)
            {
                RoadUser newRoadUser = pickCorrectRoadUser(roadUser, spawnX, spawnY);

                if (newRoadUser != null)
                {
                    newRoadUser.FaceTo(new Point(faceToX, faceToY));
                    IntersectionLeft.AddRoadUser(newRoadUser);
                }
            }
            else if (IntersectionRight != null && P.X == 382 && P.Y == leaveY)
            {
                RoadUser newRoadUser = pickCorrectRoadUser(roadUser, spawnX, spawnY);

                if (newRoadUser != null)
                {
                    newRoadUser.FaceTo(new Point(faceToX, faceToY));
                    IntersectionRight.AddRoadUser(newRoadUser);
                }
            }
            else if (IntersectionTop != null && P.X == leaveX && P.Y == 18)
            {
                RoadUser newRoadUser = pickCorrectRoadUser(roadUser, spawnX, spawnY);

                if (newRoadUser != null)
                {
                    newRoadUser.FaceTo(new Point(faceToX, faceToY));
                    IntersectionTop.AddRoadUser(newRoadUser);
                }
            }
        }

        public void TransferCarsBetweenIntersections()
        {
            if (Intersection.RoadUsers.Count > 0)
            {
                foreach (RoadUser roadUser in Intersection.RoadUsers)
                {
                    Point P = roadUser.Location;

                    if (P.Y == 382 && roadUser.Direction == 270)
                    {
                        //tranfser naar een kruispunt aan de onderkant
                        TransferCarMethod(roadUser, 156, 382, 156, -18, 156, 400);
                        TransferCarMethod(roadUser, 186, 382, 186, -18, 186, 400);
                    }
                    else if (P.X == 382 && roadUser.Direction == 0)
                    {
                        //transfer naar een kruispunt rechts
                        TransferCarMethod(roadUser, 382, 216, -18, 216, 400, 216);
                        TransferCarMethod(roadUser, 382, 244, -18, 244, 400, 244);
                    }
                    else if (P.Y == 18 && roadUser.Direction == 90)
                    {
                        //transfer naar een kruipunt aan de bovenkant
                        TransferCarMethod(roadUser, 216, 18, 216, 418, 216, 0);
                        TransferCarMethod(roadUser, 244, 18, 244, 418, 244, 0);
                    }
                    else if (P.X == 18 && roadUser.Direction == 180)
                    {
                        //transfer naar een kruispunt links
                        TransferCarMethod(roadUser, 18, 156, 418, 156, 0, 156);
                        TransferCarMethod(roadUser, 18, 186, 418, 186, 0, 186);
                    }
                }
            }

        }

        protected bool AddToTrafficLightQueue(LaneId laneId, RoadUser roadUser)
        {
            return ((Intersection.GetTrafficLight(laneId).State == SignalState.STOP
                || Intersection.GetTrafficLight(laneId).State == SignalState.CLEAR_CROSSING)
                && roadUser.BoundingBox.IntersectsWith(Intersection.GetSensor(laneId).BoundingBox)
                && !roadUser.RedLight
                //&& !roadUser.CrossRedLight
                );
        }

        protected void HandleTrafficLightLane(RoadUser roadUser, LaneId lane)
        {
            if (Intersection.GetTrafficLight(lane).State == SignalState.GO) roadUser.CrossRedLight = true;

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
            }
        }

        public void HandleCollision()
        {
            if (Intersection.RoadUsers.Count > 0)
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
                        boundBox.Offset(new Point(0, -4));
                        CheckCollision(roadUser1, boundBox);
                    }
                }
            }
        }

        public void CheckSpeed()
        {
            if (Intersection.RoadUsers.Count > 0)
            {
                foreach (RoadUser roadUser in Intersection.RoadUsers)
                {
                    if (roadUser.Speed >= 4) {
                        TrafficMessageSender.SendSpeeding(roadUser.ID, roadUser.Speed);
                    }
                }
            }
        }

        public void CheckRedLight()
        {
            if (Intersection.RoadUsers.Count > 0)
            {
                foreach (RoadUser roadUser in Intersection.RoadUsers)
                {
                    if (roadUser.RedLight) TrafficMessageSender.SendRedLight(roadUser.ID, 0);
                }
            }
        }

        public abstract void HandleQueue();
    }
}

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
                    //LEFT_LANE eerste mogelijkheid om links af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 184, 216, 400, 216);
                    //LEFT_LANE tweede mogelijkheid om links af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 184, 244, 400, 244);
                }
                    
                //EAST_INBOUND_LANE
                else if (roadUser.Direction == 180)
                {
                    
                }

                //SOUTH_INBOUND_LANE
                else if (roadUser.Direction == 90)
                {
                   
                }

                //WEST_INBOUND_LANE
                else if (roadUser.Direction == 0)
                {
                    //RIGHT_LANE eerste mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 156, 244, 156, 400);
                    //RIGHT_LANE tweede mogelijkheid om rechts af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 182, 244, 182, 400);
                    //LEFT_LANE eerste mogelijkheid om links af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 216, 216, 216, 0);
                    //LEFT_LANE tweede mogelijkheid om links af te slaan, met een kans van 1 op 3
                    Type1Turn(roadUser, P, 244, 216, 244, 0);
                }
            }
        }

        public override void RemoveEndOFLaneRoadUser()
        {

        }

        public override void HandleTrafficLight()
        {

        }

        public override void HandleQueue()
        {

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TrafficSimulatorUi
{
    class IntersectionType2 : IntersectionControl
    {
        public IntersectionType2()
            : base ()
        {

        }

        public override void MakeTurn()
        {
            foreach (RoadUser roadUser in roadUsers)
            {
                Point P = roadUser.Location;
                Random random = new Random();
                int shouldTurn = 0;

                //west inbound left lane
                if (P.Y == 216 && P.X == 216)
                {
                    shouldTurn = random.Next(0, 2);
                    if (shouldTurn == 1)
                    {
                        roadUser.FaceTo(new Point(216, 0));
                    }
                }
                else if (P.Y == 216 && P.X == 244)
                {
                    roadUser.FaceTo(new Point(244, 0));
                }

                //west inbound right lane
                if (P.Y == 244 && P.X == 156)
                {
                    shouldTurn = random.Next(0, 3);
                    if (shouldTurn == 1)
                    {
                        roadUser.FaceTo(new Point(156, 400));
                    }
                }
                else if (P.Y == 244 && P.X == 182)
                {
                    if (shouldTurn == 2)
                    {
                        roadUser.FaceTo(new Point(182, 400));
                    }
                }
            }
        }
        
    }
}

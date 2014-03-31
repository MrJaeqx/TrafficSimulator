using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Windows.Forms;
using System.Drawing;

namespace TrafficSimulator
{
    public class RandomRoadUsers
    {
        public List<IntersectionControl> Intersections { get; private set; }

        const int newRoadUserSpawnRate = 1000;

        Timer timer;

        public RandomRoadUsers(List<IntersectionControl> intersections)
        {
            Intersections = intersections;

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = newRoadUserSpawnRate;
            timer.Start();
        }

        public RoadUser pickRandomCar(int spawnX, int spawnY)
        {
            Random carType = new Random();

            int pickNewCar = carType.Next(0, 3);

            switch (pickNewCar)
            {
                case 0:
                    return new BlueCar(new Point(spawnX, spawnY), 2);
                case 1:
                    return new BlueSportsCar(new Point(spawnX, spawnY), 2);
                case 2:
                    return new GreenSportsCar(new Point(spawnX, spawnY), 2);
                default:
                    return null;
            }
        }

        private void timer_Tick(Object myObject, EventArgs myEventArgs)
        {
            Random randomIntersection = new Random();
            Random whereToSpawnRandom = new Random();

            RoadUser newRoadUser = null;

            IntersectionControl intersection = Intersections[randomIntersection.Next(0, 2)];

            if (intersection.IntersectionType == IntersectionType.TYPE_1)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 4);

                switch (whereToSpawn)
                {
                    case 0:
                        //south inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(136, 405), 1);
                        newRoadUser.FaceTo(new Point(136, 0));
                        break;
                    case 1:
                        //south inbound left road
                        newRoadUser = pickRandomCar(216, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        break;
                    case 2:
                        //south inbound right road
                        newRoadUser = pickRandomCar(244, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        break;
                    case 3:
                        //south inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(268, 405), 1);
                        newRoadUser.FaceTo(new Point(268, 0));
                        break;
                }

                intersection.AddRoadUser(newRoadUser);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_2)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 8);

                switch (whereToSpawn)
                {
                    case 0:
                        //north inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(268, -5), 1);
                        newRoadUser.FaceTo(new Point(268, 400));
                        break;
                    case 1:
                        //north inbound left lane
                        newRoadUser = pickRandomCar(156, -18);
                        newRoadUser.FaceTo(new Point(156, 400));
                        break;
                    case 2:
                        //north inbound right lane
                        newRoadUser = pickRandomCar(186, -18);
                        newRoadUser.FaceTo(new Point(186, 400));
                        break;
                    case 3:
                        //north inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(131, -5), 1);
                        newRoadUser.FaceTo(new Point(131, 400));
                        break;
                    case 4:
                        //left inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(-5, 136), 1);
                        newRoadUser.FaceTo(new Point(400, 136));
                        break;
                    case 5:
                        //left inbound left lane
                        newRoadUser = pickRandomCar(-18, 216);
                        newRoadUser.FaceTo(new Point(400, 216));
                        break;
                    case 6:
                        //left inbound right lane
                        newRoadUser = pickRandomCar(-18, 244);
                        newRoadUser.FaceTo(new Point(400, 244));
                        break;
                    case 7:
                        //left inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(-5, 268), 1);
                        newRoadUser.FaceTo(new Point(400, 268));
                        break;
                }

                intersection.AddRoadUser(newRoadUser);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_3)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 8);

                switch (whereToSpawn)
                {
                    case 0:
                        //south inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(136, 405), 1);
                        newRoadUser.FaceTo(new Point(136, 0));
                        break;
                    case 1:
                        //south inbound left lane
                        newRoadUser = pickRandomCar(216, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        break;
                    case 2:
                        //south inbound right lane
                        newRoadUser = pickRandomCar(244, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        break;
                    case 3:
                        //south inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(268, 405), 1);
                        newRoadUser.FaceTo(new Point(268, 0));
                        break;
                    case 4:
                        //left inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(-5, 136), 1);
                        newRoadUser.FaceTo(new Point(400, 136));
                        break;
                    case 5:
                        //left inbound left lane
                        newRoadUser = pickRandomCar(-18, 216);
                        newRoadUser.FaceTo(new Point(400, 216));
                        break;
                    case 6:
                        //left inbound right lane
                        newRoadUser = pickRandomCar(-18, 244);
                        newRoadUser.FaceTo(new Point(400, 244));
                        break;
                    case 7:
                        //left inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(-5, 268), 1);
                        newRoadUser.FaceTo(new Point(400, 268));
                        break;
                }

                intersection.AddRoadUser(newRoadUser);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_4)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 8);

                switch (whereToSpawn)
                {
                    case 0:
                        //south inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(136, 405), 1);
                        newRoadUser.FaceTo(new Point(136, 0));
                        break;
                    case 1:
                        //south inbound left lane
                        newRoadUser = pickRandomCar(216, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        break;
                    case 2:
                        //south inbound right lane
                        newRoadUser = pickRandomCar(244, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        break;
                    case 3:
                        //south inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(269, 405), 1);
                        newRoadUser.FaceTo(new Point(269, 0));
                        break;
                    case 4:
                        //right inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(405, 136), 1);
                        newRoadUser.FaceTo(new Point(0, 136));
                        break;
                    case 5:
                        //right inbound left lane
                        newRoadUser = pickRandomCar(418, 216);
                        newRoadUser.FaceTo(new Point(0, 216));
                        break;
                    case 6:
                        //right inbound right lane
                        newRoadUser = pickRandomCar(418, 244);
                        newRoadUser.FaceTo(new Point(0, 244));
                        break;
                    case 7:
                        //right inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(405, 269), 1);
                        newRoadUser.FaceTo(new Point(0, 269));
                        break;
                }

                intersection.AddRoadUser(newRoadUser);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_5)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 4);

                switch (whereToSpawn)
                {
                    case 0:
                        //north inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(136, -5), 1);
                        newRoadUser.FaceTo(new Point(136, 400));
                        break;
                    case 1:
                        //north inbound left lane
                        newRoadUser = pickRandomCar(216, -18);
                        newRoadUser.FaceTo(new Point(216, 400));
                        break;
                    case 2:
                        //north inbound right lane
                        newRoadUser = pickRandomCar(244, -18);
                        newRoadUser.FaceTo(new Point(216, 400));
                        break;
                    case 3:
                        //north inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(269, -5), 1);
                        newRoadUser.FaceTo(new Point(269, 400));
                        break;
                }

                intersection.AddRoadUser(newRoadUser);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 4);

                switch (whereToSpawn)
                {
                    case 0:
                        //right inbound left pedestrian
                        newRoadUser = new Pedestrian(new Point(405, 136), 1);
                        newRoadUser.FaceTo(new Point(0, 136));
                        break;
                    case 1:
                        //right inbound left lane
                        newRoadUser = pickRandomCar(418, 216);
                        newRoadUser.FaceTo(new Point(0, 216));
                        break;
                    case 2:
                        //right inbound right lane
                        newRoadUser = pickRandomCar(418, 244);
                        newRoadUser.FaceTo(new Point(0, 244));
                        break;
                    case 3:
                        //right inbound right pedestrian
                        newRoadUser = new Pedestrian(new Point(405, 269), 1);
                        newRoadUser.FaceTo(new Point(0, 269));
                        break;
                }

                intersection.AddRoadUser(newRoadUser);
            }
        }
    }
}
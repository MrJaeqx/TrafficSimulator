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

        const int newRoadUserSpawnRate = 10000;

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

            RoadUser newRoadUser;

            IntersectionControl intersection = Intersections[randomIntersection.Next(0, 7)];

            if (intersection.IntersectionType == IntersectionType.TYPE_1)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 4);

                switch (whereToSpawn)
                {
                    case 0:
                        //south inbound left pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 1:
                        //south inbound left road
                        newRoadUser = pickRandomCar(216, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 2:
                        //south inbound right road
                        newRoadUser = pickRandomCar(244, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 3:
                        //south inbound right pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    default:
                        break;
                }
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_2)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 8);

                switch (whereToSpawn)
                {
                    case 0:
                        //north inbound left pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 1:
                        //north inbound left lane
                        newRoadUser = pickRandomCar(156, -18);
                        newRoadUser.FaceTo(new Point(156, 400));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 2:
                        //north inbound right lane
                        newRoadUser = pickRandomCar(186, -18);
                        newRoadUser.FaceTo(new Point(186, 400));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 3:
                        //north inbound right pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 4:
                        //left inbound left pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 5:
                        //left inbound left lane
                        newRoadUser = pickRandomCar(-18, 216);
                        newRoadUser.FaceTo(new Point(400, 216));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 6:
                        //left inbound right lane
                        newRoadUser = pickRandomCar(-18, 244);
                        newRoadUser.FaceTo(new Point(400, 244));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 7:
                        //left inbound right pedestrian
                        //newRoadUser = new Pedestrian;
                        break;
                    default:
                        break;
                }
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_3)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 8);

                switch (whereToSpawn)
                {
                    case 0:
                        //south inbound left pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 1:
                        //south inbound left lane
                        newRoadUser = pickRandomCar(216, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 2:
                        //south inbound right lane
                        newRoadUser = pickRandomCar(244, 418);
                        newRoadUser.FaceTo(new Point(216, 0));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 3:
                        //south inbound right pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 4:
                        //left inbound left pedestrian
                        //newRoadUser = new Pedestrian();
                        break;
                    case 5:
                        //left inbound left lane
                        newRoadUser = pickRandomCar(-18, 216);
                        newRoadUser.FaceTo(new Point(400, 216));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 6:
                        //left inbound right lane
                        newRoadUser = pickRandomCar(-18, 244);
                        newRoadUser.FaceTo(new Point(400, 244));
                        intersection.AddRoadUser(newRoadUser);
                        break;
                    case 7:
                        //left inbound right pedestrian
                        //newRoadUser = new Pedestrian;
                        break;
                    default:
                        break;
                }
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_4)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 8);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_5)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 4);
            }
            else if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
            {
                int whereToSpawn = whereToSpawnRandom.Next(0, 4);
            }
        }
    }
}

﻿using System;
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
        private Random random = new Random();

        public List<IntersectionControl> Intersections { get; private set; }

        const int newRoadUserSpawnRate = 500;

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
            double newCarSpeed = random.Next(2, 4);
            if (random.Next(0, 5) == 0) newCarSpeed = 5;
            bool newCarRedLight = (random.Next(0, 5) == 0);

            switch (random.Next(0, 3))
            {
                case 0:
                    return new BlueCar(new Point(spawnX, spawnY), newCarSpeed, newCarRedLight);
                case 1:
                    return new BlueSportsCar(new Point(spawnX, spawnY), newCarSpeed, newCarRedLight);
                case 2:
                    return new GreenSportsCar(new Point(spawnX, spawnY), newCarSpeed, newCarRedLight);
                default:
                    return null;
            }
        }

        private void timer_Tick(Object myObject, EventArgs myEventArgs)
        {
            RoadUser newRoadUser = null;

            IntersectionControl intersection = Intersections[random.Next(6)];

            if (intersection.RoadUsers.Count < 20)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_1)
                {
                    switch (random.Next(4))
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
                            newRoadUser.FaceTo(new Point(244, 0));
                            break;
                        case 3:
                            //south inbound right pedestrian
                            newRoadUser = new Pedestrian(new Point(268, 405), 1);
                            newRoadUser.FaceTo(new Point(268, 0));
                            break;
                    }
                }
                else if (intersection.IntersectionType == IntersectionType.TYPE_2)
                {
                    switch (random.Next(8))
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
                }
                else if (intersection.IntersectionType == IntersectionType.TYPE_3)
                {
                    switch (random.Next(8))
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
                            newRoadUser.FaceTo(new Point(244, 0));
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
                }
                else if (intersection.IntersectionType == IntersectionType.TYPE_4)
                {
                    switch (random.Next(8))
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
                            newRoadUser.FaceTo(new Point(244, 0));
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
                            newRoadUser = pickRandomCar(418, 156);
                            newRoadUser.FaceTo(new Point(0, 156));
                            break;
                        case 6:
                            //right inbound right lane
                            newRoadUser = pickRandomCar(418, 186);
                            newRoadUser.FaceTo(new Point(0, 186));
                            break;
                        case 7:
                            //right inbound right pedestrian
                            newRoadUser = new Pedestrian(new Point(405, 269), 1);
                            newRoadUser.FaceTo(new Point(0, 269));
                            break;
                    }
                }
                else if (intersection.IntersectionType == IntersectionType.TYPE_5)
                {
                    switch (random.Next(4))
                    {
                        case 0:
                            //north inbound left pedestrian
                            newRoadUser = new Pedestrian(new Point(136, -5), 1);
                            newRoadUser.FaceTo(new Point(136, 400));
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
                            newRoadUser = new Pedestrian(new Point(269, -5), 1);
                            newRoadUser.FaceTo(new Point(269, 400));
                            break;
                    }
                }
                else if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
                {
                    switch (random.Next(4))
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
                }
                intersection.AddRoadUser(newRoadUser);
            }
        }
    }
}
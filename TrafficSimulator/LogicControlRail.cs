using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficSimulatorUi;
using System.Diagnostics;
using TrafficSimulatorUi.Traffic;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficSimulator
{
    public class LogicControlRail : LogicControl
    {
        public override List<LaneId> Queue { get; protected set; }

        private RoadUser lastTrain;
        private Random random = new Random();
        private Timer trainSpawnTimer = new Timer();
        private const int trainSpawnInterval = 6000;

        public LogicControlRail(List<TrafficSimulatorUi.IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
                {
                    base.Intersection = intersection;
                }

                if (intersection.IntersectionType == IntersectionType.TYPE_5)
                {
                    base.IntersectionLeft = intersection;
                }

                base.IntersectionRight = null;
                base.IntersectionTop = null;
                base.IntersectionBottom = null;
            }

            trainSpawnTimer.Interval = trainSpawnInterval;
            trainSpawnTimer.Tick += trainSpawnTimer_Tick;
        }

        private void trainSpawnTimer_Tick(object sender, EventArgs e)
        {
            if (random.Next(0, 2) == 0)
            {
                lastTrain = new RedTrain(new Point(223, 418));
                if (random.Next(5) == 0) lastTrain = new GreenTrain(new Point(223, 418));
                lastTrain.FaceTo(new Point(223, 0));
            }
            else
            {
                lastTrain = new RedTrain(new Point(174, 0));
                if (random.Next(5) == 0) lastTrain = new GreenTrain(new Point(174, 0));
                lastTrain.FaceTo(new Point(174, 418));
            }

            Intersection.AddRoadUser(lastTrain);

            trainSpawnTimer.Stop();
        }

        public override void MakeTurn()
        {
            //throw new NotImplementedException();
        }

        public override void HandleTrafficLight()
        {
            foreach (RoadUser roadUser in base.Intersection.RoadUsers)
            {
                //WEST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT);

                //EAST inbound LEFT AND RIGHT lane
                HandleTrafficLightLane(roadUser, LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT);

                HandleTrafficLightLane(roadUser, LaneId.EAST_PAVEMENT_LEFT);
                HandleTrafficLightLane(roadUser, LaneId.EAST_PAVEMENT_RIGHT);

                HandleTrafficLightLane(roadUser, LaneId.WEST_PAVEMENT_LEFT);
                HandleTrafficLightLane(roadUser, LaneId.WEST_PAVEMENT_RIGHT);
            }
        }

        public override void HandleQueue()
        {
            
        }

        public void TrainIncomingEvent(object sender, EventArgs e)
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);

            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);

            trainSpawnTimer.Start();
        }

        public void TrainPassedEvent(object sender, EventArgs e)
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);

            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);

            if (lastTrain != null)
            {
                if (Intersection.RoadUsers.Exists(x => x == lastTrain))
                {
                    Intersection.RemoveRoadUser(lastTrain);
                }
            }

            trainSpawnTimer.Stop();
        }
    }
}
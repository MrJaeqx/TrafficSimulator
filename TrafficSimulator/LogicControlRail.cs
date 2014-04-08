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
    /// <summary>
    /// Specifieke logic control voor kruispunt type 6 (rails)
    /// </summary>
    public class LogicControlRail : LogicControl
    {
        /// <summary>
        /// Lijst met roadusers in de wachtrij.
        /// </summary>
        public override List<LaneId> Queue { get; protected set; }

        /// <summary>
        /// Laatst gegenereerde trein.
        /// </summary>
        private RoadUser lastTrain;

        /// <summary>
        /// Random voor het bepalen van het type trein.
        /// </summary>
        private Random random = new Random();
        private Timer trainSpawnTimer = new Timer();
        private const int trainSpawnInterval = 6000;

        /// <summary>
        /// Nieuw kruispunt type 6 aanmaken.
        /// </summary>
        /// <param name="intersections">Lijst met andere kruispunten.</param>
        public LogicControlRail(List<TrafficSimulatorUi.IntersectionControl> intersections)
        {
            foreach (IntersectionControl intersection in intersections)
            {
                // Eigen kruispunt instellen.
                if (intersection.IntersectionType == IntersectionType.TYPE_RAILWAY)
                {
                    base.Intersection = intersection;
                }

                // Kruispunt links instellen
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

        /// <summary>
        /// Omdat er bij de rails geen bochten hoeven worden gemaakt is deze methode leeg.
        /// </summary>
        public override void MakeTurn()
        {

        }

        /// <summary>
        /// Stoplicht wachtrij afhandelen.
        /// </summary>
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

        /// <summary>
        /// Omdat de stoplichten door de Arduino worden beheerd is deze methode leeg.
        /// </summary>
        public override void HandleQueue()
        {
            
        }

        /// <summary>
        /// Event dat wordt aangeroepen indien er een trein aankomt.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        public void TrainIncomingEvent()
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.STOP);

            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.STOP);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.STOP);

            trainSpawnTimer.Start();
        }

        /// <summary>
        /// Methode die wordt aangeroepen indien een trein is gepasseert.
        /// </summary>
        /// <param name="sender">Niet gebruikt.</param>
        /// <param name="e">Niet gebruikt.</param>
        public void TrainPassedEvent()
        {
            base.Intersection.GetTrafficLight(LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT).SwitchTo(SignalState.GO);

            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.EAST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_LEFT).SwitchTo(SignalState.GO);
            base.Intersection.GetTrafficLight(LaneId.WEST_PAVEMENT_RIGHT).SwitchTo(SignalState.GO);

            // Indien er al eerder een trein is gespawnt en deze zich nog op de railt bevind wordt deze verwijderd.
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
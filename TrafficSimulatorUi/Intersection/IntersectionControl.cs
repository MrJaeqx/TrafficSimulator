using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Represents an intersection.
    /// An intersection contains traffic lights, sensors and road users (traffic).
    /// 
    /// The IntersectionControl class contains no logic to control traffic.
    /// Its only task is to paint the intersection and it's traffic lights, sensors and road users.
    /// 
    /// </summary>
    public partial class IntersectionControl : UserControl
    {
        /// <summary>
        /// Occurs when a traffic light is clicked
        /// </summary>
        public event EventHandler<TrafficLightClickEventArgs> TrafficLightClick;

        /// <summary>
        /// Occurs when a sensor is clicked
        /// </summary>
        public event EventHandler<SensorClickEventArgs> SensorClick;

        /// <summary>
        /// The default intersection type for new instances.
        /// </summary>
        private const IntersectionType defaultIntersectionType = IntersectionType.TYPE_1;

        /// <summary>
        /// The intersection type. 
        /// <see cref="TrafficSimulator.IntersectionType"/> enum for possible types.
        /// <seealso cref="IntersectionType"/>
        /// </summary>
        private IntersectionType intersectionType;

        /// <summary>
        /// Image containing the intersection's geometry. 
        /// </summary>
        private Image intersectionImage;

        /// <summary>
        /// Dictionary that provides a mapping from a lane to a traffic light.
        /// </summary>
        private Dictionary<LaneId, TrafficLight> trafficLights;

        /// <summary>
        /// Dictionary that provides a mapping from a lane to a sensor.
        /// </summary>
        private Dictionary<LaneId, Sensor> sensors;

        /// <summary>
        /// List of road users present on the intersection.
        /// The road users will be drawn to the control when the control is invalidated.
        /// </summary>
        protected List<RoadUser> roadUsers;

        /// <summary>
        /// Create a default intersection control
        /// </summary>
        public IntersectionControl()
        {
            InitializeComponent();
            trafficLights = new Dictionary<LaneId, TrafficLight>();
            sensors = new Dictionary<LaneId, Sensor>();
            roadUsers = new List<RoadUser>();

            IntersectionType = defaultIntersectionType;
        }

        /// <summary>
        /// The intersection type. <see cref="TrafficSimulator.IntersectionType"/> enum for possible types.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(defaultIntersectionType)]
        [Category("Intersection props")]
        public IntersectionType IntersectionType
        {
            get
            {
                return intersectionType;
            }
            set
            {
                intersectionType = value;
                ConfigureIntersection(IntersectionConfigurations.GetConfig(intersectionType));
                Invalidate();
            }
        }

        public List<RoadUser> RoadUsers
        {
            get
            {
                return roadUsers;
            }
        }

        /// <summary>
        /// Configure the intersection using the given configuration.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        private void ConfigureIntersection(IntersectionConfiguration configuration)
        {
            intersectionImage = configuration.IntersectionImage;

            trafficLights.Clear();
            foreach (LaneId laneId in configuration.LanesWithPedestrianTrafficLights)
            {
                AddTrafficLight(laneId);
            }

            foreach (LaneId laneId in configuration.LanesWithDriverTrafficLights)
            {
                AddTrafficLight(laneId);
            }

            sensors.Clear();
            foreach (LaneId laneId in configuration.LanesWithRoadSensors)
            {
                AddSensor(laneId);
            }

            foreach (LaneId laneId in configuration.LanesWithPedestrianSensors)
            {
                AddSensor(laneId);
            }

            foreach (LaneId laneId in configuration.LanesWithRailwaySensors)
            {
                AddSensor(laneId);
            }
        }

        /// <summary>
        /// Get the traffic light that is a semephore for the given lane.
        /// </summary>
        /// <param name="id">The id of the lane. <see cref="TrafficSimulator.LaneId"/> enum for possible types.</param>
        /// <returns>Returns the traffic light that guards the given lane, 
        ///          or null of no traffic light is present for the lane.</returns>
        public TrafficLight GetTrafficLight(LaneId lane)
        {
            TrafficLight trafficLight;
            if (trafficLights.TryGetValue(lane, out trafficLight))
            {
                return trafficLight;
            }
            return null;
        }

        /// <summary>
        /// Get the sensor that is used to detect road users in the given lane.
        /// </summary>
        /// <param name="id">The id of the lane. <see cref="TrafficSimulator.LaneId"/> enum for possible types.</param>
        /// <returns>Returns the sensor that is used to detect road users in the given lane, 
        ///          or null of no sensor is present for the lane.</returns>
        public Sensor GetSensor(LaneId lane)
        {
            Sensor sensor;
            if (sensors.TryGetValue(lane, out sensor))
            {
                return sensor;
            }
            return null;
        }

        /// <summary>
        /// Add a road user to the intersection so that it can be painted on the intersection.
        /// </summary>
        /// <param name="roadUser">The road user to add.</param>
        public void AddRoadUser(RoadUser roadUser)
        {
            if (roadUser == null)
            {
                throw new ArgumentNullException("roadUser");
            }

            roadUsers.Add(roadUser);
        }

        /// <summary>
        /// Remove a road user from the intersection.
        /// </summary>
        /// <param name="roadUser">The road user to remove.</param>
        public void RemoveRoadUser(RoadUser roadUser)
        {
            if (roadUser == null)
            {
                throw new ArgumentNullException("roadUser");
            }

            roadUsers.Remove(roadUser);
        }

        public void RemoveEndOfLaneRoadUser()
        {
            if (roadUsers.Count > 0)
            {
                foreach (RoadUser roadUser in roadUsers)
                {
                    Point P = roadUser.Location;

                    if (P.X >= 400 || P.X <= -32)
                    {
                        RemoveRoadUser(roadUser);
                        break;
                    }
                    else if (P.Y >= 400 || P.Y <= -32)
                    {
                        RemoveRoadUser(roadUser);
                        break;
                    }
                }
            }
        }

        public virtual void MakeTurn()
        {
            switch (this.intersectionType)
            {
                case IntersectionType.TYPE_1:
                    break;
                    TurnIntersectionType1();
                case IntersectionType.TYPE_2:
                    TurnIntersectionType2();
                    break;
                case IntersectionType.TYPE_3:
                    break;
                case IntersectionType.TYPE_4:
                    break;
                case IntersectionType.TYPE_5:
                    break;
                case IntersectionType.TYPE_RAILWAY:
                    break;
                default:
                    break;
            }
        }

        public void TurnIntersectionType1()
        {
            foreach (RoadUser roadUser in roadUsers)
            {

            }
        }
        
        public void TurnIntersectionType2()
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

        /// <summary>
        /// Paints the graphics to the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntersectionControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics drawingSurface = e.Graphics;

            drawingSurface.DrawImageUnscaled(intersectionImage, 0, 0);

            foreach (KeyValuePair<LaneId, TrafficLight> pair in trafficLights)
            {
                TrafficLight trafficLight = pair.Value;
                trafficLight.DrawTo(drawingSurface);
            }

            foreach (KeyValuePair<LaneId, Sensor> pair in sensors)
            {
                Sensor sensor = pair.Value;
                sensor.DrawTo(drawingSurface);
            }

            foreach (RoadUser roadUser in roadUsers)
            {
                roadUser.DrawTo(drawingSurface);
            }
        }

        /// <summary>
        /// Add a traffic light to the lane.
        /// Traffic lights can only be added to inbound lanes and to pavements.
        /// When a traffic light is already present for the lane. It will be replaced by a new one.
        /// </summary>
        /// <param name="lane">The lane for which to add a traffic light.</param>
        private void AddTrafficLight(LaneId lane)
        {
            TrafficLight trafficLight = null;
            switch (lane)
            {
                case LaneId.NORTH_INBOUND_ROAD_LEFT:
                case LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT: trafficLight = new DriverTrafficLight(new Point(114, 62), Orientation.HORIZONTAL_AND_FLIP); break;
                case LaneId.NORTH_INBOUND_ROAD_RIGHT: trafficLight = new DriverTrafficLight(new Point(103, 62), Orientation.HORIZONTAL_AND_FLIP); break;
                case LaneId.EAST_INBOUND_ROAD_LEFT:
                case LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT: trafficLight = new DriverTrafficLight(new Point(315, 114), Orientation.VERTICAL); break;
                case LaneId.EAST_INBOUND_ROAD_RIGHT: trafficLight = new DriverTrafficLight(new Point(315, 103), Orientation.VERTICAL); break;
                case LaneId.SOUTH_INBOUND_ROAD_LEFT:
                case LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT: trafficLight = new DriverTrafficLight(new Point(277, 315), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_INBOUND_ROAD_RIGHT: trafficLight = new DriverTrafficLight(new Point(288, 315), Orientation.HORIZONTAL); break;
                case LaneId.WEST_INBOUND_ROAD_LEFT:
                case LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT: trafficLight = new DriverTrafficLight(new Point(62, 277), Orientation.VERTICAL_AND_FLIP); break;
                case LaneId.WEST_INBOUND_ROAD_RIGHT: trafficLight = new DriverTrafficLight(new Point(62, 288), Orientation.VERTICAL_AND_FLIP); break;
                case LaneId.NORTH_PAVEMENT_LEFT: trafficLight = new PedestrianTrafficLight(new Point(275, 98), Orientation.HORIZONTAL_AND_FLIP); break;
                case LaneId.NORTH_PAVEMENT_RIGHT: trafficLight = new PedestrianTrafficLight(new Point(116, 98), Orientation.HORIZONTAL_AND_FLIP); break;
                case LaneId.EAST_PAVEMENT_LEFT: trafficLight = new PedestrianTrafficLight(new Point(286, 275), Orientation.VERTICAL); break;
                case LaneId.EAST_PAVEMENT_RIGHT: trafficLight = new PedestrianTrafficLight(new Point(286, 116), Orientation.VERTICAL); break;
                case LaneId.SOUTH_PAVEMENT_LEFT: trafficLight = new PedestrianTrafficLight(new Point(116, 286), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_PAVEMENT_RIGHT: trafficLight = new PedestrianTrafficLight(new Point(275, 286), Orientation.HORIZONTAL); break;
                case LaneId.WEST_PAVEMENT_LEFT: trafficLight = new PedestrianTrafficLight(new Point(98, 116), Orientation.VERTICAL_AND_FLIP); break;
                case LaneId.WEST_PAVEMENT_RIGHT: trafficLight = new PedestrianTrafficLight(new Point(98, 275), Orientation.VERTICAL_AND_FLIP); break;
                default: throw new ArgumentException("Lane must be inbound or a pavement.", "lane");
            }

            if (trafficLight != null)
            {
                trafficLights[lane] = trafficLight; // Using [] will replace the existing value for the given key.
            }
        }

        /// <summary>
        /// Add a sensor to the lane.
        /// Sensors can only be added to inbound lanes and to pavements.
        /// When a sensor is already present for the lane. It will be replaced by a new one.
        /// </summary>
        /// <param name="lane">The lane for which to add a sensor.</param>
        private void AddSensor(LaneId lane)
        {
            Sensor sensor = null;
            switch (lane)
            {
                case LaneId.NORTH_INBOUND_ROAD_LEFT: sensor = new SingleLaneDriverSensor(new Point(175, 110), Orientation.HORIZONTAL); break;
                case LaneId.NORTH_INBOUND_ROAD_RIGHT: sensor = new SingleLaneDriverSensor(new Point(148, 110), Orientation.HORIZONTAL); break;
                case LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT: sensor = new DoubleLaneDriverSensor(new Point(148, 110), Orientation.HORIZONTAL); break;
                case LaneId.EAST_INBOUND_ROAD_LEFT: sensor = new SingleLaneDriverSensor(new Point(286, 175), Orientation.VERTICAL); break;
                case LaneId.EAST_INBOUND_ROAD_RIGHT: sensor = new SingleLaneDriverSensor(new Point(286, 148), Orientation.VERTICAL); break;
                case LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT: sensor = new DoubleLaneDriverSensor(new Point(286, 148), Orientation.VERTICAL); break;
                case LaneId.SOUTH_INBOUND_ROAD_LEFT: sensor = new SingleLaneDriverSensor(new Point(205, 286), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_INBOUND_ROAD_RIGHT: sensor = new SingleLaneDriverSensor(new Point(233, 286), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT: sensor = new DoubleLaneDriverSensor(new Point(205, 286), Orientation.HORIZONTAL); break;
                case LaneId.WEST_INBOUND_ROAD_LEFT: sensor = new SingleLaneDriverSensor(new Point(110, 205), Orientation.VERTICAL); break;
                case LaneId.WEST_INBOUND_ROAD_RIGHT: sensor = new SingleLaneDriverSensor(new Point(110, 233), Orientation.VERTICAL); break;
                case LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT: sensor = new DoubleLaneDriverSensor(new Point(110, 205), Orientation.VERTICAL); break;
                case LaneId.NORTH_PAVEMENT_LEFT: sensor = new PedestrianSensor(new Point(263, 138), Orientation.HORIZONTAL); break;
                case LaneId.NORTH_PAVEMENT_RIGHT: sensor = new PedestrianSensor(new Point(128, 138), Orientation.HORIZONTAL); break;
                case LaneId.EAST_PAVEMENT_LEFT: sensor = new PedestrianSensor(new Point(258, 263), Orientation.VERTICAL); break;
                case LaneId.EAST_PAVEMENT_RIGHT: sensor = new PedestrianSensor(new Point(258, 128), Orientation.VERTICAL); break;
                case LaneId.SOUTH_PAVEMENT_LEFT: sensor = new PedestrianSensor(new Point(128, 258), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_PAVEMENT_RIGHT: sensor = new PedestrianSensor(new Point(263, 258), Orientation.HORIZONTAL); break;
                case LaneId.WEST_PAVEMENT_LEFT: sensor = new PedestrianSensor(new Point(138, 128), Orientation.VERTICAL); break;
                case LaneId.WEST_PAVEMENT_RIGHT: sensor = new PedestrianSensor(new Point(138, 263), Orientation.VERTICAL); break;
                case LaneId.NORTH_INBOUND_RAILWAY: sensor = new RailwaySensor(new Point(165, 2), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_OUTBOUND_RAILWAY: sensor = new RailwaySensor(new Point(165, 285), Orientation.HORIZONTAL); break;
                case LaneId.SOUTH_INBOUND_RAILWAY: sensor = new RailwaySensor(new Point(215, 388), Orientation.HORIZONTAL); break;
                case LaneId.NORTH_OUTBOUND_RAILWAY: sensor = new RailwaySensor(new Point(215, 105), Orientation.HORIZONTAL); break;
                default: throw new ArgumentException("Lane must be inbound roads, a pavement or a railway.", "lane");
            }

            if (sensor != null)
            {
                sensors[lane] = sensor; // Using [] will replace the existing value for the given key.
            }
        }

        /// <summary>
        /// Catches mouse clicks on the intersection, determines which road users, sensors or traffic lights are clicked
        /// and sends events for the clicked items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntersectionControl_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (KeyValuePair<LaneId, TrafficLight> pair in trafficLights)
            {
                TrafficLight trafficLight = pair.Value;
                if (trafficLight.BoundingBox.Contains(e.Location))
                {
                    OnTrafficLightClick(new TrafficLightClickEventArgs(pair.Key));
                }
            }

            foreach (KeyValuePair<LaneId, Sensor> pair in sensors)
            {
                Sensor sensor = pair.Value;
                if (sensor.BoundingBox.Contains(e.Location))
                {
                    OnSensorClick(new SensorClickEventArgs(pair.Key));
                }
            }

            foreach (RoadUser roadUser in roadUsers)
            {
                if (roadUser.BoundingBox.Contains(e.Location))
                {
                    // You can add your own code here to send events for a clicked road user
                    Debug.WriteLine("Clicked roaduser");
                }
            }
        }

        /// <summary>
        /// Call registered event handlers
        /// </summary>
        /// <param name="eventArgs"></param>
        protected void OnTrafficLightClick(TrafficLightClickEventArgs eventArgs)
        {
            EventHandler<TrafficLightClickEventArgs> trafficLightClick = TrafficLightClick;
            if (trafficLightClick != null)
            {
                trafficLightClick(this, eventArgs);
            }
        }

        /// <summary>
        /// Call registered event handlers
        /// </summary>
        /// <param name="eventArgs"></param>
        protected void OnSensorClick(SensorClickEventArgs eventArgs)
        {
            EventHandler<SensorClickEventArgs> sensorClick = SensorClick;
            if (sensorClick != null)
            {
                sensorClick(this, eventArgs);
            }
        }
    }
}

using System.Collections.Generic;
using System.Drawing;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// The configuration of an intersection.
    /// </summary>
    public abstract class IntersectionConfiguration
    {
        /// <summary>
        /// The image used for drawing the intersection background.
        /// </summary>
        public Image IntersectionImage { get; protected set; }

        /// <summary>
        /// The lanes on which a pedestrian traffic light is present.
        /// </summary>
        public List<LaneId> LanesWithPedestrianTrafficLights { get; protected set; }

        /// <summary>
        /// The lanes on which a driver traffic light is present.
        /// </summary>
        public List<LaneId> LanesWithDriverTrafficLights { get; protected set; }

        /// <summary>
        /// The lanes on which a sensors is present which can be used to detect waiting vehicles on the road.
        /// </summary>
        public List<LaneId> LanesWithRoadSensors { get; protected set; }

        /// <summary>
        /// The lanes on which a sensors is present which can be used to detect waiting pedestrians (they have to press the sensor).
        /// </summary>
        public List<LaneId> LanesWithPedestrianSensors { get; protected set; }

        /// <summary>
        /// The lanes on which a sensors is present which can be used to detect inbound en outbound trains.
        /// </summary>
        public List<LaneId> LanesWithRailwaySensors { get; protected set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulatorUi.Intersection.Configurations
{
    /// <summary>
    /// Configuration for intersection of type 1 
    /// </summary>
    internal sealed class Type1Configuration : IntersectionConfiguration
    {
        public Type1Configuration()
        {
            IntersectionImage = Properties.Resources.IntersectionType1Image;

            LanesWithPedestrianTrafficLights = new List<LaneId>() { };

            LanesWithDriverTrafficLights = new List<LaneId>() { 
                LaneId.NORTH_INBOUND_ROAD_LEFT,LaneId.NORTH_INBOUND_ROAD_RIGHT,
                LaneId.EAST_INBOUND_ROAD_LEFT,LaneId.EAST_INBOUND_ROAD_RIGHT,
                LaneId.SOUTH_INBOUND_ROAD_LEFT,LaneId.SOUTH_INBOUND_ROAD_RIGHT,
                LaneId.WEST_INBOUND_ROAD_LEFT, LaneId.WEST_INBOUND_ROAD_RIGHT
            };

            LanesWithRoadSensors = LanesWithDriverTrafficLights;

            LanesWithPedestrianSensors = new List<LaneId>() { };

            LanesWithRailwaySensors = new List<LaneId>() { };
        }
    }
}

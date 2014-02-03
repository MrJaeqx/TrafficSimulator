using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulatorUi.Intersection.Configurations
{
    /// <summary>
    /// Configuration for intersection of type 2 
    /// </summary>
    internal sealed class Type2Configuration : IntersectionConfiguration
    {
        public Type2Configuration()
        {
            IntersectionImage = Properties.Resources.IntersectionType2Image;

            LanesWithPedestrianTrafficLights = new List<LaneId>() {
                LaneId.EAST_PAVEMENT_LEFT, LaneId.EAST_PAVEMENT_RIGHT,
                LaneId.WEST_PAVEMENT_LEFT, LaneId.WEST_PAVEMENT_RIGHT };

            LanesWithDriverTrafficLights = new List<LaneId>() { 
                LaneId.NORTH_INBOUND_ROAD_LEFT_AND_RIGHT,
                LaneId.EAST_INBOUND_ROAD_LEFT,LaneId.EAST_INBOUND_ROAD_RIGHT,
                LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT,
                LaneId.WEST_INBOUND_ROAD_LEFT, LaneId.WEST_INBOUND_ROAD_RIGHT
            };

            LanesWithRoadSensors = LanesWithDriverTrafficLights;

            LanesWithPedestrianSensors = new List<LaneId>() {
                LaneId.EAST_PAVEMENT_LEFT, LaneId.EAST_PAVEMENT_RIGHT,
                LaneId.WEST_PAVEMENT_LEFT, LaneId.WEST_PAVEMENT_RIGHT 
            };

            LanesWithRailwaySensors = new List<LaneId>() { };
        }
    }
}

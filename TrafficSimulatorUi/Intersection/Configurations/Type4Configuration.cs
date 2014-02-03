using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulatorUi.Intersection.Configurations
{
    /// <summary>
    /// Configuration for intersection of type 4 
    /// </summary>
    internal sealed class Type4Configuration : IntersectionConfiguration
    {
        public Type4Configuration()
        {
            IntersectionImage = Properties.Resources.IntersectionType4Image;

            LanesWithPedestrianTrafficLights = new List<LaneId>() { 
                LaneId.NORTH_PAVEMENT_LEFT, LaneId.NORTH_PAVEMENT_RIGHT,
                LaneId.EAST_PAVEMENT_LEFT, LaneId.SOUTH_PAVEMENT_LEFT, 
                LaneId.SOUTH_PAVEMENT_RIGHT, LaneId.WEST_PAVEMENT_RIGHT };

            LanesWithDriverTrafficLights = new List<LaneId>() { 
                LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT,
                LaneId.SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT,
                LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT,
            };

            LanesWithRoadSensors = LanesWithDriverTrafficLights;

            LanesWithPedestrianSensors = new List<LaneId>() { 
                LaneId.NORTH_PAVEMENT_LEFT, LaneId.NORTH_PAVEMENT_RIGHT, 
                LaneId.EAST_PAVEMENT_LEFT, LaneId.SOUTH_PAVEMENT_LEFT,
                LaneId.SOUTH_PAVEMENT_RIGHT, LaneId.WEST_PAVEMENT_RIGHT
            };

            LanesWithRailwaySensors = new List<LaneId>() { };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulatorUi.Intersection.Configurations
{
    /// <summary>
    /// Configuration for intersection of type 5 
    /// </summary>
    internal sealed class Type5Configuration : IntersectionConfiguration
    {
        public Type5Configuration()
        {
            IntersectionImage = Properties.Resources.IntersectionType5Image;

            LanesWithPedestrianTrafficLights = new List<LaneId>() { 
                LaneId.NORTH_PAVEMENT_LEFT, LaneId.NORTH_PAVEMENT_RIGHT,
                LaneId.EAST_PAVEMENT_LEFT, LaneId.EAST_PAVEMENT_RIGHT,
                LaneId.SOUTH_PAVEMENT_LEFT, LaneId.SOUTH_PAVEMENT_RIGHT, 
                LaneId.WEST_PAVEMENT_LEFT, LaneId.WEST_PAVEMENT_RIGHT };

            LanesWithDriverTrafficLights = new List<LaneId>() {
                LaneId.NORTH_INBOUND_ROAD_LEFT,LaneId.NORTH_INBOUND_ROAD_RIGHT,
                LaneId.EAST_INBOUND_ROAD_LEFT,LaneId.EAST_INBOUND_ROAD_RIGHT,
                LaneId.SOUTH_INBOUND_ROAD_LEFT,LaneId.SOUTH_INBOUND_ROAD_RIGHT,
                LaneId.WEST_INBOUND_ROAD_LEFT, LaneId.WEST_INBOUND_ROAD_RIGHT};

            LanesWithRoadSensors = LanesWithDriverTrafficLights;

            LanesWithPedestrianSensors = new List<LaneId>() {
                LaneId.NORTH_PAVEMENT_LEFT, LaneId.NORTH_PAVEMENT_RIGHT,
                LaneId.EAST_PAVEMENT_LEFT, LaneId.EAST_PAVEMENT_RIGHT ,
                LaneId.SOUTH_PAVEMENT_LEFT, LaneId.SOUTH_PAVEMENT_RIGHT,
                LaneId.WEST_PAVEMENT_LEFT, LaneId.WEST_PAVEMENT_RIGHT
            };

            LanesWithRailwaySensors = new List<LaneId>() { };
        }
    }
}

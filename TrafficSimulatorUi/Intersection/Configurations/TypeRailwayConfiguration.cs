using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulatorUi.Intersection.Configurations
{
    /// <summary>
    /// Configuration for intersection of type 'Railway' 
    /// </summary>
    internal sealed class TypeRailwayConfiguration : IntersectionConfiguration
    {
        public TypeRailwayConfiguration()
        {
            IntersectionImage = Properties.Resources.IntersectionTypeRailwayImage;

            LanesWithPedestrianTrafficLights = new List<LaneId>() { 
                LaneId.EAST_PAVEMENT_LEFT, LaneId.EAST_PAVEMENT_RIGHT,
                LaneId.WEST_PAVEMENT_LEFT, LaneId.WEST_PAVEMENT_RIGHT };

            LanesWithDriverTrafficLights = new List<LaneId>() {
                LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT,
                LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT,
            };

            LanesWithRoadSensors = new List<LaneId>() {
                LaneId.EAST_INBOUND_ROAD_LEFT_AND_RIGHT,
                LaneId.WEST_INBOUND_ROAD_LEFT_AND_RIGHT };
            LanesWithPedestrianSensors = new List<LaneId>() { };
            LanesWithRailwaySensors = new List<LaneId>() {
                LaneId.NORTH_INBOUND_RAILWAY, LaneId.NORTH_OUTBOUND_RAILWAY,
                LaneId.SOUTH_INBOUND_RAILWAY, LaneId.SOUTH_OUTBOUND_RAILWAY };
        }
    }
}

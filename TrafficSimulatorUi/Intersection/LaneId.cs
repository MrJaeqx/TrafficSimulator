
namespace TrafficSimulatorUi
{
    /// <summary>
    /// Enumeration used for naming the lanes of roads and pavements
    /// that are present on an intersection.
    /// 
    /// For roads the name consists of: 
    /// - A compass direction (north, east, south, west) that states 
    ///   on which part of the intersection the road is present, see:
    ///     N
    ///   W X E
    ///     S
    /// - The direction of the road. 
    ///   For roads containing traffic that leave the intersection this is outbound.
    ///   For roads containing traffic that enter the intersection this is inbound.
    /// - The lane of the road. Each road has a right lane and a left lane
    ///   (viewed from a person who is on the road).
    ///   
    /// For pavement the name consists of:
    /// - A compass direction (north, east, south, west) that states 
    ///   on which part of the intersection the pavement is present, see:
    ///     N
    ///   W X E
    ///     S
    /// - The side of the road the pavement is on. Each pavement lies to the left 
    ///   or to the right of the main road (viewed from a person who is on the road).
    /// Pavements can be traveled in both directions by pedestrians. So no direction
    /// is present in the name of the constant.
    /// 
    /// </summary>
    public enum LaneId
    {
        NORTH_INBOUND_ROAD_LEFT = 0,
        NORTH_INBOUND_ROAD_RIGHT,
        NORTH_INBOUND_ROAD_LEFT_AND_RIGHT,
        NORTH_OUTBOUND_ROAD_LEFT,
        NORTH_OUTBOUND_ROAD_RIGHT,
        NORTH_OUTBOUND_ROAD_LEFT_AND_RIGHT,

        EAST_INBOUND_ROAD_LEFT,
        EAST_INBOUND_ROAD_RIGHT,
        EAST_INBOUND_ROAD_LEFT_AND_RIGHT,
        EAST_OUTBOUND_ROAD_LEFT,
        EAST_OUTBOUND_ROAD_RIGHT,
        EAST_OUTBOUND_ROAD_LEFT_AND_RIGHT,

        SOUTH_INBOUND_ROAD_LEFT,
        SOUTH_INBOUND_ROAD_RIGHT,
        SOUTH_INBOUND_ROAD_LEFT_AND_RIGHT,
        SOUTH_OUTBOUND_ROAD_LEFT,
        SOUTH_OUTBOUND_ROAD_RIGHT,
        SOUTH_OUTBOUND_ROAD_LEFT_AND_RIGHT,

        WEST_INBOUND_ROAD_LEFT,
        WEST_INBOUND_ROAD_RIGHT,
        WEST_INBOUND_ROAD_LEFT_AND_RIGHT,
        WEST_OUTBOUND_ROAD_LEFT,
        WEST_OUTBOUND_ROAD_RIGHT,
        WEST_OUTBOUND_ROAD_LEFT_AND_RIGHT,

        NORTH_PAVEMENT_LEFT,
        NORTH_PAVEMENT_RIGHT,

        EAST_PAVEMENT_LEFT,
        EAST_PAVEMENT_RIGHT,

        SOUTH_PAVEMENT_LEFT,
        SOUTH_PAVEMENT_RIGHT,

        WEST_PAVEMENT_LEFT,
        WEST_PAVEMENT_RIGHT,

        NORTH_INBOUND_RAILWAY,
        NORTH_OUTBOUND_RAILWAY,
        SOUTH_INBOUND_RAILWAY,
        SOUTH_OUTBOUND_RAILWAY
    }
}

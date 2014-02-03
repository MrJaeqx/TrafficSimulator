using System;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Provides data for the TrafficLightClick event
    /// </summary>
    public class TrafficLightClickEventArgs : EventArgs
    {
        /// <summary>
        /// Create a TrafficLightClickEventArgs object for sending with a TrafficLightClick event.
        /// </summary>
        /// <param name="laneId">The lane of the clicked traffic light.</param>
        public TrafficLightClickEventArgs(LaneId laneId)
        {
            LaneId = laneId;
        }

        /// <summary>
        /// The lane of the clicked trafic light.
        /// </summary>
        public LaneId LaneId { get; private set; }
    }
}

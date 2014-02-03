using System;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Provides data for the SensorClick event.
    /// </summary>
    public class SensorClickEventArgs : EventArgs
    {
        /// <summary>
        /// Create a SensorClickEventArgs object for sending with a SensorClick event.
        /// </summary>
        /// <param name="laneId">The lane of the clicked sensor.</param>
        public SensorClickEventArgs(LaneId laneId)
        {
            LaneId = laneId;
        }

        /// <summary>
        /// The lane of the clicked sensor.
        /// </summary>
        public LaneId LaneId { get; private set; }
    }
}

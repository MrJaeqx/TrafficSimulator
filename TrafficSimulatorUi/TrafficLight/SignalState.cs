
namespace TrafficSimulatorUi
{
    /// <summary>
    /// The state of the traffic lights signal.
    /// It was a design decision to work with these states instead of colors like red, yellow and green.
    /// This is because not all traffic lights have the same colors.
    /// But all traffic lights do have these states (in this simulation), which can be translated
    /// to a color and/or blinking lights.
    /// </summary>
    public enum SignalState
    {
        /// <summary>
        /// Signal when the traffic light is disabled
        /// </summary>
        IDLE,

        /// <summary>
        /// Signal traffic to drive / walk.
        /// </summary>
        GO,

        /// <summary>
        /// Signal traffic to stop if they can. The next signal will be STOP.
        /// </summary>
        CLEAR_CROSSING,

        /// <summary>
        /// Signal traffic to wait until GO.
        /// </summary>
        STOP
    }
}

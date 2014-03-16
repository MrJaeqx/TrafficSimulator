using System.Drawing;

namespace TrafficSimulatorUi
{
    public abstract class TrafficLight : IntersectionItem
    {
        /// <summary>
        /// Creates a new traffic light.
        /// </summary>
        /// <param name="location">The location for the traffic light.</param>
        /// <param name="size">The size of the traffic light.</param>
        public TrafficLight(Point location, int width, int height, Orientation orientation)
            : base(location, width, height, orientation)
        {
            State = SignalState.STOP;
        }

        /// <summary>
        /// The state of the traffic light
        /// </summary>
        public SignalState State { get; protected set; }

        /// <summary>
        /// Switches the traffic light to the given state
        /// </summary>
        /// <param name="color">The state to switch to. 
        /// Valid states are SignalState.IDLE, SignalState.GO, SignalState.STOP. </param>
        public abstract void SwitchTo(SignalState state);
    }
}

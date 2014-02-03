using System.Drawing;

namespace TrafficSimulatorUi
{
    public abstract class Sensor : IntersectionItem
    {
        /// <summary>
        /// Creates a new sensor.
        /// </summary>
        /// <param name="location">The location for the sensor.</param>
        /// <param name="orientation">The orientation to use.</param>
        public Sensor(Point location, int width, int height, Orientation orientation)
            : base(location, width, height, orientation)
        {
         
        }
    }
}

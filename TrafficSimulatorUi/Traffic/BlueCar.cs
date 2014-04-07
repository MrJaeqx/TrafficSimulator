using System.Drawing;

namespace TrafficSimulatorUi
{
    public class BlueCar: RoadUser
    {
        /// <summary>
        /// Create a new car
        /// </summary>
        public BlueCar(Point location, double speed, bool redlight)
            : base(location, speed, Properties.Resources.BlueCarImage, redlight)
        {
        }
    }
}

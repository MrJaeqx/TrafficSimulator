using System.Drawing;

namespace TrafficSimulatorUi
{
    public class BlueSportsCar : RoadUser
    {
        /// <summary>
        /// Create a new car
        /// </summary>
        public BlueSportsCar(Point location, double speed, bool redlight)
            : base(location, speed, Properties.Resources.BlueSportsCarImage, redlight)
        {
        }
    }
}

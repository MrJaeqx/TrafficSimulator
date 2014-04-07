using System.Drawing;

namespace TrafficSimulatorUi
{
    public class GreenSportsCar : RoadUser
    {
        /// <summary>
        /// Create a new car
        /// </summary>
        public GreenSportsCar(Point location, double speed, bool redlight)
            : base(location, speed, Properties.Resources.GreenSportsCarImage, redlight)
        {
        }
    }
}

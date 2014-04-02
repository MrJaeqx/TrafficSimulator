using System.Drawing;

namespace TrafficSimulatorUi
{
    public class Pedestrian : RoadUser
    {
        /// <summary>
        /// Create a new pedestrian
        /// </summary>
        public Pedestrian(Point location, double speed)
            : base(location, speed, Properties.Resources.Pedestrian, false)
        {
        }
    }
}

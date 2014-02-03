using System;
using System.Drawing;

namespace TrafficSimulatorUi
{
    public class SingleLaneDriverSensor : Sensor
    {
        /// <summary>
        /// Width of the sensor. 
        /// </summary>
        private const int width = 20;

        /// <summary>
        /// Height of the sensor.
        /// </summary>
        private const int height = 4;

        /// <summary>
        /// The brush used to paint the background.
        /// </summary>
        private SolidBrush backgroundBrush;

        /// <summary>
        /// Creates a new sensor for use on roads.
        /// </summary>
        /// <param name="location">The location for the sensor (upper left corner)</param>
        /// <param name="orientation">The orientation to use (horizontal or vertical)</param>
        public SingleLaneDriverSensor(Point location, Orientation orientation)
            : base(location, width, height, orientation)
        {
            backgroundBrush = new SolidBrush(Color.FromArgb(51, 51, 51));
        }

        /// <summary>
        /// Draws the sensor to the drawing surface.
        /// </summary>
        /// <param name="drawingSurface">The drawing surface to draw onto.</param>
        public override void DrawTo(Graphics drawingSurface)
        {
            drawingSurface.FillRectangle(backgroundBrush, BoundingBox);
        }
    }
}

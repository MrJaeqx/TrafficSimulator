using System.Drawing;


namespace TrafficSimulatorUi
{
    public abstract class IntersectionItem : IDrawable
    {
        /// <summary>
        /// Creates a new intersection item.
        /// </summary>
        /// <param name="location">The location for the item.</param>
        /// <param name="width">The width of the item.</param>
        /// <param name="heigth">The height of the item.</param>
        /// <param name="orientation">The orientation of the item.</param>
        public IntersectionItem(Point location, int width, int height, Orientation orientation)
        {
            Size size;
            if (orientation == Orientation.HORIZONTAL
               || orientation == Orientation.HORIZONTAL_AND_FLIP)
            {
                size = new Size(width, height);
            }
            else
            {
                size = new Size(height, width);
            }
            BoundingBox = new Rectangle(location, size);
        }

        /// <summary>
        /// Location of the item (upper left corner).
        /// </summary>
        public Point Location { get { return BoundingBox.Location; } }

        /// <summary>
        /// The size of the item.
        /// </summary>
        public Size Size { get { return BoundingBox.Size; } }

        /// <summary>
        /// The bounding box for this item.
        /// </summary>
        public Rectangle BoundingBox { get; private set; }

        /// <summary>
        /// Draws the item to the given (GDI+) drawing surface.
        /// </summary>
        /// <param name="drawingSurface">The drawing surface to draw onto.</param>
        public abstract void DrawTo(Graphics drawingSurface);
    }
}

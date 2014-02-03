using System.Drawing;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Interface for Drawables.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draws the Drawable to the given (GDI+) drawing surface.
        /// </summary>
        /// <param name="drawingSurface">The drawing surface to draw onto.</param>
        void DrawTo(Graphics drawingSurface);
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Container for rotated images.
    /// The contructor takes an image, which is copied and rotated when contructing the instance of this class.
    /// A copy will be made vor every degree of rotation in the range 0..360.
    /// All rotated copies are stored for later retrieval with the GetImage method.
    /// </summary>
    internal class RotatedImageCache
    {
        /// <summary>
        /// The rotated images
        /// </summary>
        private Image[] rotatedImages;

        /// <summary>
        /// Creates a RotatedImageCache
        /// </summary>
        /// <param name="image">The image to copy and rotate</param>
        public RotatedImageCache(Image image)
        {
            rotatedImages = new Image[360];
            rotatedImages = CreateRotatedImages(image);
        }

        /// <summary>
        /// Get a cached image.
        /// </summary>
        /// <param name="rotation">The rotation of the image (can be both negative or positive</param>
        /// <returns></returns>
        public Image GetImage(int rotation)
        {
            int index = MathHelper.AbsModulus(rotation, rotatedImages.Length);
            return rotatedImages[index];
        }

        /// <summary>
        /// Create an array of rotated images from the image parameter
        /// </summary>
        /// <param name="imageToRotate">The image to create rotated copies from.</param>
        /// <returns></returns>
        private Image[] CreateRotatedImages(Image imageToRotate)
        {
            for (int i = 0; i < rotatedImages.Length; i++)
            {
                rotatedImages[rotatedImages.Length - 1 - i] = CreateRotatedImage(imageToRotate, i);
            }
            return rotatedImages;
        }

        /// <summary>
        /// Rotate a given image
        /// </summary>
        /// <param name="image">The image to rotate</param>
        /// <param name="rotation">The rotation (degrees)</param>
        /// <returns>The rotated image</returns>
        private Image CreateRotatedImage(Image image, float rotation)
        {
            Bitmap draftImage = new Bitmap(
                image.Width + image.Height,
                image.Width + image.Height);

            draftImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            RectangleF cropRectangle;
            using (Graphics graphics = Graphics.FromImage(draftImage))
            {
                float width = image.Width;
                float height = image.Height;

                // Draw rotated, translated ellipse to screen.
                float x = (draftImage.Width - width) / 2F;
                float y = (draftImage.Height - height) / 2F;

                // Set world transform of graphics object to translate.
                float midX = x + (width / 2);
                float midY = y + (height / 2);
                graphics.TranslateTransform(midX, midY);

                // Then to rotate, prepending rotation matrix.
                graphics.RotateTransform(rotation);

                // put middle back
                graphics.TranslateTransform(-midX, -midY);

                //canvas.DrawRectangle(Pens.Black, x, y, width, height);
                //graphics.DrawImageUnscaled(Properties.Resources.car, Convert.ToInt32(x), Convert.ToInt32(y));
                graphics.DrawImage(image, x, y);

                PointF[] pts = new PointF[4];
                pts[0] = new PointF(x, y);
                pts[1] = new PointF(x + image.Width, y);
                pts[2] = new PointF(x + image.Width, y + image.Height);
                pts[3] = new PointF(x, y + image.Height);
                graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.World, pts);

                float cropRectangleMinX = float.MaxValue;
                float cropRectangleMaxX = float.MinValue;
                float cropRectangleMinY = float.MaxValue;
                float cropRectangleMaxY = float.MinValue;
                foreach (PointF pt in pts)
                {
                    cropRectangleMinX = Math.Min(cropRectangleMinX, pt.X);
                    cropRectangleMaxX = Math.Max(cropRectangleMaxX, pt.X);
                    cropRectangleMinY = Math.Min(cropRectangleMinY, pt.Y);
                    cropRectangleMaxY = Math.Max(cropRectangleMaxY, pt.Y);
                }
                cropRectangle = new RectangleF(
                    new PointF(cropRectangleMinX, cropRectangleMinY),
                    new SizeF(cropRectangleMaxX - cropRectangleMinX, cropRectangleMaxY - cropRectangleMinY));
            }
            return draftImage.Clone(cropRectangle, draftImage.PixelFormat);
        }
    }
}

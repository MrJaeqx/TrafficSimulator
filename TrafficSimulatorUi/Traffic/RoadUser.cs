using System;
using System.Drawing;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Movable object that represents a road user, like a car or a pedestrian.
    /// </summary>
    public abstract class RoadUser : IDrawable
    {
        /// <summary>
        /// The X coordinate of the road user (middle of image).
        /// All calculation for the position are done using doubles to prevent precision problems.
        /// The resulting position is written to the (integer) Location property.
        /// </summary>
        private double x;

        /// <summary>
        /// The Y coordinate of the road user (middle of image).
        /// All calculation for the position are done using doubles to prevent precision problems.
        /// The resulting position is written to the (integer) Location property.
        /// </summary>
        private double y;

        /// <summary>
        /// Displacement
        /// </summary>
        private double dx;
        private double dy;

        /// <summary>
        /// The location
        /// </summary>
        private Point location;

        /// <summary>
        /// the speed (see property for description)
        /// </summary>
        private double speed;

        /// <summary>
        /// The maximum speed of the road user (see property for description)
        /// </summary>
        private double maxSpeed;

        /// <summary>
        /// The bounding box of the item.
        /// </summary>
        private Rectangle boundingBox;

        /// <summary>
        /// The image of the road user
        /// </summary>
        private Image image;

        /// <summary>
        /// The direction to which the road user is heading. Permitted values are 0..360.
        /// Where 0 is east, 90 is north, 180 is west, 270 is south and 360 is east again.
        /// </summary>
        private double direction;

        /// <summary>
        /// Cache of rotated images
        /// </summary>
        private RotatedImageCache rotatedImageCache;

        /// <summary>
        /// ID of the road user.
        /// </summary>
        private int id;

        /// <summary>
        /// Amount of generated road users. Used the creation of the ID.
        /// </summary>
        private static int idCounter = 0;

        /// <summary>
        /// Boolean if the road user will ignore the traffic lights.
        /// </summary>
        private bool redLight;

        /// <summary>
        /// Bool
        /// </summary>
        private bool crossRedLight;
        /// <summary>
        /// Creates a road user
        /// </summary>
        /// <param name="image">The image to use then painting the road user.</param>
        public RoadUser(Point location, double speed, Image image, bool redlight)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            rotatedImageCache = new RotatedImageCache(image);
            Location = location;
            Speed = speed;
            MaxSpeed = speed;
            Direction = 0D;
            ID = idCounter++;
            RedLight = redlight;
            CrossRedLight = false;
        }

        /// <summary>
        /// The 'speed' of the road user.
        /// Each call to the Move method will move the road user by 'Speed' pixels. 
        /// Fractions of pixels are also alowed.
        /// </summary>
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                SetDXAndDY(Speed, Direction);
            }
        }

        /// <summary>
        /// The maximum speed the road user can go.
        /// This is used to restore the speed of the road user after it has stopped.
        /// </summary>
        public double MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }

        /// <summary>
        /// Sets the x and y displacement for moving in the given direction with 
        /// the given speed.
        /// </summary>
        /// <param name="speed">The speed, i.e. pixels to move.</param>
        /// <param name="direction">The direction to move to.</param>
        private void SetDXAndDY(double speed, double direction)
        {
            dx = speed * Math.Cos(MathHelper.DegreesToRadians(direction));
            dy = -speed * Math.Sin(MathHelper.DegreesToRadians(direction));
        }

        /// <summary>
        /// The location of the road user.
        /// Watch it: for roadUsers the location is at the center of the object.
        /// </summary>
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                x = value.X;
                y = value.Y;
            }
        }

        /// <summary>
        /// The bounding box of the road user
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
            private set
            {
                boundingBox = value;
            }
        }

        /// <summary>
        /// The image used tot draw the road user
        /// </summary>
        public Image Image
        {
            get { return image; }
            private set
            {
                image = value;
                boundingBox.X = Convert.ToInt32(x - (Image.Size.Width / 2D));
                boundingBox.Y = Convert.ToInt32(y - (Image.Size.Height / 2D));
                boundingBox.Size = image.Size;
            }
        }

        /// <summary>
        /// The direction to which the road user is heading. Permitted values are 0..360.
        /// Where 0 is east, 90 is north, 180 is west, 270 is south and 360 is east again.
        /// 
        /// When setting the direction both negative and positive values are allowed. 
        /// The direction wil be 'normalized' to a value in the range 0..360
        /// </summary>
        public double Direction
        {
            get { return direction; }
            set
            {
                direction = MathHelper.AbsModulus(value, 360D);
                Image = rotatedImageCache.GetImage(Convert.ToInt32(direction));
                SetDXAndDY(Speed, Direction);
            }
        }

        /// <summary>
        /// Unique ID of the road user.
        /// </summary>
        public int ID
        {
            get { return id; }
            private set
            {
                id = value;
            }
        }

        /// <summary>
        /// Boolean if the road user will ignore the traffic lights.
        /// </summary>
        public bool RedLight
        {
            get { return redLight; }
            private set { redLight = value; }
        }

        public bool CrossRedLight
        {
            get { return crossRedLight; }
            set { crossRedLight = value; }
        }

        /// <summary>
        /// Moves the road user forwards or backwards taking its direction into account.
        /// Each call of this method moves the road user by 'Speed' pixels.
        /// </summary>
        public void Move()
        {
            x += dx;
            y += dy;
            location.X = Convert.ToInt32(x);
            location.Y = Convert.ToInt32(y);
            boundingBox.X = Convert.ToInt32(x - (Image.Size.Width / 2D));
            boundingBox.Y = Convert.ToInt32(y - (Image.Size.Height / 2D));
        }

        /// <summary>
        /// Change the direction so that it faces the given point.
        /// </summary>
        /// <param name="point">The point to face to</param>
        public void FaceTo(Point point)
        {
            double angle = MathHelper.GetDegreesAngle(Location, point);
            Direction = angle;
        }

        /// <summary>
        /// Draws the road user to the drawing surface.
        /// </summary>
        /// <param name="drawingSurface">The drawing surface to draw onto.</param>
        public void DrawTo(Graphics drawingSurface)
        {
            drawingSurface.DrawImageUnscaled(Image, BoundingBox);
            if (RedLight)
            {
                Rectangle box = BoundingBox;
                box.Height = (BoundingBox.Height) / 4;
                box.Y = BoundingBox.Y + (BoundingBox.Height / 4);
                drawingSurface.FillRectangle(Brushes.Red, box);
            }
        }
    }
}

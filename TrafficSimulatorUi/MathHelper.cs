using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrafficSimulatorUi
{
    sealed public class MathHelper
    {
        /// <summary>
        /// Non instantiable class with math helper methods
        /// </summary>
        private MathHelper() { }

        public static int AbsModulus(int dividend, int divisor)
        {
            if (divisor <= 0)
            {
                throw new ArgumentException("must be greater than 0", "divisor");
            }

            int remainder = dividend % divisor;
            if (remainder < 0)
            {
                remainder += divisor;
            }
            // shorter but less readable: return ((dividend % divisor) + divisor) % divisor;
            return remainder;
        }

        public static double AbsModulus(double dividend, double divisor)
        {
            if (divisor <= 0)
            {
                throw new ArgumentException("must be greater than 0", "divisor");
            }

            double remainder = dividend % divisor;
            if (remainder < 0)
            {
                remainder += divisor;
            }
            // shorter but less readable: return ((dividend % divisor) + divisor) % divisor;
            return remainder;
        }

        public static double RadiansToDegrees(double radAngle)
        {
            return radAngle * (180D / Math.PI);
        }

        public static double DegreesToRadians(double degAngle)
        {
            return Math.PI * degAngle / 180D;
        }

        /// <summary>
        /// Calculates the angle between an imaginary X-axis with 'origin' as origin
        /// and the given point at 'point'. 
        /// Note: points are given in screen coordinates (Y-axis is inverted)!
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="point"></param>
        /// <returns>Angle (degrees).</returns>
        public static double GetDegreesAngle(Point origin, Point point)
        {
            double X = point.X - origin.X;
            double Y = origin.Y - point.Y;
            return RadiansToDegrees(Math.Atan2(Y, X));
        }
    }
}

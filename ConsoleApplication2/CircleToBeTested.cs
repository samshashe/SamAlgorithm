using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ConsoleApplication2
{
    public class CircleToBeTested
    {
        private Point myPoint;
        private double myRadius;

        /// <summary>
        /// Constructor for circle, default location, able to pass radius
        /// </summary>
        /// <param name="r">radius of the circle</param>
        public CircleToBeTested(double r) {
            myRadius = r;
            myPoint = new Point(0, 0);
        }

        /// <summary>
        /// Constructor for circle, able to pass in both location and radius
        /// </summary>
        /// <param name="loc">Cordinate point circle lies on</param>
        /// <param name="r">radius of the circle</param>
        public CircleToBeTested(Point loc, double r)
        {
            myRadius = r;
            myPoint = loc;
        }

        /// <summary>
        /// Circle Property for radius. Get and Set radius of circle
        /// </summary>
        public double Radius {
            get { return myRadius; }
            set { myRadius = value; }
        }

        /// <summary>
        /// Circle Property for diameter. Get and Set diameter of circle
        /// </summary>
        public double Diameter {
            get { return myRadius*2; }
            set { myRadius = value/2; }
        }

        /// <summary>
        /// Calculate the circumference of a circle within 2 decimal places
        /// </summary>
        /// <returns>returns the double value of the circumference</returns>
        public double getCircumference() {
            return ( (( 16 / 5 - 4 / 239 ) - ( 1 / 3 * ( 16 / 53 - 4 / 2393 ) ) ) + .14)*2*myRadius;
        }

        /// <summary>
        /// Calculate the area of a circle
        /// </summary>
        /// <returns></returns>
        public double getArea() {
            return Math.PI*Math.Pow(this.Diameter,2);
        }

        /// <summary>
        /// The pie-shaped piece of a circle 'cut out' by two radii.
        /// </summary>
        /// <param name="theta"> the angle between the radii must be 
        /// between 0(exclusive) and 360(exclusive)</param>
        /// <returns>returns the area of the sector</returns>
        public double getSectorArea(double theta) {
            if( theta <= 0 || theta > 360 )
                throw new ArgumentException("Angle must be between 0 and 360");
            return (Math.Pow( myRadius, 2) * theta)/2;
        }

        /// <summary>
        /// Calculates the length of a side of a square that is circumscibed
        /// inside of the circle (Really make sure ur test code is working)
        /// </summary>
        /// <returns>Returns the length of one side of the square</returns>
        public double lengthOfCircumscribedSquare() {
            double sqrDiagonal = this.Diameter;
            //Pythagorean Thereom, in said case 'a'='b' because its a square,
            //therefore we will just use 's' instead;
            double c= sqrDiagonal;
            double s = Math.Sqrt( c/2);
            return s;
        }
    }
}

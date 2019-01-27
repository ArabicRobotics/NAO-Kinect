using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace KinectCatcher
{
    public static class utilities
    {

        public enum Side
        {
            Right = 0, Left = 1,Center=2
        }

        public struct Position
        {
            public float x; public float y; public float z;
           public Vector3D GetVector()
            {
                return new Vector3D(this.x, this.y, this.z);
            }
        }
        /// <summary>
        ///  Return Degree between 2 vectors
        /// </summary>
        /// <param name="vectorA">Vector1 before the angle</param>
        /// <param name="vectorB">Vector2 After the angle</param>
        /// <returns>Double Degree</returns>
        public static double getDegree(Vector3D vectorA, Vector3D vectorB)
        {
            double dotProduct = 0.0;
            dotProduct = Vector3D.DotProduct(vectorA, vectorB);
            double deg =  Math.Acos(dotProduct) / Math.PI * 180;
            return deg;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Point1x">Angle before ( likeShoulder Center ) </param>
        /// <param name="Point1y"></param>
        /// <param name="Point2x"></param>
        /// <param name="Point2y"></param>
        /// <returns></returns>
        public static double getDegree(float point0x,float point0y, float Point1x, float Point1y,float Point2x, float Point2y)
        {
        double a = Math.Pow(Point1x - point0x, 2) + Math.Pow(Point1y - point0y, 2),
        b = Math.Pow(Point1x - Point2x, 2) + Math.Pow(Point1y - Point2y, 2),
        c = Math.Pow(Point2x - point0x, 2) + Math.Pow(Point2y - point0y, 2);
        return Math.Acos((a + b - c) / Math.Sqrt(4 * a * b)) * 180 / Math.PI;
            
        }




    }
}

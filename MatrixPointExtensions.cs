// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatrixPointExtensions.cs" company="Azven">
//   (C) Steven Digby
// </copyright>
// <summary>
//   The matrix point extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Matrix1
{
    using System;
    using System.Drawing;
    
    /// <summary>The matrix point extensions.</summary>
    public static class MatrixPointExtensions
    {
        /// <summary>The rows.</summary>
        private const int Rows = 0;

        /// <summary>The columns.</summary>
        private const int Columns = 1;

        /// <summary>The point to array.</summary>
        /// <param name="point">The point.</param>
        /// <returns>A [2x1] matrix (a single column matrix is also called a vector).</returns>
        public static double[,] PointToArray(this Point point)
        {
            // X and Y are always integers so this extension returns integers
            var vector = new double[2, 1]; // 2 Rows, 1 column
            vector[0, 0] = point.X;
            vector[1, 0] = point.Y;
            return vector;
        }

        /// <summary>Converts a Points array to an array of (X, Y) arrays.</summary>
        /// <param name="sourcePoints">The source points.</param>
        /// <returns>Returns an array of (X, Y) arrays.</returns>
        public static double[][,] PointsToArray(this Point[] sourcePoints)
        {
            // convert the mappedPoints to a matrix of doubles
            var xy = new double[sourcePoints.GetUpperBound(0) + 1][,];
            for (var index = 0; index < sourcePoints.Length; index++)
            {
                xy[index] = sourcePoints[index].PointToArray();
            }

            return xy;
        }

        /// <summary>The array to point.</summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The Point structure eqivalent of the vector.</returns>
        /// <exception cref="Exception">Matrix size exception.</exception>
        public static Point ArrayToPoint(this double[,] vector)
        {
            if (vector.GetUpperBound(Rows) != 1 || vector.GetUpperBound(Columns) != 0)
            {
                throw new Exception("Only a matrix that is 2 rows by 1 column can be converted to a Point structure.");
            }

            return new Point((int)vector[0, 0], (int)vector[1, 0]);
        }

        /// <summary>The array to points.</summary>
        /// <param name="arrayOfVectors">The array of vectors.</param>
        /// <returns>The Point array equivalent of the array of vectors.</returns>
        public static Point[] ArrayToPoints(this double[][,] arrayOfVectors)
        {
            var returnPoints = new Point[arrayOfVectors.GetUpperBound(0) + 1];
            for (var index = 0; index < arrayOfVectors.Length; index++)
            {
                returnPoints[index] = arrayOfVectors[index].ArrayToPoint();
            }

            return returnPoints;
        }

        /// <summary>Add a Point to another Point (translate in 2D).</summary>
        /// <param name="sourcePoint">The source Point.</param>
        /// <param name="targetpoint">The target point.</param>
        /// <returns>The new vector (2D translation).</returns>
        public static Point PointAdd(this Point sourcePoint, Point targetpoint)
        {
            return sourcePoint.PointToArray().AddMatrix(targetpoint.PointToArray()).ArrayToPoint();
        }

        /// <summary>Subtract a Point from another Point (translate in 2D).</summary>
        /// <param name="sourcePoint">The source point.</param>
        /// <param name="targetpoint">The target point.</param>
        /// <returns>The new vector (2D translation).</returns>
        public static Point PointSubtract(this Point sourcePoint, Point targetpoint)
        {
            return sourcePoint.PointToArray().SubtractMatrix(targetpoint.PointToArray()).ArrayToPoint();
        }

        /// <summary>The points translate.</summary>
        /// <param name="sourcePoint">The source point.</param>
        /// <param name="translateVector">The translate vector.</param>
        /// <returns>The translated Points array.</returns>
        public static Point[] PointsTranslate(this Point[] sourcePoint, Point translateVector)
        {
            // Move every point in the array by vector given by the point, translateVector  
            var returnPoints = new Point[sourcePoint.GetUpperBound(0) + 1];
            for (var i = 0; i <= sourcePoint.GetUpperBound(0); i++)
            {
                returnPoints[i] = new Point(sourcePoint[i].X + translateVector.X, sourcePoint[i].Y + translateVector.Y);
            }

            return returnPoints;
        }

        /// <summary>The rotate by degrees.</summary>
        /// <param name="sourcePoint">The source point.</param>
        /// <param name="degrees">The degrees.</param>
        /// <param name="rotateAbout">The rotate about.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        public static Point RotateByDegrees(this Point sourcePoint, double degrees, Point rotateAbout = default(Point))
        {
            // Map the source point back to where the rotation point will be (0, 0), the origin.
            var mappedPoint = sourcePoint.PointSubtract(rotateAbout);

            // Create the rotation matrix
            var rotationMatrix = degrees.RotationMatrix2D();

            // convert the mappedPoint to a matrix of doubles
            var xy = mappedPoint.PointToArray();

            // multiply the rotation matrix by the mappedPoint matrix and convert back into a Point.
            var rotatedMappedPoint = rotationMatrix.MultiplyMatrix(xy).ArrayToPoint();

            // Add the point of rotation back to 
            return rotatedMappedPoint.PointAdd(rotateAbout);
        }

        /// <summary>The rotate by radians.</summary>
        /// <param name="sourcePoint">The source point.</param>
        /// <param name="radians">The radians.</param>
        /// <param name="rotateAbout">The rotate about.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        public static Point RotateByRadians(this Point sourcePoint, double radians, Point rotateAbout = default(Point))
        {
            // Map the source point back to where the rotation point will be (0, 0), the origin.
            var mappedPoint = sourcePoint.PointSubtract(rotateAbout);

            // Create the rotation matrix
            var rotationMatrix = radians.RotationMatrix2D(MatrixExtensions.AngleUnits.Radians);

            // convert the mappedPoint to a matrix of doubles
            var xy = mappedPoint.PointToArray();

            // multiply the rotation matrix by the mappedPoint matrix and convert back into a Point.
            var rotatedMappedPoint = rotationMatrix.MultiplyMatrix(xy).ArrayToPoint();

            // Add the point of rotation back to 
            return rotatedMappedPoint.PointAdd(rotateAbout);
        }

        /// <summary>The rotate by degrees.</summary>
        /// <param name="sourcePoints">The source points.</param>
        /// <param name="degrees">The degrees.</param>
        /// <param name="rotateAbout">The rotate about.</param>
        /// <returns>The an array of rotated points.</returns>
        public static Point[] RotateByDegrees(this Point[] sourcePoints, double degrees, Point rotateAbout = default(Point))
        {
            return RotateByAnAngle(sourcePoints, degrees, true, rotateAbout);
        }

        /// <summary>The rotate by radians.</summary>
        /// <param name="sourcePoints">The source points.</param>
        /// <param name="radians">The radians.</param>
        /// <param name="rotateAbout">The rotate about.</param>
        /// <returns>The an array of rotated points.</returns>
        public static Point[] RotateByRadians(this Point[] sourcePoints, double radians, Point rotateAbout = default(Point))
        {
            return RotateByAnAngle(sourcePoints, radians, false, rotateAbout);
        }

        /// <summary>The rotate by an angle.</summary>
        /// <param name="sourcePoints">The source points.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="angleIsDegrees">The angle is degrees.</param>
        /// <param name="rotateAbout">The rotate about.</param>
        /// <returns>The an array of rotated points.</returns>
        private static Point[] RotateByAnAngle(
            Point[] sourcePoints,
            double angle,
            bool angleIsDegrees,
            Point rotateAbout = default(Point))
        {
            // Map the source points back to where the rotation point will be (0, 0), the origin; then convert to an array
            var xy = sourcePoints.PointsTranslate(new Point(-rotateAbout.X, -rotateAbout.Y)).PointsToArray();

            // Create the rotation matrix
            var rotationMatrix = angle.RotationMatrix2D(angleIsDegrees == false ? MatrixExtensions.AngleUnits.Radians : MatrixExtensions.AngleUnits.Degrees);

            // Creata an array to hold the re-mapped points for return
            var rotatedRemappedPoints = new Point[sourcePoints.GetUpperBound(0) + 1];
            
            for (var index = 0; index < rotatedRemappedPoints.Length; index++)
            {
                // multiply the rotation matrix by each mappedPoint and convert back into Points.
                rotatedRemappedPoints[index] =
                    rotationMatrix.MultiplyMatrix(xy[index]).ArrayToPoint();
            }

            // Add the point of rotation back to the rotated point, and return
            return rotatedRemappedPoints.PointsTranslate(rotateAbout);
        }
    }
}
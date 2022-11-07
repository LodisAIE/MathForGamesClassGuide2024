using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// A three by three collection of floats.
    /// </summary>
    public struct Matrix3
    {
        public float M00, M01, M02;
        public float M10, M11, M12;
        public float M20, M21, M22;

        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        /// <summary>
        /// A base matrix that does nothing when multiplied by another.
        /// Useful for setting a default matrix value.
        /// </summary>
        public static Matrix3 Identity
        {
            get 
            {
                //Create a new matrix 3
                //Assign the new matrix the values of an identity matrix
                Matrix3 identity = new Matrix3(1,0,0,
                                               0,1,0,
                                               0,0,1);
                //return the new matrix
                return identity;
            }
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians.
        /// </summary>
        /// <param name="radians">The angle in radians to rotate by.</param>
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3();
        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given values.
        /// </summary>
        /// <param name="x">The x position of the new matrix.</param>
        /// <param name="y">The y position of the new matrix.</param>
        public static Matrix3 CreateTranslation(float x, float y)
        {
            return new Matrix3();
        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given values.
        /// </summary>
        /// <param name="x">The value to use to scale the matrix in the x axis.</param>
        /// <param name="y">The value to use to scale the matrix in the y axis.</param>
        /// <returns>The result of the scale.</returns>
        public static Matrix3 CreateScale(float x, float y)
        {
            return new Matrix3();
        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3();
        }


        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3();
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3();
        }
    }
}

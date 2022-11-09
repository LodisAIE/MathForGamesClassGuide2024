using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix4
    {
        public float M00, M01, M02, M03;
        public float M10, M11, M12, M13;
        public float M20, M21, M22, M23;
        public float M30, M31, M32, M33;

        public Matrix4()
        {
            this = Identity;
        }

        public Matrix4(float m00, float m01, float m02,
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
        public static Matrix4 Identity
        {
            get
            {
                return new Matrix4(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }
        /// <summary>
        /// Creates a new matrix that has been translated by the given values.
        /// </summary>
        /// <param name="x">The x position of the new matrix.</param>
        /// <param name="y">The y position of the new matrix.</param>
        public static Matrix4 CreateTranslation(float x, float y)
        {
            return new Matrix4(1, 0, x,
                               0, 1, y,
                               0, 0, 1);
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4
                (
                    (float)Math.Cos(radians), -(float)Math.Sin(radians), 0,
                    (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                    0, 0, 1
                );
        }

        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4();
        }

        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4();
        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given values.
        /// </summary>
        /// <param name="x">The value to use to scale the matrix in the x axis.</param>
        /// <param name="y">The value to use to scale the matrix in the y axis.</param>
        /// <returns>The result of the scale.</returns>
        public static Matrix4 CreateScale(float x, float y)
        {
            return new Matrix4(x, 0, 0,
                               0, y, 0,
                               0, 0, 1);
        }

        public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(lhs.M00 + rhs.M00, lhs.M01 + rhs.M01, lhs.M02 + rhs.M02,
                               lhs.M10 + rhs.M10, lhs.M11 + rhs.M11, lhs.M12 + rhs.M12,
                               lhs.M20 + rhs.M20, lhs.M21 + rhs.M21, lhs.M22 + rhs.M22);
        }


        public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(lhs.M00 - rhs.M00, lhs.M01 - rhs.M01, lhs.M02 - rhs.M02,
                               lhs.M10 - rhs.M10, lhs.M11 - rhs.M11, lhs.M12 - rhs.M12,
                               lhs.M20 - rhs.M20, lhs.M21 - rhs.M21, lhs.M22 - rhs.M22);
        }

        static Matrix4 Transpose(Matrix4 mat)
        {
            return new Matrix4
                (
                    mat.M00, mat.M10, mat.M20,
                    mat.M01, mat.M11, mat.M21,
                    mat.M02, mat.M12, mat.M22
                );
        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            Matrix4 result = new Matrix4(
         /*m00*/ (lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20),
         /*m01*/ (lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21),
         /*m02*/ (lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22),

         /*m10*/ (lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20),
         /*m11*/ (lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21),
         /*m12*/ (lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22),

         /*m20*/ (lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M01) + (lhs.M22 * rhs.M20),
         /*m21*/ (lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21),
         /*m22*/ (lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22)
                 );

            return result;
        }

        public static Vector3 operator *(Matrix4 lhs, Vector3 rhs)
        {
            return new Matrix4();
        }
    }
}

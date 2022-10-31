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

        public Matrix3()
        {
            this = Identity;
        }

        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        public static Matrix3 Identity
        {
            get 
            {
                return new Matrix3(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.M00 + rhs.M00, lhs.M01 + rhs.M01,lhs.M02 + rhs.M02,
                               lhs.M10 + rhs.M10, lhs.M11 + rhs.M11, lhs.M12 + rhs.M12,
                               lhs.M20 + rhs.M20, lhs.M21 + rhs.M21, lhs.M22 + rhs.M22);
        }


        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.M00 - rhs.M00, lhs.M01 - rhs.M01, lhs.M02 - rhs.M02,
                               lhs.M10 - rhs.M10, lhs.M11 - rhs.M11, lhs.M12 - rhs.M12,
                               lhs.M20 - rhs.M20, lhs.M21 - rhs.M21, lhs.M22 - rhs.M22);
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
        /*m00*/ (lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M01) + (lhs.M02 * rhs.M02),
        /*m01*/ (lhs.M00 * rhs.M10) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M12),
        /*m02*/ (lhs.M00 * rhs.M20) + (lhs.M01 * rhs.M21) + (lhs.M02 * rhs.M22),

        /*m10*/ (lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M01) + (lhs.M12 * rhs.M02),
        /*m11*/ (lhs.M10 * rhs.M10) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M12),
        /*m12*/ (lhs.M10 * rhs.M20) + (lhs.M11 * rhs.M21) + (lhs.M12 * rhs.M22),

        /*m20*/ (lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M01) + (lhs.M22 * rhs.M02),
        /*m21*/ (lhs.M20 * rhs.M10) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M12),
        /*m22*/ (lhs.M20 * rhs.M20) + (lhs.M21 * rhs.M21) + (lhs.M22 * rhs.M22)
                );
        }
    }
}

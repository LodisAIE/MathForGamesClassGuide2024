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

        public static Matrix3 Identity
        {
            get 
            {
            }
        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
        }


        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {

        }
    }
}

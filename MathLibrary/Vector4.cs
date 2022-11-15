using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _w;

        /// <summary>
        /// The first value of the vector.
        /// </summary>
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// The second value of the vector.
        /// </summary>
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// The second value of the vector.
        /// </summary>
        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        /// <summary>
        /// The second value of the vector.
        /// </summary>
        public float W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }

        /// <summary>
        /// Gets the length of this vector.
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        /// <summary>
        /// Returns a copy of this vector that has a length of one.
        /// </summary>
        public Vector4 Normalized
        {
            get
            {
                if (Magnitude <= 0.0f)
                {
                    return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                }

                Vector4 normalized = new Vector4(X / Magnitude, Y / Magnitude, Z / Magnitude, 0);
                return normalized;
            }
        }

        /// <param name="x"> The first value of the vector. </param>
        /// <param name="y"> The second value of the vector. </param>
        public Vector4(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        /// <summary>
        /// Changes the length of this vector to have a magnitude that is equal to one.
        /// </summary>
        /// <returns>The result of the normalization.</returns>
        public Vector4 Normalize()
        {
            if (Magnitude <= 0.0f)
            {
                return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            }

            float mag = Magnitude;
            X /= mag;
            Y /= mag;
            Z /= mag;

            return this;
        }

        /// <summary>
        /// Finds the dot product between the two vectors.
        /// </summary>
        /// <param name="a">The vector that will be used as the base.</param>
        /// <param name="b">The vector to project on to the other.</param>
        /// <returns>The dot product scalar value.</returns>
        public static float GetDotProduct(Vector4 a, Vector4 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.Y * rhs.Z - lhs.Z * rhs.Y, lhs.Z * rhs.X - lhs.X * rhs.Z, lhs.X * rhs.Y - lhs.Y * rhs.X, 0);
        }

        /// <summary>
        /// Finds the distance between two points.
        /// </summary>
        /// <param name="a">The starting position.</param>
        /// <param name="b">The ending position.</param>
        /// <returns>The distance scalar value.</returns>
        public static float GetDistance(Vector4 a, Vector4 b)
        {
            return (b - a).Magnitude;
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);
        }

        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);
        }

        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs, lhs.W / rhs);
        }

        public static Vector4 operator /(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs / rhs.X, lhs / rhs.Y, lhs / rhs.Z, lhs / rhs.W);
        }
    }
}

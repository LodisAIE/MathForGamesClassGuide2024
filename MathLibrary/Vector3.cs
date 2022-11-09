using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector3
    {
        private float _x;
        private float _y;
        private float _z;

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
        public Vector3 Normalized
        {
            get
            {
                if (Magnitude <= 0.0f)
                {
                    return new Vector3(0.0f, 0.0f, 0.0f);
                }

                Vector3 normalized = new Vector3(X / Magnitude, Y / Magnitude, Z / Magnitude);
                return normalized;
            }
        }

        /// <param name="x"> The first value of the vector. </param>
        /// <param name="y"> The second value of the vector. </param>
        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Changes the length of this vector to have a magnitude that is equal to one.
        /// </summary>
        /// <returns>The result of the normalization.</returns>
        public Vector3 Normalize()
        {
            if (Magnitude <= 0.0f)
            {
                return new Vector3(0.0f, 0.0f, 0.0f);
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
        public static float GetDotProduct(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector3 GetCrossProduct(Vector3 a, Vector3 b)
        {
            return new Vector3();
        }

        /// <summary>
        /// Finds the distance between two points.
        /// </summary>
        /// <param name="a">The starting position.</param>
        /// <param name="b">The ending position.</param>
        /// <returns>The distance scalar value.</returns>
        public static float GetDistance(Vector3 a, Vector3 b)
        {
            return (b - a).Magnitude;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }

        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z);
        }

        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        public static Vector3 operator /(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs / rhs.X, lhs / rhs.Y, lhs / rhs.Z);
        }
    }
}

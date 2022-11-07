using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace HelloWorld
{
    internal class Transform2D
    {
        private Matrix3 _local;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Actor _owner;
        private float _rotationAngle;

        public Matrix3 Rotation
        {
            get { return _rotation; }
            set 
            {
                _rotationAngle = (float)Math.Atan2(_local.M10, _local.M00);
                _rotation = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_translation.M20, _translation.M21);
            }
            set
            {
                _translation.M20 = value.X;
                _translation.M21 = value.Y;
            }
        }

        public Vector2 LocalScale
        {
            get
            {
                return new Vector2(_scale.M00, _scale.M11);
            }
            set
            {
                _scale.M00 = value.X;
                _scale.M11 = value.Y;
            }
        }

        public Actor Owner
        {
            get { return _owner; }
        }

        public Vector2 Forward
        {
            get { return new Vector2(_rotation.M00, _rotation.M01); }
        }

        public Vector2 Up
        {
            get { return new Vector2 (_rotation.M10, _rotation.M11); }
        }

        /// <summary>
        /// Gets the amount that this transform has been rotated in radians.
        /// </summary>
        public float RotationAngle
        {
            get { return _rotationAngle; }
        }

        public Transform2D(Actor owner)
        {
            _owner = owner;
        }

        public void Translate(float x, float y)
        {
            Position += new Vector2(x, y);
        }

        public void Translate(Vector2 direction)
        {
            //new way with operator overloading
            Position += direction;
        }

        public void UpdateTransform()
        {
            _local = _translation * _rotation * _scale;
        }
    }
}

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
        private Matrix3 _global = Matrix3.Identity;

        private Matrix3 _localRotation = Matrix3.Identity;
        private Matrix3 _localTranslation = Matrix3.Identity;
        private Matrix3 _localScale = Matrix3.Identity;

        private Actor _owner;

        private Transform2D _parent;
        private Transform2D[] _children;

        private float _localRotationAngle;

        public Matrix3 LocalRotation
        {
            get { return _localRotation; }
            set 
            {
                _localRotation = value;
                _localRotationAngle = (float)Math.Atan2(_localRotation.M01, _localRotation.M00);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTranslation.M02, _localTranslation.M12);
            }
            set
            {
                _localTranslation.M02 = value.X;
                _localTranslation.M12 = value.Y;
            }
        }

        public Vector2 GlobalPosition
        {
            get
            {
                return new Vector2(_global.M02, _global.M12);
            }
        }

        public Vector2 LocalScale
        {
            get
            {
                return new Vector2(_localScale.M00, _localScale.M11);
            }
            set
            {
                _localScale.M00 = value.X;
                _localScale.M11 = value.Y;
            }
        }

        public Vector2 GlobalScale
        {
            get
            {
                Vector2 xAxis = new Vector2(_global.M00, _global.M10);
                Vector2 yAxis = new Vector2(_global.M01, _global.M11);

                return new Vector2(xAxis.Magnitude, yAxis.Magnitude);
            }
        }

        public Actor Owner
        {
            get { return _owner; }
        }

        public Vector2 Forward
        {
            get { return new Vector2(_global.M00, _global.M10).Normalized; }
        }

        public Vector2 Up
        {
            get { return new Vector2 (_global.M01, _global.M11).Normalized; }
        }

        /// <summary>
        /// Gets the amount that this transform has been rotated in radians.
        /// </summary>
        public float LocalRotationAngle
        {
            get { return _localRotationAngle; }
        }

        /// <summary>
        /// Gets the amount that this transform has been rotated in radians.
        /// </summary>
        public float GlobalRotationAngle
        {
            get { return (float)Math.Atan2(_global.M01, _global.M00); }
        }

        public Transform2D(Actor owner)
        {
            _owner = owner;
            _children = new Transform2D[0];
        }

        public void Translate(float x, float y)
        {
            LocalPosition += new Vector2(x, y);
        }

        public void Translate(Vector2 direction)
        {
            //new way with operator overloading
            LocalPosition += direction;
        }

        public void AddChild(Transform2D child)
        {
            /*
                arr tempArray set to new array[old.length + 1]

                for each child in old array
                    transfer child to new array

                tempArray[old.length] set to new child

                set child parent to this instance

                set old array to new array
            */
            
            Transform2D[] temp = new Transform2D[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                temp[i] = _children[i];
            }

            temp[_children.Length] = child;

            child._parent = this;

            _children = temp;
        }

        public bool Remove(Transform2D child)
        {
            /*
             * bool childRemoved set to false
             * arr tempArray set to new array[old.length - 1]
             * 
             * int j
             * 
             * for each child in old array
             *  if the current child isn't the child to remove...
             *      ...tempArray[j] set to current child
             *      increment j
             *  else
             *      actorRemoved set to true
             *      
             *  if the child was removed
             *      oldArray set to tempArray
             *      child.Parent set to null
             *      
             *  return child removed
            */

            bool childRemoved = false;

            Transform2D[] temp = new Transform2D[_children.Length - 1];

            int j = 0;

            for (int i = 0; j < _children.Length; i++)
            {
                if (_children[i] != child)
                {
                    temp[j] = _children[i];
                    j++;
                }
                else 
                {
                    childRemoved = true;
                }
            }

            if (childRemoved)
            {
                _children = temp;
                child._parent = null;
            }

            return childRemoved;
        }

        public void UpdateTransforms()
        {
            _local = _localTranslation * _localRotation * _localScale;

            if (_parent != null)
                _global = _parent._global * _local;
            else
                _global = _local;
        }
    }
}

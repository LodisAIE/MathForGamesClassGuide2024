using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    internal class Actor
    {
        /// <summary>
        /// Make it to where actors move and scale using the transform matrix
        /// instead of the variables we have now. 
        /// </summary>
        private Transform2D _transform;
        private string _name;
        private Collider _collisionVolume;
        private Sprite _graphic;
        private bool _isActive = true;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Transform2D Transform
        {
            get { return _transform; }
        }

        public Collider CollisionVolume
        {
            get { return _collisionVolume; }
            set { _collisionVolume = value; }
        }

        public Sprite Graphic
        {
            get { return _graphic; }
            set { _graphic = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public Actor(string name, Sprite sprite)
        {
            _transform = new Transform2D(this);
            _name = name;
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, int positionX, int positionY)
        {
            _transform = new Transform2D(this);
            _name = name;
            Transform.LocalPosition = new Vector2(positionX, positionY);
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, Vector2 position)
        {
            _transform = new Transform2D(this);
            _name = name;
            Transform.LocalPosition = position;
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, Vector2 position, float scale)
        {
            _transform = new Transform2D(this);
            _name = name;
            Transform.LocalPosition = position;
            _graphic = sprite;
            //SetScale(new Vector2(scale, scale));
        }


        /// <summary>
        /// Checks to see if the collision volume attached to this actor overlapped another.
        /// </summary>
        /// <param name="other">The other actor to check collision against.</param>
        /// <returns>Whether or not these actors are overlapping.</returns>
        public bool CheckCollision(Actor other)
        {
            return CollisionVolume.CheckCollision(other);
        }

        public virtual void OnCollision(Actor other) { }

        public virtual void Start() 
        {
        }

        float radians = 0;

        public virtual void Update(float deltaTime)
        {
            CircleCollider circleCollider = (CircleCollider)CollisionVolume;
            float increase = radians += deltaTime * 2;
            _transform.LocalRotation = Matrix3.CreateRotation(radians += deltaTime * 10);

            if (circleCollider != null)
            {
                circleCollider.CollisionRadius = _transform.LocalScale.X;
            }

            _transform.UpdateTransforms();
        }

        public virtual void Draw()
        {
            if (_graphic != null)
            {
                _graphic.Draw(_transform);
            }
        }

        public virtual void End() { }
    }
}

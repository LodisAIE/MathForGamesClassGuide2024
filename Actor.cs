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
        private Matrix3 _transform = new Matrix3();
        private string _name;
        private Collider _collisionVolume;
        private Sprite _graphic;

        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.M20, _transform.M21);
            }
            set
            {
                _transform.M20 = value.X;
                _transform.M21 = value.Y;
            }
        }

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

        public Vector2 Scale
        {
            get 
            {
                float xMag = new Vector2(_transform.M00, _transform.M10).Magnitude;
                float yMag = new Vector2(_transform.M00, _transform.M10).Magnitude;

                return new Vector2(xMag, yMag);
            }
        }

        public Actor(string name, Sprite sprite)
        {
            _name = name;
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, int positionX, int positionY)
        {
            _name = name;
            Position = new Vector2(positionX, positionY);
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, Vector2 position)
        {
            _name = name;
            Position = position;
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, Vector2 position, float scale)
        {
            _name = name;
            Position = position;
            _graphic = sprite;
            //SetScale(new Vector2(scale, scale));
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

        public void SetScale(Vector2 scale)
        {
            Vector2 xAxis = new Vector2(_transform.M00, _transform.M01);
            Vector2 yAxis = new Vector2(_transform.M10, _transform.M11);

            xAxis = xAxis.Normalized * scale.X;
            yAxis = yAxis.Normalized * scale.Y;

            _transform.M00 = xAxis.X;
            _transform.M01 = xAxis.Y;

            _transform.M10 = yAxis.X;
            _transform.M11 = yAxis.Y;
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
            _transform.M00 = 50;
            _transform.M11 = 50;
        }

        public virtual void Update(float deltaTime) { }

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

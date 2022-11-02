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

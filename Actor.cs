using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    internal class Actor
    {
        private Vector2 _position;
        private string _name;
        private char _icon;
        private Color _iconColor;
        private Collider _collisionVolume;
        private float _scale = 50;

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
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

        public char Icon
        {
            get
            {
                return _icon;
            }
        }

        public Color IconColor
        {
            get { return _iconColor; }
            set { _iconColor = value; }
        }

        public Collider CollisionVolume
        {
            get { return _collisionVolume; }
            set { _collisionVolume = value; }
        }

        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public Actor(string name, char icon)
        {
            _name = name;
            _icon = icon;
        }

        public Actor(string name, char icon, int positionX, int positionY, Color iconColor)
        {
            _name = name;
            _icon = icon;
            _position = new Vector2(positionX, positionY);
            _iconColor = iconColor;
        }

        public Actor(string name, char icon, Vector2 position, Color iconColor)
        {
            _name = name;
            _icon = icon;
            _position = position;
            _iconColor = iconColor;
        }

        public Actor(string name, char icon, Vector2 position, Color iconColor, float scale)
        {
            _name = name;
            _icon = icon;
            _position = position;
            _iconColor = iconColor;
            _scale = scale;
        }

        public void Translate(float x, float y)
        {
            _position.X += x;
            _position.Y += y;
        }

        public void Translate(Vector2 direction)
        {
            //new way with operator overloading
            _position += direction;
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

        public virtual void OnCollision(Actor other) {}

        public virtual void Start() {}

        public virtual void Update(float deltaTime) {}

        public virtual void Draw()
        {
            Raylib.DrawText(Icon.ToString(), (int)(Position.X - Scale / 2), (int)(Position.Y - Scale / 2), (int)Scale, _iconColor);
        }

        public virtual void End() {}
    }
}

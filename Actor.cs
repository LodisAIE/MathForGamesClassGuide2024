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

        public Actor(string name, char icon)
        {
            _name = name;
            _icon = icon;
        }

        public Actor(string name, char icon, int positionX, int positionY)
        {
            _name = name;
            _icon = icon;
            _position = new Vector2(positionX, positionY);
        }

        public Actor(string name, char icon, Vector2 position)
        {
            _name = name;
            _icon = icon;
            _position = position;
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

        public virtual void Start()
        {
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void Draw()
        {
            Raylib.DrawText(Icon.ToString(), (int)Position.X, -(int)Position.Y, 50, Color.DARKBLUE);
        }

        public virtual void End()
        {

        }
    }
}

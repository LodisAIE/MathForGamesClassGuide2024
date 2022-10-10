using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    internal class Actor
    {
        private int _positionX;
        private int _positionY;
        private string _name;
        private char _icon;

        public int PositionX
        {
            get 
            {
                return _positionX;
            }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                }

                _positionX = value;
            }
        }

        public int PositionY
        {
            get 
            {
                return _positionY;
            }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                }

                _positionY = value;
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
            _positionX = positionX;
            _positionY = positionY;
        }

        public void Start()
        {
        }

        public void Update()
        {
            PositionX++;
        }

        public void End()
        {

        }
    }
}

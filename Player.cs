using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace HelloWorld
{
    internal class Player : Actor
    {
        private int _speed = 2;

        public Player(string name, char icon, int positionX, int positionY) :
            base(name, icon, positionX, positionY)
        {

        }

        public override void Update()
        {
            ConsoleKey input = Engine.GetInput();

            Vector2 direction = new Vector2();

            switch (input)
            {
                case ConsoleKey.D:
                    direction = new Vector2(1, 0);
                    break;

                case ConsoleKey.A:
                    direction = new Vector2(-1, 0);
                    break;

                case ConsoleKey.W:
                    direction = new Vector2(0, -1);
                    break;

                case ConsoleKey.S:
                    direction = new Vector2(0, 1);
                    break;
            }

            Vector2 velocity = direction * _speed;

            Translate(velocity);
        }
    }
}

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
        public Player(string name, char icon, int positionX, int positionY) :
            base(name, icon, positionX, positionY)
        {

        }

        public override void Update()
        {
            ConsoleKey input = Engine.GetInput();

            switch (input)
            {
                case ConsoleKey.D:
                    Translate(1, 0);
                    break;

                case ConsoleKey.A:
                    Translate(-1, 0);
                    break;

                case ConsoleKey.W:
                    Translate(0, -1);
                    break;

                case ConsoleKey.S:
                    Translate(0, 1);
                    break;
            }
        }
    }
}

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
        private float _speed = 50;

        public Player(string name, char icon, int positionX, int positionY) :
            base(name, icon, positionX, positionY)
        {

        }

        public override void Update(float deltaTime)
        {
            Vector2 direction = Input.GetMoveInput();

            Vector2 velocity = direction.Normalized * _speed * deltaTime;

            Translate(velocity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    internal class Player : Actor
    {
        private float _speed = 50;
        private Color _defaultColor;
        private Enemy _target;

        public Enemy Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Player(string name, char icon, int positionX, int positionY, Color iconColor) :
            base(name, icon, positionX, positionY, iconColor)
        {
            _defaultColor = iconColor;
        }

        private bool CheckCanBackStab()
        {
            Vector2 direction = (Position - Target.Position).Normalized;
            float dot = Vector2.GetDotProduct(Target.Facing, direction);

            float distance = Vector2.GetDistance(Position, Target.Position);

            return dot <= -0.9f && distance <= 75;
        }

        public override void Update(float deltaTime)
        {
            if (CheckCanBackStab())
            {
                IconColor = Color.RAYWHITE;
            }
            else
            {
                IconColor = _defaultColor;
            }

            Vector2 direction = Input.GetMoveInput();

            Vector2 velocity = direction.Normalized * _speed * deltaTime;

            Console.WriteLine(velocity.Magnitude);

            Translate(velocity);
        }
    }
}

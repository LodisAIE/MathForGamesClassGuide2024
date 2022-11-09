﻿using System;
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

        public Player(string name, Sprite sprite, int positionX, int positionY) :
            base(name, sprite, positionX, positionY)
        {
            _defaultColor = Graphic.SpriteColor;
            CollisionVolume = new CircleCollider(this, 100);
        }

        private bool CheckCanBackStab()
        {
            return false;
            Vector2 direction = (Transform.LocalPosition - Target.Transform.LocalPosition).Normalized;
            float dot = Vector2.GetDotProduct(Target.Facing, direction);

            float distance = Vector2.GetDistance(Transform.LocalPosition, Target.Transform.LocalPosition);

            return dot <= -0.9f && distance <= 75;
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (CheckCanBackStab())
            {
                Graphic.SpriteColor = Color.RAYWHITE;
            }
            else
            {
                Graphic.SpriteColor = _defaultColor;
            }

            Vector2 direction = Input.GetMoveInput();

            Vector2 velocity = direction.Normalized * _speed * deltaTime;

            Transform.Translate(velocity);
        }

        public override void Draw()
        {
            base.Draw();
            CollisionVolume.Draw();
        }
    }
}

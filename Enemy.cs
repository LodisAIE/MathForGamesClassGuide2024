﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace HelloWorld
{
    internal class Enemy : Actor
    {
        private float _speed = 40;
        private Actor _target;

        public Enemy(string name, char icon, int positionX, int positionY, Actor target) :
            base(name, icon, positionX, positionY)
        {
            _target = target;
        }

        /// <summary>
        /// Gets the direction the enemy's target is in.
        /// </summary>
        /// <returns>A normalized vector that represents the targets direction.</returns>
        public Vector2 GetDirectionToTarget()
        {
            Vector2 direction = (_target.Position - Position).Normalized;
            return direction;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //To Do: Make the enemy chase its target
            Vector2 direction = GetDirectionToTarget();
            Vector2 velocity = direction * _speed * deltaTime;

            Translate(velocity);
        }
    }
}
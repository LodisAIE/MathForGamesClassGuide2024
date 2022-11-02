using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace HelloWorld
{
    internal class Scene
    {
        private Actor[] _actors;

        public Scene()
        {
            _actors = new Actor[2];
        }

        public void Start()
        {
            Sprite playerGraphic = new Sprite("Images/player.png");
            Sprite enemyGraphic = new Sprite("Images/enemy.png");

            Player player = new Player("Player", playerGraphic, 0, 1);
            Enemy enemy = new Enemy("bob", enemyGraphic, 200, 200, player);

            player.Target = enemy;

            _actors[0] = player;
            _actors[1] = enemy;

            //Call start for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public void Update(float deltaTime)
        {
            //Update each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Update(deltaTime);

                //Skip collision check if there isn't a collider attached to this actor.
                if (_actors[i].CollisionVolume == null)
                    continue;

                //Check to see if this actor collided with any other actor.
                for (int j = 0; j < _actors.Length; j++)
                {
                    //Skip collision check if there isn't a collider attached to this actor.
                    if (_actors[j].CollisionVolume == null)
                        continue;

                    if (_actors[i].CheckCollision(_actors[j]))
                    {
                        _actors[i].OnCollision(_actors[j]);
                    }
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public void End()
        {
            //Call end for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }
    }
}

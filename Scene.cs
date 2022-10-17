using System;
using System.Collections.Generic;
using System.Text;

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
            _actors[0] = new Actor("bob", 'B', 0, 0);
            _actors[1] = new Player("Player", '@', 0, 1);

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

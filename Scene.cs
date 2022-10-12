using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    internal class Scene
    {
        private char[,] _map;
        private Actor[] _actors;

        /// <summary>
        /// Initializes map array and sets all characters to be empty spaces.
        /// </summary>
        /// <param name="width">How far the map stretches horizontally.</param>
        /// <param name="height">How far the map stretches vertically.</param>
        public Scene(int width, int height)
        {
            _map = new char[height, width];
            InitializeMap();
        }

        /// <summary>
        /// Sets all characters in the map to be a space by default.
        /// </summary>
        private void InitializeMap()
        {
            for (int i = 0;  i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    _map[i, j] = ' ';
                }
            }
        }

        public void Start()
        {
            _actors = new Actor[2];
            _actors[0] = new Actor("bob", 'B', 0, 0);
            _actors[1] = new Player("Player", '@', 0, 1);

            //Call start for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public void Update()
        {
            //Update each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Update();
            }
        }

        public void Draw()
        {
            ///Clear the map to remove previous drawings of actors.
            InitializeMap();

            for (int i = 0; i < _actors.Length; i++)
            { 
                ///Prevent the program from crashing when an actor moves out of bounds. 
                if (_actors[i].Position.Y < _map.GetLength(0) && _actors[i].Position.X < _map.GetLength(1) 
                    && _actors[i].Position.Y >= 0 && _actors[i].Position.X >= 0)
                {
                    _map[(int)_actors[i].Position.Y, (int)_actors[i].Position.X] = _actors[i].Icon;
                }
            }

            //Prints all actors inside the map.
            for (int i = 0;  i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    Console.Write(_map[i, j]);
                }

                Console.WriteLine();
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

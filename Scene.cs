using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    internal class Scene
    {
        private char[,] _map;
        private Actor _actor;

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
            _actor = new Actor("bob", 'B', 0, 0);
        }

        public void Update()
        {
            _actor.Update();
        }

        public void Draw()
        {
            _map[_actor.PositionY, _actor.PositionX] = _actor.Icon;

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

        }
    }
}

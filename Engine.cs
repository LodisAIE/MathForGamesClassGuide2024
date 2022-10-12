using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Engine
    {
        private bool _applicationShouldClose;
        private Scene _testScene;
        private static ConsoleKey _input;

        //Run the game
        public void Run()
        {
            Start();

            while (!_applicationShouldClose)
            {
                Draw();
                Update();
            }

            End();
        }

        public static ConsoleKey GetInput()
        {
            return _input;
        }

        //Performed once when the game begins
        private void Start()
        {
            _testScene = new Scene(20, 20);
            _testScene.Start();
        }

        //Repeated until the game ends
        private void Update()
        {
            _input = Console.ReadKey(true).Key;
            _testScene.Update();
        }

        //Updates visuals every game loop
        private void Draw()
        {
            Console.Clear();
            _testScene.Draw();
        }

        //Performed once when the game ends
        private void End()
        {
            _testScene.End();
        }
    }
}

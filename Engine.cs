using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Engine
    {
        private bool _applicationShouldClose;
        private Scene _testScene;

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

        //Performed once when the game begins
        private void Start()
        {
            _testScene = new Scene(20, 20);
            _testScene.Start();
        }

        //Repeated until the game ends
        private void Update()
        {
            _testScene.Update();
            Console.ReadKey();
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

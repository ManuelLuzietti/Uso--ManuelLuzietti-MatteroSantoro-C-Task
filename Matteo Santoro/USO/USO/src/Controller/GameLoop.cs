using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using USO.src.model;

namespace USO.src.controller
{
    class GameLoop : IGameLoop
    {
        private ILifeBar lifebar;
        private bool running = false;

        public GameLoop() 
        {
            this.lifebar = new LifeBar();
        }
        public void stop()
        {
            this.running = false;
        }

        public async void start()
        {
            /* shoudl check for game instance, in this test i'll check for Lifebar instead */ 
            if (this.lifebar == null) 
                throw new ArgumentException("LifeBar not loaded!");

            running = true;

            while (running && !lifebar.isAlive())
            {
                this.render();
                // Update Life 
                Thread.Sleep(1000);
            }
            Console.WriteLine("Your life is under 0, you died!");
        }
        public void render()
        {
            lifebar.drain();
            lifebar.getRandomPoints();
            lifebar.logLife();
        }
    }
}

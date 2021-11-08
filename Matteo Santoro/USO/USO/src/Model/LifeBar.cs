using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace USO.src.model
{
    class LifeBar : ILifeBar
    {
        /* put here to true to see everthing */ 
        private static bool DEBUG = false;

        public static int FPS = 60;
        public static double OK_INCREASE_RATE = 0.5;
        public static double PERFECT_INCREASE_RATE = 1.05;
        private static double MAX_HEALTH = 100;
        private static double MAX_HEALTH_INCREASE = 55;
        private static double MAX_HEALTH_LOSS = 30;
        private double hpDrainRate = 0.8;

        private Random rand = new Random();
        public double hp { get; set; }

        public LifeBar() 
        {
            this.hp = MAX_HEALTH;
        }
        public void addLife(double hpValue)
        {
            /* comment this line to make the worst score and lose */ 
            this.hp = Math.Min((this.hp + hpValue), MAX_HEALTH);

            /* comment this line to make the best score and lose only if math is against you*/ 
            //this.hp = Math.Min((this.hp + hpValue), hp);
        }

        public void drain()
        {
            if (DEBUG) {
                Console.WriteLine("Draining life");
            }
            this.hp -= hpDrainRate / FPS;
        }

        public void gainLife(int gamePoints)
        {
            double hpValue;
            if (gamePoints < 0)
            {
             if (DEBUG) {
                Console.WriteLine("Player has missed the HitCircle");
            }
               this.lostLife();
            }

            if (gamePoints > 0 && gamePoints <= 50)
            {
              if (DEBUG) {
                Console.WriteLine("Player has scored OK");
            }
              hpValue = (this.hp + MAX_HEALTH_INCREASE
                * OK_INCREASE_RATE);
                this.addLife(hpValue);
            }

            if (gamePoints > 50 && gamePoints <= 100)
            {
               if (DEBUG) {
                Console.WriteLine("Player has scored GREAT");
            }
             hpValue = (this.hp + MAX_HEALTH_INCREASE);
                this.addLife(hpValue);
            }

            if (gamePoints > 100)
            {
                if (DEBUG) {
                Console.WriteLine("Player has scored PERFECT");
            }
            hpValue = (this.hp + MAX_HEALTH_INCREASE
                    * PERFECT_INCREASE_RATE);
                this.addLife(hpValue);
            }
        }

        public void getRandomPoints()
        {
            this.gainLife(rand.Next(-400, 300));
        }

        public bool isAlive()
        {
            return this.hp <= 0;
        }

        public void logLife()
        {
            Console.WriteLine("Current life: " + this.hp);
        }

        public void lostLife()
        {
            this.hp -= MAX_HEALTH_LOSS;
        }
    }
}

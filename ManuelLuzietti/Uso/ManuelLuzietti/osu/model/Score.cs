using System;
using System.Collections.Generic;
using System.Text;

namespace Uso.ManuelLuzietti.osu.model
{
    class Score: IScore
    {
        private int points;

        private int multiplier;

        private int maxMultiplier;

        /**
         * Constructor sets to 0 attributes of the class.
         */
        public Score()
        {
            this.points = 0;
            this.multiplier = 0;
            this.maxMultiplier = 0;
        }

        /**
         * Inits the score.
         */
        public void InitScore()
        {
            this.points = 0;
            this.multiplier = 0;
        }

        /**
         * Gets the points.
         *
         * @return the points
         */
        
    public int GetPoints()
        {
            return points;
        }

        /**
         * Gets the multiplier.
         *
         * @return the multiplier
         */
        
    public int GetMultiplier()
        {
            return multiplier;
        }

        /**
         * Adds the points.
         *
         * @param points the points
         */
        
    public void AddPoints(int points)
        {
            this.points += points;
        }

        /**
         * Increase multiplier.
         */
    public void IncreaseMultiplier()
        {
            this.multiplier += 1;
            this.maxMultiplier += this.multiplier > this.maxMultiplier ? 1 : 0;
        }

        /**
         * Reset multiplier.
         */
    public void ResetMultiplier()
        {
            this.multiplier = 0;
        }

        /**
         * Gets the max multiplier.
         *
         * @return the max multiplier
         */
    public int GetMaxMultiplier()
        {
            return maxMultiplier;
        }
    }
}

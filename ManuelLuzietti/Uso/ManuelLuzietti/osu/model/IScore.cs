using System;
using System.Collections.Generic;
using System.Text;

namespace Uso.ManuelLuzietti.osu.model
{
    interface IScore
    {

        /**
         * Gets the points.
         *
         * @return the points
         */
        int GetPoints();

        /**
         * Gets the multiplier.
         *
         * @return the multiplier
         */
        int GetMultiplier();

        /**
         * Adds points.
         *
         * @param points the points
         */
        void AddPoints(int points);

        /**
         * Increase multiplier.
         */
        void IncreaseMultiplier();

        /**
         * Reset multiplier.
         */
        void ResetMultiplier();

        /**
         * Gets the max multiplier.
         *
         * @return the max multiplier
         */
        int GetMaxMultiplier();

    }
}

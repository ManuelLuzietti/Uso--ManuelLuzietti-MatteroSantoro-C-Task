using System;
using System.Collections.Generic;
using System.Text;
using Uso.ManuelLuzietti.osu.model;
//using Uso.ManuelLuzietti.osu.util

namespace Uso.ManuelLuzietti.osu.controller
{
    interface IScoreManager
    {
        /**
     * Hit is the function that is called when the user hit a {@link HitPoint}.
     *
     * @param points the points
     */
        void Hit(GamePoints.gamePoints points);

        /**
         * missed is the function that is called when the user miss
         * a {@link HitPoint}.
         */
        void Missed();

        /**
         * @return the {@link Score}
         */
        Score GetScore();

        /**
         * Sets the score.
         *
         * @param score the new score
         */
        void SetScore(Score score);

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
         * Gets the statistic.
         *
         * @return the statistic
         */
        Dictionary<GamePoints.gamePoints, int> GetStatistic();
    }
}

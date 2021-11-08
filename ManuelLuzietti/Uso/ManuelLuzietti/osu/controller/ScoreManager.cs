using System;
using System.Collections.Generic;
using System.Text;
using Uso.ManuelLuzietti.osu.model;

namespace Uso.ManuelLuzietti.osu.controller
{
    class ScoreManager: IScoreManager
    {
        private Score score;

        private Dictionary<GamePoints.gamePoints, int> statistic = new Dictionary<GamePoints.gamePoints, int>() {
            {GamePoints.gamePoints.MISS, 0 },
            { GamePoints.gamePoints.OK, 0 },
            { GamePoints.gamePoints.GREAT, 0 },
            { GamePoints.gamePoints.PERFECT, 0 }
        };
    

    /**
     * Instantiates a new score manager implementation setting {@link Score} to
     * manage Uso! score.
     *
     * @param score the score
     */
    public ScoreManager(Score score)
    {
        this.score = score;
    }

    /**
     * Hit is the function that is called when the user hit a {@link HitPoint}.
     *
     * @param points the points
     */
    public void Hit(GamePoints.gamePoints points)
    {
        int value = GamePoints.GamePointsValue(points);
        this.score.AddPoints(value + value * this.score.GetMultiplier());
        this.score.IncreaseMultiplier();
        StatMap(points);
    }

    private void StatMap(GamePoints.gamePoints point)
    {
        //statistic.Compute(point, (k, v)->v += 1);
    }

    /**
     * missed is the function that is called when the user miss a
     * {@link HitPoint}.
     */
    public void Missed()
    {
        //statMap(GamePoints.gamePoints.MISS);
        this.score.ResetMultiplier();
    }

    /**
     * Used to get {@link Score}.
     *
     * @return the {@link Score}
     */
    public Score GetScore()
    {
        return this.score;
    }

    /**
     * Sets the score.
     *
     * @param score the new score
     */
    public void SetScore(Score score)
    {
        this.score = score;
    }

    /**
     * Gets the points.
     *
     * @return the points
     */
    public int GetPoints()
    {
        return this.score.GetPoints();
    }

    /**
     * Gets the multiplier.
     *
     * @return the multiplier
     */
    public int GetMultiplier()
    {
        return this.score.GetMultiplier();
    }

    /**
     * Gets the statistic.
     *
     * @return the statistic
     */
    public Dictionary<GamePoints.gamePoints, int> GetStatistic() {
        return statistic;
    }
}
}

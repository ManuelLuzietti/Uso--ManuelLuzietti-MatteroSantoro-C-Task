namespace Uso.ManuelLuzietti.osu.model
{
    interface IHitPoint
    {
        /**
     * Sets the {@link Pair}.
     *
     * @param pair the new position
     */
        void SetPosition(Pair<double, double> pair);

        /**
         * Sets the time.
         *
         * @param time the new time
         */
        void SetTime(double time);

        /**
         * Gets the {@link Pair}.
         *
         * @return the position
         */
        Pair<double, double> GetPosition();
        /**
         * Gets the time.
         *
         * @return the time
         */
        double GetTime();

        /**
         * Gets the x axis position.
         *
         * @return the x
         */
        double GetX();

        /**
         * Gets the y axis position.
         *
         * @return the y
         */
        double GetY();

        /**
         * Sets the x axis position.
         *
         * @param x the new x
         */
        void SetX(double x);

        /**
         * Sets the y axis position.
         *
         * @param y the new y
         */
        void SetY(double y);
    }
}
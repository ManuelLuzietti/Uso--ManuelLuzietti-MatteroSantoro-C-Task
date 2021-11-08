using System;
using System.Collections.Generic;
using System.Text;

namespace Uso.ManuelLuzietti.osu.model
{
    class HitpointImpl: IHitPoint
    {
        private Pair<double, double> position;

        private double time;

        /**
         * Instantiates a new hitpoint impl.
         *
        // * @param position the position
         * @param time     the time
         */
        public HitpointImpl(Pair<double, double> pair,  double time)
        {
            this.position = pair;
            this.time = time;
        }

        /**
         * Instantiates a new hitpoint impl.
         *
         * @param x    the x
         * @param y    the y
         * @param time the time
         */
        public HitpointImpl(double x, double y, double time)
        {
            this.position = new Pair<double, double>(x, y);
            this.time = time;
        }

        
    public void SetPosition(Pair<double, double> position)
        {
            this.position = position;
        }

        
    public void SetTime(double time)
        {
            this.time = time;
        }

        
    public Pair<double, double> GetPosition()
        {
            return position;
        }

     
    public double GetTime()
        {
            return time;
        }

    public double GetX()
        {
            return this.position.getX();
        }

    public double GetY()
        {
            return this.position.getY();
        }

    public void SetX(double x)
        {
            this.position = new Pair<Double, Double>(x, this.position.getY());
        }

    public void SetY(double y)
        {
            this.position = new Pair<Double, Double>(this.position.getX(), y);
        }

        
    public override String ToString()
        {
            return "[" + this.position + ", time " + this.time + "]";
        }
    }
}

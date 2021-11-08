using System;
using System.Collections.Generic;
using System.Text;

namespace Uso.ManuelLuzietti.osu.model
{
    public static class  GamePoints
    {
        public  enum gamePoints
        {
            MISS,
            OK,
            GREAT,
            PERFECT
        }

        public static int GamePointsValue(gamePoints points)
        {
            switch(points)
            {
                case gamePoints.MISS:
                    return 0;
                case gamePoints.OK:
                    return 50;
                case gamePoints.GREAT:
                    return 100;
                case gamePoints.PERFECT:
                    return 300;
                default:
                    return 0;
            }
        }
    }
}

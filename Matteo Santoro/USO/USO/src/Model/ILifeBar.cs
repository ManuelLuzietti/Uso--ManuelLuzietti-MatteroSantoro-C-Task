using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USO.src.model
{
    interface ILifeBar
    {

        /// <summary>
        /// Checks if the player life is above 0, so if it's alive.
        /// </summary>
        /// <returns></returns>
        bool isAlive();

        /// <summary>
        /// Remove life method.
        /// </summary>
        void lostLife();

        /// <summary>
        /// Elaborates the points and call the addLife method.
        /// </summary>
        /// <param name="gamePoints"></param>
        void gainLife(int gamePoints);

        /// <summary>
        /// Simulates the user playing, generating random scores got by clicking on the HitCircles.
        /// </summary>
        void getRandomPoints();

        /// <summary>
        /// Adds life to the bar
        /// </summary>
        /// <param name="hpValue"></param>
        void addLife(double hpValue);

        /// <summary>
        /// Just an utility to display hp.
        /// </summary>
        void logLife();

        /// <summary>
        /// drain removes life as the beatmap plays.
        /// </summary>
        void drain();
    }
}

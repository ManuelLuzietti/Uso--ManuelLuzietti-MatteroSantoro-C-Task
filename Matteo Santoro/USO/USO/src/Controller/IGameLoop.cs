using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USO.src.controller
{
    interface IGameLoop
    {

        /// <summary>
        /// The start method for the loop.
        /// </summary>
        void start();
        /// <summary>
        /// Method to stop the loop, here is not used but i added it to be complete.
        /// </summary>
        void stop();
        /// <summary>
        /// Grafics render method, in this test i used the terminal to "display" information.
        /// </summary>
        void render();

    }
}

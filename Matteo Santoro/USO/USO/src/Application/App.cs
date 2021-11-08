using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using USO.src.controller;

namespace USO
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IGameLoop gameLoop = new GameLoop();
            gameLoop.start();
        }
    }
}

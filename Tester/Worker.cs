using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d;
using MiniFramework2d.Enums;

namespace Tester
{
    class Worker
    {
        public void Start()
        {
            GameInitiazier game = new GameInitiazier(new MapElements[,] {}, new List<RandomEvent>());

            game.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace Tester
{
    class Worker
    {
        public void Start()
        {
            World world = new World(new IExistInWorld[5,5], 5, 5);
            for (int i = 0; i < world.Width; i++)
            {
                for (int j = 0; j < world.Height; j++)
                {
                    world.Map[i,j] = new EmptyTile(new Point(i, j));
                }
            }
            Player player = new Player("Hero Alba", "A hero on a journay", new Point(5,5), 10, 2);
            List<Enemy> enemies = new List<Enemy>();

            GameInitiazier game = new GameInitiazier(world, player, enemies);

            game.Start();
        }
    }
}

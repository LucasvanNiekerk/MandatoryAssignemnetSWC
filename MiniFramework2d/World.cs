using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d
{
    public class World
    {
        public IExistInWorld[,] Map { get; set; }

        public World(IExistInWorld[,] map)
        {
            Map = map;
        }
    }
}

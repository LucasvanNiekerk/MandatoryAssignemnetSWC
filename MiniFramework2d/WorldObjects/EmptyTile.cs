using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class EmptyTile: IExistInWorld
    {
        public EmptyTile(Point position)
        {
            Position = position;
            Random random = new Random();

            ContainsEvent = random.Next(1) == 0;
        }

        public Point Position { get; set; }

        public bool ContainsEvent { get; }
    }
}

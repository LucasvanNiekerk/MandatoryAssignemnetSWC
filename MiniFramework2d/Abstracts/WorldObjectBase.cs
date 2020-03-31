using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Abstracts
{
    public class WorldObjectBase: IWorldObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Point Position { get; set; }

        protected WorldObjectBase(string name, string description, Point position)
        {
            Name = name;
            Description = description;
            Position = position;
        }
    }
}

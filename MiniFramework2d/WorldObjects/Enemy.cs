using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class Enemy : Creature
    {
        public Enemy(string name, string description, Point position, int healthMax, int attack) : base(name, description, position, healthMax, attack)
        {
        }

        public override void Act(World currentMap)
        {
            
        }
    }
}

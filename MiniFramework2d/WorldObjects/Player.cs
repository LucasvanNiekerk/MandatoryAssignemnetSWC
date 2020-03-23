using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class Player: Creature
    {
        public Player(string name, string description, Point position, int healthMax, int attack, int defense) : base(name, description, position, healthMax, attack, defense)
        {
        }


    }
}

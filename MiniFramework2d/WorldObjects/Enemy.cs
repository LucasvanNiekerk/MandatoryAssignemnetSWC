using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Movement(currentMap);
        }

        private void Movement(World currentMap)
        {
            int rng = RandomInformation.Integer(0, 4);
            switch (rng)
            {
                case 0:
                    if (Position.Y - 1 != -1 && !(currentMap.Map[Position.X, Position.Y - 1] is Water)) Position.Y -= 1;
                    else Movement(currentMap);
                    break;
                case 1:
                    if (Position.Y + 1 != currentMap.Height && !(currentMap.Map[Position.X, Position.Y + 1] is Water)) Position.Y += 1;
                    else Movement(currentMap);
                    break;
                case 2:
                    if (Position.X - 1 != -1 && !(currentMap.Map[Position.X - 1, Position.Y] is Water)) Position.X -= 1;
                    else Movement(currentMap);
                    break;
                case 3:
                    if (Position.X + 1 != currentMap.Height && !(currentMap.Map[Position.X - 1, Position.Y] is Water)) Position.X += 1;
                    else Movement(currentMap);
                    break;
            }
        }
    }
}

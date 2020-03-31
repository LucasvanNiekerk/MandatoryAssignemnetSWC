using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class Player: Creature
    {
        public Player(string name, string description, Point position, int healthMax, int attack) : base(name, description, position, healthMax, attack)
        {
        }

        public override void Act(World currentMap)
        {
            Movement(currentMap);
        }

        private void Movement(World currentMap)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    if (Position.Y - 1 != -1 && !(currentMap.Map[Position.X, Position.Y - 1] is IBlockMovement)) Position.Y -= 1;
                    else Movement(currentMap);
                    break;
                case ConsoleKey.S:
                    if (Position.Y+1 != currentMap.Height && !(currentMap.Map[Position.X, Position.Y + 1] is IBlockMovement)) Position.Y += 1;
                    else Movement(currentMap);
                    break;
                case ConsoleKey.A:
                    if (Position.X - 1 != -1 && !(currentMap.Map[Position.X - 1, Position.Y] is IBlockMovement)) Position.X -= 1; 
                    else Movement(currentMap);
                    break;
                case ConsoleKey.D:
                    if (Position.X + 1 != currentMap.Height && !(currentMap.Map[Position.X + 1, Position.Y] is IBlockMovement)) Position.X += 1; 
                    else Movement(currentMap);
                    break;
                case ConsoleKey.Escape:
                    Debug.WriteLine("Are you sure you want to exit?");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(1);
                    else Movement(currentMap);
                    break;
            }
        }
    }
}

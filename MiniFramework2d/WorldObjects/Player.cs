using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override void Act(World currentMap)
        {
            Movement(currentMap);
        }

        private void Movement(World currentMap)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    if (Position.Y-1 != -1) Position.Y -= 1;
                    else Movement(currentMap);
                    break;
                case ConsoleKey.S:
                    if (Position.Y+1 != currentMap.Height) Position.Y += 1;
                    else Movement(currentMap);
                    break;
                case ConsoleKey.D:
                    if (Position.X - 1 != -1) Position.X -= 1; 
                    else Movement(currentMap);
                    break;
                case ConsoleKey.A:
                    if (Position.X + 1 != currentMap.Height) Position.Y += 1; 
                    else Movement(currentMap);
                    break;
                case ConsoleKey.Escape:
                    Debug.WriteLine("Are you sure you want to exit?");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(1);
                    else Movement(currentMap);
                    break;
            }
            Console.WriteLine("x: " + Position.X + "y: " + Position.Y);
        }
    }
}

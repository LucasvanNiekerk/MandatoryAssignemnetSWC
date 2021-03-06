﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MiniFramework2d;
using MiniFramework2d.Enums;
using MiniFramework2d.Factories;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace Tester
{
    class Worker
    {
        public void Start()
        {
            //World world = GenerateWorld();
            World world = new World(10, 10);
            Player player = GeneratePlayer();
            List<Enemy> enemies = GenerateEnemies(world);

            GameInitiazier game = new GameInitiazier(world, player, enemies);

            Thread thread = new Thread(StartLogger);
            thread.Start();

            game.Start();
        }

        private void StartLogger()
        {
            Thread.Sleep(500);
            string exeDirectory = FindPath.FindDirectory("MandatoryAssignemnetSWC", extraDirectory: "\\TesterLogger\\bin\\Release\\netcoreapp2.1\\win-x86\\TesterLogger.exe");

            var process = new Process
            {
                StartInfo =
                {
                    FileName = exeDirectory,
                    Arguments = (Configuration.LogPath + Configuration.LogFileName),
                    CreateNoWindow = false,
                    UseShellExecute = true,
                }
            };
            process.Start();

            Console.ReadKey();
        }

        private List<Enemy> GenerateEnemies(World world)
        {
            List<Enemy> enemies = new List<Enemy>
            {
                EnemyFactory.GetEnemyWithGear(new Point(0, 1), 100, 10),
                EnemyFactory.GetEnemyWithGear(new Point(1, 2), 200, 10),
                EnemyFactory.GetEnemyWithGear(new Point(2, 3), 50, 10),
                EnemyFactory.GetEnemyWithGear(new Point(3, 7), 75, 10)
            };

            return enemies;
        }

        private Player GeneratePlayer()
        {
            Player p = new Player("Hero Alba", "A hero on a journey", new Point(5, 5), 125, 15);
            p.EquipNewGear(GearFactory.GetGear(GearType.Chest));
            p.EquipNewWeapon(WeaponFactory.GetWeapon(WeaponType.MainHand, AttackType.Blunt));
            return p;
        }

        private World GenerateWorld()
        {
            World world = new World(new IWorldObject[5, 5]);
            for (int i = 0; i < world.Width; i++)
            {
                for (int j = 0; j < world.Height; j++)
                {
                    world.Map[i, j] = new EmptyTile("", "", new Point(i, j));
                }
            }

            world.Map[3,3] = new Dungeon("Dungeon", "Dirty cave", new Point(3,3));
            world.Map[4,4] = new Town("Small town", "A couple of houses in a forrest", new Point(4,4));
            world.Map[0,0] = new Water("Water", "Water...", new Point(0, 0));

            return world;
        }
    }
}

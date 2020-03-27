using System;
using System.Collections.Generic;
using System.Text;
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
            World world = GenerateWorld();
            Player player = GeneratePlayer();
            List<Enemy> enemies = GenerateEnemies();
            GenerateWeaponsForEnemies(enemies);

            GameInitiazier game = new GameInitiazier(world, player, enemies);

            game.Start();
        }

        private void GenerateWeaponsForEnemies(List<Enemy> enemies)
        {
            WeaponFactory wf = new WeaponFactory();
            GearFactory gf = new GearFactory();

            foreach (var enemy in enemies)
            {
                //All enemies start fully geared
                foreach (var gearType in EnumLists.GearTypeList)
                {
                    enemy.EquipNewGear(gf.GetGear(gearType));
                }

                //All enemies have a main and offhand weapon.
                foreach (var weaponType in EnumLists.WeaponTypeList)
                {
                    enemy.EquipNewWeapon(wf.GetWeapon(weaponType));
                }

            }
        }

        private List<Enemy> GenerateEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();

            enemies.Add(new Enemy("Orc", "Smelly", new Point(1, 1), 2, 2));
            return enemies;
        }

        private Player GeneratePlayer()
        {
            return new Player("Hero Alba", "A hero on a journay", new Point(5, 5), 10, 2);
        }

        private World GenerateWorld()
        {
            World world = new World(new IWorldObject[5, 5], 5, 5);
            for (int i = 0; i < world.Width; i++)
            {
                for (int j = 0; j < world.Height; j++)
                {
                    world.Map[i, j] = new EmptyTile(new Point(i, j));
                }
            }

            return world;
        }
    }
}

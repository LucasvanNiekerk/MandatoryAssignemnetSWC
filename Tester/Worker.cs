using System.Collections.Generic;
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
            foreach (var enemy in enemies)
            {
                //All enemies start fully geared
                foreach (var gearType in EnumLists.GearTypeList)
                {
                    enemy.EquipNewGear(GearFactory.GetGear(gearType));
                }

                //All enemies have a main and offhand weapon.
                foreach (var weaponType in EnumLists.WeaponTypeList)
                {
                    enemy.EquipNewWeapon(WeaponFactory.GetWeapon(weaponType, AttackType.Slash));
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
            Player p = new Player("Hero Alba", "A hero on a journay", new Point(5, 5), 10, 10);
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

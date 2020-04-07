using System.Collections.Generic;
using System.Linq;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Enums;
using MiniFramework2d.Factories;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class Dungeon : IWorldObject, IEvent
    {
        public Dungeon(string name, string description, Point position)
        {
            Name = name;
            Description = description;
            Position = position;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Point Position { get; set; }

        private List<Enemy> enemies;

        public virtual void Event(Creature dungeonCrawler)
        {
            EnterDungeon();
            Logger.Log($"There are {enemies.Count} enemies in the dungeon.");
            foreach (var enemy in enemies)
            {
                //Fight
                Combat(dungeonCrawler, enemy);
                //If dead exit dungeon and continue
                if (dungeonCrawler.Dead)
                {
                    break;
                }
                //Loot dead enemy otherwise rest and fight next
                if (enemy.Dead)
                {
                    Logger.Log($"{dungeonCrawler.Name} is looting {enemy.Name}...");
                    Loot(dungeonCrawler, enemy);
                }
                //Rest to full health (perhaps it should be random if you heal or not)
                Rest(dungeonCrawler);
                Logger.Log($"{dungeonCrawler.Name} is resting... Healed to full health {dungeonCrawler.HealthCurrent}");
            }

            Logger.Log($"{dungeonCrawler.Name} defeated the Dungeon!");
        }

        private void EnterDungeon()
        {
            enemies = new List<Enemy>();

            for (int i = 0; i < RandomInformation.Integer(1, EnumLists.GearTypeList.Count() - 1); i++)
            {
                enemies.Add(EnemyFactory.GetEnemyWithGear(new Point(0, 0), RandomInformation.Integer(1, 10), RandomInformation.Integer(1, 10)));
            }
        }

        private void Combat(Creature dungeonCrawler, Creature enemy)
        {
            Logger.Log($"{dungeonCrawler.Name} entered combat with {enemy.Name}!");
            while (!dungeonCrawler.Dead && !enemy.Dead)
            {
                //If stalemate breakout
                if (enemy - dungeonCrawler <= 0 && dungeonCrawler - enemy <= 0)
                {
                    Logger.Log($"{dungeonCrawler.Name} and {enemy.Name} are evenly matched and decided to make peace... for now.");
                    break;
                }
                // Current actor attack the target found aka other actor.
                enemy.RecieveDamage(enemy - dungeonCrawler);
                Logger.Log($"{dungeonCrawler.Name} attacked {enemy.Name} for {enemy - dungeonCrawler} damage. \n{(enemy.Dead ? enemy.Name + " died!" : " is at " + enemy.HealthCurrent + "health.")}");


                // If the other actor survived he retaliates.
                if (!enemy.Dead)
                {
                    dungeonCrawler.RecieveDamage(dungeonCrawler - enemy);
                    Logger.Log($"{enemy.Name} attacked {dungeonCrawler.Name} for {dungeonCrawler - enemy} damage. \n{(dungeonCrawler.Dead ? dungeonCrawler.Name + " died!" : " is at " + dungeonCrawler.HealthCurrent + "health.")}");
                }
            }
        }

        private void Loot(Creature dungeonCrawler, Creature enemy)
        {
            //Currently forces user to equip all new gear and weapons
            enemy.DropItems().gear?.ForEach(gear =>
            {
                if (gear != null)
                {
                    dungeonCrawler.EquipNewGear(gear);
                    Logger.Log($"{dungeonCrawler.Name} found and equipped {gear}!");
                }
            });
            enemy.DropItems().weapons?.ForEach(weapon =>
            {
                if (weapon != null)
                {
                    dungeonCrawler.EquipNewWeapon(weapon);
                    Logger.Log($"{dungeonCrawler.Name} found and equipped {weapon}!");
                }
            });
            if(enemy.DropItems().gear.Any() && enemy.DropItems().weapons.Any()) Logger.Log($"{dungeonCrawler.Name} could not find any gear or weapons on {enemy.Name}");
        }
        
        
        private void Rest(Creature dungeonCrawler)
        {
            dungeonCrawler.HealToFullHealth();
        }
    }
}

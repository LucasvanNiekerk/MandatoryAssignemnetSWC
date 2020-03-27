using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Abstracts;
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
            //Should either be randomized or predefined
            enemies = new List<Enemy> {new Enemy("Goblin", "Small", new Point(0, 0), 2, 2)};
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Point Position { get; set; }

        private List<Enemy> enemies;

        public void Event(Creature dungeonCrawler)
        {
            foreach (var enemy in enemies)
            {
                //Fight
                Combat(ref dungeonCrawler, enemy);
                //If dead exit dungeon and continue
                if (dungeonCrawler.Dead) break;
                //Loot dead enemy
                Loot(ref dungeonCrawler, enemy);
                //Rest to full health (perhaps it should be random if you heal or not)
                Rest(ref dungeonCrawler);
            }
        }

        private void Combat(ref Creature dungeonCrawler, Creature enemy)
        {
            while (!dungeonCrawler.Dead || !enemy.Dead)
            {
                // Current actor attack the target found aka other actor.
                enemy.RecieveDamage(enemy - dungeonCrawler);

                // If the other actor survived he retaliates.
                if (!enemy.Dead)
                {
                    dungeonCrawler.RecieveDamage(dungeonCrawler - enemy);
                }
            }
        }

        private void Loot(ref Creature dungeonCrawler, Creature enemy)
        {
            //Currently forces user to equip all new gear and weapons
            enemy.DropItems().gear.ForEach(dungeonCrawler.EquipNewGear);
            enemy.DropItems().weapons.ForEach(dungeonCrawler.EquipNewWeapon);
        }
        
        
        private void Rest(ref Creature dungeonCrawler)
        {
            dungeonCrawler.HealToFullHealth();
        }
    }
}

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
            foreach (var enemy in enemies)
            {
                //Fight
                Combat(dungeonCrawler, enemy);
                //If dead exit dungeon and continue
                if (dungeonCrawler.Dead) break;
                //Loot dead enemy otherwise rest and fight next
                if(enemy.Dead) Loot(dungeonCrawler, enemy);
                //Rest to full health (perhaps it should be random if you heal or not)
                Rest(dungeonCrawler);
            }
        }

        private void EnterDungeon()
        {
            enemies = new List<Enemy>();

            EnemyFactory ef = new EnemyFactory();

            for (int i = 0; i < RandomInformation.Integer(1, EnumLists.GearTypeList.Count() - 1); i++)
            {
                enemies.Add(ef.GetEnemyWithGear(new Point(0, 0), RandomInformation.Integer(1, 10), RandomInformation.Integer(1, 10)));
            }
        }

        private void Combat(Creature dungeonCrawler, Creature enemy)
        {
            while (!dungeonCrawler.Dead && !enemy.Dead)
            {
                //If stalemate breakout
                if (enemy - dungeonCrawler <= 0 && dungeonCrawler - enemy <= 0) break;
                // Current actor attack the target found aka other actor.
                enemy.RecieveDamage(enemy - dungeonCrawler);

                // If the other actor survived he retaliates.
                if (!enemy.Dead)
                {
                    dungeonCrawler.RecieveDamage(dungeonCrawler - enemy);
                }
            }
        }

        private void Loot(Creature dungeonCrawler, Creature enemy)
        {
            //Currently forces user to equip all new gear and weapons
            enemy.DropItems().gear?.ForEach(dungeonCrawler.EquipNewGear);
            enemy.DropItems().weapons?.ForEach(dungeonCrawler.EquipNewWeapon);
        }
        
        
        private void Rest(Creature dungeonCrawler)
        {
            dungeonCrawler.HealToFullHealth();
        }
    }
}

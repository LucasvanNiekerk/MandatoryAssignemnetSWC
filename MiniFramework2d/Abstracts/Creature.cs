using System;
using System.Collections.Generic;
using System.Linq;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d.Abstracts
{
    public abstract class Creature: WorldObject, IAct
    {
        protected Creature(string name, string description, Point position, int healthMax, int attack, int defense) : base(name, description, position)
        {
            HealthMax = healthMax;
            HealthCurrent = healthMax;
            Attack = attack;
            Defense = defense;

            Inventory = new List<Gear>();
            Equipment = new EquipedGear();
        }

        public List<Gear> Inventory { get; set; }
        public EquipedGear Equipment { get; set; }

        public int HealthMax { get; set; }
        public int HealthCurrent { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool Dead { get; set; }

        public virtual void Act(World currentMap)
        {
            
        }

        public bool CheckCollision(IExistInWorld obj)
        {
            return Position.Equals(obj.Position);
        }
    }
}

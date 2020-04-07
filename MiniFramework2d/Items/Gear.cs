using System;
using System.Collections.Generic;
using System.Linq;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d.Items
{
    public class Gear : IComparable<Gear>, IItem
    {
        public Gear(GearType itemSlot, string description, int defense, Dictionary<AttackType, float> resistences)
        {
            ItemSlot = itemSlot;
            Description = description;
            Defense = defense;
            Resistences = resistences;
        }

        public GearType ItemSlot { get; set; }
        public string Description { get; set; }

        public int Defense { get; set; }
        public Dictionary<AttackType, float> Resistences { get; set; }

        // Returns the average damage reduction of all attack types with a 1000 hp as base
        // (int)((1000 damage - defense) * resistance) / 3 - (int)((1000 damage - defense) * resistance) / 3
        // Example
        // ((((1000 - 10) * 0.5) +  ((1000 - 10) * 0.75) + ((1000 - 10) * 0.35)) / 3) - (((1000 - 8) * 0.85) +  ((1000 - 10) * 0.85) + ((1000 - 10) * 0.50)) / 3)
        // ((495 + 472.5 + 346.5) / 3) - ((843.2 + 841.5 + 495) / 3)
        // 438 - 762 = -324
        // Therefor the old gear is better
        // positive = new better
        // negative = old better
        // The lower the number the more damage is reduced on average
        public int CompareTo(Gear other)
        {
            int currentGear = (int)(Resistences.Sum(r => (1000 - Defense) * r.Value) / 3f);
            int newGear = (int)(other.Resistences.Sum(r => (1000 - other.Defense) * r.Value) / 3f);
            return currentGear - newGear;
        }

        public override string ToString()
        {
            return $"{ItemSlot} {Defense}";
        }
    }
}

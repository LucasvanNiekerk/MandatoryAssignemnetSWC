using System;
using System.Collections.Generic;
using System.Linq;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d.Items
{
    public class Gear : IComparable<Gear>
    {
        public Gear(GearType itemSlot, string description, int defense, Dictionary<AttackType, int> resistences)
        {
            ItemSlot = itemSlot;
            Description = description;
            Defense = defense;
            Resistences = resistences;
        }

        public GearType ItemSlot { get; set; }
        public string Description { get; set; }

        public int Defense { get; set; }
        public Dictionary<AttackType, int> Resistences { get; set; }

        public int CompareTo(Gear other)
        {
            //Returns the average damage reduction of all attack types with a 1000 hp as base
            return (int)(Resistences.Sum(r => (1000 - Defense) / r.Value) / 3f) - (int)(other.Resistences.Sum(r => (1000 - Defense) / r.Value) / 3f);
        }
    }
}

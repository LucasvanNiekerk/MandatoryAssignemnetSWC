using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d.Items
{
    public class Weapon : IComparable<Weapon>, IItem
    {
        public Weapon(WeaponType itemSlot, string description, int attack, AttackType type)
        {
            ItemSlot = itemSlot;
            Description = description;
            Attack = attack;
            Type = type;
        }

        public WeaponType ItemSlot { get; set; }
        public string Description { get; set; }

        public int Attack { get; set; }
        public AttackType Type { get; set; }

        public int CompareTo(Weapon other)
        {
            return Attack - other.Attack;
        }

        public override string ToString()
        {
            return $"{ItemSlot} {Attack} {Type}";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d.Items
{
    public class EquipedGear
    {
        public Dictionary<GearType, Gear> _equipment;
        public Dictionary<WeaponType, Weapon> _weapons;

        public EquipedGear()
        {
            _equipment = new Dictionary<GearType, Gear>();
            _weapons = new Dictionary<WeaponType, Weapon>();

            foreach (GearType gearType in EnumLists.GearTypeList)
            {
                _equipment.Add(gearType, null);
            }

            EnumLists.WeaponTypeList.ToList().ForEach(attack => _weapons.Add(attack, null));
        }

        public (AttackType[], int[]) Damage() 
        {
            int[] damage = new int[2];
            AttackType[] attackType = new AttackType[2];
            for (int i = 0; i < 2; i++)
            {
                damage[i] = _weapons.ToArray()[i].Value.Attack;
                attackType[i] = _weapons.ToArray()[i].Value.Type;
            }

            return (attackType, damage);
            //_weapons.Values.ToList().Sum(weapon => weapon.Attack);
        }

        public int Defense
        {
            get { return _equipment.Values.Sum(equipment => equipment.Defense); }
        }

        public float GetResistance(AttackType resistance)
        {
            return (1f - _equipment.Values.Select(equipment => equipment.Resistences[resistance]).Sum());
        }

        public void AddGear(Gear gear)
        {
            _equipment[gear.ItemSlot] = gear;
        }

        public void AddWeapon(Weapon weapon)
        {
            _weapons[weapon.ItemSlot] = weapon;
        }
    }
}

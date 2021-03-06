﻿using System.Collections.Generic;
using System.Linq;
using MiniFramework2d.Enums;

namespace MiniFramework2d.Items
{
    public class EquipedGear
    {
        private Dictionary<GearType, Gear> _equipment;
        private Dictionary<WeaponType, Weapon> _weapons;

        public EquipedGear()
        {
            Initialize();
        }

        private void Initialize()
        {
            _equipment = new Dictionary<GearType, Gear>();
            _weapons = new Dictionary<WeaponType, Weapon>();

            foreach (GearType gearType in EnumLists.GearTypeList)
            {
                _equipment.Add(gearType, null);
            }

            EnumLists.WeaponTypeList.ToList().ForEach(attack => _weapons.Add(attack, null));
        }

        public (List<Gear>, List<Weapon>) DropItems()
        {
            List<Gear> gear = _equipment.Values.ToList();
            List<Weapon> weapons = _weapons.Values.ToList();

            return (gear, weapons);
        }

        public (AttackType[], int[]) Damage()
        {
            int[] damage = new int[2];
            AttackType[] attackType = new AttackType[2];

            for (int i = 0; i < 2; i++)
            {
                damage[i] = _weapons.ToArray()[i].Value?.Attack ?? 0;
                attackType[i] = _weapons.ToArray()[i].Value?.Type ?? AttackType.Blunt;
            }

            return (attackType, damage);
        }

        public int Defense
        {
            get
            {
                return _equipment.Values.Sum(equipment => equipment?.Defense ?? 0);
            }
        }

        public float GetResistance(AttackType resistance)
        {
            return (1f - _equipment.Values.Select(equipment => equipment?.Resistences[resistance] ?? 0).Sum());
        }

        public void EquipGear(Gear gear)
        {
            if (gear != null) _equipment[gear.ItemSlot] = gear;
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapon != null) _weapons[weapon.ItemSlot] = weapon;
        }

        public void EquipOnlyIfBetterGear(Gear newGear)
        {
            if (newGear != null)
            {
                if (_equipment[newGear.ItemSlot] == null)
                {
                    EquipGear(newGear);
                }
                if (_equipment[newGear.ItemSlot].CompareTo(newGear) > 0)
                {
                    EquipGear(newGear);
                }
            }
        }

        public void EquipOnlyIfBetterWeapon(Weapon newWeapon)
        {
            if (newWeapon != null)
            {
                if (_weapons[newWeapon.ItemSlot] == null)
                {
                    EquipWeapon(newWeapon);
                }
                else if (_weapons[newWeapon.ItemSlot].CompareTo(newWeapon) < 0)
                {
                    EquipWeapon(newWeapon);
                }
            }
        }
    }
}

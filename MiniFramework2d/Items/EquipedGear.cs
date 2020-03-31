using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d.Items
{
    public class EquipedGear
    {
        private Dictionary<GearType, Gear> _equipment;
        private Dictionary<WeaponType, Weapon> _weapons;

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
            //_weapons.Values.ToList().Sum(newWeapon => newWeapon.Attack);
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

        public void AddGear(Gear gear)
        {
            if(gear != null) _equipment[gear.ItemSlot] = gear;
        }

        public void AddWeapon(Weapon weapon)
        {
            if(weapon != null) _weapons[weapon.ItemSlot] = weapon;
        }

        public void AddOnlyIfBetterGear(Gear newGear)
        {
            if (_equipment[newGear.ItemSlot].CompareTo(newGear) < 0)
            {
                AddGear(newGear);
            }
        }

        public void AddOnlyIfBetterWeapon(Weapon newWeapon)
        {
            if (_weapons[newWeapon.ItemSlot].CompareTo(newWeapon) < 0)
            {
                AddWeapon(newWeapon);
            }
        }
    }
}

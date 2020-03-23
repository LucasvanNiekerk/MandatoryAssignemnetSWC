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

        public int Damage
        {
            get
            {
                return _weapons.Values.ToList().Sum(weapon => weapon.Attack);
            }
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

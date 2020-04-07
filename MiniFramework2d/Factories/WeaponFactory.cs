using System;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Factories
{
    public static class WeaponFactory // IFactory
    {
        /// <summary>
        /// Returns a new weapon with weapon and attack type given. If minDamage and maxDamage is left empty or is less than 0 the weapon will have random damage.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attackType"></param>
        /// <param name="minDamage"></param>
        /// <param name="maxDamge"></param>
        /// <returns></returns>
        public static Weapon GetWeapon(WeaponType type, AttackType attackType, int minDamage = -1, int maxDamge = -1)
        {
            if (minDamage <= 0) minDamage = RandomInformation.Integer(Configuration.WeaponFactoryMinDamage, Configuration.WeaponFactoryMaxDamage);
            if (maxDamge <= 0) maxDamge = RandomInformation.Integer(minDamage, Configuration.WeaponFactoryMaxDamage);

            //if (minDamage < 0 || maxDamge < 0) throw new ArgumentException($"Not valid damage for weapon. Min: {minDamage}, Max: {maxDamge}");

            Weapon temp = new Weapon(type, 
                RandomInformation.Description(type.ToString()), 
                RandomInformation.Integer(minDamage, maxDamge), 
                attackType);

            return temp;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d.Factories
{
    public static class EnemyFactory //IFactory
    {
        public static Enemy GetEnemy(Point position, int health = 5, int attack = 5)
        {
            return new Enemy(RandomInformation.Name(), 
                RandomInformation.Description(""), 
                position, 
                health, 
                attack);
        }

        public static Enemy GetEnemyWithGear(Point position, int health = 5, int attack = 5)
        {
            Enemy result = new Enemy(RandomInformation.Name(), 
                RandomInformation.Description(""), 
                position, 
                health, 
                attack);

            for (int i = 0; i < RandomInformation.Integer(0, EnumLists.GearTypeList.Count()); i++)
            {
                result.EquipNewGear(GearFactory.GetGear(EnumLists.GearTypeList.ToList()[i]));
            }

            for (int i = 0; i < RandomInformation.Integer(0, EnumLists.WeaponTypeList.Count()); i++)
            {
                result.EquipNewWeapon(WeaponFactory.GetWeapon(EnumLists.WeaponTypeList.ToList()[i], AttackType.Slash));
            }

            return result;
        }
    }
}

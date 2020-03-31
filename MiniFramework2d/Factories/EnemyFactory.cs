using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d.Factories
{
    public class EnemyFactory: IFactory
    {
        public Enemy GetEnemy(Point position, int health = 5, int attack = 5)
        {
            return new Enemy(RandomInformation.Name(), 
                RandomInformation.Description(""), 
                position, 
                health, 
                attack);
        }

        public Enemy GetEnemyWithGear(Point position, int health = 5, int attack = 5)
        {
            Enemy result = new Enemy(RandomInformation.Name(), 
                RandomInformation.Description(""), 
                position, 
                health, 
                attack);

            for (int i = 0; i < RandomInformation.Integer(0, EnumLists.GearTypeList.Count() -1); i++)
            {
                result.EquipNewGear(GearFactory.GetGear(EnumLists.GearTypeList.ToList()[i]));
            }

            for (int i = 0; i < RandomInformation.Integer(0, EnumLists.WeaponTypeList.Count() - 1); i++)
            {
                result.EquipNewWeapon(WeaponFactory.GetWeapon(EnumLists.WeaponTypeList.ToList()[i], AttackType.Slash));
            }

            return result;
        }
    }
}

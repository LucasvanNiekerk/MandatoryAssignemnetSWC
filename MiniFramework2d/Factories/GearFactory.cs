using System.Collections.Generic;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Factories
{
    public static class GearFactory // IFactory
    {
        public static Gear GetGear(GearType typeOfClass, int minDefense = Configuration.GearFactoryMinDefense, int maxDefense = Configuration.GearFactoryMaxDefense)
        {
            Gear temp = new Gear(typeOfClass, 
                RandomInformation.Description(GearType.Chest.ToString()), 
                RandomInformation.Integer(minDefense, maxDefense), 
                new Dictionary<AttackType, float>());

            foreach (AttackType type in EnumLists.AttackTypeList)
            {
                temp.Resistences.Add(type, RandomInformation.Float());
            }

            return temp;
        }
    }
}

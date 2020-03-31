using System.Collections.Generic;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Factories
{
    public class GearFactory: IFactory
    {
        public Gear GetGear(GearType typeOfClass, int minDefense = 1, int maxDefense = 10)
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

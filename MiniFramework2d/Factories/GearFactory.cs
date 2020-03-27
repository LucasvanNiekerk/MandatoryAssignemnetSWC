using System.Collections.Generic;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Factories
{
    public class GearFactory: IFactory
    {
        public Gear GetGear(GearType typeOfClass)
        {
            Gear temp = new Gear(GearType.Chest, 
                RandomInformation.Description(GearType.Chest.ToString()), 
                RandomInformation.Integer(0, 10), 
                new Dictionary<AttackType, float>());

            foreach (AttackType type in EnumLists.AttackTypeList)
            {
                temp.Resistences.Add(type, RandomInformation.Float());
            }

            switch (typeOfClass)
            {
                case GearType.Chest:
                    temp.ItemSlot = GearType.Chest;
                    break;
                case GearType.Feet:
                    temp.ItemSlot = GearType.Feet;
                    break;
                case GearType.Head:
                    temp.ItemSlot = GearType.Head;
                    break;
                case GearType.Legs:
                    temp.ItemSlot = GearType.Legs;
                    break;
                case GearType.Shoulder:
                    temp.ItemSlot = GearType.Shoulder;
                    break;
            }

            return temp;
        }
    }
}

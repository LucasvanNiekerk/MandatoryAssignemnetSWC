using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniFramework2d.Enums
{
    public class EnumLists
    {
        public static IEnumerable<AttackType> AttackTypeList
        {
            get { return Enum.GetValues(typeof(AttackType)).Cast<AttackType>(); }
        }
        
        public static IEnumerable<GearType> GearTypeList
        {
            get { return Enum.GetValues(typeof(GearType)).Cast<GearType>(); }
        }

        public static IEnumerable<WeaponType> WeaponTypeList
        {
            get { return Enum.GetValues(typeof(WeaponType)).Cast<WeaponType>(); }
        }
    }
}

using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;

namespace MiniFramework2d.Factories
{
    class AbstractItemFactory
    {
        public static IFactory GetFactory(AbstractFactoryType typeOfFactory)
        {
            switch (typeOfFactory)
            {
                case AbstractFactoryType.Gear: return new GearFactory();
                case AbstractFactoryType.Weapon: return new WeaponFactory();
            }

            return null;
        }
    }
}

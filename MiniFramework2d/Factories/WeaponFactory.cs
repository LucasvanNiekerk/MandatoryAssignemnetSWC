using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Factories
{
    public class WeaponFactory: IFactory
    {
        public Weapon GetWeapon(WeaponType type)
        {
            Weapon temp = new Weapon(type, RandomInformation.Description(type.ToString()), RandomInformation.Integer(5,12), AttackType.Slash);

            return temp;
        }

    }
}

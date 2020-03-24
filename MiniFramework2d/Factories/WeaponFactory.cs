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
            Weapon temp = new Weapon(type, RandomInformation.RandomDescription(type.ToString()), RandomInformation.RandomInteger(5,12), AttackType.Slash);

            int rng = RandomInformation.RandomInteger(1, 2);
            if (rng == 1) temp.Type = AttackType.Blunt;
            else if (rng == 2) temp.Type = AttackType.Stab;

            switch (type)
            {
                case WeaponType.MainHand:
                    temp.ItemSlot = WeaponType.MainHand;
                    break;
                case WeaponType.OffHand:
                    temp.ItemSlot = WeaponType.OffHand;
                    break;

            }

            return temp;
        }

    }
}

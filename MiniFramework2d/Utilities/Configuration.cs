using System;
using System.Collections.Generic;
using System.Text;

namespace MiniFramework2d.Utilities
{
    public static class Configuration
    {
        public const string LogPath = "../../../logs/";
        public static readonly string LogFileName = DateTime.Now.ToFileTimeUtc().ToString();

        public const int WeaponFactoryMinDamage = 1;
        public const int WeaponFactoryMaxDamage = 15;

        public const int GearFactoryMinDefense = 1;
        public const int GearFactoryMaxDefense = 15;

        public const int EnemyFactoryMinHealth = 2;
        public const int EnemyFactoryMaxHealth = 10;
        public const int EnemyFactoryMinAttack = 1;
        public const int EnemyFactoryMaxAttack = 5;
    }
}

using System;
using System.IO;

namespace MiniFramework2d.Utilities
{
    public static class Configuration
    {
        private static readonly string ExeDirectory = Environment.CurrentDirectory;
        public static readonly string LogPath = FindDirectory(ExeDirectory) + "\\logs\\";
        public static readonly string LogFileName = DateTime.Now.ToFileTimeUtc() + "_Logs.txt";

        private static string FindDirectory(string currentDirectory)
        {
            string tempDirectory = Directory.GetParent(currentDirectory).FullName;
            if (!tempDirectory.EndsWith("Tester")) tempDirectory = FindDirectory(tempDirectory);
            return tempDirectory;
        }

        public const int TurnDelay = 500;

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

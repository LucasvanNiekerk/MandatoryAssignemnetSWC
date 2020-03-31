using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Enums;

namespace MiniFramework2d.Utilities
{
    public static class RandomInformation
    {
        static Random rng = new Random();
        public static string Name()
        {
            rng = new Random();

            List<string> words = new List<string>()
            {
                "Fire",
                "Ligtning",
                "Water",
                "Earth",
                "Light"
            };

            return words[rng.Next(words.Count - 1)];

        }
        public static string Description(string type)
        {
            rng = new Random();

            List<string> words = new List<string>()
            {
                "Trash",
                "Okay",
                "Rare",
                "Legendary",
                "Godlike"
            };

            return words[rng.Next(words.Count - 1)] + type;
        }

        public static int Integer(int min, int max)
        {
            rng = new Random();

            return rng.Next(min, max);
        }

        public static float Float()
        {
            rng = new Random();

            return (float)rng.NextDouble();
        }

    }
}

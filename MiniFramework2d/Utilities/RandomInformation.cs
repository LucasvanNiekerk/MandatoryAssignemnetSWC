using System;
using System.Collections.Generic;

namespace MiniFramework2d.Utilities
{
    public static class RandomInformation
    {
        private static Random rng = new Random(DateTime.Now.Millisecond);
        public static string Name()
        {
            List<string> words = new List<string>()
            {
                "Fire",
                "Lightning",
                "Water",
                "Earth",
                "Light"
            };

            return words[rng.Next(words.Count - 1)];

        }
        public static string Description(string type)
        {
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
            return rng.Next(min, max);
        }

        public static float Float()
        {
            return (float)rng.NextDouble();
        }
    }
}

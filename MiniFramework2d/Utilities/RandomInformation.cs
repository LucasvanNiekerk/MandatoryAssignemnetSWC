using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Enums;

namespace MiniFramework2d.Utilities
{
    public static class RandomInformation
    {
        public static string RandomName(string type)
        {
            Random rng = new Random();

            List<string> words = new List<string>()
            {
                "Fire",
                "Ligtning",
                "Water",
                "Earth",
                "Light"
            };

            return words[rng.Next(words.Count - 1)] + type;

        }
        public static string RandomDescription(string type)
        {
            Random rng = new Random();

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

        public static int RandomInteger(int min, int max)
        {
            Random rng = new Random();

            return rng.Next(min, max);
        }

        public static float RandomFloat()
        {
            Random rng = new Random();

            return (float)rng.NextDouble();
        }

    }
}

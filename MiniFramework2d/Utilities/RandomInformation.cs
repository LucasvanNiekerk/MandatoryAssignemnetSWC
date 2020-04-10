using System;
using System.Collections.Generic;
using System.IO;

namespace MiniFramework2d.Utilities
{
    public static class RandomInformation
    {
        private static Random rng = new Random(DateTime.Now.Millisecond);

        private static readonly string namePath = FindPath.FindDirectory("MandatoryAssignemnetSWC", extraDirectory: "\\MiniFramework2d\\Utilities\\Names\\");
        private static readonly string[] maleNames = File.ReadAllLines(namePath + "drengenavne.txt");
        private static readonly string[] femaleNames = File.ReadAllLines(namePath + "pigenavne.txt");
        private static readonly string[] sirNames = File.ReadAllLines(namePath + "efternavne.txt");

        public static string Name()
        {
            if (rng.Next(2) == 1)
            {
                return maleNames[rng.Next(maleNames.Length)] + " " + sirNames[rng.Next(sirNames.Length)];
            }
            else
            {
                return femaleNames[rng.Next(femaleNames.Length)] + " " + sirNames[rng.Next(sirNames.Length)];
            }
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

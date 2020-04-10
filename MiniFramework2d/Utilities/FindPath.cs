using System;
using System.IO;

namespace MiniFramework2d.Utilities
{
    public static class FindPath
    {
        public static string FindDirectory(string directoryToFind, string currentDirectory = "", string extraDirectory = null)
        {
            string result = "";
            if (currentDirectory == "")
            {
                currentDirectory = Environment.CurrentDirectory;
            }

            result = Directory.GetParent(currentDirectory).FullName;

            if (!result.EndsWith(directoryToFind))
            {
                result = FindDirectory(directoryToFind, result);
            }
            return result + extraDirectory;
        }
    }
}

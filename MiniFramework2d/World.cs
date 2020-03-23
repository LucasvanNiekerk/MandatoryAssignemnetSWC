using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d
{
    public class World
    {
        public IExistInWorld[,] Map { get; set; }

        public int Height { get; }
        public int Width { get; }

        /// <summary>
        /// For predefined worlds
        /// </summary>
        /// <param name="map"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public World(IExistInWorld[,] map, int height, int width)
        {
            Map = map;
            Height = height;
            Width = width;
        }

        /// <summary>
        /// For random worlds
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public World(int height, int width)
        {
            Map = GenerateRandomMap(height, width);
            Height = height;
            Width = width;
        }

        private IExistInWorld[,] GenerateRandomMap(int height, int width)
        {
            IExistInWorld[,] result = new IExistInWorld[height, width];
            Random random = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    switch (random.Next())
                    {
                        case 0:
                            result[i,j] = new EmptyTile(new Point(i, j));
                            break;
                        case 1:
                            result[i, j] = new EmptyTile(new Point(i, j));
                            break;
                        case 2:
                            result[i, j] = new EmptyTile(new Point(i, j));
                            break;
                        case 3:
                            result[i, j] = new EmptyTile(new Point(i, j));
                            break;
                        case 4:
                            result[i, j] = new Town("Town", "Big Town", new Point(i,j));
                            break;
                        case 5:
                            result[i, j] = new Town("Town", "Big Town", new Point(i, j));
                            break;
                        case 6:
                            result[i, j] = new Dungeon("Dungeon", "Scary Dungeon", new Point(i,j));
                            break;
                        case 7:
                            result[i, j] = new Water("Water", "Deep scart Water", new Point(i,j));
                            break;
                    }
                }
            }


            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d
{
    public class World
    {
        /// <summary>
        /// For predefined worlds
        /// </summary>
        /// <param name="map"></param>
        public World(IWorldObject[,] map)
        {
            Map = map;
            Height = map.GetLength(0);
            Width = map.GetLength(1);
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

        public IWorldObject[,] Map { get; }

        public int Height { get; }
        public int Width { get; }
        

        private IWorldObject[,] GenerateRandomMap(int height, int width)
        {
            IWorldObject[,] result = new IWorldObject[height, width];
            Random random = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch (random.Next(8))
                    {
                        case 0:
                            result[x,y] = new EmptyTile("", "", new Point(x, y));
                            break;
                        case 1:
                            result[x, y] = new EmptyTile("", "", new Point(x, y));
                            break;
                        case 2:
                            result[x, y] = new EmptyTile("", "", new Point(x, y));
                            break;
                        case 3:
                            result[x, y] = new EmptyTile("", "", new Point(x, y));
                            break;
                        case 4:
                            result[x, y] = new Town("Town", "Big Town", new Point(x,y));
                            break;
                        case 5:
                            result[x, y] = new Town("Town", "Big Town", new Point(x, y));
                            break;
                        case 6:
                            result[x, y] = new Dungeon("Dungeon", "Scary Dungeon", new Point(x,y));
                            break;
                        case 7:
                            result[x, y] = new Water("Water", "Deep scart Water", new Point(x,y));
                            break;
                    }
                }
            }


            return result;
        }

        public void PrintMap(List<Creature> actors)
        {
            Console.Clear();
            IWorldObject[,] drawMap = (IWorldObject[,])Map.Clone();

            actors.ForEach(actor => drawMap[actor.Position.X, actor.Position.Y] = actor);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    //This is weird but it works
                    switch (drawMap[y,x])
                    {
                        case Dungeon dungeon:
                            Console.Write('d');
                            break;
                        case EmptyTile emptyTile:
                            Console.Write('e');
                            break;
                        case Town town:
                            Console.Write('t');
                            break;
                        case Water water:
                            Console.Write('w');
                            break;
                        case Enemy enemy:
                            Console.Write('E');
                            break;
                        case Player player:
                            Console.Write('P');
                            break;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

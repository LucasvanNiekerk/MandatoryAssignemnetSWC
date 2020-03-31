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

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch (random.Next())
                    {
                        case 0:
                            result[i,j] = new EmptyTile("", "", new Point(i, j));
                            break;
                        case 1:
                            result[i, j] = new EmptyTile("", "", new Point(i, j));
                            break;
                        case 2:
                            result[i, j] = new EmptyTile("", "", new Point(i, j));
                            break;
                        case 3:
                            result[i, j] = new EmptyTile("", "", new Point(i, j));
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

        public void PrintMap(List<Creature> actors)
        {
            Console.Clear();
            IWorldObject[,] drawMap = (IWorldObject[,])Map.Clone();

            actors.ForEach(actor => drawMap[actor.Position.Y, actor.Position.X] = actor);

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    switch (drawMap[i,j])
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

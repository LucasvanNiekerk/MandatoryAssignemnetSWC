using MiniFramework2d.Abstracts;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class Town: IWorldObject
    {
        public Town(string name, string description, Point position)
        {
            Name = name;
            Description = description;
            Position = position;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Point Position { get; set; }
    }
}

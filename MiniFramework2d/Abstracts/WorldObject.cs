using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Abstracts
{
    public abstract class WorldObject: IExistInWorld
    {
        public WorldObject(string name, string description, Point position)
        {
            Name = name;
            Description = description;
            Position = position;
        }

        //World Object Properties
        public string Name { get; set; }
        public string Description { get; set; }

        //IExistInWorld Properties
        public Point Position { get; set; }

    }
}

using MiniFramework2d.Abstracts;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public sealed class Water : WorldObjectBase, IBlockMovement
    {
        public Water(string name, string description, Point position) : base(name, description, position)
        {
        }
    }
}

using MiniFramework2d.Utilities;

namespace MiniFramework2d.Interfaces
{
    public interface IWorldObject
    {
        //World Object Properties
        string Name { get; set; }
        string Description { get; set; }
        Point Position { get; set; }

    }
}

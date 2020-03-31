using MiniFramework2d.Abstracts;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class Town: WorldObjectBase, IEvent
    {
        public Town(string name, string description, Point position) : base(name, description, position)
        {
        }

        public virtual void Event(Creature actor)
        {
            actor.HealToFullHealth();
        }
    }
}

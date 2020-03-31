using System;
using System.Collections.Generic;
using System.Text;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Enums;
using MiniFramework2d.Factories;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.WorldObjects
{
    public class EmptyTile: WorldObjectBase, IEvent
    {
        public EmptyTile(string name, string description, Point position) : base(name, description, position)
        {
            Position = position;

            ContainsEvent = RandomInformation.Integer(0, 1) == 0;
        }

        public bool ContainsEvent { get; }

        //Currently simply gives a random weapons
        public virtual void Event(Creature actor)
        {
            if (ContainsEvent)
            {
                actor.EquipNewWeapon(WeaponFactory.GetWeapon(WeaponType.MainHand, AttackType.Slash));
            }
        }
    }
}

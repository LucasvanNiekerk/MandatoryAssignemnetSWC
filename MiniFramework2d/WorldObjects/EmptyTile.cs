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
    public class EmptyTile: IWorldObject, IEvent
    {
        public EmptyTile(Point position)
        {
            Position = position;

            ContainsEvent = RandomInformation.Integer(0, 1) == 0;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Point Position { get; set; }

        public bool ContainsEvent { get; }

        //Currently simply gives a random weapons
        public void Event(Creature actor)
        {
            if (ContainsEvent)
            {
                WeaponFactory wf = new WeaponFactory();

                actor.EquipNewWeapon(wf.GetWeapon(WeaponType.MainHand));
            }
        }
    }
}

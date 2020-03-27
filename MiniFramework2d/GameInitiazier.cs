using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d
{
    public class GameInitiazier
    {
        private World _world;
        private List<Creature> _actors;
        /// <summary>
        /// You can import your own world or you can generate a random world. By either give your own map[] or simply state how big it should be (mind you it is extreamly random at the moment).
        /// </summary>
        /// <param name="world"></param>
        /// <param name="player"></param>
        /// <param name="enemies"></param>
        public GameInitiazier(World world, Player player, List<Enemy> enemies)
        {
            _world = world;

            _actors = new List<Creature>();

            //To prevent the player from spawning outside the world...
            player.Position = new Point(world.Height/2, world.Width/2);

            _actors.Add(player);
            _actors.AddRange(enemies);
        }
        public void Start()
        {
            bool running = true;

            while (running)
            {
                _world.PrintMap(_actors);
                Update();
            }
        }

        private void Update()
        {
            foreach (Creature currentActor in _actors)
            {
                currentActor.Act(_world);
                _actors.Where(a => a != currentActor).ToList().ForEach(otherActor =>
                {
                    if (currentActor.CheckCollision(otherActor))
                    {
                        switch (otherActor as IWorldObject)
                        {
                            case Dungeon dungeon:
                                dungeon.Event(currentActor);
                                break;
                            case EmptyTile emptyTile:
                                if(emptyTile.ContainsEvent) Console.WriteLine("EVENT WOHOO");
                                break;
                            case Enemy enemy:
                                Combat(currentActor, otherActor);
                                break;
                            case Player player:
                                Combat(currentActor, otherActor);
                                break;
                            case Town town:
                                currentActor.HealToFullHealth();
                                break;
                            case Water water:
                                Console.WriteLine("Howd you even get here!?");
                                break;
                        }
                    }
                });
                Thread.Sleep(500);
            }

            List<Creature> deadCreatures = new List<Creature>();
            for (int i = 0; i < _actors.Count; i++)
            {
                if (_actors[i].Dead)
                {
                    deadCreatures.Add(_actors[i]);
                    
                }
            }

            foreach (var deadCreature in deadCreatures)
            {
                _actors.Remove(deadCreature);
            }
        }

        private void Combat(Creature currentActor, Creature otherActor)
        {
            // The two actors fight until one of them dies.
            while (!currentActor.Dead && !otherActor.Dead)
            {
                // Current actor attack the target found aka other actor.
                otherActor.RecieveDamage(otherActor-currentActor);

                // If the other actor survived he retaliates.
                if (!otherActor.Dead)
                {
                    currentActor.RecieveDamage(currentActor - otherActor);
                }
            }
        }
    }
}

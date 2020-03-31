using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Utilities;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d
{
    /// <summary>
    /// Main Component
    /// </summary>
    public class GameInitiazier
    {
        /// <summary>
        /// You can import your own world or you can generate a random world. By either give your own map[] or simply state how big it should be (mind you it is extremely random at the moment).
        /// The player is the user, he can move and you can give him start attack and defense, the player will start at map height/2 and width/2.
        /// A list of enemies to be on the board, their position should be less than map height and bound. As default they will move a random direction each turn.
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

            //To prevent enemies from spawning outside the world...
            foreach (var enemy in enemies)
            {
                if (enemy.Position.X < 0 || enemy.Position.X > world.Width)
                {
                    enemy.Position.X = RandomInformation.Integer(0, world.Width);
                }
                if (enemy.Position.Y < 0 || enemy.Position.Y > world.Height)
                {
                    enemy.Position.Y = RandomInformation.Integer(0, world.Height);
                }
            }

            _actors.Add(player);
            _actors.AddRange(enemies);
        }

        private World _world;
        private List<Creature> _actors;


        public void Start()
        {
            while (_actors.Count > 1)
            {
                _world.PrintMap(_actors);
                Update();
                _world.PrintMap(_actors);
            }

            Console.WriteLine($"The winner is {_actors[0].Name} congratiolations!");
            Console.WriteLine();
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
                        Combat(currentActor, otherActor);
                    }

                    if (currentActor.CheckCollision(_world.Map[currentActor.Position.X, currentActor.Position.Y]))
                    {
                        switch (_world.Map[currentActor.Position.X, currentActor.Position.Y])
                        {
                            case Dungeon dungeon:
                                dungeon.Event(currentActor);
                                break;
                            case EmptyTile emptyTile:
                                if (emptyTile.ContainsEvent) Console.WriteLine("EVENT WOHOO");
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
                Thread.Sleep(100);
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

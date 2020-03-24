using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                                Console.WriteLine("Scary dungeon lots of enemies, fight or die!");
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
            }
        }

        private void Combat(Creature currentActor, Creature otherActor)
        {
            while (!currentActor.Dead || !otherActor.Dead)
            {
                otherActor.RecieveDamage(otherActor-currentActor);
                if (!otherActor.Dead)
                {
                    currentActor.RecieveDamage(currentActor-otherActor);

                    if (otherActor.Dead)
                    {

                    }
                }
            }
        }
    }
}

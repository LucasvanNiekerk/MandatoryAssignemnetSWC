using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Abstracts;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d
{
    public class GameInitiazier
    {
        private World _world;
        private List<Creature> _actors;
        /// <summary>
        /// You can import your own world or you can generate a random world.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="player"></param>
        /// <param name="enemies"></param>
        public GameInitiazier(World world, Player player, List<Enemy> enemies)
        {
            
            _world = world;

            _actors = new List<Creature>();
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
                        Combat(currentActor, otherActor);
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

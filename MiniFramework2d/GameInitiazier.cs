using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniFramework2d.Abstracts;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.WorldObjects;

namespace MiniFramework2d
{
    public class GameInitiazier
    {
        private World _world;
        private Player _player;
        private List<Enemy> _enemies;
        private List<Creature> _actors;
        public GameInitiazier(World world, Player player, List<Enemy> enemies)
        {
            _world = world;
            _player = player;
            _enemies = enemies;

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
            _actors.ForEach(actor => 
            { 
                actor.Act(_world);
                _actors.Where(a => a != actor).ToList().ForEach(act =>
                {
                    if (actor.CheckCollision(act))
                    {
                        Combat(actor, act);
                    }
                });
            });
        }

        private void Combat(Creature firstObj, Creature secondObj)
        {
            while (firstObj.Dead || secondObj.Dead)
            {
                //Todo Fix damage, defense and resistence inside creature..
                //secondObj.HealthCurrent - (firstObj.Attack - secondObj.Defense) * secondObj.Equipment.
            }
        }
    }
}

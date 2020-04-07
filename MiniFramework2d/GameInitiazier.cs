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
            player.Position = new Point(world.Height / 2, world.Width / 2);

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
            Logger.Log($"Game start!\nThere are {_actors.Count} actors alive!\n");
            _world.PrintMap(_actors);
            while (_actors.Count > 1)
            {
                Update();
                _world.PrintMap(_actors);
            }

            Logger.Log($"The game is over...\nThe winner is {_actors[0]?.Name ?? "no one survived"} congratiolations!");

            Console.WriteLine($"The winner is {_actors[0]?.Name ?? "no one survived"} congratiolations!");
            Console.WriteLine();
        }

        private void Update()
        {
            _actors.ForEach(currentActor =>
            {
                //If currentActor didn't die previously in the round they will act.
                if (!currentActor.Dead)
                {
                    Logger.Log($"{currentActor}");
                    currentActor.Act(_world);
                    Logger.Log($"{currentActor.Name} moved to {currentActor.Position}");

                    //We then check if any of the the current actor has collided with any of the other actors
                    foreach (Creature otherActor in _actors)
                    {
                        //We dont want to fight our self and didn't die during the round.
                        if (currentActor != otherActor && !otherActor.Dead)
                        {
                            //We then check check for collision and if there is they engage in combat
                            if (currentActor.CheckCollision(otherActor))
                            {
                                Logger.Log($"{currentActor.Name} collided with {otherActor.Name}");
                                Combat(currentActor, otherActor);
                                break;
                            }
                        }
                    }
                    //Afterwards we check if the current actor died previously otherwise we check what tile they are now standing on and use that tiles event
                    if (!currentActor.Dead)
                    {
                        switch (_world.Map[currentActor.Position.X, currentActor.Position.Y])
                        {
                            case Dungeon dungeon:
                                Logger.Log($"{currentActor.Name} entered a Dungeon!");
                                dungeon.Event(currentActor);
                                break;
                            case EmptyTile emptyTile:
                                Logger.Log($"{currentActor.Name} stepped on an empty tile!");
                                emptyTile.Event(currentActor);
                                break;
                            case Town town:
                                currentActor.HealToFullHealth();
                                Logger.Log($"{currentActor.Name} entered a town and healed up. {currentActor.Name} is at full health {currentActor.HealthCurrent}.");
                                break;
                            case Water water:
                                Console.WriteLine("Howd you even get here!?");
                                Logger.Log($"Something went wrong {currentActor.Name} is in water... Please call the gamemaster at +45 #### ####.");
                                break;
                        }
                    }
                    Thread.Sleep(100);
                    Logger.Log("\n");
                }
            });
            
            RemoveDeadActors();
        }


        private void RemoveDeadActors()
        {
            List<Creature> deadCreatures = new List<Creature>();
            foreach (var actor in _actors)
            {
                if (actor.Dead)
                {
                    deadCreatures.Add(actor);
                }
            }

            if (deadCreatures.Any())
            {
                string deadActorsLoggerString = "";
                foreach (var deadCreature in deadCreatures)
                {
                    _actors.Remove(deadCreature);
                    deadActorsLoggerString += deadCreature.Name + "\n";
                }
                Logger.Log($"These actors died this turn:\n{deadActorsLoggerString}");
            }
            else
            {
                Logger.Log("No one died this turn!\n");
            }
        }

        private void Combat(Creature currentActor, Creature otherActor)
        {
            Logger.Log($"{currentActor.Name} entered combat with {otherActor.Name}!");
            // The two actors fight until one of them dies.
            while (!currentActor.Dead && !otherActor.Dead)
            {
                //If stalemate break out
                if (currentActor - otherActor <= 0 && otherActor - currentActor <= 0)
                {
                    Logger.Log($"{currentActor.Name} and {otherActor.Name} are evenly matched and decided to make peace... for now.");
                    break;
                }

                // Current actor attack the target found aka other actor.
                otherActor.RecieveDamage(otherActor - currentActor);
                Logger.Log($"{currentActor.Name} attacked {otherActor.Name} for {otherActor - currentActor} damage. \n{(otherActor.Dead ? otherActor.Name + " died!" : " is at " + otherActor.HealthCurrent + "health.")}");

                // If the other actor survived he retaliates.
                if (!otherActor.Dead)
                {
                    currentActor.RecieveDamage(currentActor - otherActor);
                    Logger.Log($"{otherActor.Name} attacked {currentActor.Name} for {currentActor - otherActor} damage. \n{(currentActor.Dead ? currentActor.Name + " died!" : " is at " + currentActor.HealthCurrent + "health.")}");
                }
            }
        }
    }
}


/*_actors.Where(a => a != currentActor).ToList().ForEach(otherActor =>
                    {
                        if (!otherActor.Dead)
                        {
                            if (currentActor.CheckCollision(otherActor))
                            {
                                Logger.Log($"{currentActor.Name} collided with {otherActor.Name}");
                                Combat(currentActor, otherActor);
                            }
                            else if (currentActor.CheckCollision(_world.Map[currentActor.Position.X, currentActor.Position.Y]))
                            {
                                switch (_world.Map[currentActor.Position.X, currentActor.Position.Y])
                                {
                                    case Dungeon dungeon:
                                        Logger.Log($"{currentActor.Name} entered a Dungeon!");
                                        dungeon.Event(currentActor);
                                        break;
                                    case EmptyTile emptyTile:
                                        Logger.Log($"{currentActor.Name} stepped on an empty tile!");
                                        emptyTile.Event(currentActor);
                                        break;
                                    case Town town:
                                        currentActor.HealToFullHealth();
                                        Logger.Log($"{currentActor.Name} entered a town and healed up. {currentActor.Name} is at full health {currentActor.HealthCurrent}.");
                                        break;
                                    case Water water:
                                        Console.WriteLine("Howd you even get here!?");
                                        Logger.Log($"Something went wrong {currentActor.Name} is in water... Please call the gamemaster at +45 #### ####.");
                                        break;
                                }
                            }
                        }

                    });*/

using System.Collections.Generic;
using MiniFramework2d.Enums;
using MiniFramework2d.Interfaces;
using MiniFramework2d.Items;
using MiniFramework2d.Utilities;

namespace MiniFramework2d.Abstracts
{
    public abstract class Creature: WorldObject, IAct
    {
        protected Creature(string name, string description, Point position, int healthMax, int attack) : base(name, description, position)
        {
            _healthMax = healthMax;
            HealthCurrent = healthMax;
            _attack = attack;

            Inventory = new List<Gear>();
            _equipment = new EquipedGear();
        }

        private int _attack;
        private int _healthCurrent;
        private EquipedGear _equipment;
        private int _healthMax;

        public List<Gear> Inventory { get; }

        public int HealthCurrent
        {
            get => _healthCurrent;
            set
            {
                if (value >= 0) Dead = true;
                _healthCurrent = value;
            }
        }

        
        public bool Dead { get; set; }

        //Technically decorator?
        public (AttackType[], int[]) Damage()
        {
            var output = _equipment.Damage();
            for (int i = 0; i < output.Item2.Length; i++)
            {
                output.Item2[i] = output.Item2[i] + _attack;
            }

            return output;
        }

        private int Defense()
        {
            return _equipment.Defense;
        }

        //Adaptor??
        private float Resistance(AttackType type)
        {
            return _equipment.GetResistance(type);
        }

        //Minusing two creatures will return damage dealt to left creature.
        public static int operator -(Creature defendingCreature, Creature attackingCreature)
        {
            int damageDealt = 0;

            //Array of attacking Creatures equipped weapons containing their damage and attackType.
            var creature1Weapons = attackingCreature.Damage();
            for (int i = 0; i < creature1Weapons.Item2.Length; i++)
            {
                // Damage = (Creature attacking weapon Damage - Creature defending defense) * Creature defending resistance against attacking weapon type
                damageDealt += (int)((creature1Weapons.Item2[i] - defendingCreature.Defense()) * defendingCreature.Resistance(creature1Weapons.Item1[i]));
            }

            return damageDealt;
        }

        public virtual void Act(World currentMap)
        {
            
        }

        public void RecieveDamage(int amount)
        {
            HealthCurrent -= amount;
        }

        public void HealToFullHealth()
        {
            HealthCurrent = _healthMax;
        }

        public bool CheckCollision(IExistInWorld obj)
        {
            return this.Position.Equals(obj.Position);
        }
    }
}

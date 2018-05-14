namespace HeroGame.Entities
{
    using System;

    public abstract class Hero
    {
        private double health;

        private double armor;

        protected Hero()
        {
            this.Armor = 300;
            this.Health = 300;
            this.Damage = 100;
        }

        public virtual double Armor
        {
            get { return this.armor; }
            set
            {
                double armorPoints = value;

                if (value <= 0)
                {
                    armorPoints = 0;
                }

                this.armor = armorPoints;
            }
        }

        public virtual double Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    throw new ArgumentException($"{this.GetType().Name} is death");
                }

                this.health = value;
            }
        }

        protected double Damage { get; set; }

        public virtual bool Defend()
        {
            return false;
        }

        public virtual void Attack(Hero defender)
        {
            var rnd = new Random();

            // heros do random damage between 80% and 120%
            var percentDamage = rnd.Next(80, 121);
            var damage = Math.Round(this.Damage * (percentDamage / 100.0));
            

            if (defender.Armor - damage >= 0)
            {
                defender.Armor -= damage;
            }
            else if (defender.Armor != 0)
            {
                defender.Health -= (damage - defender.Armor);
                defender.Armor = 0;
            }
            else
            {
                defender.Health -= damage;
            }
        }
    }
}

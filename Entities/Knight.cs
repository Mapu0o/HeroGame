namespace HeroGame.Entities
{
    using System;

    public class Knight : Hero
    {

        public override void Attack(Hero defender)
        {
            var rnd = new Random();

            // heros do random damage between 80% and 120%
            var percentDamage = rnd.Next(80, 121);
            var damage = Math.Round(this.Damage * (percentDamage / 100.0));

            var changeToDoubleAtack = rnd.Next(0, 101);

            if (changeToDoubleAtack <= 10)
            {
                damage *= 2;
            }

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

        public override bool Defend()
        {
            var rnd = new Random();

            var percent = rnd.Next(0, 101);

            // 20% chance to completely block the attack
            if (percent <= 20)
            {
                return true;
            }

            return false;
        }
    }
}

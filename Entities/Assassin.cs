namespace HeroGame.Entities
{
    using System;

    public class Assassin : Hero
    {
        public override void Attack(Hero defender)
        {
            var rnd = new Random();

            // heros do random damage between 80% and 120%
            var percentDamage = rnd.Next(80, 121);
            var damage = Math.Round(this.Damage * (percentDamage / 100.0));

            var changeToTripleAtack = rnd.Next(0, 101);

            if (changeToTripleAtack <= 30)
            {
                damage *= 3;
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
    }
}

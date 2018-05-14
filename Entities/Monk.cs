namespace HeroGame.Entities
{
    using System;

    public class Monk : Hero
    {
        public override bool Defend()
        {
            var rnd = new Random();

            var percent = rnd.Next(0, 101);

            // 30% chance to avoid the attack
            if (percent <= 30)
            {
                return true;
            }

            return false;
        }
    }
}

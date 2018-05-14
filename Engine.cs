namespace HeroGame
{
    using HeroGame.Entities;
    using System;

    public class Engine
    {
        private Hero playerOne;
        private Hero playerTwo;

        public void Run()
        {
            Console.WriteLine("[Assassin], [Knight], [Monk], [Warrior]");

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Pick a hero: ");
                var heroName = Console.ReadLine();

                if (i == 0)
                {
                    playerOne = CreateHero(heroName);
                }
                else
                {
                    playerTwo = CreateHero(heroName);
                }
            }

            Battle(playerOne, playerTwo);
        }

        private static void Battle(Hero playerOne, Hero playerTwo)
        {
            var turns = 0;

            while (true)
            {
                try
                {
                    if (turns % 2 == 0)
                    {
                        if (!playerTwo.Defend())
                        {
                            playerOne.Attack(playerTwo);
                            Console.WriteLine($@"{playerOne} attacks and {playerTwo} has {playerTwo.Health}");
                        }
                    }
                    else
                    {
                        if (!playerOne.Defend())
                        {
                            playerTwo.Attack(playerOne);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    if (playerOne.Health != 0)
                    {
                        Console.WriteLine($"{playerOne.GetType().Name} won the fight with [{playerOne.Health}]Health, [{playerOne.Armor}]Armor");
                    }
                    else
                    {
                        Console.WriteLine($"{playerTwo.GetType().Name} won the fight with [{playerTwo.Health}]Health, [{playerTwo.Armor}]Armor");
                    }
                    Environment.Exit(0);
                }

                turns++;
            }
        }

        private static Hero CreateHero(string heroName)
        {
            Hero hero;

            switch (heroName.ToLower())
            {
                case "assassin":
                    hero = new Assassin();
                    break;
                case "knight":
                    hero = new Knight();
                    break;
                case "monk":
                    hero = new Monk();
                    break;
                case "warrior":
                    hero = new Warrior();
                    break;

                default: throw new ArgumentException("Invalid hero type!");
            }

            return hero;
        }
    }
}

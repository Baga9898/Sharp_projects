using System;

namespace Fight
{
    class Fighter
    {
        public string name;
        public int lives;
        public int damage;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] fighters1 = {"Ninja1", "Ninja2", "Ninja3"};
            string[] fighters2 = {"Knight1", "Knight2", "Knight3"};

            string fighter1 = fighters1[new Random().Next(0, fighters1.Length)];
            string fighter2 = fighters2[new Random().Next(0, fighters2.Length)];
            
            Console.WriteLine($"First fighter is: {fighter1}");
            Console.WriteLine($"Second fighter is: {fighter2}");

            Random rnd = new Random();

            int damage1 = rnd.Next(0, 100);
            int damage2 = rnd.Next(0, 100);

            Fighter firstTeamFighter = new Fighter();
            firstTeamFighter.name = fighter1;
            firstTeamFighter.lives = 1000;
            firstTeamFighter.damage = damage1;
            int lives1 = firstTeamFighter.lives;

            Fighter secondTeamFighter = new Fighter();
            secondTeamFighter.name = fighter2;
            secondTeamFighter.lives = 1000;
            secondTeamFighter.damage = damage2;
            int lives2 = secondTeamFighter.lives;

            int death = 0;

            for (int i = 1;;)
            {
                lives1 = lives1 - damage2;
                lives2 = lives2 - damage1;
                
                Console.WriteLine($"HIT# {i}");

                Console.WriteLine($"{fighter1}: {lives1}/1000");
                Console.WriteLine($"{fighter2}: {lives2}/1000");

                if (lives1 <= death)
                {
                    Console.WriteLine($"{fighter2} is winner");
                    Console.WriteLine($"{fighter1} is looser");
                    break;
                }
                else if (lives2 <= death)
                {
                    Console.WriteLine($"{fighter1} is winner");
                    Console.WriteLine($"{fighter2} is looser");
                    break;
                }
                i++;
            }
            Console.ReadLine();
        }
    }
}
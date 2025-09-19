using System;

namespace ShotgunGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SHOTGUN – Textspel";

            // Fråga efter namn 
            Console.Write("Skriv ditt namn: ");
            string namn = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(namn))
            {
                namn = "Spelare";
            }

            bool kör = true;

            while (kör)
            {
                Console.Clear();
                Console.WriteLine("SHOTGUN - Textspel");
                Console.WriteLine("1) Spela match");
                Console.WriteLine("2) Avsluta");
                Console.Write("Ditt val: ");
                string val = (Console.ReadLine() ?? "").Trim();

                if (val == "1")
                {
                    var spel = new GameLogik(namn);
                    spel.StartaMatch();

                    // Tillbaka till menyn efter matchen
                    Console.WriteLine();
                    Console.WriteLine("Tryck på tangent för att gå till menyn");
                    Console.ReadKey();
                }
                else if (val == "2")
                {
                    kör = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Tryck på tangent för att gå till menyn");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Synd att du lämnar; vi hade ju så roligt!");
        }
    }
}

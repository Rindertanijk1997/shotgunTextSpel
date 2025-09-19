using System;

namespace ShotgunGame
{
    // Klass för mig
    public class HumanPlayer : Player
    {
        // Namnet skickas till Player 
        public HumanPlayer(string namn) : base(namn)
        {
        }

        // spelaren väljer sitt drag 
        public override Move VäljDrag()
        {
            // loopar tills man väljer något giltigt
            while (true)
            {
                Console.WriteLine($"{Namn}, välj ditt drag:");
                Console.WriteLine("1) Ladda");
                Console.WriteLine("2) Blocka");

                if (KanSkjuta)
                {
                    Console.WriteLine("3) Skjuta");
                }

                if (KanShotgun)
                {
                    Console.WriteLine("4) Shotgun");
                }

                Console.WriteLine("");

                // Läs in spelarens val
                string input = Console.ReadLine() ?? "";

                // tolka spelarens val som en siffra
                if (int.TryParse(input, out int val))
                {
                    Move valtDrag = (Move)val;

                    // Kolla om draget är tillåtet
                    if (valtDrag == Move.Ladda)
                    {
                        Console.WriteLine("Du väljer: Ladda");
                        return Move.Ladda;
                    }
                    if (valtDrag == Move.Blocka)
                    {
                        Console.WriteLine("Du väljer: Blocka");
                        return Move.Blocka;
                    }
                    if (valtDrag == Move.Skjuta && KanSkjuta)
                    {
                        Console.WriteLine("Du väljer: Skjuta");
                        return Move.Skjuta;
                    }
                    if (valtDrag == Move.Shotgun && KanShotgun)
                    {
                        Console.WriteLine("Du väljer: Shotgun");
                        return Move.Shotgun;
                    }
                }

                // Om valet är fel
                Console.WriteLine("Ogiltigt val, försök igen!");
            }
        }
    }
}

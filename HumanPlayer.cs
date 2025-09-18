using System;

namespace ShotgunGame
{
    // Klass för mig
    public class HumanPlayer : Player
    {
        // Namnet skickas till Player-klassen 
        public HumanPlayer(string namn) : base(namn)
        {
        }

        // spelaren väljer sitt drag 
        public override Move VäljDrag()
        {
            while (true) // loopar tills man väljer något giltigt
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
                Console.Write("Ditt val: ");
                string input = Console.ReadLine() ?? "";

                // tolka spelarens val som en siffra
                if (int.TryParse(input, out int val))
                {
                    Move valtDrag = (Move)val;

                    // Kolla draget är tillåtet just nu
                    if (valtDrag == Move.Ladda) return Move.Ladda;
                    if (valtDrag == Move.Blocka) return Move.Blocka;
                    if (valtDrag == Move.Skjuta && KanSkjuta) return Move.Skjuta;
                    if (valtDrag == Move.Shotgun && KanShotgun) return Move.Shotgun;
                }

                // Om valet är fel
                Console.WriteLine("Ogiltigt val, försök igen!");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace ShotgunGame
{
    // Klass för datorn 
    public class BotPlayer : Player
    {
        private Random slump = new Random();

        // Namnet skickas vidare till Player-klassen 
        public BotPlayer(string namn) : base(namn)
        {
        }

        // Här bestämmer datorn sitt drag
        public override Move VäljDrag()
        {
            // Skapa en lista med alla tillåtna drag just nu
            List<Move> möjligaDrag = new List<Move>();

            // Dessa två drag är alltid tillåtna
            möjligaDrag.Add(Move.Ladda);
            möjligaDrag.Add(Move.Blocka);

            // Skjuta om det finns minst 1 skott
            if (KanSkjuta)
            {
                möjligaDrag.Add(Move.Skjuta);
            }

            // Shotgun om det finns minst 3 skott
            if (KanShotgun)
            {
                möjligaDrag.Add(Move.Shotgun);
            }

            // Slumpa ett drag 
            int index = slump.Next(möjligaDrag.Count);
            Move datornsVal = möjligaDrag[index];

            // Vänta 3 sekunder för att göra det mer verkligt
            System.Threading.Thread.Sleep(3000);

            // Skriv ut i terminalen vad datorn väljer (siffra + namn)
            Console.WriteLine($"{Namn} väljer: {(int)datornsVal}) {datornsVal}");

            return datornsVal;
        }
    }
}

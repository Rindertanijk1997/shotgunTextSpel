using System;

namespace ShotgunGame
{
    // Den här klassen innehåller spel-logiken 
    public class GameLogik
    {
        private readonly Player människa;
        private readonly Player dator;

        // skapa spelet med en människa och en bot
        public GameLogik(string spelarNamn)
        {
            människa = new HumanPlayer(spelarNamn);
            dator = new BotPlayer(); 
        }

        // Kör en match tills någon vinner
        public void StartaMatch()
        {
            Console.Clear();
            Console.WriteLine("Välkomen till SHOTGUN");
            Console.WriteLine("Regler: Ladda = +1 skott, Blocka = inget händer, Skjuta = -1 skott, Shotgun kräver ≥3 skott och vinner direkt.");
            Console.WriteLine();

            bool matchPågår = true;

            while (matchPågår)
            {
                VisaStatus(); // visa antal skott före varje runda

                // jag väljer drag
                Move mittDrag = människa.VäljDrag();

                // dator väljer drag 
                Move datornsDrag = dator.VäljDrag();

                // räkna resultat av rundan
                RoundResult resultat = RäknaUtRunda(mittDrag, datornsDrag);

                // Kolla om någon vann
                if (resultat == RoundResult.MänniskaVinner)
                {
                    Console.WriteLine("Du vann matchen!");
                    matchPågår = false;
                }
                else if (resultat == RoundResult.DatorVinner)
                {
                    Console.WriteLine("Datorn vann matchen!");
                    matchPågår = false;
                }
                else
                {
                    // Ingen vann, fortsätt
                }
            }
        }

        // Visa antal skott
        private void VisaStatus()
        {
            Console.WriteLine($"Antal skott - {människa.Namn}: {människa.Skott} Och {dator.Namn}: {dator.Skott}");
            Console.WriteLine("");
        }

        // Resultat för en runda
        private enum RoundResult
        {
            Fortsätt,
            MänniskaVinner,
            DatorVinner
        }

        // alla regler för vad som händer beroende på drag
        private RoundResult RäknaUtRunda(Move human, Move bot)
        {
            //  Shotgun-fall
            if (human == Move.Shotgun && bot == Move.Shotgun)
            {
                // båda tappar 1 skott, ingen vinner
                människa.FörbrukaSkott();
                dator.FörbrukaSkott();
                Console.WriteLine("Shotgun vs Shotgun → båda förlorar 1 skott. Ingen vinner denna runda.");
                return RoundResult.Fortsätt;
            }
            if (human == Move.Shotgun)
            {
                Console.WriteLine("Du använder SHOTGUN → du vinner direkt!");
                return RoundResult.MänniskaVinner;
            }
            if (bot == Move.Shotgun)
            {
                Console.WriteLine("Datorn använder SHOTGUN → datorn vinner direkt!");
                return RoundResult.DatorVinner;
            }

            // vanliga komb
            if (human == Move.Ladda && bot == Move.Ladda)
            {
                människa.Ladda();
                dator.Ladda();
                Console.WriteLine("Ladda vs Ladda → båda får +1 skott.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Ladda && bot == Move.Blocka)
            {
                människa.Ladda();
                Console.WriteLine("Ladda vs Blocka → du får +1 skott.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Blocka && bot == Move.Ladda)
            {
                dator.Ladda();
                Console.WriteLine("Blocka vs Ladda → datorn får +1 skott.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Blocka && bot == Move.Blocka)
            {
                Console.WriteLine("Blocka vs Blocka → ingenting händer.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Skjuta && bot == Move.Blocka)
            {
                människa.FörbrukaSkott();
                Console.WriteLine("Skjuta vs Blocka → du förlorar 1 skott.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Blocka && bot == Move.Skjuta)
            {
                dator.FörbrukaSkott();
                Console.WriteLine("Blocka vs Skjuta → datorn förlorar 1 skott.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Skjuta && bot == Move.Skjuta)
            {
                människa.FörbrukaSkott();
                dator.FörbrukaSkott();
                Console.WriteLine("Skjuta vs Skjuta → båda förlorar 1 skott.");
                return RoundResult.Fortsätt;
            }

            if (human == Move.Skjuta && bot == Move.Ladda)
            {
                Console.WriteLine("Skjuta vs Ladda → du skjuter en laddande motståndare → du vinner!");
                return RoundResult.MänniskaVinner;
            }

            if (human == Move.Ladda && bot == Move.Skjuta)
            {
                Console.WriteLine("Ladda vs Skjuta → datorn skjuter dig när du laddar → datorn vinner!");
                return RoundResult.DatorVinner;
            }

        }
    }
}

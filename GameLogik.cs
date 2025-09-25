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
                // visa antal skott före varje runda
                VisaStatus();
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
                    // ingen vann, fortsätt
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

        // här använder jag en tuple (human, bot) för att ställa bådas drag mot varandra
        // och direkt bestämma resultatet av rundan
        private RoundResult RäknaUtRunda(Move human, Move bot)
        {
            var result = RoundResult.Fortsätt;

            switch ((human, bot))
            {
                // SHOTGUN-fall först
                case (Move.Shotgun, Move.Shotgun):
                    människa.FörbrukaSkott();
                    dator.FörbrukaSkott();
                    Console.WriteLine("Shotgun vs Shotgun = båda förlorar 1 skott. Ingen vinner denna runda.");
                    result = RoundResult.Fortsätt;
                    break;

                case (Move.Shotgun, _):
                    Console.WriteLine("Du använder SHOTGUN = du vinner direkt!");
                    result = RoundResult.MänniskaVinner;
                    break;

                case (_, Move.Shotgun):
                    Console.WriteLine("Datorn använder SHOTGUN = datorn vinner direkt!");
                    result = RoundResult.DatorVinner;
                    break;

                // Vanliga kombinationer
                case (Move.Ladda, Move.Ladda):
                    människa.Ladda();
                    dator.Ladda();
                    Console.WriteLine("Ladda vs Ladda = båda får +1 skott.");
                    break;

                case (Move.Ladda, Move.Blocka):
                    människa.Ladda();
                    Console.WriteLine("Ladda vs Blocka = du får +1 skott.");
                    break;

                case (Move.Blocka, Move.Ladda):
                    dator.Ladda();
                    Console.WriteLine("Blocka vs Ladda = datorn får +1 skott.");
                    break;

                case (Move.Blocka, Move.Blocka):
                    Console.WriteLine("Blocka vs Blocka = ingenting händer.");
                    break;

                case (Move.Skjuta, Move.Blocka):
                    människa.FörbrukaSkott();
                    Console.WriteLine("Skjuta vs Blocka = du förlorar 1 skott.");
                    break;

                case (Move.Blocka, Move.Skjuta):
                    dator.FörbrukaSkott();
                    Console.WriteLine("Blocka vs Skjuta = datorn förlorar 1 skott.");
                    break;

                case (Move.Skjuta, Move.Skjuta):
                    människa.FörbrukaSkott();
                    dator.FörbrukaSkott();
                    Console.WriteLine("Skjuta vs Skjuta = båda förlorar 1 skott.");
                    break;

                case (Move.Skjuta, Move.Ladda):
                    Console.WriteLine("Skjuta vs Ladda = du skjuter en laddande motståndare = du vinner!");
                    result = RoundResult.MänniskaVinner;
                    break;

                case (Move.Ladda, Move.Skjuta):
                    Console.WriteLine("Ladda vs Skjuta = datorn skjuter dig när du laddar = datorn vinner!");
                    result = RoundResult.DatorVinner;
                    break;

                // tror den ska vara omöjlig att få, men man vet aldrig
                default:
                    Console.WriteLine("Oväntad kombination = ingen förändring.");
                    break;
            }

            return result;
        }

    }
}

namespace ShotgunGame
{
    // Player är en huvudklass för båse mig och bot
    public abstract class Player
    {
        // Spelarens namn  
        public string Namn { get; }

        // Antal skott startar på 0.
        public int Skott { get; protected set; } = 0;

        // Hjälp för att läsa av regler enkelt
        public bool KanSkjuta
        {
            get { return Skott > 0; }
        }

        public bool KanShotgun
        {
            get { return Skott >= 3; }
        }

        // sätter namnet
        protected Player(string namn)
        {
            Namn = namn;
        }

        public void Ladda()
        {
            Skott = Skott + 1;
        }

        // skjuta = minus 1 skott tills man når 0
        public void FörbrukaSkott()
        {
            Skott = Skott - 1;
            if (Skott < 0)
            {
                Skott = 0;
            }
        }

        // Varje spelare måste kunna välja ett drag.
        public abstract Move VäljDrag();
    }
}

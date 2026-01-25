namespace Integrated_Pokedex
{
    internal class PokedexKlasse
    {

        //Die Klasse ist dafür da, damit wir den Index immer übergeben können
        public int pkdxIndex { get; set; }

        private PokedexKlasse()
        {
            pkdxIndex = 1;
        }

        private static PokedexKlasse wert = null;
        public static PokedexKlasse GetSingleton()
        {
            if (wert == null)
            {
                wert = new PokedexKlasse();
            }
            return wert;
        }

        public string classNameSQLBefehl { get; set; }
        public string classBildSQLBefehl { get; set; }

        public static PokedexKlasse ZeichenSingelton()
        {
            if (wert == null)
            {
                wert = new PokedexKlasse();
            }
            return wert;
        }
    }
}

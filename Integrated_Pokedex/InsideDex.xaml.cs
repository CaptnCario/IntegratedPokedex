using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data.SQLite;

namespace Integrated_Pokedex
{
    /// <summary>
    /// Interaktionslogik für InsideDex.xaml
    /// </summary>
    public partial class InsideDex : Window
    {
        Dictionary<int, string> pokemonListe = new Dictionary<int, string>();
        Dictionary<int, string> pkBilderListe = new Dictionary<int, string>();
        Dictionary<int, string> searchListe = new Dictionary<int, string>();
        Dictionary<int, string> searchBilder = new Dictionary<int, string>();
        Dictionary<int, int> NumberDex = new Dictionary<int, int>();
        int[] otherEntrys = new int[7];

        char pokedex_ID = MainWindow.pokedexID;
        string eingabe;
        public int index;
        string ausgabe = "";
        bool durchgang = true;
        bool searchMode;
        int begrenzer;
        string pokedexWahl;
        public static int mindIndex;
        public static int maxiIndex;

        public InsideDex()
        {
            InitializeComponent();
            searchMode = false;
            index = PokedexKlasse.GetSingleton().pkdxIndex;

            switch (pokedex_ID)
            {
                case ('N'):

                    txtDexÜberschrift.Text = "National - DEX";

                    eingabe = "Select PokedexID,DName from PokemonData;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from PokemonData;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int ina = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(ina, k.Key);
                        ina++;
                    }
                    index = NumberDex[1];

                    pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));

                    //Start der Methode zur Berechnung des Pokemon Liste
                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    txtLineIndex.Text = index + " " + pokemonListe[index].ToString();

                    //Ende der Methode zur Berechnung der Pokemon Liste

                    //Übergabe des Indexes in die Klasse
                    PokedexKlasse.GetSingleton().pkdxIndex = index;

                    //MIt dem Index kannst du auch im Dictionary sowolh den Namen als auch die Id ausgeben.Nimm den Index einfach als ID
                    //Index nutzten wir einfach für alles es ist der gelbe Block und sobald person auf knopf drückt, dannerhöt sich er oder minus

                    break;

                case ('K'):

                    pokedexWahl = "dbKantoDex";
                    //TestDex
                    txtDexÜberschrift.Text = "KANTO - DEX";

                    eingabe = "Select PokedexID,DName from dbKantoDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbKantoDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iKA = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iKA, k.Key);
                        iKA++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('H'):
                    //Hoenn Dex

                    txtDexÜberschrift.Text = "HOENN - DEX";

                    eingabe = "Select PokedexID,DName from dbHoennDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbHoennDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int ih = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(ih, k.Key);
                        ih++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;

                    break;

                case ('S'):
                    txtDexÜberschrift.Text = "SINNOH - DEX";

                    eingabe = "Select PokedexID,DName from dbSinnohDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbSinnohDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iSI = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iSI, k.Key);
                        iSI++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('E'):
                    txtDexÜberschrift.Text = "EINALL - DEX";

                    eingabe = "Select PokedexID,DName from dbEinallDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbEinallDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iEI = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iEI, k.Key);
                        iEI++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('L'):
                    txtDexÜberschrift.Text = "KALOS - DEX";

                    eingabe = "Select PokedexID,DName from dbKalosDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbKalosDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iKAn = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iKAn, k.Key);
                        iKAn++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('A'):
                    txtDexÜberschrift.Text = "ALOLA - DEX";

                    eingabe = "Select PokedexID,DName from dbAlolaDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbAlolaDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iAL = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iAL, k.Key);
                        iAL++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('G'):
                    txtDexÜberschrift.Text = "GALAR - DEX";

                    eingabe = "Select PokedexID,DName from dbGalarDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbGalarDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iGA = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iGA, k.Key);
                        iGA++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('P'):
                    txtDexÜberschrift.Text = "PALDEA - DEX";

                    eingabe = "Select PokedexID,DName from dbPaldeaDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbPaldeaDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iPA = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iPA, k.Key);
                        iPA++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                case ('J'):
                    txtDexÜberschrift.Text = "JOHTO - DEX";

                    eingabe = "Select PokedexID,DName from dbJothoDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    eingabe = "Select PokedexID,Link from dbJothoDex;";
                    pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                    int iJO = 1;
                    foreach (var k in pokemonListe)
                    {
                        NumberDex.Add(iJO, k.Key);
                        iJO++;
                    }
                    index = NumberDex[1];

                    if (searchMode == false)
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                    }
                    else
                    {
                        pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                    }

                    beAfMainPK(index, ref otherEntrys);

                    errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                    errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                    if (searchMode == false)
                    {
                        txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                    }
                    else
                    {
                        txtLineIndex.Text = index + " " + searchListe[index].ToString();
                    }

                    PokedexKlasse.GetSingleton().pkdxIndex = index;
                    break;

                default:
                    break;
            }
            mindIndex = NumberDex.Values.First();
            maxiIndex = NumberDex.Values.Last();

        }

        private void gOben_Click(object sender, RoutedEventArgs e)
        {
            index = NumberDex.Values.First();

            //Übergabe des Indexes in die Klasse
            PokedexKlasse.GetSingleton().pkdxIndex = index;

            //Start der Methode zur Berechnung des Pokemon Liste

            beAfMainPK(index, ref otherEntrys);

            //Zur Verhinderung das es über 1 geht
            //Dictionary ist problem

            errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);

            //Zur Verhinderung das es über 1 geht
            errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

            if (searchMode == false)
            {
                txtLineIndex.Text = index + " " + pokemonListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
            }
            else
            {
                txtLineIndex.Text = index + " " + searchListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
            }

        }

        private void kOben_Click(object sender, RoutedEventArgs e)
        {

            if (index > NumberDex.Values.First())
            {
                index--;
            }

            PokedexKlasse.GetSingleton().pkdxIndex = index;
            //Start der Methode zur Berechnung des Pokemon Liste

            beAfMainPK(index, ref otherEntrys);

            //Zur Verhinderung das es über 151 geht

            errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
            errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

            if (searchMode == false)
            {
                txtLineIndex.Text = index + " " + pokemonListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
            }
            else
            {
                txtLineIndex.Text = index + " " + searchListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
            }

            //Ende der Methode zur Berechnung der Pokemon Liste
        }

        private void kUnten_Click(object sender, RoutedEventArgs e)
        {
            if (searchMode == false)
            {
                if (index < NumberDex.Values.Last())
                {
                    index++;
                }
            }
            else
            {
                if (index < NumberDex.Values.Last())
                {
                    index++;
                }
            }



            PokedexKlasse.GetSingleton().pkdxIndex = index;
            //Start der Methode zur Berechnung des Pokemon Liste

            beAfMainPK(index, ref otherEntrys);

            //Zur Verhinderung das es über 151 geht

            errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
            errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

            if (searchMode == false)
            {
                txtLineIndex.Text = index + " " + pokemonListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
            }
            else
            {
                txtLineIndex.Text = index + " " + searchListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
            }

            //Ende der Methode zur Berechnung der Pokemon Liste
        }

        private void gUnten_Click(object sender, RoutedEventArgs e)
        {
            if (searchMode == false)
            {
                index = NumberDex.Values.Last();
            }
            else
            {
                index = NumberDex.Values.Last();
            }


            //Übergabe des Indexes in die Klasse
            PokedexKlasse.GetSingleton().pkdxIndex = index;

            //Start der Methode zur Berechnung des Pokemon Liste

            beAfMainPK(index, ref otherEntrys);

            //Zur Verhinderung das es über 1 geht
            //Dictionary ist problem

            errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);

            //Zur Verhinderung das es über 1 geht
            errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

            if (searchMode == false)
            {
                txtLineIndex.Text = index + " " + pokemonListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
            }
            else
            {
                txtLineIndex.Text = index + " " + searchListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
            }

        }

        private void dexSuche_Click(object sender, RoutedEventArgs e)
        {
            Suche sFenster = new Suche();
            sFenster.AltesFenster = this;
            sFenster.ShowDialog();


            //index = 1;

            eingabe = PokedexKlasse.ZeichenSingelton().classNameSQLBefehl;

            if (eingabe != "") 
            {
                searchMode = true;
                dexAnsehen.Visibility = Visibility.Hidden;
            }
            else
            {
                searchMode = false;
                dexAnsehen.Visibility = Visibility.Visible;
            }

            if(searchMode == true)
            {
                NumberDex.Clear();
                pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                eingabe = PokedexKlasse.ZeichenSingelton().classBildSQLBefehl;
                pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                int iKA = 1;
                foreach (var k in searchListe)
                {
                    NumberDex.Add(iKA, k.Key);
                    iKA++;
                }
                index = NumberDex[1];


                pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));

                //Start der Methode zur Bereachnung des Pokemon Liste
                beAfMainPK(index, ref otherEntrys);

                errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);
            }
            else
            {
                NumberDex.Clear();
                eingabe = "Select PokedexID,DName from " + pokedexWahl + ";";
                pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                eingabe = "Select PokedexID,Link from " + pokedexWahl + ";";
                pkDatabase(eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);

                int iKA = 1;
                foreach (var k in pokemonListe)
                {
                    NumberDex.Add(iKA, k.Key);
                    iKA++;
                }
                index = NumberDex[1];

                if (searchMode == false)
                {
                    pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
                }
                else
                {
                    pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
                }

                beAfMainPK(index, ref otherEntrys);

                errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);
                errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

                if (searchMode == false)
                {
                    txtLineIndex.Text = index + " " + pokemonListe[index].ToString();
                }
                else
                {
                    txtLineIndex.Text = index + " " + searchListe[index].ToString();
                }

                PokedexKlasse.GetSingleton().pkdxIndex = index;
            }
        }

        public void Update()
        {
            PokedexKlasse.GetSingleton().pkdxIndex = index;
            //Start der Methode zur Berechnung des Pokemon Liste

            beAfMainPK(index, ref otherEntrys);

            //Zur Verhinderung das es über 151 geht

            errorLimiterP(index, ref otherEntrys, txtLineP1, txtLineP2, txtLineP3, pokemonListe, pokedex_ID, ref searchListe, searchMode, ref begrenzer, ref NumberDex);

            //Zur Verhinderung das es über 1 geht
            errorLimiterM(index, ref otherEntrys, txtLineM1, txtLineM2, txtLineM3, pokemonListe, ref searchListe, searchMode, ref NumberDex);

            if (searchMode == false)
            {
                txtLineIndex.Text = index + " " + pokemonListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(pkBilderListe[index]));
            }
            else
            {
                txtLineIndex.Text = index + " " + searchListe[index].ToString();

                pkmnBild.Source = new BitmapImage(new Uri(searchBilder[index]));
            }
            


            //Ende der Methode zur Berechnung der Pokemon Liste
        }

        private void dexAnsehen_Click(object sender, RoutedEventArgs e)
        {


            SelectedPokemon0 sPFenster = new SelectedPokemon0();
            sPFenster.vorWindow = this;
            sPFenster.ShowDialog();

        }

        static void pkDatabase(string eingabe,ref string ausgabe, ref Dictionary<int,string> pokemonListe, ref Dictionary<int,string> pkBilderListe, ref Dictionary<int, string> searchListe, bool searchMode, ref Dictionary<int, string> searchBilder, ref int begrenzer)
        {
            string databasePath = @"..\..\Database\Baum.db";
            
            //create connection string
            string connectionString = "Data Source="+databasePath+";Version=3;";
            
            do
            {
                //Connect to SQL Server
                using (SQLiteConnection sqLiteConnection = new SQLiteConnection(connectionString))
                {
                    //Open SQL connection
                    sqLiteConnection.Open();

                    //Init SQL Command
                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand(eingabe,sqLiteConnection))
                    {
                        //Execute Query
                        using (var reader = sqLiteCommand.ExecuteReader())
                        {
                            //Read Data
                            writeSQLOutput(reader, ref eingabe, ref ausgabe, ref pokemonListe, ref pkBilderListe, ref searchListe, searchMode, ref searchBilder, ref begrenzer);
                        }
                    }
                }
            } while (false); //Muss später noch geändert werden!
        }

        static void writeSQLOutput(SQLiteDataReader reader,ref string eingabe, ref string ausgabe,ref Dictionary<int,string> pokemonListe, ref Dictionary<int,string> pkBilderListe, ref Dictionary<int, string> searchListe, bool searchmode, ref Dictionary<int, string> searchBilder,ref int begrenzer)
        {
            bool test;
            int value;
            int sValue = 0;
            int searchValue = 1;
            int nameValue = 1;
            begrenzer = 1;
            //Get table column names

            if (reader.RecordsAffected <= 0)
            {
                foreach (DataRow row in reader.GetSchemaTable().Rows)
                {
                    Console.Write(row["ColumnName"] + "\t");
                }
            }
            Console.WriteLine(reader.RecordsAffected + " Zeile/n verändert!");

            Console.WriteLine();

            //Read data
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ausgabe = reader.GetValue(i).ToString();

                    begrenzer++;

                    test = int.TryParse(ausgabe, out value);
                    if (test == true) 
                    {
                        sValue = value;
                    }

                    if (eingabe.Contains("DName"))
                    { 
                        if (test == false)
                        {
                            if (searchmode == false)
                            {
                                pokemonListe.Add(sValue, ausgabe);
                            }
                            else
                            {
                                searchListe.Add(nameValue,ausgabe);
                                nameValue++;
                            }

                        }

                    } else if (eingabe.Contains("Link"))
                    {
                        if (test == false)
                        {
                            if (searchmode == false)
                            {
                                pkBilderListe.Add(sValue, ausgabe);
                            }
                            else
                            {
                                searchBilder.Add(searchValue, ausgabe);
                                searchValue++;
                            }

                        }
                    }
                }
                Console.WriteLine();
            }
        }
        //Methode zur Aufrufung von + und - der Buttons 
        static void beAfMainPK(int index, ref int[] otherEntrys)
        {
            int temp;

            for(int i = 1; i <= 3; i++)
            {
                temp = 0;
                temp = index + i;
                otherEntrys[i+3] = temp;

            }

            for(int i=1; i <= 3; i++)
            {
                temp = 0;
                temp = index - i;
                otherEntrys[i] = temp;
            }

        }

        static void errorLimiterM(int index, ref int[] otherEntrys,TextBlock txtLineM1,TextBlock txtLineM2,TextBlock txtLineM3,Dictionary<int,string> pokemonListe, ref Dictionary<int, string> searchListe, bool searchMode,ref Dictionary<int,int> NumberDex)
        {
            if (searchMode == false)
            {
                //TextLineM1
                if (index <= NumberDex.Values.First() + 2) 
                {
                    txtLineM3.Text = "------------------------";
                }
                else
                {
                    txtLineM3.Text = otherEntrys[3] + " " + pokemonListe[otherEntrys[3]];
                }
                //TextLineM2
                if (index <= NumberDex.Values.First() + 1) 
                {
                    txtLineM2.Text = "------------------------";
                }
                else
                {
                    txtLineM2.Text = otherEntrys[2] + " " + pokemonListe[otherEntrys[2]];
                }
                //TextLineM3
                if (index == NumberDex.Values.First())
                {
                    txtLineM1.Text = "------------------------";
                }
                else
                {
                    txtLineM1.Text = otherEntrys[1] + " " + pokemonListe[otherEntrys[1]];
                }
            }
            else
            {
                //TextLineM1
                if (index <= NumberDex.Values.First() + 2) 
                {
                    txtLineM3.Text = "------------------------";
                }
                else
                {
                    txtLineM3.Text = otherEntrys[3] + " " + searchListe[otherEntrys[3]];
                }
                //TextLineM2
                if (index <= NumberDex.Values.First() + 1) 
                {
                    txtLineM2.Text = "------------------------";
                }
                else
                {
                    txtLineM2.Text = otherEntrys[2] + " " + searchListe[otherEntrys[2]];
                }
                //TextLineM3
                if (index == NumberDex.Values.First())
                {
                    txtLineM1.Text = "------------------------";
                }
                else
                {
                    txtLineM1.Text = otherEntrys[1] + " " + searchListe[otherEntrys[1]];
                }
            }

        }

        static void errorLimiterP(int index, ref int[] otherEntrys, TextBlock txtLineP1, TextBlock txtLineP2, TextBlock txtLineP3, Dictionary<int, string> pokemonListe, char pokedex_ID, ref Dictionary<int, string> searchListe, bool searchMode,ref int begrenzer, ref Dictionary<int,int> NumberDex)
        {
            if (searchMode == false)
            {
                //TextLineP1
                if (index >= NumberDex.Values.Last() - 2)
                {
                    txtLineP3.Text = "------------------------";
                }
                else
                {
                    txtLineP3.Text = otherEntrys[6] + " " + pokemonListe[otherEntrys[6]];
                }
                //TextLineP2
                if (index >= NumberDex.Values.Last() - 1)
                {
                    txtLineP2.Text = "------------------------";
                }
                else
                {
                    txtLineP2.Text = otherEntrys[5] + " " + pokemonListe[otherEntrys[5]];
                }
                //TextLineP3

                if (index == NumberDex.Values.Last())
                {
                    txtLineP1.Text = "------------------------";
                }
                else
                {
                    txtLineP1.Text = otherEntrys[4] + " " + pokemonListe[otherEntrys[4]];

                }
  
            }
            else
            {
                //TextLineP1
                if (index >= NumberDex.Values.Last() - 2)
                {
                    txtLineP3.Text = "------------------------";
                }
                else
                {
                    txtLineP3.Text = otherEntrys[6] + " " + searchListe[otherEntrys[6]];
                }
                //TextLineP2 
                if (index >= NumberDex.Values.Last()- 1)
                {
                    txtLineP2.Text = "------------------------";
                }
                else
                {
                    txtLineP2.Text = otherEntrys[5] + " " + searchListe[otherEntrys[5]];
                }
                //TextLineP3

                if (index == NumberDex.Values.Last())
                {
                    txtLineP1.Text = "------------------------";
                }
                else
                {
                    txtLineP1.Text = otherEntrys[4] + " " + searchListe[otherEntrys[4]];

                }
            }

        }

    }
}
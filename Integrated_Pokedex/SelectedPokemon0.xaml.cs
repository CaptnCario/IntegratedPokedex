using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Media;
using System.Data.SQLite;

namespace Integrated_Pokedex
{
    /// <summary>
    /// Interaktionslogik für SelectedPokemon0.xaml
    /// </summary>
    public partial class SelectedPokemon0 : Window
    {
        public int mIndex;
        string eingabe;
        string ausgabe;
        List<string> Daten = new List<string>();
        string[] silhouetteArry = new string[15];
        int silTemp;
        bool silExists;
        double tempGroesse;
        bool groesseTF;
        string PokdexWahl;
        int maxIndex = InsideDex.maxiIndex;
        int minIndex = InsideDex.mindIndex;
        public InsideDex vorWindow;
        AudioDex AudioFile = new AudioDex();
        public SelectedPokemon0()
        {
            InitializeComponent();
            //
            switch (MainWindow.pokedexID)
            {
                case ('N'):
                    PokdexWahl = "PokemonData";
                    break;

                case ('K'):
                    PokdexWahl = "dbKantoDex";
                    break;

                case ('H'):
                    PokdexWahl = "dbHoennDex";
                    break;

                case ('S'):
                    PokdexWahl = "dbSinnohDex";
                    break;

                case ('E'):
                    PokdexWahl = "dbEinallDex";
                    break;

                case ('L'):
                    PokdexWahl = "dbKalosDex";
                    break;

                case ('A'):
                    PokdexWahl = "dbAlolaDex";
                    break;

                case ('G'):
                    PokdexWahl = "dbGalarDex";
                    break;

                case ('P'):
                    PokdexWahl = "dbPaldeaDex";
                    break;

                case ('J'):
                    PokdexWahl = "dbJothoDex";
                    break;

                default:
                    break;


            }

            //
            mIndex = PokedexKlasse.GetSingleton().pkdxIndex;
            eingabe = "Select PokedexID, DName, EName, EvolutionID, Typ1, Typ2, Bezeichnung, Groesse, Gewicht, SilhouettenID, Link from " + PokdexWahl + " where PokedexID = " + mIndex + ";";

            pkDatabase(eingabe,ref ausgabe);

            stringList(ref ausgabe, ref Daten,eingabe);

            silhouettenVergleich(silhouetteArry);

            //Eintrag
            txtPkmnID.Text = Daten[0];
            txtDePokemonName.Text = Daten[1];
            txtEnPokemonName.Text = Daten[2];
            txtPkBezeichnung.Text = Daten[6];
            txtPkGroesse.Text = "GRÖßE:      " + Daten[7] + "m";
            txtPkGewicht.Text = "GEWICHT:    " + Daten[8] + "kg";

            //Gewicht
            txtPokemonWeight.Text = Daten[8] + "kg";
            pkWeightMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            txtWightPokemonName.Text = Daten[1];

            //Größe
            pkSizeMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            groesseTF = double.TryParse(Daten[7], out tempGroesse);
            if(tempGroesse<= 1.7)
            {
                pkSizeMainPic.Width = tempGroesse * (165 / 1.7);
            }
            else
            {
                pkSizeMainPic.Width = tempGroesse * (165 / 1.7);
                TonySize.Height = 100 * (1.7 / tempGroesse);
            }

            txtSizePokemonName.Text = Daten[1];

            //Sound
            pkSoundMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            txtSoundPokemonName.Text = Daten[1];
            txtSizePokemon.Text = Daten[1] + ": " + Daten[7] + "m";

            Typ1.Source = new BitmapImage(new Uri(@"..\..\Images\Typen Bilder\" + Daten[4] + ".png",UriKind.Relative));

            if (Daten[5] != "") 
            {
                Typ2.Source = new BitmapImage(new Uri(@"..\..\Images\Typen Bilder\" + Daten[5] + ".png",UriKind.Relative));
            }
            else
            {
                Typ2.Source = null;
            }            

            //CodeSnippet für Silhouette
            silExists = int.TryParse(Daten[9], out silTemp);
            if (silExists == true)
            {
                pkSilhouette.Source = new BitmapImage(new Uri(silhouetteArry[silTemp],UriKind.Relative));
                silExists = false;
            }

            pkMainPic.Source = new BitmapImage(new Uri(Daten[10]));

            ausgabe = "";

            eingabe = "Select Eintrag from " + PokdexWahl + " where PokedexID = " + mIndex + ";";

            pkDatabase(eingabe, ref ausgabe);

            stringList(ref ausgabe, ref Daten,eingabe);

            txtPkEintrag.Text = Daten[12];

        }

        private void einOben_Click(object sender, RoutedEventArgs e)
        {
            if (mIndex > minIndex)
            {
                mIndex--;
            }

            PokedexKlasse.GetSingleton().pkdxIndex = mIndex;

            Daten.Clear();
            ausgabe = "";

            //Start der Information
            eingabe = "Select PokedexID, DName, EName, EvolutionID, Typ1, Typ2, Bezeichnung, Groesse, Gewicht, SilhouettenID, Link from " + PokdexWahl + " where PokedexID = " + mIndex + ";";
            
            pkDatabase(eingabe, ref ausgabe);
            
            stringList(ref ausgabe, ref Daten,eingabe);

            silhouettenVergleich(silhouetteArry);

            //Eintrag
            txtPkmnID.Text = Daten[0];
            txtDePokemonName.Text = Daten[1];
            txtEnPokemonName.Text = Daten[2];
            txtPkBezeichnung.Text = Daten[6];
            txtPkGroesse.Text = "GRÖßE:      " + Daten[7] + "m";
            txtPkGewicht.Text = "GEWICHT:    " + Daten[8] + "kg";

            //Gewicht
            txtPokemonWeight.Text = Daten[8] + "kg";
            pkWeightMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            txtWightPokemonName.Text = Daten[1];

            //Größe
            pkSizeMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            groesseTF = double.TryParse(Daten[7], out tempGroesse);
            if (tempGroesse <= 1.7)
            {
                pkSizeMainPic.Width = tempGroesse * (165 / 1.7);
            }
            else
            {
                pkSizeMainPic.Width = tempGroesse * (165 / 1.7);
                TonySize.Height = 100 * (1.7 / tempGroesse);
            }
            txtSizePokemonName.Text = Daten[1];

            //Sound
            pkSoundMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            txtSoundPokemonName.Text = Daten[1];
            txtSizePokemon.Text = Daten[1] + ": " + Daten[7] + "m";

            Typ1.Source = new BitmapImage(new Uri(@"..\..\Images\Typen Bilder\" + Daten[4] + ".png",UriKind.Relative));

            if (Daten[5] != "")
            {
                Typ2.Source = new BitmapImage(new Uri(@"..\..\Images\Typen Bilder\" + Daten[5] + ".png",UriKind.Relative));
            }
            else
            {
                Typ2.Source = null;
            }

            //CodeSnippet für Silhouette
            silExists = int.TryParse(Daten[9], out silTemp);
            if (silExists == true)
            {
                pkSilhouette.Source = new BitmapImage(new Uri(silhouetteArry[silTemp],UriKind.Relative));
                silExists = false;
            }

            pkMainPic.Source = new BitmapImage(new Uri(Daten[10]));

            ausgabe = "";

            eingabe = "Select Eintrag from " + PokdexWahl + " where PokedexID = " + mIndex + ";";

            pkDatabase(eingabe, ref ausgabe);

            stringList(ref ausgabe, ref Daten, eingabe);

            txtPkEintrag.Text = Daten[12];
        }

        private void einUnten_Click(object sender, RoutedEventArgs e)
        {

            if (mIndex < maxIndex)
            {
                mIndex++;
            }

            PokedexKlasse.GetSingleton().pkdxIndex = mIndex;

            Daten.Clear();
            ausgabe = "";

            eingabe = "Select PokedexID, DName, EName, EvolutionID, Typ1, Typ2, Bezeichnung, Groesse, Gewicht, SilhouettenID, Link from " + PokdexWahl + " where PokedexID = " + mIndex + ";";

            pkDatabase(eingabe, ref ausgabe);

            stringList(ref ausgabe, ref Daten,eingabe);

            //Eintrag
            txtPkmnID.Text = Daten[0];
            txtDePokemonName.Text = Daten[1];
            txtEnPokemonName.Text = Daten[2];
            txtPkBezeichnung.Text = Daten[6];
            txtPkGroesse.Text = "GRÖßE:      " + Daten[7] + "m";
            txtPkGewicht.Text = "GEWICHT:    " + Daten[8] + "kg";

            //Gewicht
            txtPokemonWeight.Text = Daten[8] + "kg";
            pkWeightMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            txtWightPokemonName.Text = Daten[1];

            //Größe
            pkSizeMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            groesseTF = double.TryParse(Daten[7], out tempGroesse);
            if (tempGroesse <= 1.7)
            {
                pkSizeMainPic.Width = tempGroesse * (165 / 1.7);
            }
            else
            {
                pkSizeMainPic.Width = tempGroesse * (165 / 1.7);
                TonySize.Height = 100 * (1.7 / tempGroesse);
            }
            txtSizePokemonName.Text = Daten[1];

            //Sound
            pkSoundMainPic.Source = new BitmapImage(new Uri(Daten[10]));
            txtSoundPokemonName.Text = Daten[1];
            txtSizePokemon.Text = Daten[1] + ": " + Daten[7] + "m";

            Typ1.Source = new BitmapImage(new Uri(@"..\..\Images\Typen Bilder\" + Daten[4] + ".png",UriKind.Relative));

            if (Daten[5] != "")
            {
                Typ2.Source = new BitmapImage(new Uri(@"..\..\Images\Typen Bilder\" + Daten[5] + ".png", UriKind.Relative));
            }
            else
            {
                Typ2.Source = null;
            }

            //CodeSnippet für Silhouette
            silExists = int.TryParse(Daten[9], out silTemp);
            if (silExists == true)
            {
                pkSilhouette.Source = new BitmapImage(new Uri(silhouetteArry[silTemp],UriKind.Relative));
                silExists = false;
            }

            pkMainPic.Source = new BitmapImage(new Uri(Daten[10]));

            ausgabe = "";

            eingabe = "Select Eintrag from " + PokdexWahl + " where PokedexID = " + mIndex + ";";

            pkDatabase(eingabe, ref ausgabe);

            stringList(ref ausgabe, ref Daten, eingabe);

            txtPkEintrag.Text = Daten[12];
        }

        static void pkDatabase(string eingabe,ref string ausgabe)
        {
            //Define Database
            string databasePath = @"..\..\Database\Baum.db";

            //create connection string
            string connectionString = "Data Source=" + databasePath + ";Version=3;";

            //Connect to SQL Server
            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(connectionString))
            {
                //Open SQL connection
                sqLiteConnection.Open();

                //Init SQL Command
                using (SQLiteCommand sqLiteCommand = new SQLiteCommand(eingabe, sqLiteConnection))
                {
                    //Execute Query
                    using (var reader = sqLiteCommand.ExecuteReader())
                    {
                        //Read Data
                        writeSQLOutput(reader, ref ausgabe);
                    }
                }
            }
        }

        static void writeSQLOutput(SQLiteDataReader reader,ref string ausgabe)
        {
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
                    ausgabe += reader.GetValue(i).ToString() + " ";
                }

                Console.WriteLine();
            }
        }

        static void stringList(ref string ausgabe,ref List<string> Daten, string eingabe)
        {
            if (eingabe.Contains("Eintrag"))
            {
                Daten.Add(ausgabe);
            }
            else
            {
                string[] temp = ausgabe.Split(new char[] { ' ' });

                for (int i = 0; i < temp.Length; i++)
                {
                    Daten.Add(temp[i]);
                }

            }


        }

        static void silhouettenVergleich(string[] silhouetteArry)
        {

            for(int i=1; i <= 14; i++)
            {
                silhouetteArry[i] = @"..\..\Images\Silhouette\Silhouette_" + i + ".png";
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            PokedexKlasse.GetSingleton().pkdxIndex = mIndex;
            vorWindow.index = mIndex;
            vorWindow.Update();

        }

        private void changeMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Ist für das Wechseln des Hintergrundbildes da
            if (entEintrag.IsSelected)
            {
                imgBackground.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Background_Images\showEntry4.png",UriKind.Relative));
            }

            if (entGewicht.IsSelected)
            {
                imgBackground.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Background_Images\weightDex.png",UriKind.Relative));
            }

            if (entGroesse.IsSelected)
            {
                imgBackground.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Background_Images\GroesseDex.png",UriKind.Relative));
            }

            if (entRuf.IsSelected)
            {
                imgBackground.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Background_Images\SoundDex.png",UriKind.Relative));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PokedexKlasse.GetSingleton().pkdxIndex = mIndex; //Übergabe des Indexes in die Klasse der Singelton Methode
            vorWindow.index = mIndex;
            vorWindow.Update();
        }

        private void soundButton_Click(object sender, RoutedEventArgs e)
        {
            AudioFile.PlayPokemonSound(Daten[1],MainWindow.pokedexID);
        }
    }
}

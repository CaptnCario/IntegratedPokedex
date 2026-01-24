using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Integrated_Pokedex
{

    internal class AudioDex
    {
        MediaPlayer playSound = new MediaPlayer();

        private string _scrollPath;
        private string _pokemonSoundPath;
        private string _temp;

        public string ScrollPath
        {
            get { return _scrollPath; }
            set { _scrollPath = value; }
        }

        public string PokemonSoundPath
        {
            get { return _pokemonSoundPath; }
            set { _pokemonSoundPath = value; }
        }

        public string Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public AudioDex()
        {
            ScrollPath = @"..\..\DexAudio\scrollSound.mp3";
            PokemonSoundPath = @"..\..\PKSounds(MP3)\";
        }

        public void PlayScrollScround()
        {
            playSound.Open(new Uri(ScrollPath, UriKind.Relative));
            playSound.Play();
        }

        public void PlayPokemonSound(string DName, char regionID)
        {
            string region = PokedexRegion(regionID);
            string eingabe = "Select pd.PokedexID FROM PokemonData pd JOIN "+region+" dpd ON pd.DName = dpd.DName Where dpd.DName = '"+DName+"';";
            string ausgabe ="";
            
            pkDatabase(eingabe, ref ausgabe);
            ausgabe = string.Concat(ausgabe.Where(c => !Char.IsWhiteSpace(c)));
            Temp = PokemonSoundPath;

            PokemonSoundPath = PokemonSoundPath + ausgabe + ".mp3";
            playSound.Open(new Uri(PokemonSoundPath, UriKind.Relative));
            playSound.Play();

            PokemonSoundPath = Temp;
            Temp = "";
        }

        static void pkDatabase(string eingabe, ref string ausgabe)
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

        static void writeSQLOutput(SQLiteDataReader reader, ref string ausgabe)
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

        static string PokedexRegion(char regionID)
        {
            switch (regionID)
            {
                case ('N'):
                    return "PokemonData";

                case ('K'):
                    return "dbKantoDex";

                case ('H'):
                    return "dbHoennDex";

                case ('S'):
                    return "dbSinnohDex";

                case ('E'):
                    return "dbEinallDex";

                case ('L'):
                    return "dbKalosDex";

                case ('A'):
                    return "dbAlolaDex";

                case ('G'):
                    return "dbGalarDex";

                case ('P'):
                    return "dbPaldeaDex";

                case ('J'):
                    return "dbJothoDex";

                default:
                    return "";
            }
        }

            
    }
}

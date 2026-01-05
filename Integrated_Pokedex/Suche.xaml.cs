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
using System.Data.SQLite;

namespace Integrated_Pokedex
{
    /// <summary>
    /// Interaktionslogik für Suche.xaml
    /// </summary>
    public partial class Suche : Window
    {
        bool[] filter = new bool[3];
        char pokedex_ID = MainWindow.pokedexID;
        public static string sqlBefehlName;
        public static string sqlBefehlBild;
        string dexWahl;
        string nEingabe;
        string typEingabe;
        int silEingabe;
        string ausgabe;
        public InsideDex AltesFenster;
        public Suche()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (pokedex_ID)
            {
                case ('N'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "PokemonData";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }


                    break;

                case ('K'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbKantoDex";
                    BefehlChecker(filter,ref sqlBefehlName,ref sqlBefehlBild,dexWahl,nEingabe,typEingabe,silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)  
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('H'):
                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbHoennDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }
                    break;

                case ('S'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbSinnohDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('E'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbEinallDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('L'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbKalosDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('A'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbAlolaDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('G'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbGalarDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('P'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbPaldeaDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                case ('J'):

                    if (filter[0] == true)
                    {
                        nEingabe = txtName.Text;
                    }
                    dexWahl = "dbJothoDex";
                    BefehlChecker(filter, ref sqlBefehlName, ref sqlBefehlBild, dexWahl, nEingabe, typEingabe, silEingabe);

                    pkDatabase(sqlBefehlName, ref ausgabe);

                    if (filter[0] == false && filter[1] == false && filter[2] == false)
                    {
                        sucheError Fehler = new sucheError();
                        Fehler.ShowDialog();
                    }
                    else
                    {
                        PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = sqlBefehlName;
                        PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = sqlBefehlBild;
                        AltesFenster.Update();
                        this.Close();
                    }

                    break;

                default:
                    break;


            }
        

        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            checkName.IsChecked = false;
            checkSilhouette.IsChecked = false;
            checkTypen.IsChecked = false;

            filter[0] = false;
            filter[1] = false;
            filter[2] = false;

            PokedexKlasse.ZeichenSingelton().classNameSQLBefehl = "";
            PokedexKlasse.ZeichenSingelton().classBildSQLBefehl = "";
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "" && txtName.Text != " ")
            {
                checkName.IsChecked = true;
                filter[0] = true;
            }
        }

        private void TypChecker(object sender, RoutedEventArgs e)
        {
            if (boxNormal.IsChecked == true || boxPflanze.IsChecked == true || boxFeuer.IsChecked == true || boxElektro.IsChecked == true || boxKampf.IsChecked == true || boxFlug.IsChecked == true || boxGift.IsChecked == true || boxBoden.IsChecked == true || boxGestein.IsChecked == true || boxKäfer.IsChecked == true || boxEis.IsChecked == true || boxFee.IsChecked == true || boxPsycho.IsChecked == true || boxGeist.IsChecked == true || boxDrache.IsChecked == true || boxUnlicht.IsChecked == true || boxStahl.IsChecked == true || boxWasser.IsChecked == true)
            {
                checkTypen.IsChecked = true;
                filter[1] = true;

                if(boxNormal.IsChecked == true)
                {
                    typEingabe = "Normal";
                }
                if (boxWasser.IsChecked == true)
                {
                    typEingabe = "Wasser";
                }
                if (boxPflanze.IsChecked == true)
                {
                    typEingabe = "Pflanze";
                }
                if (boxFeuer.IsChecked == true)
                {
                    typEingabe = "Feuer";
                }
                if (boxElektro.IsChecked == true)
                {
                    typEingabe = "Elektro";
                }
                if (boxKampf.IsChecked == true)
                {
                    typEingabe = "Kampf";
                }
                if (boxFlug.IsChecked == true)
                {
                    typEingabe = "Flug";
                }
                if (boxGift.IsChecked == true)
                {
                    typEingabe = "Gift";
                }
                if (boxBoden.IsChecked == true)
                {
                    typEingabe = "Bode";
                }
                if (boxGestein.IsChecked == true)
                {
                    typEingabe = "Gestein";
                }
                if (boxKäfer.IsChecked == true)
                {
                    typEingabe = "Kaefer";
                }
                if (boxEis.IsChecked == true)
                {
                    typEingabe = "Eis";
                }
                if (boxFee.IsChecked == true)
                {
                    typEingabe = "Fee";
                }
                if (boxPsycho.IsChecked == true)
                {
                    typEingabe = "Psycho";
                }
                if (boxGeist.IsChecked == true)
                {
                    typEingabe = "Geist";
                }
                if (boxDrache.IsChecked == true)
                {
                    typEingabe = "Drache";
                }
                if (boxUnlicht.IsChecked == true)
                {
                    typEingabe = "Unlicht";
                }
                if (boxStahl.IsChecked == true)
                {
                    typEingabe = "Stahl";
                }
            }
        }

        private void SilChecker(object sender, RoutedEventArgs e)
        {
            if (sil1.IsChecked == true || sil2.IsChecked == true || sil3.IsChecked == true || sil4.IsChecked == true || sil5.IsChecked == true || sil6.IsChecked == true || sil7.IsChecked == true || sil8.IsChecked == true || sil9.IsChecked == true || sil10.IsChecked == true || sil11.IsChecked == true || sil12.IsChecked == true || sil13.IsChecked == true || sil14.IsChecked == true)
            {
                checkSilhouette.IsChecked = true;
                filter[2] = true;

                if (sil1.IsChecked == true)
                {
                    silEingabe = 1;
                }
                if (sil2.IsChecked == true)
                {
                    silEingabe = 2;
                }
                if (sil3.IsChecked == true)
                {
                    silEingabe = 3;
                }
                if (sil4.IsChecked == true)
                {
                    silEingabe = 4;
                }
                if (sil5.IsChecked == true)
                {
                    silEingabe = 5;
                }
                if (sil6.IsChecked == true)
                {
                    silEingabe = 6;
                }
                if (sil7.IsChecked == true)
                {
                    silEingabe = 7;
                }
                if (sil8.IsChecked == true)
                {
                    silEingabe = 8;
                }
                if (sil9.IsChecked == true)
                {
                    silEingabe = 9;
                }
                if (sil10.IsChecked == true)
                {
                    silEingabe = 10;
                }
                if (sil11.IsChecked == true)
                {
                    silEingabe = 11;
                }
                if (sil12.IsChecked == true)
                {
                    silEingabe = 12;
                }
                if (sil13.IsChecked == true)
                {
                    silEingabe = 13;
                }
                if (sil14.IsChecked == true)
                {
                    silEingabe = 14;
                }

            }
        }

        static void BefehlChecker(bool[] filter, ref string sqlBefehlName,ref string sqlBefehlBild,string dexWahl,string nEingabe, string typEingabe,int silEingabe)
        {
            if (filter[0] == true)
            {
                if (filter[1] == true)
                {
                    if (filter[2] == true)
                    {
                        sqlBefehlName = "Select DName from " + dexWahl + " where DName Like '%" + nEingabe + "%' and Typ1 like '" + typEingabe + "' and SilhouettenID = " + silEingabe + ";";
                        sqlBefehlBild = "Select Link from " + dexWahl + " where PkNamenSuche Like '%" + nEingabe + "%' and Typ1 like '" + typEingabe + "' and SilhouettenID = " + silEingabe + ";";
                    }
                    else
                    {
                        sqlBefehlName = "Select DName from " + dexWahl + " where DName Like '%" + nEingabe + "%' and Typ1 like '" + typEingabe + "';";
                        sqlBefehlBild = "Select Link from " + dexWahl + " where PkNamenSuche Like '%" + nEingabe + "%' and Typ1 like '" + typEingabe + "';";
                    }
                }
                else
                {
                    sqlBefehlName = "Select DName from " + dexWahl + " where DName Like '%" + nEingabe + "%';";
                    sqlBefehlBild = "Select Link from " + dexWahl + " where PkNamenSuche Like '%" + nEingabe + "%';";
                }
            }

            if (filter[1] == true)
            {
                if (filter[2] == true)
                {
                    sqlBefehlName = "Select DName from " + dexWahl + " where Typ1 like '" + typEingabe + "' and SilhouettenID = " + silEingabe + ";";
                    sqlBefehlBild = "Select Link from " + dexWahl + " where Typ1 like '" + typEingabe + "' and SilhouettenID = " + silEingabe + ";";
                }
                else
                {
                    sqlBefehlName = "Select DName from " + dexWahl + " where Typ1 like '" + typEingabe + "';";
                    sqlBefehlBild = "Select Link from " + dexWahl + " where Typ1 like '" + typEingabe + "';";
                }
            }

            if (filter[0] == true)
            {
                if (filter[2] == true)
                {
                    sqlBefehlName = "Select DName from " + dexWahl + " where DName Like '%" + nEingabe + "%' and SilhouettenID = " + silEingabe + ";";
                    sqlBefehlBild = "Select Link from " + dexWahl + " where PkNamenSuche Like '%" + nEingabe + "%' and SilhouettenID = " + silEingabe + ";";
                }
                else
                {
                    sqlBefehlName = "Select DName from " + dexWahl + " where DName Like '%" + nEingabe + "%';";
                    sqlBefehlBild = "Select Link from " + dexWahl + " where PkNamenSuche Like '%" + nEingabe + "%';";
                }
            }

            if (filter[2] == true)
            {
                sqlBefehlName = "Select DName from " + dexWahl + " where SilhouettenID = " + silEingabe + ";";
                sqlBefehlBild = "Select Link from " + dexWahl + " where SilhouettenID = " + silEingabe + ";";
            }
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
                using (SQLiteCommand sqlCommand = new SQLiteCommand(eingabe, sqLiteConnection))
                {
                    //Execute Query
                    using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
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



    }

}

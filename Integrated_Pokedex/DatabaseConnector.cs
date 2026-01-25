using System;
using System.Data.SQLite;
using System.IO;

public static class SQLiteHelper
{
    private static string connectionString = "Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\Baum.db") + ";Version=3";

    public static void InitializeDatabase()
    {
        if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\Baum.db")))
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (var command = new SQLiteCommand(connection))
                {

                }
            }
        }
        else
        {
            Console.WriteLine("ERROR JOJO");
        }
    }

    internal class DatabaseConnector
    {

    }
}


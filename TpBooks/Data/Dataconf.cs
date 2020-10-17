using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace TpBooks.Data
{
    public class Dataconf
    {
        public static SQLiteConnection CreateConnection()
        {
            // Create a new database connection:
            List<String> entries = new List<string>();
            string cs = @"URI=file:C:\Users\Utilisateur\OneDrive\Documents\TpCsharp\TpBooks\blogging.db";

            using var db = new SQLiteConnection(cs);
            // Open the connection:
            try
            {
                db.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            return db;
        }

        public static string ReadData()
        {
            string myreader = null;

            List<String> entries = new List<string>();
            string cs = @"URI=file:C:\Users\Utilisateur\OneDrive\Documents\TpCsharp\TpBooks\blogging.db";

            using var db = new SQLiteConnection(cs);
            db.Open();

            var sqliteCmd = db.CreateCommand();
            sqliteCmd.CommandText = "SELECT id FROM Book WHERE id = \"02E93E5E-CD7E-4696-9E9E-6CC42264370D\" ";

            var rdID = sqliteCmd.ExecuteReader();
            while (rdID.Read())
            {
                myreader = rdID.GetString(0);
                Console.WriteLine(myreader);
            }
            db.Close();

            return myreader;
        }
    }
}
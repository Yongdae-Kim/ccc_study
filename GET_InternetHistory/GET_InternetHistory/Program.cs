using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace GET_InternetHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            String userName = Environment.UserName;

            SQLiteConnection conn = new SQLiteConnection
            ("Data Source=C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * From urls";

            SQLiteDataReader dr = cmd.ExecuteReader();

            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\History.txt");
            
            while (dr.Read())
                file.WriteLine(dr[1].ToString());
            
            file.Close();
        }
    }
}

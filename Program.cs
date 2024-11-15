using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBall
{
    internal class Program
    {
        public static Connect conn = new Connect();
        public static void GetAllData()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM `player`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) 
            { 

                var player = new 
                { 
                 Id = dr.GetInt32(0),
                 Name = dr.GetString(1),
                 Height = dr.GetInt32(2),
                 Weight = dr.GetInt32(3),
                 CreatedTime = dr.GetDateTime(4)
                };

                Console.WriteLine($"Játékos adatok: {player.Name},{player.Height}, {player.Weight}, {player.CreatedTime}");
            }
            dr.Close();
            conn.Connection.Close();

        } 
        static void Main(string[] args)
        {
            GetAllData();
        }
    }
}

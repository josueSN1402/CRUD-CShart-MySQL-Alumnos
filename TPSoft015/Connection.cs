using MySql.Data.MySqlClient;
using System;

namespace TPSoft015
{
    public class Connection
    {
        public MySqlConnection connection()
        {
            string ip = "localhost";
            string bd = "bdalumnos";
            string user = "root";
            string pass = "mysql2022";
            string sql = "Database=" + bd + "; Data Source=" + ip + "; User Id= " + user + "; Password=" + pass + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(sql);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}

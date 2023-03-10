using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class connections
    {
        public static MySqlConnection getConnection()
        {
            MySqlConnection koneksi = null;

            try
            {
                string server = "host=localhost; database = db_buku; user = root; password =Gibran2507_;";
                koneksi = new MySqlConnection(server);
            }
            catch (MySqlException sqlex)
            {
                throw new Exception(sqlex.Message.ToString());
            }
            return koneksi;
        }
    }
}
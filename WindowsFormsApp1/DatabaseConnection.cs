using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    internal class DatabaseConnection
    {
        private  MySqlConnection connection;
        
        public DatabaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Database=windowsformsapp_data;Uid=root;Pwd=20092003madMYSQL;";
            connection=new MySqlConnection(connectionString);
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }

    }
}

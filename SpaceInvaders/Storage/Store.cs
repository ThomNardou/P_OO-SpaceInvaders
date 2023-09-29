using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Model;

namespace Storage
{
    public class Store
    {
        public MySqlConnection Connection;

        public void Init()
        {
            string srv_addr = "localhost";
            string dbname = "volscore";
            string uid = "root";
            string pass = "root";
            string connectStr;
            connectStr = "SERVER=" + srv_addr + ";" + "DATABASE=" + dbname + ";" + "UID=" + uid + ";" + "PASSWORD=" + pass + ";";
            Connection = new MySqlConnection(connectStr);
        }

        public bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void ClosConnection()
        {
            Connection.Close();
        }
    }
}

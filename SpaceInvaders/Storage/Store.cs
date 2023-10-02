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
        private int compteur = 1;
        public int Compteur
        {
            get => compteur;
            set => compteur = value;
        }

        public void Init()
        {
            string srv_addr = "localhost";
            string dbname = "db_space_invaders";
            string uid = "root";
            string pass = "root";
            string port = "6033";
            string connectStr;
            connectStr = "SERVER=" + srv_addr + ";" + "DATABASE=" + dbname + ";" + "UID=" + uid + ";" + "PASSWORD=" + pass + ";" + "PORT=" + port + ";";
            Connection = new MySqlConnection(connectStr);
        }

        public bool OpenConnection()
        {
            try
            {
                Connection.Open();
                Debug.WriteLine("Connexion réussie !!!");
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

        public void WriteSelect()
        {
            string sqlQuerySelect = "SELECT joupseudo, jouNombrePoints FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
            MySqlCommand cmd = new MySqlCommand(sqlQuerySelect, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(compteur + "." + "\t" + Convert.ToString(reader["jouPseudo"]) + "\t" + Convert.ToString(reader["jouNombrePoints"]));
                compteur++;
            }
            
        }
    }
}

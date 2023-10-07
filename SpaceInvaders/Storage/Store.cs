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

        private List<String> records = new List<String>();
        public List<String> Record
        {
            get => records;
            set => records = value;
        }

        public bool OpenConnection()
        {
            string srv_addr = "localhost";
            string dbname = "db_space_invaders";
            string uid = "root";
            string pass = "root";
            string port = "6033";
            string connectStr;
            connectStr = "SERVER=" + srv_addr + ";" + "DATABASE=" + dbname + ";" + "UID=" + uid + ";" + "PASSWORD=" + pass + ";" + "PORT=" + port + ";";
            Connection = new MySqlConnection(connectStr);

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

        public void SaveSelect()
        {
            OpenConnection();
            string sqlQuerySelect = "SELECT joupseudo, jouNombrePoints FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
            MySqlCommand cmd = new MySqlCommand(sqlQuerySelect, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                records.Add(compteur + "." + "\t" + Convert.ToString(reader["jouPseudo"]) + "\t" + Convert.ToString(reader["jouNombrePoints"]));
                compteur++;
            }
            
        }

        public void InsertValue(Player player)
        {
            string sqlQuerySelect = $"INSERT INTO t_joueur(joupseudo, jouNombrePoints) VALUES ('{player.Pseudo}', {player._score});";
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQuerySelect, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) { }
            ClosConnection();
        }
    }
}

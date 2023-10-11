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
        // Déclaration des attributs
        public MySqlConnection connection;
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

        /// <summary>
        /// Fonction qui ovre la connexion à la DB
        /// </summary>
        /// <returns>true or false</returns>
        public bool OpenConnection()
        {
            // Valeurs de connection de la base de donnée
            string srv_addr = "localhost";
            string dbname = "db_space_invaders";
            string uid = "root";
            string pass = "root";
            string port = "6033";

            // Chaine de connexion permettant de de se connecter à la base de donnée
            string connectStr = "SERVER=" + srv_addr + ";" + "DATABASE=" + dbname + ";" + "UID=" + uid + ";" + "PASSWORD=" + pass + ";" + "PORT=" + port + ";";

            // attribue la chaine de connexion 
            connection = new MySqlConnection(connectStr);

            try
            {
                // Ouvre la connection entre la base de donnée et le programme
                connection.Open();
                Debug.WriteLine("Connexion réussie !!!");
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Ferme la connexion à la DB
        /// </summary>
        public void ClosConnection()
        {
            // Ferme la connexion
            connection.Close();
        }

        /// <summary>
        /// Enregistrer les resulatats du SELECT dans la liste
        /// </summary>
        public void SaveSelect()
        {
            // Ouvre la connexion
            OpenConnection();

            // Requête SQL à executer
            string sqlQuerySelect = "SELECT joupseudo, jouNombrePoints FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
            // permet d'effectuer des opérations sur la base de données
            MySqlCommand cmd = new MySqlCommand(sqlQuerySelect, connection);
            // Éxecute la requête SQL
            MySqlDataReader reader = cmd.ExecuteReader();

            // Boucle while qui s'execute tant que la requête SQL est cours d'execution
            while (reader.Read())
            {
                // Enregistre le pseudo du joueur et son score dans une liste
                records.Add(compteur + "." + "\t" + (string)reader["jouPseudo"] + "\t" + (string)reader["jouNombrePoints"]);
                compteur++;
            }
            
        }

        /// <summary>
        /// va inserer le pseudo du joueur et son score dans la DB
        /// </summary>
        /// <param name="player"></param>
        public void InsertValue(Player player)
        {
            string sqlQuerySelect = $"INSERT INTO t_joueur(joupseudo, jouNombrePoints) VALUES ('{player.Pseudo}', {player._score});";
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQuerySelect, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ClosConnection();
        }
    }
}

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySql_Connector
{
    public class MySqlDbManager
    {
        private MySqlConnection connection;
        private string connectionString;

        public MySqlDbManager(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Connexion réussie !");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur lors de l'ouverture de la connexion : " + ex.Message);
                // Vous pouvez choisir de lever l'exception à nouveau ici ou de gérer l'erreur d'une autre manière.
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur lors de la fermeture de la connexion : " + ex.Message);
                // Vous pouvez choisir de lever l'exception à nouveau ici ou de gérer l'erreur d'une autre manière.
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection(); // Ouvrir la connexion si ce n'est pas déjà fait.

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                // Vous pouvez choisir de lever l'exception à nouveau ici ou de gérer l'erreur d'une autre manière.
            }
            finally
            {
                CloseConnection(); // Fermer la connexion après l'exécution de la requête.
            }

            return dataTable;
        }

        // Ajoutez d'autres méthodes pour effectuer des opérations sur la base de données.
        static void Main(string[] args)
        {
            // Le code que vous souhaitez exécuter en tant qu'application autonome.
            // Par exemple, vous pouvez créer une instance de MySqlDbManager et effectuer des opérations avec elle.
            string connectionString = "server=localhost;user=root;database=warhammer_db";
            MySqlDbManager dbManager = new MySqlDbManager(connectionString);
        }
    }
}



using System;
using MySql_Connector;
using System.Data;

namespace DB_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;database=warhammer_db";

            // Créez une instance de MySqlDbManager pour gérer la connexion à la base de données.
            MySqlDbManager dbManager = new MySqlDbManager(connectionString);

            try
            {
                // Ouvrez la connexion à la base de données.
                dbManager.OpenConnection();

                // Exécutez votre requête SQL. Par exemple, une requête de sélection de toutes les lignes d'une table.
                string query = "SELECT * FROM test";
                var result = dbManager.ExecuteQuery(query);

                foreach (DataRow row in result.Rows)
                {
                    Console.WriteLine("ID : " + row["id"].ToString());
                    Console.WriteLine("Nom : " + row["nom"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
            finally
            {
                // Fermez la connexion lorsque vous avez terminé.
                dbManager.CloseConnection();
            }
        }
    }
}




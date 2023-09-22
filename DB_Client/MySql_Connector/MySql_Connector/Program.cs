using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "server=localhost;user=root;database=warhammer_db";

        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connexion réussie !");

            // Vous pouvez exécuter vos opérations de base de données ici.

            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
        }
        finally
        {
            connection.Dispose();
        }
    }
}


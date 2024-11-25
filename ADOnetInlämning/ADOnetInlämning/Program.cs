using Microsoft.Data.SqlClient;
namespace ADOnetInlämning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            
            Console.Write("Enter actors first name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Enter actors last name: ");
            string lastName = Console.ReadLine();
            
            var command = new SqlCommand($"SELECT COUNT(DISTINCT film_actor.film_id) FROM actor INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id WHERE actor.first_name = '{firstName}' AND actor.last_name = '{lastName}'", connection);
            
            connection.Open();
            var rec = command.ExecuteReader();

            if (rec.HasRows)
            {
                while (rec.Read())
                {
                    Console.WriteLine($"They have been in {rec[0]} movies");                   
                }
            }
            connection.Close();
        }
    }
}

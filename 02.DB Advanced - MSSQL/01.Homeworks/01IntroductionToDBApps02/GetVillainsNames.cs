using System;
using System.Data.SqlClient;

namespace _01IntroductionToDBApps02
{
    class GetVillainsNames
    {
        static void Main()
        {

            string serverCon = "Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(serverCon);
            try
            {
                connection.Open();
                string getVillians = "SELECT v.Name, COUNT(MinionId) AS c\n" +
                    "FROM Villains v\n" +
                    "JOIN MinionsVillains mv ON v.Id = mv.VillainId\n" +
                    "GROUP BY v.Name\n" +
                    "HAVING COUNT(MinionId) > 3\n" +
                    "ORDER BY c DESC";
                ExecuteCommand(getVillians, connection);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void ExecuteCommand(string commandText, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(commandText, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }
            }
        }
    }
}

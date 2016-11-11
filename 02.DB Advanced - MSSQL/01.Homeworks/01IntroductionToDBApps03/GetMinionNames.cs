using System;
using System.Data;
using System.Data.SqlClient;

namespace _01IntroductionToDBApps03
{
    class GetMinionNames
    {
        static void Main()
        {
            SqlConnection serverCon = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True");
            int id = int.Parse(Console.ReadLine());
            string villainNameSQL = "SELECT Name FROM Villains WHERE id = @villainId";
            SqlCommand cmd = new SqlCommand(villainNameSQL, serverCon);
            cmd.Parameters.AddWithValue("@villainId", id);
            serverCon.Open();
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("No villain with ID " + id + " exists in the database.");
                    return;
                }
                reader.Read();
                string villainName = reader[0].ToString();
                Console.WriteLine("Villain: " + villainName);

            }
            serverCon.Close();

            string minionsSQL = "select m.name, age\n" +
                                "FROM Villains v\n" +
                                "JOIN MinionsVillains mv ON v.Id = mv.VillainId\n" +
                                "JOIN Minions m ON m.id = mv.MinionId\n" +
                                "WHERE v.Id = @villainId";
            cmd = new SqlCommand(minionsSQL, serverCon);
            cmd.Parameters.AddWithValue("@villainId", id);
            serverCon.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("<no minions>");
                    return;
                }

                int counter = 1;
                while (reader.Read())
                {
                    Console.WriteLine(counter + " " + reader["name"] + " " + reader["age"]);
                    counter++;
                }
            }
            serverCon.Close();

        }
    }
}

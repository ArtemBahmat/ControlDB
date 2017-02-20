using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ControlDB
{
    public class Task2
    {
        public void PrintDataWhoScored(List<int> matchesIds)
        {
            foreach (var id in matchesIds)
            {
                PrintDataWhoScored(id);
            }
        }

        public List<int> GetAllMatchesId()
        {
            List<int> result = new List<int>();
            string sql = @"SELECT Id FROM Matches";

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = Task1.ConnectionString;
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0));
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        private void PrintDataWhoScored(int matchId)
        {
            string sql = @"select s.TimeMinute, p.Name as PlayerName, t.Name as TeamName from dbo.scores s
                        inner join dbo.matches m on s.MatchId = m.id
                        inner join dbo.Players p on p.id  = s.playerid
                        inner join dbo.Teams t on t.id = p.teamid
                        where m.id = @matchId
                        order by s.timeminute ";

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = Task1.ConnectionString;
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("matchId", matchId);
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"Match № {matchId}");

                        while (reader.Read())
                        {
                            try
                            {
                                int timeMinute = reader.GetInt32(0);
                                string playerName = reader.GetString(1) ?? string.Empty;
                                string teamName = reader.GetString(2) ?? string.Empty;
                                Console.WriteLine($"{timeMinute} - {playerName} - {teamName}");
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ControlDB
{
    public class Task1
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Control"].ConnectionString;

        public List<Match> GetMatches()
        {
            List<Match> matches = new List<Match>();

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText =
                         @"Select A.Name AS TeamA, B.Name AS TeamB, m.TeamAScore, m.TeamBScore from Matches m
                            JOIN Teams A On m.TeamA = A.Id
					        JOIN Teams B On m.TeamB = B.Id
					        WHERE A.Name IS NOT NULL AND B.Name IS NOT NULL"; ;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Match match = new Match(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        matches.Add(match);
                    }
                }
            }
            catch (Exception)
            { }
            
            return matches;
        }

        public List<Match> GetFullMatches(List<Match> matches)
        {
            foreach (var match in matches)
            {
                match.TeamAPlayers = GetPlayers(match.TeamA);
                match.TeamBPlayers = GetPlayers(match.TeamB);
            }

            return matches;
        }

        private List<string> GetPlayers(string teamName)
        {
            List<string> result = new List<string>();
            string sql = @"SELECT p.Name FROM Players p
                          JOIN Teams t ON p.TeamId = t.Id
                          WHERE t.Name = @teamName";

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("teamName", teamName);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.GetString(0) != null)
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public void PrintSummaryInfo(List<Match> matches)
        {
            foreach (var match in matches)
            {
                Console.WriteLine($"{match.TeamA} - {match.TeamB} {match.ScoreTeamA}:{match.ScoreTeamB}");
                Console.WriteLine($"{match.TeamA} players in this match:");
                foreach (string player in match.TeamAPlayers)
                {
                    Console.WriteLine(player);
                }
                Console.WriteLine($"{match.TeamB} players in this match:");
                foreach (string player in match.TeamBPlayers)
                {
                    Console.WriteLine(player);
                }
            }
        }


    }
}

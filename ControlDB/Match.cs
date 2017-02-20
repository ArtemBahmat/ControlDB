using System.Collections.Generic;

namespace ControlDB
{
    public class Match
    {
        public string TeamA { get; set; }
        public List<string> TeamAPlayers { get; set; }
        public string TeamB { get; set; }
        public List<string> TeamBPlayers { get; set; }
        public int ScoreTeamA { get; set; }
        public int ScoreTeamB { get; set; }

        public Match(string teamA, string teamB, int scoreTeamA, int scoreTeamB)
        {
            TeamA = teamA;
            TeamB = teamB;
            ScoreTeamA = scoreTeamA;
            ScoreTeamB = scoreTeamB;
        }
    }
}

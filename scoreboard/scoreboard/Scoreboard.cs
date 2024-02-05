using Scoreboard.Models;

namespace Scoreboard
{
    public class Scoreboard
    {
        private List<Match> matches;

        public Scoreboard()
        {
            matches = new List<Match>();
        }

        public bool CreateMatch(string homeTeamName, string awayTeamName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateScore(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore)
        {
            throw new NotImplementedException();
        }

        public bool FinishMatch(string homeTeamName, string awayTeamName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> GetSummaryOfMatches()
        {
            throw new NotSupportedException();
        }
    }
}

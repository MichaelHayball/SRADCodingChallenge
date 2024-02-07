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
            if (string.IsNullOrEmpty(homeTeamName))
                throw new ArgumentNullException(nameof(homeTeamName), "homeTeamName cannot be null or empty");
            if (string.IsNullOrEmpty(awayTeamName))
                throw new ArgumentNullException(nameof(awayTeamName), "awayTeamName cannot be null or empty");
            if (string.Equals(homeTeamName.Trim(), awayTeamName.Trim(), StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("homeTeamName cannot be the same as awayTeamName");

            if (matches.Any(x => x.awayTeamName == awayTeamName || x.homeTeamName == awayTeamName))
                throw new InvalidOperationException($"team {awayTeamName} is already in play");
            if (matches.Any(x => x.awayTeamName == homeTeamName || x.homeTeamName == homeTeamName))
                throw new InvalidOperationException($"team {homeTeamName} is already in play");

            matches.Add(new Match
            {
                homeTeamName = homeTeamName,
                homeTeamScore = 0,
                awayTeamName = awayTeamName,
                awayTeamScore = 0
            });

            return true;
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

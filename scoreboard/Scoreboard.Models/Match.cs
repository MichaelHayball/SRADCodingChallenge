namespace Scoreboard.Models
{
    public record Match
    {
        public required string homeTeamName { get; set; }
        public int homeTeamScore { get; set; } = 0;
        public required string awayTeamName { get; set; }
        public int awayTeamScore { get; set; } = 0;
    }
}

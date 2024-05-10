namespace PromiedosApi.Models;

public class Match : BaseEntity
{
    public DateTime MatchDate { get; set; } 
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }
    public Tournament Tournament { get; set; }

    public Match() { }

    public Match(DateTime matchDate, Team homeTeam, Team awayTeam, int homeGoals, int awayGoals,
        Tournament tournament)
    {
        MatchDate = matchDate;
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeGoals = homeGoals;
        AwayGoals = awayGoals;
        Tournament = tournament;
    }
}
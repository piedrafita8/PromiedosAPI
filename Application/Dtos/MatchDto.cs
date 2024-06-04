namespace PromiedosApi.Application.Dtos;

public class MatchDto
{
    public long HomeTeamId { get; set; }
    public long AwayTeamId { get; set; }
    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }
    public long TournamentId { get; set; }
}

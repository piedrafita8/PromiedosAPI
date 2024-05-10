namespace PromiedosApi.Models;

public class Tournament : BaseEntity
{
    public string TournamentName { get; set; }
    public int Year { get; set; }
    public string Format { get; set; }
    public List<Team> Teams { get; set; }

    public Tournament(string tournamentName, int year, string format)
    {
        TournamentName = tournamentName;
        Year = year;
        Format = format;
        Teams = new List<Team>();
    }
    
}
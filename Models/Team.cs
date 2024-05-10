namespace PromiedosApi.Models;

public class Team : BaseEntity
{
    public string TeamName { get; set; }
    public Stadium Stadium { get; set; }
    public City City { get; set; }
    
    public Team (){}

    public Team(string teamName, Stadium stadium, City city)
    {
        TeamName = teamName;
        Stadium = stadium;
        City = city;
    }
}
namespace PromiedosApi.Models;

public class Stadium : BaseEntity
{
    public string StadiumName { get; set; }
    public City City { get; set; }
    
    public Stadium(){}
    
    public Stadium(string stadiumName, City city)
    {
        StadiumName = stadiumName;
        City = city;
    }
}
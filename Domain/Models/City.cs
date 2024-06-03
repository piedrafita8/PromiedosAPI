namespace PromiedosApi.Domain.Models;

public class City : BaseEntity
{
    public string CityName { get; set; }
    public string Province { get; set; }
    
    public City (){}
    
    public City (string cityName, string province)
    {
        CityName = cityName;
        Province = province;
    }
}
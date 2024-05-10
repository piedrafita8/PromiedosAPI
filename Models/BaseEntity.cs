namespace PromiedosApi.Models;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;
    
}
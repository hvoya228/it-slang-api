namespace Dictionary.Data.Models;

public class Term : BaseModel
{
    public string Text { get; set; } = string.Empty;
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public Guid UseFrequencyId { get; set; }
    public UseFrequency UseFrequency { get; set; } = null!;
}
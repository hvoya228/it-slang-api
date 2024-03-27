namespace Dictionary.Data.Models;

public class Term : BaseModel
{
    public string Text { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string UsingExample { get; set; } = string.Empty;
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
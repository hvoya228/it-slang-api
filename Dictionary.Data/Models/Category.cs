namespace Dictionary.Data.Models;

public class Category : BaseModel
{
    public string Text { get; set; } = string.Empty;
    
    public ICollection<Term> Terms { get; set; } = null!;
}
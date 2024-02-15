namespace Dictionary.Data.Models;

public class UseFrequency : BaseModel
{
    public int Frequency { get; set; }
    
    public ICollection<Term> Terms { get; set; } = null!;
}
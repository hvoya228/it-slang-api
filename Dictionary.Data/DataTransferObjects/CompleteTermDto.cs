namespace Dictionary.Data.DataTransferObjects;

public class CompleteTermDto : BaseDto
{
    public string Text { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int UseFrequency { get; set; }
    
    public Guid CategoryId { get; set; }
    public Guid UseFrequencyId { get; set; }
}
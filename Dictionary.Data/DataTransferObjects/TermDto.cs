namespace Dictionary.Data.DataTransferObjects;

public class TermDto : BaseDto
{
    public string Text { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Guid UseFrequencyId { get; set; }
}
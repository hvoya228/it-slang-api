namespace Dictionary.Data.DataTransferObjects;

public class DictionaryObjectDto : BaseDto
{
    public string TermText { get; set; } = string.Empty;
    public string TermExplanation { get; set; } = string.Empty;
    public string CategoryText { get; set; } = string.Empty;
    public int UseFrequency { get; set; }
}
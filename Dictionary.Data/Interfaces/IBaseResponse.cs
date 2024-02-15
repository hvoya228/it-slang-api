namespace Dictionary.Data.Interfaces;

public interface IBaseResponse<T>
{
    T Data { get; set; }
}
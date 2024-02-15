using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Interfaces;

namespace Dictionary.BLL.Interfaces;

public interface IUseFrequencyService
{
    Task<IBaseResponse<UseFrequencyDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<UseFrequencyDto>>> GetAll();
    Task<IBaseResponse<string>> Insert(UseFrequencyDto modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}
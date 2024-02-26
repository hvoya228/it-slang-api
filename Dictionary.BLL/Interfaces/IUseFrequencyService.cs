using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Interfaces;

namespace Dictionary.BLL.Interfaces;

public interface IUseFrequencyService
{
    Task<IBaseResponse<IEnumerable<UseFrequencyDto>>> Get();
    Task<IBaseResponse<string>> Insert(UseFrequencyDto modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}
using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Interfaces;

namespace Dictionary.BLL.Interfaces;

public interface ITermService
{
    Task<IBaseResponse<TermDto>> GetById(Guid id);
    Task<IBaseResponse<IEnumerable<TermDto>>> Get();
    Task<IBaseResponse<string>> Insert(TermDto modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}
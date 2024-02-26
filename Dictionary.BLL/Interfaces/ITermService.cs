using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Interfaces;

namespace Dictionary.BLL.Interfaces;

public interface ITermService
{
    Task<IBaseResponse<IEnumerable<CompleteTermDto>>> GetByText(string text);
    Task<IBaseResponse<IEnumerable<CompleteTermDto>>> GetByCategoryId(Guid categoryId);
    Task<IBaseResponse<IEnumerable<CompleteTermDto>>> Get();
    Task<IBaseResponse<string>> Insert(TermDto model);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}
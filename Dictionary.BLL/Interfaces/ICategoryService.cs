using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Interfaces;

namespace Dictionary.BLL.Interfaces;

public interface ICategoryService
{
    Task<IBaseResponse<IEnumerable<CategoryDto>>> Get();
    Task<IBaseResponse<string>> Insert(CategoryDto? modelDto);
    Task<IBaseResponse<string>> DeleteById(Guid id);
}
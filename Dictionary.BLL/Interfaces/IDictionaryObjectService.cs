using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Interfaces;

namespace Dictionary.BLL.Interfaces;

public interface IDictionaryObjectService
{
    Task<IBaseResponse<DictionaryObjectDto>> Get();
}
using AutoMapper;
using Dictionary.BLL.Interfaces;
using Dictionary.DAL.Interfaces;
using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Enums;
using Dictionary.Data.Interfaces;
using Dictionary.Data.Models;
using Dictionary.Data.Responses;

namespace Dictionary.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IBaseResponse<IEnumerable<CategoryDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.CategoryRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<CategoryDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<CategoryDto>();
                
            foreach (var model in models)
                dtoList.Add(_mapper.Map<CategoryDto>(model));
                
            return CreateBaseResponse<IEnumerable<CategoryDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<CategoryDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> Insert(CategoryDto? modelDto)
    {
        try
        {
            if (modelDto is not null)
            {
                modelDto.Id = Guid.NewGuid();
                
                await _unitOfWork.CategoryRepository.InsertAsync(_mapper.Map<Category>(modelDto));
                await _unitOfWork.SaveChangesAsync();

                return CreateBaseResponse<string>("Object inserted!", StatusCode.Ok, resultsCount: 1);
            }

            return CreateBaseResponse<string>("Objet can`t be empty...", StatusCode.BadRequest);
        }
        catch (Exception e)
        {
            return CreateBaseResponse<string>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> DeleteById(Guid id)
    {
        try
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return CreateBaseResponse<string>("Object deleted!", StatusCode.Ok, resultsCount: 1);
        }
        catch (Exception e)
        {
            return CreateBaseResponse<string>($"{e.Message} or object not found", StatusCode.InternalServerError);
        }
    }
    
    private BaseResponse<T> CreateBaseResponse<T>(string description, StatusCode statusCode, T? data = default, int resultsCount = 0)
    {
            return new BaseResponse<T>()
            {
                ResultsCount = resultsCount,
                Data = data!,
                Description = description,
                StatusCode = statusCode
            };
    }
}
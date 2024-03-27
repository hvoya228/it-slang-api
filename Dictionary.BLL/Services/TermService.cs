using AutoMapper;
using Dictionary.BLL.Interfaces;
using Dictionary.DAL.Interfaces;
using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Enums;
using Dictionary.Data.Interfaces;
using Dictionary.Data.Models;
using Dictionary.Data.Responses;

namespace Dictionary.BLL.Services;

public class TermService : ITermService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TermService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IBaseResponse<IEnumerable<CompleteTermDto>>> GetByText(string text)
    {
        try
        {
            var models = await _unitOfWork.TermRepository.GetByTextAsync(text);

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<CompleteTermDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<CompleteTermDto>();
                
            foreach (var model in models)
            {
                try
                {
                    var dto = _mapper.Map<CompleteTermDto>(model);
                    var category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId);
                    dto.Category = category.Text;
                    dto.CategoryId = category.Id;
                    dtoList.Add(dto);
                }
                catch
                {
                    dtoList.Add(new CompleteTermDto() {Id = model.Id});
                }
            }
                
            return CreateBaseResponse<IEnumerable<CompleteTermDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e)
        {
            return CreateBaseResponse<IEnumerable<CompleteTermDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<IEnumerable<CompleteTermDto>>> GetByCategoryId(Guid categoryId)
    {
        try
        {
            var models = await _unitOfWork.TermRepository.GetByCategoryIdAsync(categoryId);

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<CompleteTermDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<CompleteTermDto>();
                
            foreach (var model in models)
            {
                try
                {
                    var dto = _mapper.Map<CompleteTermDto>(model);
                    var category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId);
                    dto.Category = category.Text;
                    dto.CategoryId = category.Id;
                    dtoList.Add(dto);
                }
                catch
                {
                    dtoList.Add(new CompleteTermDto() {Id = model.Id});
                }
            }
                
            return CreateBaseResponse<IEnumerable<CompleteTermDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e)
        {
            return CreateBaseResponse<IEnumerable<CompleteTermDto>>(e.Message, StatusCode.InternalServerError);
        }
    }
    
    public async Task<IBaseResponse<IEnumerable<CompleteTermDto>>> Get()
    {
        try
        {
            var models = await _unitOfWork.TermRepository.GetAsync();

            if (models.Count is 0)
            {
                return CreateBaseResponse<IEnumerable<CompleteTermDto>>("0 objects found", StatusCode.NotFound);
            }

            var dtoList = new List<CompleteTermDto>();

            foreach (var model in models)
            {
                try
                {
                    var dto = _mapper.Map<CompleteTermDto>(model);
                    var category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId);
                    dto.Category = category.Text;
                    dto.CategoryId = category.Id;
                    dtoList.Add(dto);
                }
                catch
                {
                    dtoList.Add(new CompleteTermDto() {Id = model.Id});
                }
            }

            return CreateBaseResponse<IEnumerable<CompleteTermDto>>("Success!", StatusCode.Ok, dtoList, dtoList.Count);
        }
        catch(Exception e) 
        {
            return CreateBaseResponse<IEnumerable<CompleteTermDto>>(e.Message, StatusCode.InternalServerError);
        }
    }

    public async Task<IBaseResponse<string>> Insert(TermDto? modelDto)
    {
        try
        {
            if (modelDto is null) 
                return CreateBaseResponse<string>("Objet can`t be empty...", StatusCode.BadRequest);
            
            modelDto.Id = Guid.NewGuid();
            await _unitOfWork.TermRepository.InsertAsync(_mapper.Map<Term>(modelDto));
            await _unitOfWork.SaveChangesAsync();

            return CreateBaseResponse<string>("Object inserted!", StatusCode.Ok, resultsCount: 1);

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
            await _unitOfWork.TermRepository.DeleteAsync(id);
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
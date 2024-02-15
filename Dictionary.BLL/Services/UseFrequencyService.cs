using AutoMapper;
using Dictionary.BLL.Interfaces;
using Dictionary.DAL.Interfaces;
using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Enums;
using Dictionary.Data.Interfaces;
using Dictionary.Data.Models;
using Dictionary.Data.Responses;

namespace Dictionary.BLL.Services;

public class UseFrequencyService : IUseFrequencyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UseFrequencyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IBaseResponse<UseFrequencyDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<UseFrequencyDto>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<UseFrequencyDto>>();
        var dtoList = new List<UseFrequencyDto>();

        try
        {
            var models = await _unitOfWork.UseFrequencyRepository.GetAsync();

            foreach (var model in models)
            {
                var dto = _mapper.Map<UseFrequencyDto>(model);
                dtoList.Add(dto);
            }

            if (dtoList.Count is 0)
            {
                baseResponse.Description = "0 objects found";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            baseResponse.ResultsCount = dtoList.Count;
            baseResponse.Description = "Success!";
            baseResponse.Data = dtoList;
            baseResponse.StatusCode = StatusCode.Ok;

            return baseResponse;
        }
        catch(Exception e) 
        {
            return new BaseResponse<IEnumerable<UseFrequencyDto>>()
            {
                Description = $"{e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<string>> Insert(UseFrequencyDto? modelDto)
    {
        try
        {
            if (modelDto is not null)
            {
                modelDto.Id = Guid.NewGuid();
                var model = _mapper.Map<UseFrequency>(modelDto);
                await _unitOfWork.UseFrequencyRepository.InsertAsync(model);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse<string>()
                {
                    Description = $"Object inserted!"
                };
            }
            else
            {
                return new BaseResponse<string>()
                {
                    Description = $"Objet can`t be empty..."
                };
            }
        }
        catch(Exception e)
        {
            return new BaseResponse<string>()
            {
                Description = $"{e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<string>> DeleteById(Guid id)
    {
        try
        {
            await _unitOfWork.UseFrequencyRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<string>()
            {
                Description = $"Object deleted!"
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<string>()
            {
                Description = $"{e.Message}"
            };
        }
    }
}
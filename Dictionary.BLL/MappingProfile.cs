using AutoMapper;
using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Models;

namespace Dictionary.BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Term, TermDto>();
        CreateMap<TermDto, Term>();
        
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        
        CreateMap<UseFrequency, UseFrequencyDto>();
        CreateMap<UseFrequencyDto, UseFrequency>();
    }
}
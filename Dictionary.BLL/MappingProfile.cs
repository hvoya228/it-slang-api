using AutoMapper;
using Dictionary.Data.DataTransferObjects;
using Dictionary.Data.Models;

namespace Dictionary.BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Term, CompleteTermDto>();
        CreateMap<CompleteTermDto, Term>();
        
        CreateMap<Term, TermDto>();
        CreateMap<TermDto, Term>();
        
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}
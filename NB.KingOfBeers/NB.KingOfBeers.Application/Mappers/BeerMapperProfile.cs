using NB.KingOfBeers.Application.Dtos;
using NB.KingOfBeers.Database.Models;

namespace NB.KingOfBeers.Application.Mappers;

public class BeerMapperProfile : Profile
{
    public BeerMapperProfile()
    {
        CreateMap<BeerDto, Beer>()
            .ForMember(x => x.PercentageAlcoholByVolume, opt => opt.MapFrom(src => src.PercentageAlcoholByVolume))
            .ReverseMap();

    }
}
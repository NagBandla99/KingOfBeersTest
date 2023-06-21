using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Dtos.BarBeers;
using NB.KingOfBeers.Application.Dtos;

namespace NB.KingOfBeers.Application.Mappers;

public class BarBeerMapperProfile : Profile
{
    public BarBeerMapperProfile()
    {
        CreateMap<BarBeersDto, BarBeers>()
            .ForMember(x => x.Beer, opt => opt.MapFrom(src => src.Beer))

            .ReverseMap();

        CreateMap<BarBeers, BeerDto>()
            .ForMember(x => x.BeerId, opt => opt.MapFrom(src => src.BeerId))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Beer.Name))
            .ForMember(x => x.PercentageAlcoholByVolume, opt => opt.MapFrom(src => src.Beer.PercentageAlcoholByVolume))
            .ReverseMap();

    }
}
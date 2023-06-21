using NB.KingOfBeers.Database.Models;

namespace NB.KingOfBeers.Application.Mappers;

using NB.KingOfBeers.Application.Dtos.BreweryBeer;

public class BreweryBeersMapperProfile : Profile
{
    public BreweryBeersMapperProfile()
    {
        CreateMap<BreweryBeerDto, BreweryBeers>()
            .ForMember(x => x.Beer, opt => opt.MapFrom(src => src.Beer))
            .ForMember(x => x.Brewery, opt => opt.MapFrom(src => src.Brewery))

             .ReverseMap();

    }
}
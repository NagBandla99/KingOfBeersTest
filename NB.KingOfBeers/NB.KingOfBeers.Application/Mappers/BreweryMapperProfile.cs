using NB.KingOfBeers.Database.Models;
using NB.KingOfBeers.Application.Dtos.Brewery;

namespace NB.KingOfBeers.Application.Mappers;

public class BreweryMapperProfile : Profile
{
    public BreweryMapperProfile()
    {
        CreateMap<BreweryDto, Brewery>()
             .ReverseMap();

    }
}
using NB.KingOfBeers.Database.Models;

namespace NB.KingOfBeers.Application.Mappers;

using NB.KingOfBeers.Application.Dtos.Bar;

public class BarMapperProfile : Profile
{
    public BarMapperProfile()
    {
        CreateMap<BarDto, Bar>()
            .ReverseMap();

    }
}
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Common;
using WorldTravel.Application.Countries.Dtos;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Queries.GetAllCountries;

public class GetAllCountriesQueryHandler(ILogger<GetAllCountriesQueryHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) : IRequestHandler<GetAllCountriesQuery, PagedResult<CountryDto>>
{
    public async Task<PagedResult<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all countries");

        var (countries, totalCount) = await countriesRepository.GetAllMatchingSearchAsync(request.SearchPhrase, request.Page, request.Size, request.SortBy, request.Direction);
        var countriesDto = mapper.Map<IEnumerable<CountryDto>>(countries);

        var result = new PagedResult<CountryDto>(countriesDto, totalCount, request.Size, request.Page);
        return result;
    }
}


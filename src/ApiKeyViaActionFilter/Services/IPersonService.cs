using ApiKeyViaActionFilter.Dtos;
using ApiKeyViaActionFilter.Dtos.Person;

namespace ApiKeyViaActionFilter.Services
{
    public interface IPersonService
    {
        Task<PagingInfoDto<PersonDto>> QueryAsync(
            int take,
            int skip,
            CancellationToken cancellationToken = default);

        Task<PersonDto> AddAsync(
            PersonCreateRequestDto createRequest,
            CancellationToken cancellationToken = default);
    }
}

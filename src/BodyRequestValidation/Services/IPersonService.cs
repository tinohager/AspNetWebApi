using BodyRequestValidation.Dtos;
using BodyRequestValidation.Dtos.Person;

namespace BodyRequestValidation.Services
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

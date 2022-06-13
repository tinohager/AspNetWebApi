using BodyRequestValidation.Dtos;
using BodyRequestValidation.Dtos.Person;
using System.Collections.Concurrent;

namespace BodyRequestValidation.Services
{
    public class PersonService : IPersonService
    {
        private int _nextId = 0;
        private ConcurrentDictionary<int, PersonDto> _persons = new ConcurrentDictionary<int, PersonDto>();

        public Task<PagingInfoDto<PersonDto>> QueryAsync(
            int take,
            int skip,
            CancellationToken cancellationToken = default)
        {
            var persons = this._persons.Values;
            return Task.FromResult(new PagingInfoDto<PersonDto>
            {
                Total = persons.Count,
                Items = persons.OrderBy(o => o.Id).Take(take).Skip(skip).ToArray()
            });
        }

        public Task<PersonDto> AddAsync(
            PersonCreateRequestDto createRequest,
            CancellationToken cancellationToken = default)
        {
            var nextId = Interlocked.Increment(ref this._nextId);

            var item = new PersonDto
            {
                Id = nextId,
                CreatedAt = DateTime.Now,
                Firstname = createRequest.Firstname,
                Lastname = createRequest.Lastname,
                EmailAddress = createRequest.EmailAddress,
                FoodPreferences = createRequest.FoodPreferences
            };

            this._persons.TryAdd(nextId, item);

            return Task.FromResult(item);
        }
    }
}

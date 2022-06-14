using ApiKeyViaActionFilter.Attributes;
using ApiKeyViaActionFilter.Dtos;
using ApiKeyViaActionFilter.Dtos.Person;
using ApiKeyViaActionFilter.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiKeyViaActionFilter.Controllers
{
    [ApiController]
    [ApiKey]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonService personService)
        {
            this._logger = logger;
            this._personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<PagingInfoDto<PersonDto>>> QueryAsync(
            [FromQuery] int take = 100,
            [FromQuery] int skip = 0,
            CancellationToken cancellationToken = default)
        {
            var pagingInfo = await this._personService.QueryAsync(take, skip, cancellationToken);
            return StatusCode(StatusCodes.Status200OK, pagingInfo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PagingInfoDto<PersonDto>>> AddAsync(
            PersonCreateRequestDto createRequest,
            CancellationToken cancellationToken = default)
        {
            var item = await this._personService.AddAsync(createRequest, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, item);
        }
    }
}
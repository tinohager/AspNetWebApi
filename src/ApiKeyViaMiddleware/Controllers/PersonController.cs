using ApiKeyViaMiddleware.Attributes;
using ApiKeyViaMiddleware.Dtos;
using ApiKeyViaMiddleware.Dtos.Person;
using ApiKeyViaMiddleware.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiKeyViaMiddleware.Controllers
{
    [ApiController]
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

        [ApiKey]
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
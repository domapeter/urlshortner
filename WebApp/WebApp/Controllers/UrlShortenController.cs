using AutoMapper;
using DTO;
using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class URLShortnerController : ControllerBase
    {
        private readonly IValidator<ShortLinkCreateRequest> validator;
        private readonly IMapper mapper;
        private readonly ILinkService linkService;

        public URLShortnerController(IValidator<ShortLinkCreateRequest> validator, IMapper mapper, ILinkService linkService)
        {
            this.validator = validator;
            this.mapper = mapper;
            this.linkService = linkService;
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> GetByShortUrl([FromRoute] string url)
        {
            var link = await linkService.GetAsync(url);

            var dto = mapper.Map<ShortLinkResponse>(link);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShortLinkCreateRequest request)
        {
            await validator.ValidateAndThrowAsync(request);

            var entity = mapper.Map<LinkPair>(request);

            var linkPair = await linkService.CreateAsync(entity);

            var dto = mapper.Map<ShortLinkResponse>(linkPair);

            return Created(dto.ShortUrl, dto);
        }
    }
}
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenController : ControllerBase
    {
        private readonly IValidatorFactory validatorFactory;
        private readonly IMapper mapper;
        private readonly ILinkService linkService;

        public UrlShortenController(IValidatorFactory validatorFactory, IMapper mapper, ILinkService linkService)
        {
            this.validatorFactory = validatorFactory;
            this.mapper = mapper;
            this.linkService = linkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByShortUrl([FromRoute] string url)
        {
            var link = linkService.GetUrl(url);
        }
    }
}
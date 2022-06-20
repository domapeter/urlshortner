using DTO;
using Entities;

namespace WebApp.Controllers
{
    public interface ILinkService
    {
        public Task<LinkPair> GetAsync(string url);

        public Task<LinkPair> CreateAsync(LinkPair enity);
    }
}
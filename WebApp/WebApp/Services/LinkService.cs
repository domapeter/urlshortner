using DAL.Interfaces;
using DTO;
using Entities;
using Microsoft.AspNetCore.WebUtilities;
using WebApp.Controllers;

namespace WebApp.Services
{
    public class LinkService : ILinkService
    {
        private IAsyncUnitOfWork<LinkPair> unitOfWork;

        public LinkService(IAsyncUnitOfWork<LinkPair> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<LinkPair> CreateAsync(LinkPair enity)
        {
            return await unitOfWork.CreateAsync(enity);
        }

        public async Task<LinkPair> GetAsync(string url)
        {
            var id = GetId(url);

            return await unitOfWork.FindAsync(p => p.Id == id);
        }

        private int GetId(string urlChunk)
        {
            return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(urlChunk));
        }
    }
}
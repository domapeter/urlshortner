using Entities.Base;
using Microsoft.AspNetCore.WebUtilities;

namespace Entities
{
    public class LinkPair : EntityBaseSingleKey<int>
    {
        public string Link { get; set; }
        public string ShortLink => WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Id));
    }
}
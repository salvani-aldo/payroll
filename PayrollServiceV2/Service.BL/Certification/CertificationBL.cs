using AutoMapper;
using Command.Message;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;

namespace Service.BL.Certification
{
    public sealed class CertificationBL : BaseBL
    {
        public CertificationBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
        }

        public void Get()
        {
        }
    }
}

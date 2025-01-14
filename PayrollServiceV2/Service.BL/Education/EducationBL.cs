using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Education;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Education
{
    public sealed class EducationBL : BaseBL, IEducationBL
    {
        public EducationBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            var result = await _message.Send<EducationGetModel>();

            return result;
        }
    }
}

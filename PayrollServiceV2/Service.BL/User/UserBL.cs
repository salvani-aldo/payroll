using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.User.GetById.Model;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;
using System.Transactions;

namespace Service.BL.User
{
    public sealed class UserBL : BaseBL, IUserBL
    {
        public UserBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
        }

        public async Task<IEnumerable<IQuery>> GetUser(string? user)
        {
            IEnumerable<UserGetByNameQueryModel> model;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                model = await _message.Send<UserGetByNameQueryModel>(new UserGetByNameCommandModel(user));

                scope.Complete();
            }

            return model;
        }
    }
}

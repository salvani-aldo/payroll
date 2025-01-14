using Command.Message.Interface;
using Microsoft.EntityFrameworkCore;

namespace Command.Message
{
    public class Message
    {
        private readonly IServiceProvider _serviceProvider;

        public Message(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// sends command to handler and return a lists of results
        /// </summary>
        /// <param name="command">parameters to be use</param>
        /// <param name="query">result</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Send<T>(ICommand command) where T : IQuery
        {
            Type type = typeof(ICommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);

            IEnumerable<T> result = await handler.Handle((dynamic)command);

            return result;
        }

        /// <summary>
        /// sends command to handler and will not return any results
        /// </summary>
        /// <param name="command">Type of ICommand; parameters to be use</param>
        /// <returns></returns>
        public async Task Send(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);

            await handler.Handle((dynamic)command);
        }

        /// <summary>
        /// sends command to handler and returns a lists of result
        /// </summary>
        /// <typeparam name="T">Type of IQuery</typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Send<T>() where T : IQuery
        {
            Type type = typeof(IQueryHandler<>);
            Type[] typeArgs = { typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);

            IEnumerable<T> result = await handler.Handle();

            return result;
        }

        #region With DbContext
        public async Task<IEnumerable<T>> Send<T>(ICommand command, DbContext dbContext) where T : IQuery
        {
            Type type = typeof(ICommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);

            IEnumerable<T> result = await handler.Handle((dynamic)command, dbContext);

            return result;
        }
        #endregion

    }
}
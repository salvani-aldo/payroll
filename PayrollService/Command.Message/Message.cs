using Command.Message.Interface;

namespace Command.Message
{
    public sealed class Message
    {
        private readonly IServiceProvider _serviceProvider;

        public Message(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<ICommand>> Send(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);
            
            dynamic handler = _serviceProvider.GetService(handlerType);
            IEnumerable<ICommand> result = await handler.Handle((dynamic)command);

            return result;
        }

        public async Task<IEnumerable<T>> Send<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            List<T> result = await handler.Handle((dynamic)query);

            return result;
        }

        public async Task<IEnumerable<T>> Send<T>()
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { typeof(T), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            List<T> result = await handler.Handle();

            return result;
        }
    }
}

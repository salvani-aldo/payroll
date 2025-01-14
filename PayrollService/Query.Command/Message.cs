using QueryRequest.Command.Interface;

namespace Query.Request.Command
{
    public sealed class Message
    {
        private readonly IServiceProvider _serviceProvider;

        public Message(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Send(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            handler.Handle((dynamic)command);
        }

        public T Send<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}

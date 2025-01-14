using QueryRequest.Command.Interface;
using QueryRequest.Command.Model.Request;

namespace QueryRequest.Command.Request
{
    public sealed class EmployeeCommand : ICommandHandler<EmployeeRequestModel>
    {
        public void Handle(EmployeeRequestModel command)
        {
            Console.WriteLine("this is the handle part...");
        }
    }
}

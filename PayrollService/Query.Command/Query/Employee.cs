using QueryRequest.Command.Interface;
using QueryRequest.Command.Model.Query;
using QueryRequest.Command.Model.Request;

namespace QueryRequest.Command.Query
{
    public sealed class EmployeeCommand : IQueryHandler<EmployeeQueryModel, EmployeeQueryModel>
    {
        public EmployeeQueryModel Handle(EmployeeQueryModel query)
        {
            return new EmployeeQueryModel(1, "test name");
        }
    }
}

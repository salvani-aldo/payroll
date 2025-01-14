using QueryRequest.Command.Interface;

namespace QueryRequest.Command.Model.Request
{
    public class EmployeeRequestModel : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public EmployeeRequestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

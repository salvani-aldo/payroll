using Command.Message.Interface;

namespace Command.Request.Handler.Employee.Delete
{
    public class EmployeeDeleteModel : ICommand
    {
        public int Id { get; set; }

        public EmployeeDeleteModel(int id)
        {
            Id = id;
        }
    }
}

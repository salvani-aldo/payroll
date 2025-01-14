using Command.Message.Interface;

namespace Command.Request.Emplooyee.Delete
{
    public class EmployeeDeleteModel : ICommand, IQuery
    {
        public int Id { get; set; }

        public EmployeeDeleteModel(int id)
        {
            Id = id;
        }
    }
}

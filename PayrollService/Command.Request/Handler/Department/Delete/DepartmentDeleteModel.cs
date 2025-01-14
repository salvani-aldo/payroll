using Command.Message.Interface;

namespace Command.Request.Handler.Department.Delete
{
    public sealed class DepartmentDeleteModel : ICommand
    {
        public int Id { get; set; }

        public DepartmentDeleteModel(int id)
        {
            Id = id;
        }
    }
}

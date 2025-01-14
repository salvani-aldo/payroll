using Command.Message.Interface;

namespace Command.Request.Department.Delete.ByEmployee
{
    public class DepartmentDeleteModel : ICommand, IQuery
    {
        public int Id { get; set; }

        public DepartmentDeleteModel(int id)
        {
            Id = id;
        }
    }
}

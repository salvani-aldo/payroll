using Command.Message.Interface;

namespace Command.Request.Department.Post.Model
{
    public class DepartmentPostCommandModel : ICommand
    {
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public int UserId { get; set; }
    }
}

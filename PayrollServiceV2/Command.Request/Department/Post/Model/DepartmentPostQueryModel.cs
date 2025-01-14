using Command.Message.Interface;

namespace Command.Request.Department.Post.Model
{
    public class DepartmentPostQueryModel : IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
    }
}

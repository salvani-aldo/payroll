using Command.Message.Interface;

namespace Command.Request.Handler.Department.Post
{
    public sealed class DepartmentPostModel : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public DepartmentPostModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }
    }
}

using Command.Message.Interface;

namespace Command.Request.Department.Put.Model
{
    public class DepartmentPutCommandModel : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public int UserId { get; set; }
    }
}

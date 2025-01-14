using Command.Message.Interface;

namespace Command.Request.Department.Put.Model
{
    public class DepartmentPutQueryModel : IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
    }
}

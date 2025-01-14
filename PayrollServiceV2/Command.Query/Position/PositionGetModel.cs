using Command.Message.Interface;

namespace Command.Query.Position
{
    public class PositionGetModel : IQuery
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string Department { get; set; } = "";
        public int DepartmentId { get; set; }
    }
}

using Command.Message.Interface;

namespace Command.Request.Position.Put.Model
{
    public class PositionPutRequestModel : IQuery
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public int DepartmentId { get; set; }
    }
}

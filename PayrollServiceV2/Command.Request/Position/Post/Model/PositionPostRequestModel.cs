using Command.Message.Interface;

namespace Command.Request.Position.Post.Model
{
    public class PositionPostRequestModel : IQuery
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public int DepartmentId { get; set; }
        public string Department { get; set; } = "";
    }
}

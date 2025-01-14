using Command.Message.Interface;

namespace Command.Request.Position.Post.Model
{
    public class PositionPostCommandModel : ICommand
    {
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
    }
}

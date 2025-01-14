using Command.Message.Interface;

namespace Command.Request.Handler.Position.Post
{
    public class PositionPostModel : ICommand
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public PositionPostModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }

        public PositionPostModel()
        {
        }
    }
}

using Command.Message.Interface;

namespace Command.Query.Handler.Position.Get
{
    public class PositionGetModel : IQuery<PositionGetModel>
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public PositionGetModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }

        public PositionGetModel()
        {
        }
    }
}

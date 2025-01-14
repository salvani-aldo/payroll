using Command.Message.Interface;

namespace Command.Query.Handler.State
{
    public class StateGetModel : IQuery<StateGetModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public StateGetModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }

        public StateGetModel()
        {
        }
    }
}

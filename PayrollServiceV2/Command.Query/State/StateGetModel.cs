

using Command.Message.Interface;

namespace Command.Query.State
{
    public class StateGetModel : ICommand, IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public StateGetModel()
        {
        }
    }
}

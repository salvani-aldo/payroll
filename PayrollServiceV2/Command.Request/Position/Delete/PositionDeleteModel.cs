using Command.Message.Interface;

namespace Command.Request.Position.Delete
{
    public class PositionDeleteModel : ICommand, IQuery
    {
        public int Id { get; set; } = 0;

        public PositionDeleteModel(int id)
        {
            Id = id;
        }

        public PositionDeleteModel()
        {
        }
    }
}

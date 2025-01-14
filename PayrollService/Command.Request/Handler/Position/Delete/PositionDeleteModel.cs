using Command.Message.Interface;

namespace Command.Request.Handler.Position.Delete
{
    public  class PositionDeleteModel: ICommand
    {
        public int Id { get; set; } = 0;

        public PositionDeleteModel(int id)
        {
            Id = id;
        }
    }
}

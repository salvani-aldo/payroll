using Command.Message.Interface;

namespace Command.Query.User.GetById.Model
{
    public class UserGetByNameCommandModel : ICommand
    {
        public string? Name { get; set; }

        public UserGetByNameCommandModel(string? name)
        {
            Name = name;
        }
    }
}

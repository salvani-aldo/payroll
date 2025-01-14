using Command.Message.Interface;

namespace Command.Query.User.GetById.Model
{
    public class UserGetByNameQueryModel : IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public bool Admin { get; set; }
        public bool Deleted { get; set; }
    }
}

using Command.Message.Interface;

namespace Command.Request.Education.Delete.ById
{
    public class EducationDeleteModel : ICommand, IQuery
    {
        public int Id { get; set; }

        public EducationDeleteModel(int id)
        {
            Id = id;
        }
    }
}

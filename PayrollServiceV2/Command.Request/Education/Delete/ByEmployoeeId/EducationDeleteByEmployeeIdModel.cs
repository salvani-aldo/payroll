

using Command.Message.Interface;

namespace Command.Request.Education.Delete.ByEmployoeeId
{
    public class EducationDeleteByEmployeeIdModel : ICommand, IQuery
    {
        public int Id { get; set; }

        public EducationDeleteByEmployeeIdModel(int id)
        {
            Id = id;
        }

        public EducationDeleteByEmployeeIdModel()
        {
        }
    }
}

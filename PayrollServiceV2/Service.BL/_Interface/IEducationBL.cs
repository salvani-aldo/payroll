using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface IEducationBL
    {
        Task<IEnumerable<IQuery>> Get();
    }
}

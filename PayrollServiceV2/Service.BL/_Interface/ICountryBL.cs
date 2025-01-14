using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface ICountryBL
    {
        Task<IEnumerable<IQuery>> Get();
    }
}

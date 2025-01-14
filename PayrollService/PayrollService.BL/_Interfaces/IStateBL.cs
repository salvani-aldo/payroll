using Command.Query.Handler.Country;
using Command.Query.Handler.State;

namespace Payroll.BL._Interfaces
{
    public interface IStateBL
    {
        Task<IEnumerable<StateGetModel>> GetStates();
    }
}

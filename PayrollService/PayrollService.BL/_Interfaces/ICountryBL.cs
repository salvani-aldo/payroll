using Command.Query.Handler.Country;
using Command.Query.Handler.Department.Get;

namespace Payroll.BL._Interfaces
{
    public interface ICountryBL
    {
        Task<IEnumerable<CountryGetModel>> GetCountries();
    }
}

using Command.Message;
using Command.Query.Handler.Country;
using Payroll.BL._Interfaces;

namespace Payroll.BL.Country
{
    public class CountryBL : ICountryBL
    {
        private readonly Message _message;
        public CountryBL(Message message)
        {
            _message = message;
        }

        public async Task<IEnumerable<CountryGetModel>> GetCountries()
        {
            var result = await _message.Send(new CountryGetModel());

            return result;
        }
    }
}

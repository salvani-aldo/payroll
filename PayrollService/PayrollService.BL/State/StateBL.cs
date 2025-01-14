using Command.Message;
using Command.Query.Handler.State;
using Payroll.BL._Interfaces;

namespace Payroll.BL.State
{
    public class StateBL : IStateBL
    {
        private readonly Message _message;

        public StateBL(Message message)
        {
            _message = message;
        }

        public async Task<IEnumerable<StateGetModel>> GetStates()
        {
            var result = await _message.Send(new StateGetModel());
            
            return result;
        }
    }
}

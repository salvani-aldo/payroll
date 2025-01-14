using Command.Message;
using Command.Message.Interface;
using Command.Query.Handler.Position.Get;
using Command.Request.Handler.Position.Delete;
using Command.Request.Handler.Position.Post;
using Command.Request.Handler.Position.Put;
using FluentValidation;
using Model.Validation.Position;
using Payroll.BL._Interfaces;

namespace Payroll.BL.Position
{
    public sealed class PositionBL : IPositionBL
    {
        private readonly Message _message;

        public PositionBL(Message message)
        {
            _message = message;
        }

        public async Task DeletePosition(int id)
        {
            PositionDeleteModel model = new PositionDeleteModel(id);
            
            PositionDeleteModelValidator modelValidation = new PositionDeleteModelValidator();
            modelValidation.ValidateAndThrow(model);

            await _message.Send(model);
        }

        public async Task<IEnumerable<PositionGetModel>> GetPositions()
        {
            var result = await _message.Send(new PositionGetModel());

            return result;
        }

        public async Task<IEnumerable<ICommand>> SavePosition(PositionPostModel model)
        {
            PositionPostModelValidator modelValidation = new PositionPostModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send(model);

            return result;
        }

        public async Task<IEnumerable<ICommand>> UpdatePosition(PositionPutModel model)
        {
            PositionPutModelValidator modelValidation = new PositionPutModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send(model);

            return result;
        }
    }
}

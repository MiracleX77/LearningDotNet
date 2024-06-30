using MediatR;
using Roller.Appication.Configuration;
using Roller.Appication.ContractRepo;
using Roller.Domain.Entities;

namespace Roller.Appication.Features.Roll
{
    public sealed class GetRollHandler : IConfigHandler<GetRoll, RollResult>
    {
        private readonly IRollRepository _rollRepository;

        public GetRollHandler(IRollRepository rollRepository)
        {
            _rollRepository = rollRepository;
        }

        public async Task<RollResult> Handle(GetRoll request, CancellationToken cancellationToken)
        {
            var roll = await _rollRepository.GetRollByIdAsync(request.Id);
            RollResult result = new RollResult(){
                Id = roll.Id,
                UserId = roll.UserId,
                Value = roll.Value,
                Created = roll.Created
            };
            return result;
        }
    }

    public sealed class GetAllRollsHandler : IConfigHandler<GetAllRolls, List<RollResult>>
    {
        private readonly IRollRepository _rollRepository;

        public GetAllRollsHandler(IRollRepository rollRepository)
        {
            _rollRepository = rollRepository;
        }

        public async Task<List<RollResult>> Handle(GetAllRolls request, CancellationToken cancellationToken)
        {
            var rolls = await _rollRepository.GetRollsAsync();
            List<RollResult> result = new List<RollResult>();
            foreach (var roll in rolls)
            {
                result.Add(new RollResult(){
                    Id = roll.Id,
                    UserId = roll.UserId,
                    Value = roll.Value,
                    Created = roll.Created
                });
            }
            return result;
        }
    }

    public sealed class CreateRollHandler : IConfigHandler<CreateRoll, RollResult>
    {
        private readonly IRollRepository _rollRepository;

        public CreateRollHandler(IRollRepository rollRepository)
        {
            _rollRepository = rollRepository;
        }

        public async Task<RollResult> Handle(CreateRoll request, CancellationToken cancellationToken)
        {
            var roll = new Domain.Entities.Roll(){
                UserId = request.UserId,
                Value = new Random().Next(1, 7),
                Created = DateTime.Now.ToUniversalTime()
            };
            await _rollRepository.CreateRollAsync(roll);
            RollResult result = new RollResult(){
                Id = roll.Id,
                UserId = roll.UserId,
                Value = roll.Value,
                Created = roll.Created
            };
            return result;
        }
    }
}
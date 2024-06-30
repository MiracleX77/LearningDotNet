using Roller.Appication.Configuration;

namespace Roller.Appication.Features.Roll
{
    public class GetRoll : IConfig<RollResult>
    {
        public int Id { get; set; }

        public GetRoll(int id)
        {
            Id = id;
        }
    }

    public class GetAllRolls : IConfig<List<RollResult>>
    {
        public GetAllRolls()
        {
        }
    }

    public class CreateRoll : IConfig<RollResult>
    {
        public int UserId { get; set; }

        public CreateRoll(int userId)
        {
            UserId = userId;
        }
    }
}
namespace Roller.Appication.Features.Roll
{
    public class GetAllRollsResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int Value { get; set; }

        public DateTime Created { get; set; }
    }

    public class RollResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int Value { get; set; }

        public DateTime Created { get; set; }
    }
}
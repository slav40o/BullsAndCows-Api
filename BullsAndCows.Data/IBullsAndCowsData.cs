namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<Player> Players { get; }

        IRepository<Game> Games { get; }

        void SaveChanges();
    }
}

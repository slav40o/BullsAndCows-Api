namespace BullsAndCows.Data
{
    using BullsAndCows.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class BullsAndCowsDbContext : IdentityDbContext<Player>
    {
        public BullsAndCowsDbContext()
            : base("BullsAndCowsDatabase", throwIfV1Schema: false)
        {
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }
    }
}

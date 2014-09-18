namespace BullsAndCows.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using BullsAndCows.Data;

    public sealed class Configuration : DbMigrationsConfiguration<BullsAndCowsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BullsAndCowsDbContext context)
        {
        }
    }
}

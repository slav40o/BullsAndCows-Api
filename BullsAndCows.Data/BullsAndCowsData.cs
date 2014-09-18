namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;

    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class BullsAndCowsData : IBullsAndCowsData
    {
        private BullsAndCowsDbContext context;
        private IDictionary<Type, object> repositories;

        public BullsAndCowsData()
            : this(new BullsAndCowsDbContext())
        {
        }

        public BullsAndCowsData(BullsAndCowsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Player> Players
        {
            get { return this.GetRepository<Player>(); }
        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                if (!this.repositories.ContainsKey(type))
                {
                    var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                    this.repositories.Add(type, newRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}

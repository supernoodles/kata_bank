namespace Session8
{
    using System.Collections.Generic;

    public class Repository : IRepository
    {
        private IPersistance persistance;

        public Repository(IPersistance persistance)
        {
            this.persistance = persistance;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return persistance.GetAll();
        }

        public void Store(Transaction expectedTransaction)
        {
            persistance.Store(expectedTransaction);
        }
    }
}
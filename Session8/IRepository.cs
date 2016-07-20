using System.Collections.Generic;

namespace Session8
{
    public interface IRepository
    {
        void Store(Transaction expectedTransaction);
        IEnumerable<Transaction> GetAll();
    }
}
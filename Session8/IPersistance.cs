namespace Session8
{
    using System.Collections.Generic;

    public interface IPersistance
    {
        void Store(Transaction transaction);
        IEnumerable<Transaction> GetAll();
    }
}
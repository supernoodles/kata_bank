namespace Session8
{
    using System.Collections.Generic;

    public interface IStatementPrinter
    {
        void PrintTransactions(IEnumerable<Transaction> transactions);
    }
}
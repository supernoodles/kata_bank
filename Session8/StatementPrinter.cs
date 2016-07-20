namespace Session8
{
    using System.Collections.Generic;

    public class StatementPrinter : IStatementPrinter
    {
        private IConsole console;

        public StatementPrinter(IConsole console)
        {
            this.console = console;
        }

        public void PrintTransactions(IEnumerable<Transaction> transactions)
        {
            console.Print("DATE AMOUNT BALANCE");

            var balance = 0;

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
                console.Print(string.Format("{0} {1} {2}", transaction.Date, transaction.Amount, balance));
            }
        }
    }
}
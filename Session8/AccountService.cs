namespace Session8
{
    public class AccountService
    {
        private readonly IRepository repository;

        private readonly IClock clock;

        private readonly IStatementPrinter statementPrinter;

        public AccountService(IRepository repository, IClock clock, IStatementPrinter statementPrinter)
        {
            this.repository = repository;
            this.clock = clock;
            this.statementPrinter = statementPrinter;
        }

        public void Add(int amount)
        {
            var transaction = new Transaction(clock.Now(), amount);

            repository.Store(transaction);
        }

        public void Withdraw(int amount)
        {
            var transaction = new Transaction(clock.Now(), amount * -1);

            repository.Store(transaction);
        }

        public void PrintStatement()
        {
            statementPrinter.PrintTransactions(repository.GetAll());
        }
    }
}
namespace Session8Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Session8;

    [TestFixture]
    public class AccountServiceShould
    {
        private Mock<IRepository> repositoryMock;
        private Mock<IClock> clockMock;
        private Mock<IStatementPrinter> statementPrinterMock;

        private AccountService accountService;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>();

            clockMock = new Mock<IClock>();

            statementPrinterMock = new Mock<IStatementPrinter>();

            accountService = new AccountService(repositoryMock.Object, clockMock.Object, statementPrinterMock.Object);
        }

        [Test]
        public void PeristADepositTransaction()
        {
            var expectedTransaction = new Transaction("01/05/2014", 100);

            clockMock.Setup(c => c.Now()).Returns("01/05/2014");

            accountService.Add(100);

            repositoryMock.Verify(r => r.Store(expectedTransaction));
        }

        [Test]
        public void PersistAWithdrawalTransaction()
        {
            var expectedTransaction = new Transaction("03/07/2015", -200);

            clockMock.Setup(c => c.Now()).Returns("03/07/2015");

            accountService.Withdraw(200);

            repositoryMock.Verify(r => r.Store(expectedTransaction));
        }

        [Test]
        public void PrintTransactionStatement()
        {
            accountService.PrintStatement();

            statementPrinterMock.Verify(s => s.PrintTransactions(It.IsAny<IEnumerable<Transaction>>()));
        }
    }
}

namespace Session8Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Session8;

    [TestFixture]
    public class AcceptanceTests
    {
        private Mock<IConsole> consoleMock;
        private AccountService accountService;

        [SetUp]
        public void Setup()
        {
            consoleMock = new Mock<IConsole>();
            var clockMock = new Mock<IClock>();
            clockMock.SetupSequence(c => c.Now())
                .Returns("01/04/2014")
                .Returns("02/04/2014")
                .Returns("06/04/2014");

            var statementPrinter = new StatementPrinter(consoleMock.Object);

            var peristanceMock = new Mock<IPersistance>();
            var store = new List<Transaction>();
            peristanceMock.Setup(p => p.Store(It.IsAny<Transaction>())).Callback<Transaction>(t => store.Add(t));
            peristanceMock.Setup(p => p.GetAll()).Returns(store);

            var repository = new Repository(peristanceMock.Object);

            accountService = new AccountService(repository, clockMock.Object, statementPrinter);
        }

        [Test]
        public void Test1()
        {
            accountService.Add(1000);
            accountService.Withdraw(100);
            accountService.Add(500);

            accountService.PrintStatement();

            consoleMock.Verify(c => c.Print("DATE AMOUNT BALANCE"));
            consoleMock.Verify(c => c.Print("01/04/2014 1000 1000"));
            consoleMock.Verify(c => c.Print("02/04/2014 -100 900"));
            consoleMock.Verify(c => c.Print("06/04/2014 500 1400"));
        }
    }
}

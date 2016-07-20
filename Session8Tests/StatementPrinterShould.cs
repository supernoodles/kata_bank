namespace Session8Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Session8;

    [TestFixture]
    public class StatementPrinterShould
    {
        private Mock<IConsole> consoleMock;

        private StatementPrinter statementPrinter;

        [SetUp]
        public void Setup()
        {
            consoleMock = new Mock<IConsole>();

            statementPrinter = new StatementPrinter(consoleMock.Object);
        }

        [Test]
        public void PrintStatementHeader()
        {
            statementPrinter.PrintTransactions(new List<Transaction>());

            consoleMock.Verify(c => c.Print("DATE AMOUNT BALANCE"));
        }

        [Test]
        public void PrintDepositTransaction()
        {
            var transactions = new List<Transaction> { new Transaction("10/04/2015", 100) };

            statementPrinter.PrintTransactions(transactions);

            consoleMock.Verify(c => c.Print("10/04/2015 100 100"));
        }

        [Test]
        public void PrintTwoDepositTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("10/04/2015", 100),
                new Transaction("20/06/2016", 200)
            };

            statementPrinter.PrintTransactions(transactions);

            consoleMock.Verify(c => c.Print("10/04/2015 100 100"));
            consoleMock.Verify(c => c.Print("20/06/2016 200 300"));
        }

        [Test]
        public void PrintWithdrawalTransaction()
        {
            var transactions = new List<Transaction> { new Transaction("10/04/2015", -100) };

            statementPrinter.PrintTransactions(transactions);

            consoleMock.Verify(c => c.Print("10/04/2015 -100 -100"));
        }

        [Test]
        public void PrintTwoWithdrawalTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("10/04/2015", -100),
                new Transaction("12/05/2015", -250)
            };

            statementPrinter.PrintTransactions(transactions);

            consoleMock.Verify(c => c.Print("10/04/2015 -100 -100"));
            consoleMock.Verify(c => c.Print("12/05/2015 -250 -350"));
        }

        [Test]
        public void PrintMixedTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("10/04/2015", 250),
                new Transaction("12/05/2015", -100)
            };

            statementPrinter.PrintTransactions(transactions);

            consoleMock.Verify(c => c.Print("10/04/2015 250 250"));
            consoleMock.Verify(c => c.Print("12/05/2015 -100 150"));
        }
    }
}

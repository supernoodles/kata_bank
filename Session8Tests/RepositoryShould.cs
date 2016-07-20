namespace Session8Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Session8;

    [TestFixture]
    public class RepositoryShould
    {
        private Mock<IPersistance> persistanceMock;

        private Repository repository;

        [SetUp]
        public void Setup()
        {
            persistanceMock = new Mock<IPersistance>();

            repository = new Repository(persistanceMock.Object);
        }

        [Test]
        public void StoreATransactionToPersistanceLayer()
        {
            var transaction = new Transaction("01/02/1965", 100);

            repository.Store(transaction);

            persistanceMock.Verify(p => p.Store(transaction));
        }

        [Test]
        public void RetrieveAllTransactionsFromPersistanceLayer()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("10/05/2015", 100),
                new Transaction("09/12/2016", -200)
            };

            persistanceMock.Setup(p => p.GetAll()).Returns(transactions);

            Assert.That(repository.GetAll(), Is.EqualTo(transactions));
        }
    }
}

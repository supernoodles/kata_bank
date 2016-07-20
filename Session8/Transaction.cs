namespace Session8
{
    public class Transaction
    {
        public string Date { get; private set; }

        public int Amount { get; private set; }

        public Transaction(string date, int amount)
        {
            Date = date;
            Amount = amount;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Transaction;

            return Date.Equals(other.Date) && Amount.Equals(other.Amount);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = 23 * hash + Date.GetHashCode();
            hash = 23 * hash + Amount.GetHashCode();
            return hash;
        }
    }
}
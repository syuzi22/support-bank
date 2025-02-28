namespace SupportBank
{
    public class Transaction(DateTime transactionDate, string fromPerson, string toPerson, string narrative, int amount)
    {
        public DateTime TransactionDate { get; } = transactionDate;
        public string FromPerson { get; } = fromPerson;
        public string ToPerson { get; } = toPerson;
        public string Narrative { get; } = narrative;
        public int Amount { get; } = amount;
    }
}

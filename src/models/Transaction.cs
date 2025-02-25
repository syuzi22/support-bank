namespace SupportBank
{
    public class Transaction(DateTime transactionDate, Guid fromPersonID, Guid toPersonID, string narrative, int amount)
    {
        public DateTime TransactionDate { get; set; } = transactionDate;
        public Guid FromPersonID { get; set; } = fromPersonID;
        public Guid ToPersonID { get; set; } = toPersonID;
        public string Narrative { get; set; } = narrative;
        public int Amount { get; set; } = amount;
    }
}

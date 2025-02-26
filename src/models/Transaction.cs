namespace SupportBank
{
    public class Transaction(DateTime transactionDate, string fromPerson, string toPerson, string narrative, int amount)
    {
        public DateTime TransactionDate { get; set; } = transactionDate;
        public string FromPerson { get; set; } = fromPerson;
        public string ToPerson { get; set; } = toPerson;
        public string Narrative { get; set; } = narrative;
        public int Amount { get; set; } = amount;

        public static List<Transaction> CreateTransactionList(List<string> fileLines)
        {
            List<Transaction> transactions = [];
            for (var i = 1; i < fileLines.Count; i++) {
                string[] transactionParts = fileLines[i].Split(",");
                
                Transaction transaction = new Transaction(
                    Convert.ToDateTime(transactionParts[0]),
                    transactionParts[1],
                    transactionParts[2],
                    transactionParts[3],
                    AmountConversion.ConvertPoundToPence(transactionParts[4])                 
                );
                transactions.Add(transaction);

            }
            return transactions;
        }
    }
}

namespace SupportBank
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "./data/Transactions2014.csv";
            List<string> fileLines = CSVReader.ReadFile(filePath);
            List<Transaction> transactions = TransactionService.CreateTransactionList(fileLines);
            Dictionary<string, Person> personList = PersonService.CreatePersonList(transactions);
            ConsoleApp.Run(personList);
        }
    }
}



namespace SupportBank
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "./data/Transactions2014.csv";
            List<string> fileLines = CSVReader.ReadFile(filePath);
            List<Transaction> transactions = CSVReader.CreateTransactionList(fileLines);
            SupportBank supportBank = new();
            supportBank.CreatePersonList(transactions);
            ConsoleApp.Run(supportBank.personList);
        }
    }
}

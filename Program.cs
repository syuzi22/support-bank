namespace SupportBank
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "./data/Transactions2014.csv";
            List<string> fileLines = CSVReader.ReadFile(filePath);
            List<Transaction> transactions = Transaction.CreateTransactionList(fileLines);
            List<Person> personList = Person.CreatePersonList(transactions);

            while (true)
            {
                Console.WriteLine("\n Please enter your command: List All, List [Account] or Exit");
                string command = Console.ReadLine() ?? "";
                Person? account = Person.GetPersonAccountFromInput(command, personList);
                if (command == "List All")
                {
                    Printer.PrintPeople(personList);
                }
                else if (account != null)
                {
                    Printer.PrintAccount(account);
                }
                else if (command.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}



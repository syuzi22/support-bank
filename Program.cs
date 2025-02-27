using NLog;
using NLog.Config;
using NLog.Targets;
namespace SupportBank
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "./data/Transactions2014.csv";
            // string filePath = "./data/DodgyTransactions2015.csv";
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            try
            {
                if (CSVReader.ValidateCSVFile(filePath))
                {
                    List<string> fileLines = CSVReader.ReadFile(filePath);
                    List<Transaction> transactions = CSVReader.CreateTransactionList(fileLines);
                    SupportBank supportBank = new();
                    supportBank.CreatePersonList(transactions);
                    ConsoleApp.Run(supportBank.personList);
                }
                else
                {
                    throw new FormatException("CSV file is not in a proper format.");
                }
            }
            catch (FormatException)
            {
                throw;
            }

        }
    }
}

using NLog;
using NLog.Config;
using NLog.Targets;
namespace SupportBank
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            string filePath = "./data/Transactions2014.csv";
            //string filePath = "./data/DodgyTransactions2015.csv";
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            try
            {
                Logger.Debug("Application started.");
                List<string> fileLines = CSVReader.ReadFile(filePath)??
                     throw new FormatException("CSV file is not in a proper format.");
                List<Transaction> transactions = CSVReader.CreateTransactionList(fileLines);
                if (transactions.Count == 0)
                {
                    Logger.Warn("No transactions present.");
                }
                else
                {
                    Logger.Debug("Transactions created successfully.");
                }
                SupportBank supportBank = new();
                supportBank.CreatePersonList(transactions);
                Logger.Debug("Personlist created successfully.");
                ConsoleApp.Run(supportBank.personList);
                Logger.Debug("Application ended successfully.");

            }
            catch (FormatException)
            {
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

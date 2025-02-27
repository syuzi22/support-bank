using System.Runtime.InteropServices;
using System.Globalization;
using NLog;

namespace SupportBank
{
    class CSVReader
    {

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static bool ValidateCSVFile(string filePath)
        {

            List<string> fileLines = ReadFile(filePath);
            bool isValid = true;

            for (int line = 1; line < fileLines.Count; line++)
            {
                string[] lineParts = fileLines[line].Split(",");
                string logMessage = $" was not recognized as a valid value in the file {filePath} at line number {line + 1}";
                if (!DateTime.TryParse(lineParts[0], out DateTime parsedDate))
                {
                    Logger.Error($" '{lineParts[0]}' {logMessage}");
                    isValid = false;

                }
                if (!decimal.TryParse(lineParts[4], NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal amount))
                {
                    Logger.Error($" '{lineParts[4]}' {logMessage}");
                    isValid = false;
                }
            }
            return isValid;

        }
        public static List<string> ReadFile(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line;
            List<string> lines = [];

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            return lines;

        }
        public static List<Transaction> CreateTransactionList(List<string> fileLines)
        {
            List<Transaction> transactions = [];

            for (var i = 1; i < fileLines.Count; i++)
            {
                string[] transactionParts = fileLines[i].Split(",");

                Transaction transaction = new Transaction(
                    Convert.ToDateTime(transactionParts[0]),
                    transactionParts[1],
                    transactionParts[2],
                    transactionParts[3],
                    AmountConversion.ConvertPoundToPence((transactionParts[4]))
                );
                transactions.Add(transaction);
            }
            return transactions;
        }
    }
}

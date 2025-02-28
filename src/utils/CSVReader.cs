using System.Runtime.InteropServices;
using System.Globalization;
using NLog;
using System.Reflection.Metadata.Ecma335;

namespace SupportBank
{
    class CSVReader
    {

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static List<string>? ReadFile(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line;
            List<string> lines = [];
            int lineNumber = 0;
            bool isValid = true;
            Console.WriteLine(Path.GetExtension(filePath));
            if(!Path.GetExtension(filePath).Equals(".csv",StringComparison.OrdinalIgnoreCase))
            {   
                throw new Exception("File extension is not csv.");
            }

            while ((line = reader.ReadLine()) != null)
            {
                if (!(lineNumber == 0))//Skip Header
                {
                    try
                    {
                        string[] lineParts = line.Split(",");
                        if (!DateTime.TryParse(lineParts[0], out DateTime parsedDate))
                        {
                            Logger.Error($" '{lineParts[0]}' was not recognized as a valid value in the file {filePath} at line number {line + 1} ");
                            isValid = false;

                        }
                        if (!decimal.TryParse(lineParts[4], NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal amount))
                        {
                            Logger.Error($" '{lineParts[4]}' was not recognized as a valid value in the file {filePath} at line number {line + 1}");
                            isValid = false;
                        }
                        if (String.IsNullOrEmpty(lineParts[1]) || String.IsNullOrEmpty(lineParts[2]))
                        {
                            Logger.Error("FromName/ToName is empty in the file.");
                            isValid = false;
                        }
                        if (isValid)
                        {
                            lines.Add(line);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Logger.Error("Number of columns doesn't meet the requirement.");
                        throw;
                    }                    

                }
                lineNumber++;
            }
             return isValid? lines : null;
        }
           

        public static List<Transaction> CreateTransactionList(List<string> fileLines)
        {
            List<Transaction> transactions = [];

            foreach (var line in fileLines)
            {
                string[] transactionParts = line.Split(",");

                Transaction transaction = new(
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

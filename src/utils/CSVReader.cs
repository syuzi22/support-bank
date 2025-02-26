namespace SupportBank
{
    class CSVReader
    {

        public static void ReadFile(string filePath, List<Transaction> transactions,Dictionary<string, Person> personList)
        {
            
            using StreamReader reader = new(filePath);
            string? line;
            List<string> lines = [];
            
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            parseFile(lines, transactions, personList);
        }

        public static void parseFile(List<string> lines, List<Transaction> transactions,Dictionary<string, Person> personList) {
            for (var i = 1; i < lines.Count; i++) {
                string[] transactionParts = lines[i].Split(",");
                string name1 = transactionParts[1];
                string name2 = transactionParts[2];


                if (!personList.TryGetValue(name1, out Person? value))
                {
                    value = new Person(name1);
                    personList.Add(name1, value);
                }

                if (!personList.TryGetValue(name2, out value))
                {
                    value = new Person(name2);
                    personList.Add(name2, value);
                }

                Transaction transaction = new Transaction(
                    Convert.ToDateTime(transactionParts[0]),
                    personList[name1].PersonId,
                    personList[name2].PersonId,
                    transactionParts[3],
                    Amount.ConvertPoundToPence(transactionParts[4])                 
                );
                transactions.Add(transaction);

            }
        }
    }
}

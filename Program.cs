using System;
using System.Data.Common;
using System.IO;

namespace SupportBank
{
    class Program
    {

        public static void Main(string[] args)
        {
            List<Transaction> transactions = [];
            Dictionary<string, Person> personList = [];
            string filePath = "./data/Transactions2014.csv";
            CSVReader.ReadFile(filePath, transactions, personList);
            List<string> debtList = DebtDataBuilder.BuildDebtList(personList,transactions);
            Printer.PrintPeople(debtList);
            // Printer.PrintDictionary(personList, transactions);
            // DebtDataBuilder
        }
    }
}



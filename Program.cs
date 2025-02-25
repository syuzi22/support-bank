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
            Dictionary<Person,Transaction> personTransactionDetails = new Dictionary<Person, Transaction>();
            // Printer.PrintDictionary(personList, transactions);
        }
    }
}



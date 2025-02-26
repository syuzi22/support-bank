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
            List<Person> personList = [];

            string filePath = "./data/Transactions2014.csv";
            List<string> fileLines = CSVReader.ReadFile(filePath);
            transactions = Transaction.CreateTransactionList(fileLines);
            personList = Person.CreatePersonList(transactions);
            Printer.PrintAccount(personList[0]);        
        }
    }
}



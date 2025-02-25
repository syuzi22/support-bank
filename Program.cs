// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

namespace SupportBank {
    class Program {
        public static void Main(string[] args) {
            string filePath = "./data/Transactions2014.csv";
            List<string> transactions = [];
            CSVReader.ReadFIle(filePath, transactions);
            Printer.PrintList(transactions);
        }
    }

    class CSVReader {
        public static void ReadFIle(string filePath, List<string> transactions) {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    transactions.Add(line);
                }
            }
        }
    }

    class Printer {
        public static void PrintList(List<string> list) {
            list.ForEach(listItem => Console.WriteLine(listItem));
        }
    }
}

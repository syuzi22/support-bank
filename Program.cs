using System;
using System.Data.Common;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static List<string> transactions = [];
        public static void Main(string[] args)
        {
            string filePath = "./data/Transactions2014.csv";
            CSVReader.ReadFIle(filePath, transactions);
            Dictionary<string, Person> personList = CreatePersonList();
            Printer.PrintDictionary(personList);
        }

        public static Dictionary<string, Person> CreatePersonList()
        {
            Dictionary<string, Person> personList = [];
            for (int i = 1; i < transactions.Count; i++)
            {
                string[] transactionParts = transactions[i].Split(",");
                string name1 = transactionParts[1];
                string name2 = transactionParts[2];
               
                if (!personList.TryGetValue(name1, out Person? value))
                {
                    value = new Person(name1);
                    personList.Add(name1, value);
                }

                value.Owes += Amount.ConvertPoundToPence(transactionParts[4]);

                if (!personList.TryGetValue(name2, out value))
                {
                    value = new Person(name2);
                    personList.Add(name2, value);
                }

                value.IsOwed += Amount.ConvertPoundToPence(transactionParts[4]);
            }

            return personList;
        }
    }

    class CSVReader
    {
        public static void ReadFIle(string filePath, List<string> transactions)
        {
            using StreamReader reader = new(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                transactions.Add(line);
            }
        }
    }

    class Printer
    {
        public static void PrintList(List<string> list)
        {
            list.ForEach(listItem => Console.WriteLine(listItem));
        }

        public static void PrintDictionary(Dictionary<string, Person> dictionary)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-15}", "Name", "Owes", "IsOwed");
            Console.WriteLine("============================================");
            foreach (var value in dictionary.Values)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15}", value.Name, Amount.ConvertPenceToPound(value.Owes), Amount.ConvertPenceToPound(value.IsOwed));
            }
        }
    }

    class Person
    {
        public Guid PersonId { get; set; }
        public string? Name { get; set; }
        public int Owes { get; set; }
        public int IsOwed { get; set; }

        public Person(string name)
        {
            PersonId = Guid.NewGuid();
            Name = name;
        }

    }

    class Amount
    {
        public static int ConvertPoundToPence(string pound)
        {
            return Convert.ToInt32(Math.Round(Convert.ToDouble(pound), 2) * 100);
        }
        public static double ConvertPenceToPound(int pence)
        {
            return Convert.ToDouble(pence / 100.0);
        }
    }
}



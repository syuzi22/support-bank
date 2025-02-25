namespace SupportBank
{
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
}
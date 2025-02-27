namespace SupportBank
{
    class Printer
    {
        public static void PrintPeople(Dictionary<string, Person> personList)
        {
            string formatString = "{0,-15} {1,-15} {2,-15}";
            Console.WriteLine(formatString, "Name", "Owes", "IsOwed");
            Console.WriteLine("============================================");
            foreach (var person in personList.Values)
            {
                int owes = person.GetPersonOwes();
                int isOwed = person.GetPersonIsOwed();

                Console.WriteLine(formatString, person.Name, 
                AmountConversion.ConvertPenceToPound(owes), 
                AmountConversion.ConvertPenceToPound(isOwed));
            }
        }

        public static void PrintAccount(Person person){
            string formatString = "{0,-15} {1,-30} {2,-15} {3,-15}";
            Console.WriteLine(formatString, "Date", "Narrative", "To", "Amount");
            Console.WriteLine("=====================================================================");
            foreach (var transaction in person.Transactions.Where(t=> t.FromPerson == person.Name))
            {
                Console.WriteLine(formatString, transaction.TransactionDate.ToString("yyyy-MM-dd"), 
                transaction.Narrative, 
                transaction.ToPerson,
                AmountConversion.ConvertPenceToPound(transaction.Amount));              
            }
        }
    }
}
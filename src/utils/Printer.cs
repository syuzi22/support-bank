namespace SupportBank
{
    class Printer
    {
        public static void PrintPeople(List<Person> list)
        {
            
            Console.WriteLine("{0,-15} {1,-15} {2,-15}", "Name", "Owes", "IsOwed");
            Console.WriteLine("============================================");
            int owes ;
            int isOwed;
            foreach (var value in list)
            {
                owes = value.Transactions.Where(t=>t.FromPerson ==value.Name).Sum(s=>s.Amount);
                isOwed = value.Transactions.Where(t=>t.ToPerson ==value.Name).Sum(s=>s.Amount);

                Console.WriteLine("{0,-15} {1,-15} {2,-15}", value.Name, 
                AmountConversion.ConvertPenceToPound(owes), 
                AmountConversion.ConvertPenceToPound(isOwed));
            }
        }

        public static void PrintAccount(Person person){
            Console.WriteLine("{0,-15} {1,-30} {2,-15} {3,-15}", "Date", "Narrative", "To", "Amount");
            Console.WriteLine("=====================================================================");
            foreach (var item in person.Transactions.Where(t=> t.FromPerson == person.Name))
            {
                Console.WriteLine("{0,-15} {1,-30} {2,-15} {3,-15}", item.TransactionDate.ToString("yyyy-MM-dd"), 
                (item.Narrative), 
                (item.ToPerson),
                AmountConversion.ConvertPenceToPound(item.Amount));              
            }
        }
    }
}
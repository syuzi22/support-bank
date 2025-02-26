namespace SupportBank
{
    class Printer
    {
        public static void PrintPeople(List<string> list)
        {
            
            Console.WriteLine("{0,-15} {1,-15} {2,-15}", "Name", "Owes", "IsOwed");
            Console.WriteLine("============================================");
            foreach (var value in list)
            {
                
                Console.WriteLine("{0,-15} {1,-15} {2,-15}", value.Split(",")[0], 
                Amount.ConvertPenceToPound(value.Split(",")[1]), 
                Amount.ConvertPenceToPound(value.Split(",")[2]));
            }
        }
    }
}
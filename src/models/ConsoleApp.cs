using System.Text.RegularExpressions;

namespace SupportBank
{
    public class ConsoleApp()
    {
        public static void Run(Dictionary<string, Person> personList)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\n Please enter one of the following commands: List All, List [Account] or Exit");
                string command = Console.ReadLine() ?? "";
                switch (true)
                {
                    case bool when command.Contains("List All", StringComparison.CurrentCultureIgnoreCase):
                        Printer.PrintPeople(personList);
                        break;
                    case bool when command.Contains("List", StringComparison.CurrentCultureIgnoreCase):
                        Person? account = GetPersonAccountFromInput(command, personList);
                        if (account != null)
                        {
                            Printer.PrintAccount(account);
                        }
                        else
                        {
                            Console.WriteLine("Account doesn't exist.");
                        }
                        break;
                    case bool when command.Contains("exit", StringComparison.CurrentCultureIgnoreCase):
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;

                }
            }
        }

        private static Person? GetPersonAccountFromInput(string input, Dictionary<string, Person> personList)
        {
            string pattern = @"List (.+)";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string name = match.Groups[1].Value;
                if (!personList.TryGetValue(name, out Person? person))
                {
                    return null;
                }
                return person;
            }
            else
            {                
                return null;
            }
        }
    }
}
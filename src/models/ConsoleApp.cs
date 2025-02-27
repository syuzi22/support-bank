using System.Text.RegularExpressions;

namespace SupportBank {
    public class ConsoleApp() {
        public static void Run(Dictionary<string, Person> personList) {
            while (true)
                {
                    Console.WriteLine("\n Please enter your command: List All, List [Account] or Exit");
                    string command = Console.ReadLine() ?? "";
                    Person? account = GetPersonAccountFromInput(command, personList);
                    if (command == "List All")
                    {
                        Printer.PrintPeople(personList);
                    }
                    else if (account != null)
                    {
                        Printer.PrintAccount(account);
                    }
                    else if (command.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }

                    // What if account==null - can we give the user some useful info 
                    // if they've tried to do list for an account that doesn't exist before sending them back around the loop?

                }
        }

        private static Person? GetPersonAccountFromInput(string input, Dictionary<string, Person> personList) {
            string pattern = @"List (.+)";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string name =  match.Groups[1].Value;
                if (!personList.TryGetValue(name, out Person? person)) {
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
using NLog;

namespace SupportBank
{
    class SupportBank
    {
        public readonly Dictionary<string, Person> personList =[]; 
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public void CreatePersonList(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                UpdatePersonTransactions(transaction.FromPerson, personList, transaction);
                UpdatePersonTransactions(transaction.ToPerson, personList, transaction);
            }    
            if(personList.Count ==0)
            {
                Logger.Warn("Personlist is empty.");
            }
        }
  
        private void UpdatePersonTransactions(string personName, Dictionary<string, Person> personList, Transaction transaction)
        {
            if (!personList.TryGetValue(personName, out Person? person))
            {
                person = new Person(personName);
                personList.Add(personName, person);
            }
            person.Transactions.Add(transaction);
        }
    }

}
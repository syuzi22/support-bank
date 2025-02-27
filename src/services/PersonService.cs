namespace SupportBank {
    class PersonService {
        public static Dictionary<string, Person> CreatePersonList(List<Transaction> transactions)
        {
            Dictionary<string, Person> personList = [];
            foreach (var transaction in transactions)
            {
                // to think about doubling
                string fromPersonName = transaction.FromPerson;
                string toPersonName = transaction.ToPerson;
                
                if (!personList.TryGetValue(fromPersonName, out Person? fromPerson)) {
                    fromPerson = new Person(fromPersonName);
                    personList.Add(fromPersonName, fromPerson);
                }
                fromPerson.Transactions.Add(transaction);

                if (!personList.TryGetValue(toPersonName, out Person? toPerson)) {
                    toPerson = new Person(toPersonName);
                    personList.Add(toPersonName, toPerson);
                }
                toPerson.Transactions.Add(transaction);
            }
            return personList;
        }
    }
}
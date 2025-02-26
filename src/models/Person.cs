namespace SupportBank
{
    public class Person(string name)
    {
        public Guid PersonId { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = name;
        public List<Transaction> Transactions { get; set; } = [];

        public static List<Person> CreatePersonList(List<Transaction> transactions)
        {
            List<Person> personList = [];
            foreach (var item in transactions)
            {
                Person person;

                if (!personList.Any(p => p.Name == item.FromPerson))
                {
                    person = new Person(item.FromPerson);
                    person.Transactions.Add(item);
                    personList.Add(person);

                }
                else
                {
                    personList.Find(p => p.Name == item.FromPerson)?.Transactions.Add(item);
                }

                if (!personList.Any(p => p.Name == item.ToPerson))
                {
                    person = new Person(item.ToPerson);
                    person.Transactions.Add(item);
                    personList.Add(person);

                }
                else
                {
                    personList.Find(p => p.Name == item.ToPerson)?.Transactions.Add(item);
                }

            }
            return personList;
        }
    }
}
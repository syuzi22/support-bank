namespace SupportBank
{
    public class Person(string name)
    {
        public string? Name { get; } = name;
        public List<Transaction> Transactions { get; } = [];

        public int GetPersonOwes() {
            return Transactions.Where(t=>t.FromPerson ==Name).Sum(s=>s.Amount);
        }

        public int GetPersonIsOwed() {
            return Transactions.Where(t=>t.ToPerson ==Name).Sum(s=>s.Amount);
        }
    }
}
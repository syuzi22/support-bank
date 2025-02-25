 namespace SupportBank
{
    class Person(string name)
    {
        public Guid PersonId { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = name;
        public int Owes { get; set; }
        public int IsOwed { get; set; }
    }
}
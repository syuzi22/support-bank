namespace SupportBank
{

    class DebtDataBuilder
    {

        public static List<string> BuildDebtList(Dictionary<string,Person> personList, List<Transaction> transactions)
        {
            List<string> debtList = [];
            foreach (var item in personList.Values)
            {
                int owes = transactions.Where(t=>t.FromPersonID == item.PersonId).Sum(t => t.Amount);
                int isOwed = transactions.Where(t=>t.ToPersonID == item.PersonId).Sum(t => t.Amount);
                debtList.Add(item.Name +"," + owes + "," + isOwed);
            }
            return debtList;
        }
    }
}
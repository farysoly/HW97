namespace HW97.Models
{
    public class AccountingRepository : Repository
    {
        public double SetAccountingRamein()
        {
            var accountingList = GetDb<AccountingModel>();
            var debitSum = accountingList.Sum(c => c.Debit);
            var creditSum = accountingList.Sum(c => c.Credit);
            return debitSum - creditSum;
        }
    }
}

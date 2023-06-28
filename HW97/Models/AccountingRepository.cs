namespace HW97.Models
{
    public class AccountingRepository : Repository
    {
        public double SetAccountingRamein()
        {
            AccountingModel accountingModel = new AccountingModel();
            var accountingList = GetDb(accountingModel);
            var debitSum = accountingList.Sum(c => c.Debit);
            var creditSum = accountingList.Sum(c => c.Credit);
            return debitSum - creditSum;
        }
    }
}

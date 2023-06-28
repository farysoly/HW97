namespace HW97.Models
{
    public class AccountingRepository : Repository<AccountingModel>
    {
        public double GetAccountingRamein()
        {
            AccountingModel accountingModel = new AccountingModel();
            var accountingList = GetDb();
            var debitSum = accountingList.Sum(c => c.Debit);
            var creditSum = accountingList.Sum(c => c.Credit);
            return debitSum - creditSum;
        }
    }
}

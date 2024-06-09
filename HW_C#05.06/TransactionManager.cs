using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C_05._06
{
    public class TransactionManager
    {
        public decimal AverageTransaction<T>(IEnumerable<T> transactions, DateTime start, DateTime stop) where T : ITransaction
        {
            var FilteredTransaction = transactions.Where(t => t.Date >= start && t.Date <= stop);
            if(!FilteredTransaction.Any())
            {
                throw new Exception("Нет транзакций в данном интервале.");
            }
            decimal totalAmount = FilteredTransaction.Sum(t => t.Amount);
            int transactionCount = FilteredTransaction.Count();
            return totalAmount / transactionCount;
        }
    }
}

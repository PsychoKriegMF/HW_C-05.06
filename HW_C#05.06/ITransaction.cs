using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C_05._06
{
    public interface ITransaction
    {
        int TransactionId { get; }
        decimal Amount {  get; }
        DateTime Date { get; }
    }
}

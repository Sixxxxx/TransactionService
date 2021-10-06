using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsService.Models
{
    public class Transaction
    {
        public Transaction()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
        }
        public string Id { get; private set; }
        public string ClientId { get; private set; }
        public string WalletAddress { get; private set; }
        public string RecieverWalletAddress { get; private set; }
        public string CurrencyType { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}

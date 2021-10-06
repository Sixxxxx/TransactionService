using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionsService.Models;

namespace TransactionsService.Interfaces
{
    public interface ITransaction
    {
        Task<Transaction> GetTransaction(string TransactionId);
        Task<bool> DoesTransactionExist(string ClientId, string WalletAddress, string RecieverWalletAddress, DateTime DateCreated);
        Task<bool> CreateTransaction(Transaction transaction);
    }
}

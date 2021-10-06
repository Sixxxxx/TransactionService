using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TransactionsService.Database;
using TransactionsService.Interfaces;
using TransactionsService.Models;

namespace TransactionsService.Repositories
{
    public class TransactionRepository : ITransaction
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public TransactionRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> DoesTransactionExist(string ClientId, string WalletAddress, string RecieverWalletAddress, DateTime DateCreated) => await _applicationDbContext.Transactions.AnyAsync(t => t.ClientId == ClientId && t.WalletAddress == WalletAddress && t.RecieverWalletAddress == RecieverWalletAddress && t.DateCreated == DateCreated);


        public async Task<Transaction> GetTransaction(string TransactionId) => await _applicationDbContext.Transactions.Where(t => t.Id == TransactionId).SingleOrDefaultAsync();
        public async Task<bool> CreateTransaction(Transaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return false;
                }

                _applicationDbContext.Transactions.Add(transaction);
                await _applicationDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

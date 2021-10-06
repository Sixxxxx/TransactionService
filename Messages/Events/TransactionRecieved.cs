using System;
using TransactionsService.Interfaces;

namespace TransactionsService.Messages.Events
{
    public class TransactionRecieved : IEvent
    {
        public TransactionRecieved(string clientId, string walletAddress, string RecieverWalletAddress, string currencyType)
        {
            Id = Guid.NewGuid().ToString();
            ClientId = clientId;
            WalletAddress = walletAddress;
            CurrencyType = currencyType;
        }
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string WalletAddress { get; set; }
        public string RecieverWalletAddress { get; set; }
        public string CurrencyType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using TransactionsService.Interfaces;

namespace TransactionsService.Messages.Commands
{
    public class UpdateTransaction : ICommand
    {
        [JsonConstructor]
        public UpdateTransaction(string clientId, string walletAddress, string recieverWalletAddress, string currencyType, DateTime dateCreated)
        {
            Id = Guid.NewGuid().ToString();
            ClientId = clientId;
            WalletAddress = walletAddress;
            RecieverWalletAddress = recieverWalletAddress;
            CurrencyType = currencyType;
            DateCreated = dateCreated;
        }
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string WalletAddress { get; set; }
        public string RecieverWalletAddress { get; set; }
        public string CurrencyType { get; set; }
        public DateTime DateCreated { get; set; }      
    }
}

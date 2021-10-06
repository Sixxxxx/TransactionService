using System;

namespace TransactionsService.Dtos
{
    public class TransactionDtoForCreate
    {
       public string ClientId { get; set; }
       public string WalletAddress { get; set; }
       public string RecieverWalletAddress { get; set; }
       public DateTime DateCreated { get; set; }
       public string CurrencyType { get; set; }
    }
}

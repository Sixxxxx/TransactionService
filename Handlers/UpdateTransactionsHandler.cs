using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TransactionsService.Models;
using TransactionsService.Interfaces;
using TransactionsService.Messages.Events;
using TransactionsService.Messages.Commands;

namespace TransactionsService.Handler
{
    public class UpdateTransactionsHandler : ICommandHandler<UpdateTransaction>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ITransaction _transaction;


        public UpdateTransactionsHandler(IPublisher publisher, IMapper mapper, ILogger logger, ITransaction transaction)
        {
            _publisher = publisher;
            _mapper = mapper;
            _logger = logger;
            _transaction = transaction;
        }


        public async Task HandleAsync(UpdateTransaction command)
        {
            if (command == null)
            {
                _logger.LogError($"Invalid post attempt");

                return;
            }

             //                                                                                                                     //
            //within here you would find logic that checks if the wallet address, clientid and recieverwallet address are all valid//
           //                                                                                                                     //


            var transaction = await _transaction.DoesTransactionExist(command.ClientId, command.WalletAddress, command.RecieverWalletAddress, command.DateCreated);

            if (transaction)
            {
                _logger.LogError($"Transaction with Client Id {command.ClientId} and wallet address {command.WalletAddress} already exists");

                return;
            }

            var transactionToCreate = _mapper.Map<Transaction>(command);

            var res = await _transaction.CreateTransaction(transactionToCreate);

            if (!res)
            {
                _logger.LogInformation($"Transaction failed to create");
            }

            _logger.LogInformation($"Transaction successfully added");

            //Publish event
            await _publisher.PublishAsync(new TransactionRecieved(command.ClientId, command.WalletAddress, command.RecieverWalletAddress, command.CurrencyType));
        }
    }
}

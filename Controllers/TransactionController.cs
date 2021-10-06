using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TransactionsService.Dtos;
using TransactionsService.Messages.Events;
using TransactionsService.Interfaces;
using TransactionsService.Models;

namespace TransactionsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _transaction;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IPublisher _publisher;

        public TransactionController(ITransaction transaction, IMapper mapper, ILogger<TransactionController> logger, IPublisher publisher)
        {
            _transaction = transaction;
            _mapper = mapper;
            _logger = logger;
            _publisher = publisher;
        }

        [HttpGet("GetTransaction/{TransactionId}")]
        public async Task<IActionResult> GetAccountById(string TransactionId)
        {
            if (TransactionId == "")
            {
                return BadRequest();
            }

            var transaction = await _transaction.GetTransaction(TransactionId);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(new { transaction, message = "Transaction returned" });
        }


        [HttpPost("UpdateTransaction")]
        public async Task<IActionResult> CreateTransaction(TransactionDtoForCreate Transaction)
        {
            if (Transaction == null)
            {
                return BadRequest(new { message = "Invalid post attempt" });
            }

             //                                                                                                                     //
            //within Here you would find logic that checks if the wallet address, clientid and recieverwallet address are all valid//
           //                                                                                                                     //

            var transaction = await _transaction.DoesTransactionExist(Transaction.ClientId, Transaction.WalletAddress, Transaction.RecieverWalletAddress, Transaction.DateCreated);
            
            if (transaction)
            {
                return BadRequest(new { response = "301", message = "Transaction already exists" });
            }

            var transactionToCreate = _mapper.Map<Transaction>(Transaction);

            var res = await _transaction.CreateTransaction(transactionToCreate);
            
            if (!res)
            {
                return BadRequest(new { response = "301", message = "Transaction failed to create" });
            }

            _logger.LogInformation($"Transaction successfully added");

            //Publish event
            await _publisher.PublishAsync(new TransactionRecieved(Transaction.ClientId, Transaction.WalletAddress, Transaction.RecieverWalletAddress, Transaction.CurrencyType));

            return Ok(new
            {
                Transaction,
                message = "Transaction successfully created"
            });
        }
    }
}

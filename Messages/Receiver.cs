using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using TransactionsService.Interfaces;
using TransactionsService.Handler;

namespace TransactionsService.Events
{
    public class Receiver : IReceiver
    {
        public Task ReceiveAsync<ICommand>(ICommand command)
        {
            //Do nothing
            return Task.CompletedTask;
        }
    }
}

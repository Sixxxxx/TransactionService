using System.Threading.Tasks;

namespace TransactionsService.Interfaces
{
    public interface IReceiver
    {
        Task ReceiveAsync<ICommand>(ICommand command);
    }
}

using System.Threading.Tasks;

namespace TransactionsService.Interfaces
{
    public interface ICommandHandler<ICommand> 
    {
        Task HandleAsync(ICommand command);
    }
}

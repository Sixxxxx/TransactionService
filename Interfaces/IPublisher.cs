using System.Threading.Tasks;

namespace TransactionsService.Interfaces
{
    public interface IPublisher
    {
        Task PublishAsync<IEvent>(IEvent @event);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionsService.Interfaces;

namespace TransactionsService.Events
{
    public class Publisher : IPublisher
    {
        public Task PublishAsync<IEvent>(IEvent @event) 
        {
            //Do nothing
            return Task.CompletedTask;
        }

       
    }
}
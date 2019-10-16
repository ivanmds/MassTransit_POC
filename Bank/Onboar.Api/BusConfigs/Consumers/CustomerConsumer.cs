using System.Threading.Tasks;
using MassTransit;
using Onboar.Api.Model;

namespace Onboar.Api.BusConfigs.Consumers
{
    public class CustomerConsumer : IConsumer<Customer>
    {
        public Task Consume(ConsumeContext<Customer> context)
        {
            throw new System.NotImplementedException();
        }
    }
}

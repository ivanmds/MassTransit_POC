using System.Threading.Tasks;
using MassTransit;
using Onboar.Api.Model;

namespace Onboar.Api.BusConfigs.Consumers
{
    public class CustomerConsumer : IConsumer<Customer>
    {
        public Customer Result { get; private set; }
        public async Task Consume(ConsumeContext<Customer> context)
        {
            Result = await Task.FromResult(context.Message);
        }
    }
}

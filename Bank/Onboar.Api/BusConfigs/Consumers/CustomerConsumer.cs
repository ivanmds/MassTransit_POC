using System.Threading.Tasks;
using MassTransit;
using Onboar.Api.Model;

namespace Onboar.Api.BusConfigs.Consumers
{
    public class CustomerConsumer : IConsumer<ICustomer>
    {
        public Task Consume(ConsumeContext<ICustomer> context)
        {
            throw new System.NotImplementedException();
        }
    }
}

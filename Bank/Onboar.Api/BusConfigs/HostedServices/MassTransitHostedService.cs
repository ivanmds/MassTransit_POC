using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Onboar.Api.BusConfigs.HostedServices
{
    public class MassTransitHostedService : IHostedService
    {
        private readonly IBusControl _bus;

        public MassTransitHostedService(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _bus.StopAsync(cancellationToken);
        }
    }
}

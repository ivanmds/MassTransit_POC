using MassTransit;
using Microsoft.Extensions.Hosting;
using Onboar.Api.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Onboar.Api.BusConfigs.HostedServices
{
    public class CustomerHostedService : IHostedService
    {
        private readonly IRequestClient<ICustomer> _client;
        private Timer _timer;

        public CustomerHostedService(IRequestClient<ICustomer> client) => _client = client;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(GetCustomer, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }


        async void GetCustomer(object state)
        {
             await _client.GetResponse<ICustomer>(new { });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();

            return Task.CompletedTask;
        }
    }
}

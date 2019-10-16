using System;
using Automatonymous;

namespace Onboar.Api.BusConfigs.StatesMachines
{
    public class CustomerStateMachine : SagaStateMachineInstance
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CorrelationId { get; set; }
    }
}

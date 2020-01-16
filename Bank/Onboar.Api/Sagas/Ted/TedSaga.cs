using Automatonymous;
using MassTransit.RedisSagas;
using MassTransit.Saga;
using System;

namespace Onboar.Api.Sagas.Ted
{
    public class TedSaga : MassTransitStateMachine<TedSaga>, ISaga, IVersionedSaga
    {
        public TedSaga()
        {
            Name("ted_saga");
        }

        public Guid CorrelationId { get; set; }
        public int Version { get; set; }
    }
}

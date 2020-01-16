using Automatonymous;
using MassTransit.RedisSagas;
using MassTransit.Saga;
using System;

namespace Onboar.Api.Sagas.Ted
{
    public class TedSaga : AutomatonymousStateMachine<TedSaga>, ISaga, IVersionedSaga
    {
        public TedSaga()
        {
        }

        public Guid CorrelationId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

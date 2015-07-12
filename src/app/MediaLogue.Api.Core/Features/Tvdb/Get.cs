using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Model;
using MediatR;

namespace MediaLogue.Api.Core.Features.Tvdb
{
    public class Get
    {
        public class Query : IRequest<Show>
        {
            public int ShowId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Show>
        {
            private readonly ITvdbGateway _gateway;
            private readonly ITvdbMapper _mapper;

            public Handler(ITvdbGateway gateway, ITvdbMapper mapper)
            {
                _gateway = gateway;
                _mapper = mapper;
            }

            public Show Handle(Query message)
            {
                var xml = _gateway.GetShow(message.ShowId).Result;
                var show = _mapper.MapShowFrom(xml);

                return show;
            }
        }
    }
}

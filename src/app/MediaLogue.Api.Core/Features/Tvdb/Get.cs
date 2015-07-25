using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Contracts.Services;
using MediaLogue.Domain.Model;
using MediaLogue.Domain.Services;
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
            private readonly ITvdbService _tvdbService;

            public Handler(ITvdbService tvdbService)
            {
                _tvdbService = tvdbService;
            }

            public Show Handle(Query message)
            {
                var show = _tvdbService.GetShow(message.ShowId);

                return show;
            }
        }
    }
}

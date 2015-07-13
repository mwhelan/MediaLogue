using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Model;
using MediaLogue.Infrastructure.Data.DocumentDb;
using MediatR;

namespace MediaLogue.Api.Core.Features.Shows
{
    public class Get
    {
        public class Query : IRequest<Show>
        {
            public int ShowId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Show>
        {
            public Show Handle(Query message)
            {
                return DocumentDbRepository<Show>.GetShow(x => x.Id == message.ShowId);
            }
        }
    }
}

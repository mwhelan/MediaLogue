using System.Linq;
using MediaLogue.Domain.Model;
using MediaLogue.Infrastructure.Data;
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
            private readonly IMediaLogueContext _db;

            public Handler(IMediaLogueContext db)
            {
                _db = db;
            }

            public Show Handle(Query message)
            {
                return _db.Shows.FirstOrDefault(x => x.Id == message.ShowId);
            }
        }
    }
}

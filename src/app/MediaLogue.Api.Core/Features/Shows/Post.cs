using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Model;
using MediatR;

namespace MediaLogue.Api.Core.Features.Shows
{
    public class Post
    {
        public class Command : IRequest
        {
            public int ShowId { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly ITvdbGateway _gateway;
            private readonly ITvdbMapper _mapper;

            public Handler(ITvdbGateway gateway, ITvdbMapper mapper)
            {
                _gateway = gateway;
                _mapper = mapper;
            }

            protected override async void HandleCore(Command message)
            {
                //var showInDb = DocumentDbRepository<Show>.GetShow(x => x.Id == message.ShowId);
                //if (showInDb == null)
                //{
                //    var xml = _gateway.GetShow(message.ShowId).Result;
                //    var show = _mapper.MapShowFrom(xml);

                //    await DocumentDbRepository<Show>.CreateItemAsync(show);
                //}
            }
        }
    }
}
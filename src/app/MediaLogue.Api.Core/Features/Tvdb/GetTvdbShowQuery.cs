using MediaLogue.Domain.Model;
using MediatR;

namespace MediaLogue.Api.Core.Features.Tvdb
{
    public class GetTvdbShowQuery : IRequest<Show>, IAsyncRequest<Show>
    {
        public int ShowId { get; set; }
    }
}

using MediaLogue.Domain.Model;
using MediatR;

namespace MediaLogue.Application.Queries
{
    public class GetTvdbShowQuery : IRequest<Show>, IAsyncRequest<Show>
    {
        public int ShowId { get; set; }
    }
}

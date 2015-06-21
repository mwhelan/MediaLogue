using System;
using MediaLogue.Core.Domain.Model;
using MediaLogue.Core.Domain.Services;
using MediatR;

namespace MediaLogue.Api.Core.Features
{
    public class GetTvdbShowQuery : IRequest<Show>, IAsyncRequest<Show>
    {
        public int ShowId { get; set; }
    }
}

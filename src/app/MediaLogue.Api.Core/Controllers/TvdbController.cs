using System.Web.Http;
using MediaLogue.Application.Queries;
using MediatR;

namespace MediaLogue.Api.Core.Controllers
{
    public class TvdbController : ApiController
    {
        private readonly IMediator _mediator;

        public TvdbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IHttpActionResult Get(int id)
        {
            var query = new GetTvdbShowQuery() {ShowId = id};
            var result =  _mediator.SendAsync(query);
            return Ok(result);
        }
    }
}

using System.Web.Http;
using MediaLogue.Api.Core.Features.Tvdb;
using MediatR;

namespace MediaLogue.Api.Core.Controllers
{
    using System;

    public class TvdbController : ApiController
    {
        private readonly IMediator _mediator;

        public TvdbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var query = new GetTvdbShowQuery() { ShowId = id };
                var result = _mediator.SendAsync(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
            }
            return this.BadRequest();
        }
    }
}

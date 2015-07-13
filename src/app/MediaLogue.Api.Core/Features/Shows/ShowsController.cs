using System;
using System.Web.Http;
using MediatR;

namespace MediaLogue.Api.Core.Features.Shows
{
    public class ShowsController : ApiController
    {
        private readonly IMediator _mediator;

        public ShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var query = new Get.Query {ShowId = id};
            var result = _mediator.Send(query);

            return result != null ? 
                (IHttpActionResult) Ok(result) 
                : NotFound();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]int id)
        {
            var command = new Post.Command {ShowId = id};
            var result = _mediator.Send(command);

            return CreatedAtRoute("DefaultApi", new { id = command.ShowId },command);
        }
    }
}

using System.Web.Http;
using MediatR;

namespace MediaLogue.Api.Core.Features.Tvdb
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
            var query = new Get.Query() {ShowId = id};
            var result = _mediator.Send(query);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

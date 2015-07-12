using MediaLogue.Infrastructure.Data.Tvdb;

namespace Specs.Integration.MediaLogue.Infrastructure.Data.Tvdb
{
    using Specs.Library.MediaLogue.TestData;

    public class TvdbGatewayTests
    {
        //[Fact]
        public void Can_get_show_from_Tvdb()
        {
            var gateway = new TvdbGateway(new AsyncClient());
            var result = gateway.GetShow(ShowData.Turn.Id).Result;
        }
    }
}

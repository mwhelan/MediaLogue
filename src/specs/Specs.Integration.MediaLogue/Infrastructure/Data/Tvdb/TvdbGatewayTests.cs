using MediaLogue.Infrastructure.Data.Tvdb;
using Xunit;

namespace Specs.Integration.MediaLogue.Infrastructure.Data.Tvdb
{
    public class TvdbGatewayTests
    {
        [Fact]
        public void Can_get_show_from_Tvdb()
        {
            var gateway = new TvdbGateway(new AsyncClient());
            var result = gateway.GetShow(ShowData.Turn.Id).Result;

        }
    }

    public static class ShowData
    {
        public static class TheFieldOfBlood
        {
            public static int Id = 248620;
        }

        public static class Turn
        {
            public static int Id = 272135;
        }
    }
}

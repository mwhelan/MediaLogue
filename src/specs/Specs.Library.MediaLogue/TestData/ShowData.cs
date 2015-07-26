using MediaLogue.Domain.Model;
using MediaLogue.Domain.Services;
using MediaLogue.Infrastructure.Data.Tvdb;
using Specs.Library.MediaLogue.TestData.Stubs;

namespace Specs.Library.MediaLogue.TestData
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ShowData
    {
        static ShowData()
        {
            ShowStubs = new List<ShowStub>
            {
                new ShowStub(TheFieldOfBlood.Id, "TheFieldOfBlood_FullSeries.xml"),
                new ShowStub(Turn.Id, "Turn_FullSeries.xml")
            };
        }

        public static List<ShowStub> ShowStubs { get; private set; }
        
        public static class TheFieldOfBlood
        {
            public static int Id = 248620;

            public static string FullSeriesXml
            {
                get { return ShowStubs.Single(x => x.Id == Id).FullSeriesXml; }
            }
            private static Show _show;
            public static Show Show
            {
                get
                {
                    if (_show == null) _show = new TvdbService(new StubTvdbGateway(), new TvdbMapper()).GetShow(Id);
                    return _show;
                }
            }
        }

        public static class Turn
        {
            public static int Id = 272135;
            public static string FullSeriesXml
            {
                get { return ShowStubs.Single(x => x.Id == Id).FullSeriesXml; }
            }

            private static Show _show;
            public static Show Show
            {
                get
                {
                    if(_show == null) _show = new TvdbService(new StubTvdbGateway(), new TvdbMapper()).GetShow(Id);
                    return _show;
                }
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Specs.Library.MediaLogue.TestData
{
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
        }

        public static class Turn
        {
            public static int Id = 272135;
            public static string FullSeriesXml
            {
                get { return ShowStubs.Single(x => x.Id == Id).FullSeriesXml; }
            }
        }
    }
}

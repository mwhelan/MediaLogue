using MediaLogue.Domain.Model;
using MediaLogue.Infrastructure.Data;
using Respawn;
using Specs.Library.MediaLogue;
using TestStack.Dossier;

namespace Specs.Integration.MediaLogue.Infrastructure
{
    public class MediaLogueContextSpecs : ScenarioFor<IMediaLogueContext>
    {
        private Show _show;

        //private static Checkpoint _checkpoint = new Checkpoint { TablesToIgnore = new[] { "sysdiagrams" }};

        //public void Setup()
        //{
        //    SUT = new MediaLogueContext("IntegrationSpecsContext");
        //    //var testPath = Path.GetDirectoryName(typeof(MediaLogueContextSpecs).Assembly.CodeBase.Replace("file:///", ""));
        //    //AppDomain.CurrentDomain.SetData("DataDirectory", testPath); // For localdb connection string that uses |DataDirectory|
        //    //var connectionString = ConfigurationManager.ConnectionStrings["IntegrationSpecsContext"].ConnectionString;
        //    //_checkpoint.Reset(connectionString);
        //}

        public void Given_a_Show_with_five_episodes()
        {
            _show = Builder<Show>.CreateNew()
                .Set(x => x.Episodes, Builder<Episode>.CreateListOfSize(5).BuildList);
        }

        public void When_it_is_added()
        {
            SUT.Shows.Add(_show);
            SUT.SaveChanges();
        }

        public void Then_the_Show_is_persisted()
        {
            
        }

        public void AndThen_the_Episodes_are_all_persisted()
        {
            
        }
    }
}

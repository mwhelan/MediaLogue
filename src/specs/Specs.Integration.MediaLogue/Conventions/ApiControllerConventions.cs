namespace Specs.Integration.MediaLogue.Conventions
{
    using global::MediaLogue.Api.Core.Features.Tvdb;

    using Specs.Library.MediaLogue;

    using TestStack.ConventionTests;
    using TestStack.ConventionTests.ConventionData;
    using TestStack.ConventionTests.Conventions;

    public class ApiControllerConventions : ScenarioFor<object, ConventionsStory>
    {
        protected IConvention<Types> convention;
        private Types types;

        public void Given_the_Api_Controllers()
        {
             this.types = Types.InAssemblyOf<TvdbController>();
        }

        public void When_the_convention_is_applied()
        {
            convention = new ApiControllerNamingAndBaseClassConvention();
        }

        public void Then_should_all_inherit_from_ApiController_and_have_Controller_suffix()
        {
            Convention.Is(convention, types);
        }
    }
}

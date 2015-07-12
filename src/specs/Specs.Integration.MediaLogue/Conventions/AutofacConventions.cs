namespace Specs.Integration.MediaLogue.Conventions
{
    using System.Web.Http;

    using global::MediaLogue.Api.Core.Config;

    using Specs.Library.MediaLogue;

    using TestStack.ConventionTests;
    using TestStack.ConventionTests.Autofac;

    public abstract class AutofacConventions : ScenarioFor<ApiApplication, ConventionsStory>
    {
        protected IConvention<AutofacRegistrations> convention;

        protected AutofacRegistrations data;

        public void Setup()
        {
            this.SUT = new ApiApplication(new HttpConfiguration());
        }

        public void Given_the_fully_configured_Autofac_container()
        {
            this.SUT.Configure();
            this.data = new AutofacRegistrations(this.SUT.Container.ComponentRegistry);
        }

        /// <summary>
        /// For example, transients should not be injectected into singletons
        /// </summary>
        public class AutofacServicesShouldOnlyHaveDependenciesWithLesserLifetimeConvention : AutofacConventions
        {
            public void When_the_convention_is_applied()
            {
                this.convention = new ServicesShouldOnlyHaveDependenciesWithLesserLifetime();
            }

            public void Then_services_should_only_have_dependencies_with_lesser_lifetimes()
            {
                Convention.Is(this.convention, this.data);
            }
        }

        public class AutofacCanResolveAllRegisteredServicesConvention : AutofacConventions
        {
            public void When_the_convention_is_applied()
            {
                this.convention = new CanResolveAllRegisteredServices(this.SUT.Container);
            }

            public void Then_services_should_all_be_resolved()
            {
                Convention.Is(this.convention, this.data);
            }
        }
    }
}

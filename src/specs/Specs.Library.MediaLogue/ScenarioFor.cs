using NUnit.Framework;
using Specify.Stories;
using TestStack.Dossier;

namespace Specs.Library.MediaLogue
{
    [TestFixture]
    public abstract class ScenarioFor<TSut, TStory> : Specify.ScenarioFor<TSut, TStory>
        where TSut : class
        where TStory : Story, new()
    {
        protected ScenarioFor()
        {
            Any = new AnonymousValueFixture();
        }

        [Test]
        public override void Specify()
        {
            base.Specify();
        }

        /// <summary>
        /// Generate anonymous data using this fixture - one instance per ScenarioFor instance.
        /// </summary>
        public AnonymousValueFixture Any { get; internal set; }
    }

    [TestFixture]
    public abstract class ScenarioFor<TSut> : ScenarioFor<TSut, SpecificationStory>
        where TSut : class
    {
    }
}

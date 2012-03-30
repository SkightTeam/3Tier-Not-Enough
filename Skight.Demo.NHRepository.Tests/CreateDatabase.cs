using NUnit.Framework;

namespace Skight.Demo.NHRepository.Tests
{
    [TestFixture]
    public class CreateDatabase
    {
        [Test]
        public void Run()
        {
            var provider = SessionProvider.Instance;
            provider.IsBuildScheme = true;
            provider.initilize();
        }
         
    }
}
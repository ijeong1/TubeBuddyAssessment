using System.Linq;
using NUnit.Framework;
using TubeBuddyAssessment.PageModels;

namespace TubeBuddyAssessment.UnitTests.PageModelTests
{
    [TestFixture]
    public class SecondPageModelTests
    {
        public SecondPageModelTests()
        {
        }

        [Test]
        public void TestInitList()
        {
            var secondPageModel = new SecondPageModel();
            Assert.AreEqual(secondPageModel.FunctionList.Count(), 3);
        }

        [Test]
        public void TestCommand()
        {
            var secondPageModel = new SecondPageModel();
            secondPageModel.ButtonCommand.Execute(null);

            Assert.AreEqual(secondPageModel.SelectionCheck, false);
        }
    }
}

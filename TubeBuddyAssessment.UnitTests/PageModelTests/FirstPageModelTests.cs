using Moq;
using NUnit.Framework;
using TubeBuddyAssessment.PageModels;
using TubeBuddyAssessment.Services;

namespace TubeBuddyAssessment.UnitTests.PageModelTests
{
    [TestFixture]
    public class FirstPageModelTests
    {
        public class FirstPageModelTest{
        }

        [Test]
        public void Test_TextInput()
        {
            var _dialogSerice = new Mock<IDialogService>();
            var _settingsService = new Mock<ISettingsService>();
            var firstPageModel = new FirstPageModel(_dialogSerice.Object, _settingsService.Object);

            firstPageModel.TextInput = "Test";
            Assert.IsTrue(firstPageModel.TextInputCheck);
        }

        [Test]
        public void Test_TextInput_Null()
        {
            var _dialogSerice = new Mock<IDialogService>();
            var _settingsService = new Mock<ISettingsService>();
            var firstPageModel = new FirstPageModel(_dialogSerice.Object, _settingsService.Object);

            firstPageModel.TextInput = null;
            Assert.IsFalse(firstPageModel.TextInputCheck);
        }
    }
}

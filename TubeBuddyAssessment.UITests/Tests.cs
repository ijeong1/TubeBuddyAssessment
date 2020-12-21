using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TubeBuddyAssessment.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void DialogMessagePopUp_Expect_True_OnFirstRun()
        {
            if (platform == Platform.Android)
            {
                var messageText = app.Query(i => i.Id("message")).FirstOrDefault().Text;
                var alertBox = app.Query(i => i.Id("alertTitle")).FirstOrDefault().Text;

                Assert.AreEqual(messageText, "Welcome to TubeBuddy Assessment App!");
            }
            else
            {
                //We need to wait for the ability to add automationID to alert boxes in iOS
                var messageText = app.Query(i => i.Text("Welcome to TubeBuddy Assessment App!")).FirstOrDefault().Text;
                var alertBox = app.Query(i => i.Text("Welcome")).FirstOrDefault().Text;

                Assert.AreEqual(messageText, "Welcome to TubeBuddy Assessment App!");
            }
        }


        //Check whether text input and label are the same
        [Test]
        public void TextInputAndLabe_Expect_True()
        {
            app.WaitForElement(c => c.Marked("OK"));
            app.Tap(c => c.Marked("OK"));

            app.WaitForElement(c => c.Marked("Type your text here."));
            app.EnterText(c => c.Marked("Type your text here."), "Hello World!");


            //app.Query(x => x.Marked("label").Descendant());
            var label = app.Query(x => x.Marked("TextLabel").Descendant()).FirstOrDefault();

            Assert.AreEqual(label.Text, "Hello World!");
        }

        [Test]
        public void IsSliderEnabled_Expect_True()
        {
            app.WaitForElement(c => c.Marked("OK"));
            app.Tap(c => c.Marked("OK"));

            app.WaitForElement(c => c.Marked("Type your text here."));
            app.EnterText(c => c.Marked("Type your text here."), "Hello World!");

            var elementEnabled = app.Query(x => x.Marked("InputSlider")).FirstOrDefault().Enabled;
            Assert.AreEqual(elementEnabled, true);
        }

        [Test]
        public void IsSliderEnabled_Expect_False()
        {
            app.WaitForElement(c => c.Marked("OK"));
            app.Tap(c => c.Marked("OK"));

            var elementEnabled = app.Query(x => x.Marked("InputSlider")).FirstOrDefault().Enabled;
            Assert.AreEqual(elementEnabled, false);
        }
    }
}

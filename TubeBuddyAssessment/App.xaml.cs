using FreshMvvm;
using TubeBuddyAssessment.PageModels;
using TubeBuddyAssessment.Services;
using Xamarin.Forms;

namespace TubeBuddyAssessment
{
    public partial class App : Application
    {
        //App
        public App()
        {
            //Register Services to the IoC
            FreshIOC.Container.Register<IDialogService, DialogService>(); //DialogService
            FreshIOC.Container.Register<ISettingsService, SettingsService>(); //SettingService

            //Main Navigation
            LoadMainTabbedPage();
        }

        // Handle Navigation to the MainTappedPage
        public void LoadMainTabbedPage()
        {
            //FreshMvvm supports TabbedNavigation with Navigation named Assessment
            var tabbedNavigation = new FreshTabbedFONavigationContainer("Assessment");
            //Add FirstPageModel with TabIcon1
            tabbedNavigation.AddTab<FirstPageModel>("First", "TabIcon1", null);
            //Add SecondPageModel with TabIcon2
            tabbedNavigation.AddTab<SecondPageModel>("Second", "TabIcon2", null);
            //Set tabbedNavigation as a MainPage
            MainPage = tabbedNavigation;
        }

        protected override void OnStart()
        {
            // Handle when this app starts
        }

        protected override void OnSleep()
        {
            // Handle when this app sleeps
        }

        protected override void OnResume()
        {
            // Handle when this app resumes
        }
    }
}

using Xamarin.Essentials;

namespace TubeBuddyAssessment.Services
{
    public class SettingsService : ISettingsService
    {
        //create a new key if the IsInitiated Key and value do not exist in localstorage.
        public static bool IsInitiated
        {
            get => Preferences.Get(nameof(IsInitiated), false);
            set => Preferences.Set(nameof(IsInitiated), value);
        }

        //When IsInitiated is initially set to False, this function return the opposite value.
        public bool IsFirstRun()
        {
            return !IsInitiated;
        }

        //After the dialog is shown, the value is forcibly changed to TRUE.
        public void SetAppIsInitated()
        {
            IsInitiated = true;
        }
    }
}

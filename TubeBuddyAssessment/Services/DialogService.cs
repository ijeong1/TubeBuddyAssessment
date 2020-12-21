using Xamarin.Forms;

namespace TubeBuddyAssessment.Services
{
    public class DialogService : IDialogService
    {
        //Show Dialog
        public void ShowMessage(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.DisplayAlert(title, message, "OK");
            });
        }
    }
}

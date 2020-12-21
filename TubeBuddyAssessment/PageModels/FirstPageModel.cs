using TubeBuddyAssessment.Services;

namespace TubeBuddyAssessment.PageModels
{
    public class FirstPageModel : BasePageModel
    {
        //Local Properties for Services Dialog and Settings 
        IDialogService _dialogService;
        ISettingsService _settingsService;

        //properties for Input
        private string _textInput;
        public string TextInput
        {
            get
            {
                return _textInput;
            }

            set
            {
                _textInput = value;
                NotifyPropertyChanged(nameof(TextInputCheck)); //Check the value is not null or empty
                NotifyPropertyChanged(nameof(TextInput)); //Notify text being entered
            }
        }

        //properties for label rotation 0 ~ 360
        private int _rotationAngle;
        public int RotationAngle
        {
            get { return _rotationAngle;  }
            set
            {
                _rotationAngle = value;
                NotifyPropertyChanged(nameof(RotationAngle));
            }
        }

        public bool TextInputCheck
        {
            get
            {
                return !string.IsNullOrEmpty(TextInput);
            }
        }

        //ViewModel Constructor
        public FirstPageModel(IDialogService dialogService, ISettingsService settingsService)
        {
            _dialogService = dialogService;
            _settingsService = settingsService;

            // Check if the app is running the first time
            if (_settingsService.IsFirstRun()) ShowWelcomeMessage();
        }

        private void ShowWelcomeMessage()
        {
            //Change the value after the dialog is displayed. Do not display this window from the next execution.
            _dialogService.ShowMessage("Welcome", "Welcome to TubeBuddy Assessment App!");
            _settingsService.SetAppIsInitated();
        }
    }
}

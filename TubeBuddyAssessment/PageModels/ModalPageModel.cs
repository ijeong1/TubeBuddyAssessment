using Xamarin.Forms;
using Xamarin.Essentials;
using TubeBuddyAssessment.Models;

namespace TubeBuddyAssessment.PageModels
{
    public class ModalPageModel : BasePageModel
    {
        //Property for Type (Connectivity, Device Info, Screen Info)
        public string Type { get; set; }

        //Detail Infomation, This value can be changed dynamically.
        private string _info;
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                NotifyPropertyChanged(nameof(Info));
            }
        }

        public ModalPageModel()
        {   
        }

        //When the modal is created
        public override void Init(object initData)
        {
            FunctionItem item = (FunctionItem)initData;
            switch (item.Key)
            {
                case 1:
                    //Connectivity
                    ShowInternetConnectivityInfo();
                    break;
                case 2:
                    //Device Info
                    ShowDeviceInfo();
                    break;
                case 3:
                    //Screen Info
                    ShowDeviceScreenInfo();
                    break;
            }
        }

        //Show internet connection information
        private void ShowInternetConnectivityInfo()
        {
            var connectivity = Connectivity.NetworkAccess == NetworkAccess.Internet;

            //Create an event that changes state while the window is floating
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            Type = "Internet Connectivity";
            
            if(connectivity)
                Info = "Internet Connected!";
            else
                Info = "Internet Not Connected!";
        }

        //Handling events that change state while the window is floating
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            if(access == NetworkAccess.Internet){
                Info = "Internet Connected!";
            }
            else
            {
                Info = "Internet Not Connected!";
            }
        }

        //Show Device Info
        private void ShowDeviceInfo()
        {
            Type = "Device Infomation";

            var device = DeviceInfo.Model;
            var manufacturer = DeviceInfo.Manufacturer;
            var deviceName = DeviceInfo.Name;
            var idiom = DeviceInfo.Idiom;
            var platform = DeviceInfo.Platform;
            var version = DeviceInfo.VersionString;

            Info = $"Model : {device}\nManufacturer: {manufacturer}\nDevice Name: {deviceName}\n" +
                $"Idiom: {idiom}\nPlatform: {platform}\nVersion: {version}";
        }

        //Show Screen Information
        private void ShowDeviceScreenInfo()
        {
            Type = "Screen Infomation";

            //Subscribe to change of screen metrics
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;

            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            var orientation = mainDisplayInfo.Orientation;

            // Rotation
            var rotation = mainDisplayInfo.Rotation;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;

            // Screen density
            var density = mainDisplayInfo.Density;

            Info = $"Metrics: {mainDisplayInfo}\n" +
                $"Orientation: {orientation}\n" +
                $"Rotation: {rotation}\n" +
                $"Resolution {width} * {height}\n" +
                $"Density: {density}";
        }

        //handle events that change state while the window is floating
        private void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            // Get Metrics
            var displayInfo = e.DisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            var orientation = displayInfo.Orientation;

            // Rotation
            var rotation = displayInfo.Rotation;

            // Width (in pixels)
            var width = displayInfo.Width;

            // Height (in pixels)
            var height = displayInfo.Height;

            // Screen density
            var density = displayInfo.Density;

            Info = $"Metrics: {displayInfo}\n" +
                $"Orientation: {orientation}\n" +
                $"Rotation: {rotation}\n" +
                $"Resolution {width} * {height}\n" +
                $"Density: {density}";
        }

        //handle Dismiss Command 
        public Command DismissCommand
        {
            get
            {
                return new Command(() => {
                    //pop the modal page
                    CoreMethods.PopPageModel(true);
                });
            }
        }
    }
}

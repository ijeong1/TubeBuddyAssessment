using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreshMvvm;

namespace TubeBuddyAssessment.PageModels
{
    //BaseViewModel Handle INotifyPropertyChanged and FreshBasePageModel
    public class BasePageModel : FreshBasePageModel, INotifyPropertyChanged
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        //Handles property changes linked to xaml files.
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}

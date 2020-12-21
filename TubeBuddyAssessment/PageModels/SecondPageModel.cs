using Xamarin.Forms;
using TubeBuddyAssessment.Models;
using System.Collections.ObjectModel;

namespace TubeBuddyAssessment.PageModels
{
    //Second ViewModel
    public class SecondPageModel : BasePageModel
    {
        //Properties for Function Picker
        private ObservableCollection<FunctionItem> _functionList;
        public ObservableCollection<FunctionItem> FunctionList {
            get
            {
                return _functionList;
            }
            set
            {
                _functionList = value;
                NotifyPropertyChanged(nameof(FunctionList));
            }
        }

        //Properties for Selected Item from Picker
        private FunctionItem _selectedFunctionItem;
        public FunctionItem SelectedFunctionItem
        {
            get
            {
                return _selectedFunctionItem;
            }
            set
            {
                _selectedFunctionItem = value;
                NotifyPropertyChanged(nameof(SelectionCheck));
            }
        }

        //Check the selected value is not null
        public bool SelectionCheck
        {
            get
            {
                return SelectedFunctionItem != null;
            }
        }

        //ViewModel Constructor
        public SecondPageModel()
        {
            InitList(); //Setup a list for Picker
        }

        public void InitList()
        {
            FunctionList = new ObservableCollection<FunctionItem>(){
                new FunctionItem () { Key=1, Title="Connectivity"},
                new FunctionItem () { Key=2, Title="Device Info"},
                new FunctionItem () { Key=3, Title="Display Info"},
            };
        }


        //Command for Button
        public Command ButtonCommand
        {
            get
            {
                return new Command(async() => {
                    //if the Selected Item is not null
                    if (SelectionCheck)
                    {
                        //Push a new modal page
                        await CoreMethods.PushPageModel<ModalPageModel>(SelectedFunctionItem, true, true);
                    }
                });
            }
        }
    }
}

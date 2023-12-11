using PROG7312_UI.Core;

namespace PROG7312_UI.MVVM.View_Model
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand RBCommand { get; set; }
        public RelayCommand IACommand { get; set; }
        public RelayCommand FCNCommand { get; set; }
        public RelayCommand HelpCommand { get; set; }

        public RBViewModel RBVM { get; set; }
        public IAViewModel IAVM { get; set; }
        public HelpViewModel HVM { get; set; }
        public FCNViewModel FCNVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChange();
            }
        }

        private object _helpView;
        public object HelpView
        {
            get { return _helpView; }
            set
            {
                _helpView = value;
                OnPropertyChange();
            }
        }




        public MainViewModel()
        {
            RBVM = new RBViewModel();
            IAVM = new IAViewModel();
            HVM = new HelpViewModel();
            FCNVM = new FCNViewModel();


            RBCommand = new RelayCommand(o =>
            {
                CurrentView = RBVM;
            });
            HelpCommand = new RelayCommand(o =>
            {
                CurrentView = HVM;
            });
            IACommand = new RelayCommand(o =>
            {
                CurrentView = IAVM;
            });
            FCNCommand = new RelayCommand(o =>
            {
                CurrentView = FCNVM;
            });


        }
    }
}

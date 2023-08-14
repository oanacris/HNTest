using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace HNTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private DelegateCommand<string> _navigateCommand;


        public DelegateCommand<string> NavigateCommand
        {
            get => _navigateCommand;
            private set => SetProperty(ref _navigateCommand, value);
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate); 
        }

        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("TabRegion", navigationPath);
        }
    }
}

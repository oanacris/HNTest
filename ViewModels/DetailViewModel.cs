using HNTest.DataSource;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using Prism.Services.Dialogs;

namespace HNTest.ViewModels
{
    public class DetailViewModel : BindableBase, INavigationAware
    {
        private readonly IDataSourceService _dataSourceService;
        private readonly IDialogService _dialogService;

        public ObservableCollection<HNItemViewModel> BestStory
        {
            get => _bestStory;
            set => SetProperty(ref _bestStory, value);
        }

        public DetailViewModel(IDataSourceService dataSourceService, IDialogService dialogService)
        {
            _dataSourceService = dataSourceService;
            _dialogService = dialogService;
            BestStory = new ObservableCollection<HNItemViewModel>();
            OnDetails("37098483");

        }
        private void OnDetails(string id)
        {
            var story =  _dataSourceService.GetHNById(id);
            BestStory.Add(new HNItemViewModel(story.Result)); 
        }


        private string _title = "DetailView";
        private ObservableCollection<HNItemViewModel> _bestStory;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using HNTest.DataSource;
using HNTest.Events;
using HNTest.Models;
using Prism.Events;

namespace HNTest.ViewModels
{
    public class GeneralViewModel : BindableBase, INavigationAware
    {

        private readonly IDataSourceService _dataSourceService;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<BestStoriesViewModel> BestStories
        {
            get => _bestStories;
            set => SetProperty(ref _bestStories, value);
        }

        public DelegateCommand RefreshCommand
        {
            get => _refreshCommand;
            private set => SetProperty(ref _refreshCommand, value);
        }

        public DelegateCommand SubmitCommand { get; private set; } 


        public GeneralViewModel(IDataSourceService dataSourceService, IEventAggregator eventAggregator)
        {
            _dataSourceService = dataSourceService;
            _eventAggregator = eventAggregator;
            BestStories = new ObservableCollection<BestStoriesViewModel>();

            RefreshCommand = new DelegateCommand(OnRefresh, CanRefresh);
            SubmitCommand = new DelegateCommand(OnSubmit, CanSubmit);

            OnRefresh();
        }

        private bool CanSubmit()
        {
            return SelectedStory != null;
        }

        private void OnSubmit()
        {
            var p = new DialogParameters();
            p.Add("Id", SelectedStory.Id);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }


        public event Action<IDialogResult> RequestClose;

        private string _title = "GeneralView";
        private BestStoriesViewModel _selectedStory;
        private DelegateCommand _refreshCommand;
        private ObservableCollection<BestStoriesViewModel> _bestStories;

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
         

        private bool CanRefresh()
        {
            return true;  
        }

         

        public void OnNavigatedTo(NavigationContext navigationContext)
        { 
        } 
     

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { 
        }
         

        private void OnRefresh()
        {
            SelectedStory = null;

            var stories = _dataSourceService.GetBestStories();

            foreach (var story in stories)
            {
                BestStories.Add(new BestStoriesViewModel(new HN
                    {
                        Id = story
                    })
                );
            }
        }
         

        public BestStoriesViewModel SelectedStory
        {
            get => _selectedStory;
            set
            {
                SetProperty(ref _selectedStory, value);
                SendStory();
                SendDetails();
                SubmitCommand.RaiseCanExecuteChanged();
            }
        }

        private void SendStory()
        {
            _eventAggregator.GetEvent<StorySentEvent>().Publish(SelectedStory);
        }


        private void SendDetails()
        {
            var story = _dataSourceService.GetHNById(SelectedStory?.Id.ToString());
            _eventAggregator.GetEvent<StoryDetailSentEvent>().Publish(SelectedStory == null
                ? new HNItemViewModel(new HNItem())
                : new HNItemViewModel(story.Result));
        }
    }
}

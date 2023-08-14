using HNTest.DataSource;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using HNTest.Events;
using Prism.Events;
using Prism.Services.Dialogs;

namespace HNTest.ViewModels
{
    public class DetailViewModel : BindableBase, INavigationAware
    {
        private BestStoriesViewModel _selectedStory;
        private ObservableCollection<HNItemViewModel> _bestStory;

        public ObservableCollection<HNItemViewModel> BestStory
        {
            get => _bestStory;
            set => SetProperty(ref _bestStory, value);
        }


        public BestStoriesViewModel SelectedStory
        {
            get => _selectedStory;
            set
            {
                SetProperty(ref _selectedStory, value);
            }
        }

        public DetailViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<StorySentEvent>().Subscribe(OnStoryReceived);
            eventAggregator.GetEvent<StoryDetailSentEvent>().Subscribe(OnStoryDetailReceived);
        }

        private void OnStoryDetailReceived(HNItemViewModel bestStory)
        {
            BestStory = new ObservableCollection<HNItemViewModel> { bestStory };
        }

        private void OnStoryReceived(BestStoriesViewModel story)
        {
            SelectedStory = story;
        }
        


        private string _title = "DetailView";
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
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}

using Prism.Events;
using System.Windows;
using HNTest.ViewModels;

namespace HNTest.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator _eventAggregator;
        public MainWindow(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();  
        }

    }
}

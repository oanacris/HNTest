using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNTest.Views;
using Prism.Ioc;
using Prism.Regions;

namespace HNTest.Modules
{
    public class MainModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
         

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GeneralView>();
            containerRegistry.RegisterForNavigation<DetailView>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("TabRegion", typeof(GeneralView));
            _regionManager.RegisterViewWithRegion("TabRegion", typeof(DetailView));
        }

    }
}

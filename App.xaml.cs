using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using HNTest.DataSource;
using HNTest.Modules;
using HNTest.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;


namespace HNTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            EventManager.RegisterClassHandler(typeof(Window),
            Keyboard.KeyUpEvent, new KeyEventHandler(keyUp), true);


        }


        private void keyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"{e.Key} {e.Device}");
            e.Handled = true;
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDataSourceService, DataSourceService>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();

        }

    }
}

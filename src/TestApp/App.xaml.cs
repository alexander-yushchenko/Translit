using System.Windows;
using AY.Translit.TestApp.ViewModels;

namespace AY.Translit.TestApp
{
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var viewModel = new MainWindowViewModel();
            var view = new MainWindowView(viewModel);
            view.Show();
        }
    }
}

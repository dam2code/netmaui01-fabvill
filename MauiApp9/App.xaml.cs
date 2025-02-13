using Android.Views;
using MauiApp9;

namespace MauiApp9
{
    public partial class App : Application
    {
        public static ViewModels.MovieListViewModel MainViewModel { get; private set; }

        public App()
        {
            InitializeComponent();
            MainViewModel = new ViewModels.MovieListViewModel();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            MainViewModel.RefreshMovies().ContinueWith(s => { });
            return window;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp9.Views
{
    public partial class MoviesListPage : ContentPage
    {
        public MoviesListPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new Views.MovieDetailPage());
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            ViewModels.MovieViewModel movie = (ViewModels.MovieViewModel)menuItem.BindingContext;
            App.MainViewModel?.DeleteMovie(movie);
        }
    }
}

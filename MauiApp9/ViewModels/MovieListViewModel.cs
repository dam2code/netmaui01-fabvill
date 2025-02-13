using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp9.ViewModels
{
    public class MovieListViewModel : ObservableObject
    {
        public ICommand DeleteMovieCommand { get; private set; }
        public ObservableCollection<MovieViewModel> Movies { get; set; }

        public MovieListViewModel()
        {
            Movies = [];
            DeleteMovieCommand = new Command<MovieViewModel>(DeleteMovie);
        }

        public async Task RefreshMovies()
        {
            IEnumerable<Models.Movie> moviesData = await Models.MoviesDatabase.GetMovies();

            foreach (Models.Movie movie in moviesData)
                Movies.Add(new MovieViewModel(movie));
        }

        public void DeleteMovie(MovieViewModel movie) =>
            Movies.Remove(movie);
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            ViewModels.MovieViewModel movie = (ViewModels.MovieViewModel)menuItem.BindingContext;
            App.MainViewModel.DeleteMovie(movie);
        }
    }

}

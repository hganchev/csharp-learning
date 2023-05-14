using System;
namespace SOLID
{
    // DIP - Dependency inversion principle - Depend upon abstractions, [not] concretions
    class DIP
    {
        public DIP()
        {
            Console.WriteLine(@"DIP - Depend upon abstractions, [not] concretions");
            var myMovieWatcher = new MovieWatcher();
            myMovieWatcher.WatchMovie("Jurassic Park");

             var myMovieWatcher2 = new MovieWatcher2();
             myMovieWatcher2.WatchMovie("Jurassic Park 2");
        }
    }
    // Example: class Movie which is implemented in Watcher and used
    public class Movies
    {
        public void Movie(string movieName)
        {
            Console.WriteLine("Movie name: " + movieName);
        }
    }

    public class MovieWatcher
    {
        private Movies myMovies = new Movies();

        public void WatchMovie(string movieName)
        {
            Console.WriteLine("Watching ");
            myMovies.Movie(movieName);
        }
    }

    // Example: using abstraction for dependency
    public interface IMovie
    {
        public void WatchMovie(string movieName);
    }

    public class MovieWatcher2: IMovie
    {
        public void WatchMovie(string movieName)
        {
            Console.WriteLine("Watching movie name: " + movieName);
        }
    }
}
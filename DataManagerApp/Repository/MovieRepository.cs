using DataManagerApp.Model;
using DataManagerApp.Logging;

namespace DataManagerApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private static readonly List<Movie> _movies = new();
        private static int _nextId = 1;
        private readonly ILogger _logger;

        public MovieRepository(ILogger logger)
        {
            _logger = logger;
        }

        public void Create(Movie movie)
        {
            movie.Id = _nextId++;
            _movies.Add(movie);
            _logger.Log("Create", "Movie", movie.Id);
        }

        public Movie? FindById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            _logger.Log("Read", "Movie", id);
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public void Update(Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Year = movie.Year;
                _logger.Log("Update", "Movie", movie.Id);
            }
        }
        public void Delete(int id)
        {
            _movies.RemoveAll(m => m.Id == id);
            _logger.Log("Delete", "Movie", id);
        }
    }
}

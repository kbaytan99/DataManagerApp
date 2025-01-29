using DataManagerApp.Model;

namespace DataManagerApp.Repository
{
    /// <summary>
    /// Defines the contract for movie repository operations.
    /// Provides methods for CRUD functionalities.
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Adds a new movie to the repository.
        /// </summary>
        /// <param name="movie">The movie entity to be added.</param>
        void Create(Movie movie);

        /// <summary>
        /// Retrieves a movie by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the movie.</param>
        /// <returns>The movie if found; otherwise, null.</returns>
        Movie? FindById(int id);

        /// <summary>
        /// Retrieves all movies from the repository.
        /// </summary>
        /// <returns>An enumerable collection of movies.</returns>
        IEnumerable<Movie> GetAll();

        /// <summary>
        /// Updates the information of an existing movie.
        /// </summary>
        /// <param name="movie">The movie entity with updated details.</param>
        void Update(Movie movie);

        /// <summary>
        /// Deletes a movie by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the movie to be deleted.</param>
        void Delete(int id);
    }
}

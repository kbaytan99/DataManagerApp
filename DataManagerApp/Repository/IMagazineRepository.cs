using DataManagerApp.Model;

namespace DataManagerApp.Repository
{
    /// <summary>
    /// Interface for magazine repository operations.
    /// Defines methods for CRUD (Create, Read, Update, Delete) functionalities.
    /// </summary>
    public interface IMagazineRepository
    {
        /// <summary>
        /// Adds a new magazine to the repository.
        /// </summary>
        /// <param name="magazine">The magazine entity to be added.</param>
        void Create(Magazine magazine);

        /// <summary>
        /// Retrieves a magazine by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the magazine.</param>
        /// <returns>The magazine if found; otherwise, null.</returns>
        Magazine? FindById(int id);

        /// <summary>
        /// Retrieves all magazines from the repository.
        /// </summary>
        /// <returns>An enumerable collection of magazines.</returns>
        IEnumerable<Magazine> GetAll();

        /// <summary>
        /// Updates the information of an existing magazine.
        /// </summary>
        /// <param name="magazine">The magazine entity with updated details.</param>
        void Update(Magazine magazine);

        /// <summary>
        /// Deletes a magazine by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the magazine to be deleted.</param>
        void Delete(int id);
    }
}

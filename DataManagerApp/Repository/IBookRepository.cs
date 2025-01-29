using DataManagerApp.Model;

namespace DataManagerApp.Repository
{
    /// <summary>
    /// Defines the contract for book repository operations.
    /// Provides methods for CRUD (Create, Read, Update, Delete) functionalities.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Adds a new book to the repository.
        /// </summary>
        /// <param name="book">The book entity to be added.</param>
        void Create(Book book);

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <returns>The book if found; otherwise, null.</returns>
        Book? FindById(int id);

        /// <summary>
        /// Retrieves all books from the repository.
        /// </summary>
        /// <returns>An enumerable collection of books.</returns>
        IEnumerable<Book> GetAll();

        /// <summary>
        /// Updates the information of an existing book.
        /// </summary>
        /// <param name="book">The book entity with updated details.</param>
        void Update(Book book);

        /// <summary>
        /// Deletes a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book to be deleted.</param>
        void Delete(int id);
    }
}

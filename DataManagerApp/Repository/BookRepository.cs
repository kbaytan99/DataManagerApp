using DataManagerApp.Model;
using DataManagerApp.Logging;

namespace DataManagerApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();
        private readonly ILogger _logger;
        private static int _nextId = 1;

        public BookRepository(ILogger logger)
        {
            _logger = logger;
        }

        public void Create(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            _logger.Log("Create", "Book", book.Id);
        }

        public Book? FindById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            _logger.Log("Read", "Book", id);
            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public void Update(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                _logger.Log("Update", "Book", book.Id);
            }
        }

        public void Delete(int id)
        {
            _books.RemoveAll(b => b.Id == id);
            _logger.Log("Delete", "Book", id);
        }
    }
}

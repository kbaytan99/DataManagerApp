namespace DataManagerApp.Model
{
    /// <summary>
    /// Represents a book entity.
    /// Implements the IEntity interface.
    /// </summary>
    public class Book : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        public Book(string title)
        {
            Title = title;
        }
    }
}

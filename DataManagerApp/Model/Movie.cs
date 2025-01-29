namespace DataManagerApp.Model
{
    /// <summary>
    /// Represents a movie entity.
    /// Implements the IEntity interface.
    /// </summary>
    public class Movie : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the movie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the release year of the movie.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Movie"/> class.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="year">The release year of the movie.</param>
        public Movie(string title, int year)
        {
            Title = title;
            Year = year;
        }
    }
}

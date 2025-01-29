namespace DataManagerApp.Model
{
    /// <summary>
    /// Represents a magazine entity.
    /// Implements the IEntity interface.
    /// </summary>
    public class Magazine : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the magazine.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the magazine.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the editorial of the magazine.
        /// </summary>
        public string Editorial { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Magazine"/> class.
        /// </summary>
        /// <param name="title">The title of the magazine.</param>
        /// <param name="editorial">The editorial of the magazine.</param>
        public Magazine(string title, string editorial)
        {
            Title = title;
            Editorial = editorial;
        }
    }
}

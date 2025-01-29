namespace DataManagerApp.Model
{
    /// <summary>
    /// Interface for defining the base structure of an entity.
    /// Every entity must implement these common properties.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the title or name of the entity.
        /// </summary>
        string Title { get; set; }
    }
}

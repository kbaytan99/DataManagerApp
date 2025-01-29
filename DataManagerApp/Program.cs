using DataManagerApp.Logging;
using DataManagerApp.Repository;
using DataManagerApp.View;

namespace DataManagerApp
{
    /// <summary>
    /// Main entry point of the application.
    /// Initializes dependencies and starts the main form.
    /// 
    /// @author Kaan Baytan
    /// @version 1.0
    /// @since 29.01.2025
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Main method to start the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize repositories (Dependency Injection)

            ILogger logger = new MemoryLogger();

            IBookRepository bookRepository = new BookRepository(logger);
            IMovieRepository movieRepository = new MovieRepository(logger);
            IMagazineRepository magazineRepository = new MagazineRepository(logger);

            // Start the main form with dependencies
            Application.Run(new frmPrincipal(bookRepository, movieRepository, magazineRepository, logger));
        }
    }
}

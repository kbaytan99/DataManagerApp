using DataManagerApp.Logging;
using DataManagerApp.Model;
using DataManagerApp.Repository;

namespace DataManagerApp.View
{
    /// <summary>
    /// Main form for managing books, movies, and magazines.
    /// Provides UI functionalities for adding, filtering, and deleting entities.
    /// </summary>
    public partial class frmPrincipal : Form
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMagazineRepository _magazineRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmPrincipal"/> class.
        /// </summary>
        /// <param name="bookRepository">The repository for books.</param>
        /// <param name="movieRepository">The repository for movies.</param>
        /// <param name="magazineRepository">The repository for magazines.</param>
        public frmPrincipal(IBookRepository bookRepository, IMovieRepository movieRepository, IMagazineRepository magazineRepository, ILogger logger)
        {
            _bookRepository = bookRepository;
            _movieRepository = movieRepository;
            _magazineRepository = magazineRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            InitializeComponent();
        }

        /// <summary>
        /// Event handler when the form loads. Initializes the UI and loads default data.
        /// </summary>
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            InitializeComboBox();
            LoadInitialData();
            UpdateDataGridView();
        }

        /// <summary>
        /// Initializes the ComboBox with entity types.
        /// </summary>
        private void InitializeComboBox()
        {
            comboBoxEntity.Items.AddRange(new[] { "Book", "Movie", "Magazine" });
            comboBoxEntity.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads default data into the in-memory repository.
        /// </summary>
        private void LoadInitialData()
        {
            _movieRepository.Create(new Movie("Siete años en el Tíbet", 1997));
            _movieRepository.Create(new Movie("Kung Fu Panda 4", 2024));
            _bookRepository.Create(new Book("JavaScript: The Good Parts"));
            _bookRepository.Create(new Book("PHP by Example"));
            _magazineRepository.Create(new Magazine("Events", "TWSA"));
        }

        /// <summary>
        /// Updates the DataGridView based on the selected entity type.
        /// </summary>
        private void UpdateDataGridView()
        {
            if (comboBoxEntity.SelectedItem == null) return;

            dataGridViewEntity.DataSource = comboBoxEntity.SelectedItem.ToString() switch
            {
                "Movie" => _movieRepository.GetAll().ToList(),
                "Book" => _bookRepository.GetAll().ToList(),
                "Magazine" => _magazineRepository.GetAll().ToList(),
                _ => new List<object>()
            };
        }

        /// <summary>
        /// Event handler when the ComboBox selection changes.
        /// Updates the DataGridView accordingly.
        /// </summary>
        private void comboBoxEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        /// <summary>
        /// Adds a new entity based on the selected type and updates the DataGridView.
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxEntity.SelectedItem == null) return;

            switch (comboBoxEntity.SelectedItem.ToString())
            {
                case "Movie":
                    _movieRepository.Create(new Movie("New Movie", DateTime.Now.Year));
                    break;
                case "Book":
                    _bookRepository.Create(new Book("New Book"));
                    break;
                case "Magazine":
                    _magazineRepository.Create(new Magazine("New Magazine", "New Editorial"));
                    break;
            }

            textFilter.Text = "";
            UpdateDataGridView();
        }

        /// <summary>
        /// Deletes the selected entity from the repository and updates the DataGridView.
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEntity.SelectedRows.Count == 0 || dataGridViewEntity.SelectedRows[0]?.Cells[0]?.Value == null)
            {
                MessageBox.Show("Please select a row to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewEntity.SelectedRows[0].Cells[0].Value);

            switch (comboBoxEntity.SelectedItem.ToString())
            {
                case "Movie":
                    _movieRepository.Delete(id);
                    break;
                case "Book":
                    _bookRepository.Delete(id);
                    break;
                case "Magazine":
                    _magazineRepository.Delete(id);
                    break;
            }

            textFilter.Text = "";
            UpdateDataGridView();
        }

        /// <summary>
        /// Filters the DataGridView based on the entered text.
        /// </summary>
        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = textFilter.Text.ToLower().Trim();
            if (comboBoxEntity.SelectedItem == null) return;

            if (string.IsNullOrWhiteSpace(filter))
            {
                UpdateDataGridView();
                return;
            }

            switch (comboBoxEntity.SelectedItem.ToString())
            {
                case "Movie":
                    dataGridViewEntity.DataSource = _movieRepository.GetAll()
                        .Where(m => m.Id.ToString().Contains(filter) ||
                                    m.Title.ToLower().Contains(filter) ||
                                    m.Year.ToString().Contains(filter))
                        .ToList();
                    break;

                case "Book":
                    dataGridViewEntity.DataSource = _bookRepository.GetAll()
                        .Where(b => b.Id.ToString().Contains(filter) ||
                                    b.Title.ToLower().Contains(filter))
                        .ToList();
                    break;

                case "Magazine":
                    dataGridViewEntity.DataSource = _magazineRepository.GetAll()
                        .Where(m => m.Id.ToString().Contains(filter) ||
                                    m.Title.ToLower().Contains(filter) ||
                                    m.Editorial.ToLower().Contains(filter))
                        .ToList();
                    break;
            }
        }

        /// <summary>
        /// Clears the placeholder text when the user enters the filter textbox.
        /// </summary>
        private void textFilter_Enter(object sender, EventArgs e)
        {
            if (textFilter.Text == "Filter...")
            {
                textFilter.Text = "";
                textFilter.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Restores the placeholder text when the user leaves the filter textbox.
        /// </summary>
        private void textFilter_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textFilter.Text))
            {
                textFilter.Text = "Filter...";
                textFilter.ForeColor = System.Drawing.Color.Gray;
            }
        }

        /// <summary>
        /// Shows the operation logs in a message box.
        /// </summary>
        private void buttonShowLogs_Click(object sender, EventArgs e)
        {
            if (_logger == null)
            {
                MessageBox.Show("Logger error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string logs = string.Join(Environment.NewLine, _logger.GetLogs() ?? new List<string>());
            MessageBox.Show(logs, "Operation Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}   

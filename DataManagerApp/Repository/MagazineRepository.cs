using DataManagerApp.Model;
using DataManagerApp.Logging;

namespace DataManagerApp.Repository
{
    public class MagazineRepository : IMagazineRepository
    {
        private static readonly List<Magazine> _magazines = new();
        private static int _nextId = 1;
        private readonly ILogger _logger;
        public MagazineRepository(ILogger logger)
        {
            _logger = logger;
        }

        public void Create(Magazine magazine)
        {
            magazine.Id = _nextId++;
            _magazines.Add(magazine);
            _logger.Log("Create", "Magazine", magazine.Id);
        }

        public Magazine? FindById(int id)
        {
            var magazine = _magazines.FirstOrDefault(m => m.Id == id);
            _logger.Log("Read", "Magazine", id);
            return magazine;
        }

        public IEnumerable<Magazine> GetAll()
        {
            return _magazines;
        }

        public void Update(Magazine magazine)
        {
            var existingMagazine = _magazines.FirstOrDefault(m => m.Id == magazine.Id);
            if (existingMagazine != null)
            {
                existingMagazine.Title = magazine.Title;
                existingMagazine.Editorial = magazine.Editorial;
                _logger.Log("Update", "Magazine", magazine.Id);
            }
        }

        public void Delete(int id)
        {
            _magazines.RemoveAll(m => m.Id == id);
            _logger.Log("Delete", "Magazine", id);
        }
    }
}

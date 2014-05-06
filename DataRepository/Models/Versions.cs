using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Versions : IEntityId
    {
        public int Id { get; set; }

        public string VersionName { get; set; }
    }
}

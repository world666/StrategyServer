using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Version : IEntityId
    {
        public int Id { get; set; }

        public string VersionName { get; set; }
    }
}

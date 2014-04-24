using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Users : IEntityId
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string HashPassword { get; set; }
        public string SessionCode { get; set; }
    }
}

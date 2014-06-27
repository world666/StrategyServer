using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class ActiveBusiness : IEntityId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool LeasePurchase { get; set; }
        public virtual User User { get; set; }
        public virtual Business Business { get; set; }
    }
}

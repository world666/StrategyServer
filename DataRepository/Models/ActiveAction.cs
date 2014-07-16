using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;
using Action = DataRepository.Models.Action;

namespace DataRepository.Models
{
    public class ActiveAction : IEntityId
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int ActiveBusinessId { get; set; }
        public virtual Action Action { get; set; }
        public virtual ActiveBusiness ActiveBusiness { get; set; }
    }
}

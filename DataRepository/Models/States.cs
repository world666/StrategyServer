using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class States : IEntityId
    {
        public int Id { get; set; }

        public List<string> StatesNames { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Regions : IEntityId
    {
        public int Id { get; set; }
        public string RegionsNames { get; set; }
        public List<string> RegionsNamesList
        {
            get
            {
                var separator = new string[] { "[$]" };
                return RegionsNames.Split(separator, StringSplitOptions.None).ToList();
            }
            set
            {
                RegionsNames = String.Join("[$]", value);
            }
        }
        public int StatesId { get; set; }
        public virtual States States { get; set; }
        public virtual ICollection<Businesses> Businesses { get; set; }
    }
}

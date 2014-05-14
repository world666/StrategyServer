using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Businesses : IEntityId
    {
        public int Id { get; set; }
        public string BusinessesNames { get; set; }
        public List<string> BusinessesNamesList
        {
            get
            {
                var separator = new string[] { "[$]" };
                return BusinessesNames.Split(separator, StringSplitOptions.None).ToList();
            }
            set
            {
                BusinessesNames = String.Join("[$]", value);
            }
        }
        public int RegionsId { get; set; }
        public string Description { get; set; }
        public virtual Regions Regions { get; set; }
    }
}

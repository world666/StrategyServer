using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Business : IEntityId
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
        public string Description { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}

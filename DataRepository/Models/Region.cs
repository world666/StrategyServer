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
    public class Region : IEntityId
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
        public int StateId { get; set; }
        public double ProfitTax { get; set; }
        public double GrossProfitTax { get; set; }
        public double Industry { get; set; }
        public double Cx { get; set; }
        public double ServicesSector { get; set; }
        public double Trade { get; set; }
        public double Tourism { get; set; }
        public virtual State State { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class State : IEntityId
    {
        public int Id { get; set; }
        public string StatesNames { get; set; }
        public List<string> StatesNamesList
        {
            get
            {
                var separator = new string[] {"[$]"};
                return StatesNames.Split(separator, StringSplitOptions.None).ToList();
            }
            set
            {
                StatesNames = String.Join("[$]", value);
            }
        }
        public double CountryDevelopmentCoef { get; set; }
        public double CountryCurrencyUnit { get; set; }
        public double NewsInfluenceCoef { get; set; }
        public double LicensesExcises { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}

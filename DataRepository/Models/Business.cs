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
        public string Descriptions { get; set; }
        public List<string> DescriptionsList
        {
            get
            {
                var separator = new string[] { "[$]" };
                return Descriptions.Split(separator, StringSplitOptions.None).ToList();
            }
            set
            {
                Descriptions = String.Join("[$]", value);
            }
        }
        public string Addresses { get; set; }
        public List<string> AddressesList
        {
            get
            {
                var separator = new string[] { "[$]" };
                return Addresses.Split(separator, StringSplitOptions.None).ToList();
            }
            set
            {
                Addresses = String.Join("[$]", value);
            }
        }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        //public virtual ICollection<ActiveBusiness> ActiveBusinesses { get; set; }
    }
}

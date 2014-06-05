using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Models
{
    public class Action : IEntityId
    {
        public int Id { get; set; }
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
        public int BusinessId { get; set; }
        public virtual Business Business { get; set; }
    }
}

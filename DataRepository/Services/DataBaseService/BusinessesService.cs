using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class BusinessesService
    {
        public List<Business> GetBusinesses(Language lang, int regionId)
        {
            var language = Convert.ToInt32(lang);
            var businesses = new List<Business>();
            using (var repoUnit = new RepoUnit())
            {
                businesses = repoUnit.Regions.FindFirstBy(r => r.Id == regionId).Businesses.ToList();
            }
            return businesses.Select(b => new Business()
            {
                Id = b.Id,
                BusinessesNamesList = new List<string>() { b.BusinessesNamesList[language] },
                DescriptionsList = new List<string>() { b.DescriptionsList[language] },
                RegionId = b.RegionId
            }).ToList();
        }
    }
}

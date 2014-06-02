using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class RegionsService
    {
        public List<Region> GetRegions(Language lang, int stateId)
        {
            var language = Convert.ToInt32(lang);
            var regions = new List<Region>();
            using (var repoUnit = new RepoUnit())
            {
                regions = repoUnit.States.FindFirstBy(s => s.Id == stateId).Regions.ToList();
            }
            return regions.Select(r => new Region()
            {
                Id = r.Id,
                RegionsNamesList = new List<string>() { r.RegionsNamesList[language] },
                StateId = r.StateId,
                ProfitTax = r.ProfitTax,
                GrossProfitTax = r.GrossProfitTax,
                Industry = r.Industry,
                Cx = r.Cx,
                ServicesSector = r.ServicesSector,
                Trade = r.Trade,
                Tourism = r.Tourism
            }).ToList();
        }

        public List<Region> GetRegions(int stateId)
        {
            var regions = new List<Region>();
            using (var repoUnit = new RepoUnit())
            {
                regions = repoUnit.States.FindFirstBy(s => s.Id == stateId).Regions.ToList();
            }
            return regions.Select(r => new Region()
            {
                Id = r.Id,
                RegionsNamesList = r.RegionsNamesList,
                StateId = r.StateId,
                ProfitTax = r.ProfitTax,
                GrossProfitTax = r.GrossProfitTax,
                Industry = r.Industry,
                Cx = r.Cx,
                ServicesSector = r.ServicesSector,
                Trade = r.Trade,
                Tourism = r.Tourism
            }).ToList();
        }

        public void AddRegions(List<Region> newRegions)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var rg in newRegions)
                {
                    repoUnit.Regions.Save(rg);
                }
            }
        }

        public void EditRegions(List<Region> regions)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var rg in regions)
                {
                    repoUnit.Regions.Edit(rg);
                }
            }
        }

        public void DeleteRegions(List<int> regionIds)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var id in regionIds)
                {
                    var region = repoUnit.Regions.FindFirstBy(r => r.Id == id);
                    if (region != null)
                    {
                        repoUnit.Regions.Delete(region);
                    }
                }
            }
        }

    }
}

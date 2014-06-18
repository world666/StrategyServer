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
        public List<Region> GetRegions(int languageId, int stateId)
        {
            var regions = new List<Region>();
            var languagesService = new LanguagesService();
            var langCount = languagesService.GetLanguagesCount();
            using (var repoUnit = new RepoUnit())
            {
                regions = repoUnit.States.FindFirstBy(s => s.Id == stateId).Regions.ToList();
            }
            var retRegions = new List<Region>();
            foreach (var r in regions)
            {
                if (r.RegionsNames != null)
                {
                    if (r.RegionsNamesList.Count == langCount)
                    {
                        r.RegionsNamesList = new List<string>() {r.RegionsNamesList[languageId]};
                        r.State = null;
                        r.Businesses = null;
                        retRegions.Add(r);
                    }
                }
            }
            return retRegions;
        }

        public List<Region> GetRegions(int stateId)
        {
            var regions = new List<Region>();
            using (var repoUnit = new RepoUnit())
            {
                regions = repoUnit.States.FindFirstBy(s => s.Id == stateId).Regions.ToList();
            }
            regions.ForEach(r =>
            {
                if (r.RegionsNames == null)
                    r.RegionsNames = "";
                r.State = null;
                r.Businesses = null;
            });
            return regions;
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

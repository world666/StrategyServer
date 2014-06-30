using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Models.GenericRepository;

namespace DataRepository.Services.DataBaseService
{
    public class ActiveBusinessesService
    {
        public void AddBusiness(ActiveBusiness newActiveBusiness)
        {
            newActiveBusiness.StartDate = DateTime.Now;
            newActiveBusiness.LastUpdate = newActiveBusiness.StartDate;
            using (var repoUnit = new RepoUnit())
            {
                repoUnit.ActiveBusinesses.Save(newActiveBusiness);
            }
        }

        public void DeleteBusiness(int activeBusinessId)
        {
            using (var repoUnit = new RepoUnit())
            {
                    var activeBusiness = repoUnit.ActiveBusinesses.FindFirstBy(b => b.Id == activeBusinessId);
                    if (activeBusiness != null)
                    {
                        repoUnit.ActiveBusinesses.Delete(activeBusiness);
                    }
            }
        }

        public List<ActiveBusiness> GetActiveBusinesses(int userId)
        {
            var activeBusinesses = new List<ActiveBusiness>();
            using (var repoUnit = new RepoUnit())
            {
                activeBusinesses = repoUnit.Users.FindFirstBy(r => r.Id == userId).ActiveBusinesses.ToList();
            }
            activeBusinesses.ForEach(b =>
            {
                b.User = null;
                b.Business = null;
                b.Actions = null;
            });
            return activeBusinesses;
        }

        public List<Business> GetBusinesses(int userId)
        {
            var activeBusinesses = new List<ActiveBusiness>();
            var businesses = new List<Business>();
            var languagesService = new LanguagesService();
            var langCount = languagesService.GetLanguagesCount();
            using (var repoUnit = new RepoUnit())
            {
                activeBusinesses = repoUnit.Users.FindFirstBy(r => r.Id == userId).ActiveBusinesses.ToList();
                activeBusinesses.ForEach(b => businesses.Add(repoUnit.Businesses.FindFirstBy(r => r.Id == b.BusinessId)));
            }
            var retBusinesses = new List<Business>();
            foreach (var b in businesses)
            {
                if (b.BusinessesNames != null && b.Descriptions != null && b.Addresses != null)
                {
                    if (b.BusinessesNamesList.Count == langCount && b.DescriptionsList.Count == langCount && b.AddressesList.Count == langCount)
                    {
                        b.Region = null;
                        b.Actions = null;
                        b.ActiveBusinesses = null;
                        retBusinesses.Add(b);
                    }
                }
            }
            return retBusinesses;
        }

    }
}

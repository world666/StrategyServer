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
            var langCount = Enum.GetNames(typeof(Language)).Length;
            int i = 0;
            using (var repoUnit = new RepoUnit())
            {
                businesses = repoUnit.Regions.FindFirstBy(r => r.Id == regionId).Businesses.ToList();
            }
            businesses.ForEach(b =>
            {
                if (b.BusinessesNamesList.Count != langCount || b.DescriptionsList.Count != langCount || b.AddressesList.Count != langCount)
                {
                    businesses[i] = null;
                }
                else
                {
                    b.BusinessesNamesList = new List<string>() {b.BusinessesNamesList[language]};
                    b.DescriptionsList = new List<string>() {b.DescriptionsList[language]};
                    b.AddressesList = new List<string>() {b.AddressesList[language]};
                    b.Region = null;
                    b.Actions = null;
                }
                i++;
            });
            return businesses;
        }

        public List<Business> GetBusinesses(int regionId)
        {
            var businesses = new List<Business>();
            using (var repoUnit = new RepoUnit())
            {
                businesses = repoUnit.Regions.FindFirstBy(r => r.Id == regionId).Businesses.ToList();
            }
            businesses.ForEach(b =>
            {
                if (b.BusinessesNames == null)
                    b.BusinessesNames = "";
                if (b.Descriptions == null)
                    b.Descriptions = "";
                if (b.Addresses == null)
                    b.Addresses = "";
                b.Region = null;
                b.Actions = null;
            });
            return businesses;
        }

        public void AddBusinesses(List<Business> newBusinesses)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var bns in newBusinesses)
                {
                    repoUnit.Businesses.Save(bns);
                }
            }
        }

        public void EditBusinesses(List<Business> businesses)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var bns in businesses)
                {
                    repoUnit.Businesses.Edit(bns);
                }
            }
        }

        public void DeleteBusinesses(List<int> businessIds)
        {
            using (var repoUnit = new RepoUnit())
            {
                foreach (var id in businessIds)
                {
                    var business = repoUnit.Businesses.FindFirstBy(b => b.Id == id);
                    if (business != null)
                    {
                        repoUnit.Businesses.Delete(business);
                    }
                }
            }
        }

    }
}

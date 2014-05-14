using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.DataAccess
{
    public class ServerDbInitializer : DropCreateDatabaseIfModelChanges<ServerContext>
    {
        protected override void Seed(ServerContext context)
        {
            if (context == null)
                context = new ServerContext();

            //Init Versions table
            var versions = new List<Versions>
                {
                    new Versions {VersionName = "BusinessStartegy v1.0"},
                };
            versions.ForEach(v => context.Versions.Add(v));
            //Init States table
            var states = new List<States>
            {
                new States {StatesNamesList = new List<string> {"Ukraine", "Украина"}},
                new States {StatesNamesList = new List<string> {"England", "Англия"}}
            };
            states.ForEach(v => context.States.Add(v));
            //Init Regions table
            var regions = new List<Regions>
            {
                new Regions {RegionsNamesList = new List<string> {"Donetsk", "Донецк"}, StatesId = 1},
                new Regions {RegionsNamesList = new List<string> {"London", "Лондон"}, StatesId = 2}
            };
            regions.ForEach(v => context.Regions.Add(v));
            //Init Businesses table
            var businesses = new List<Businesses>
            {
                new Businesses {BusinessesNamesList = new List<string> {"Plant", "Завод"}, RegionsId = 1, Description = "Металлургический завод"},
                new Businesses {BusinessesNamesList = new List<string> {"Restaurant", "Ресторан"}, RegionsId = 1, Description = "Итальянская кухня"}
            };
            businesses.ForEach(v => context.Businesses.Add(v));

            context.SaveChanges();
        }
    }
}

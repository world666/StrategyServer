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
            var states = new List<State>
            {
                new State
                {
                    StatesNamesList = new List<string> {"Ukraine", "Украина"}, 
                    Regions = new List<Region>
                    {
                        new Region 
                        {
                            RegionsNamesList = new List<string> {"Donetsk", "Донецк"},
                            Businesses = new List<Business>
                            {
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Plant", "Завод"}, 
                                    Description = "Металлургический завод"
                                }
                            }
                        }
                    }
                },
                new State
                {
                    StatesNamesList = new List<string> {"England", "Англия"},
                    Regions = new List<Region>
                    {
                        new Region
                        {
                            RegionsNamesList = new List<string> {"London", "Лондон"},
                            Businesses = new List<Business>
                            {
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Restaurant", "Ресторан"}, 
                                    Description = "Итальянская кухня"
                                }
                            }
                        }
                    }
                }
            };
            states.ForEach(v => context.States.Add(v));

            context.SaveChanges();
        }
    }
}

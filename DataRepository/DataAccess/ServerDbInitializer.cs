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
            var versions = new List<DataRepository.Models.Version>
                {
                    new DataRepository.Models.Version {VersionName = "BusinessStartegy v1.0"}
                };
            versions.ForEach(v => context.Versions.Add(v));
            //Init Languages table
            var languages = new List<Language>
                {
                    new Language {LanguageName = "English"},
                    new Language {LanguageName = "Russian"}
                };
            languages.ForEach(l => context.Languages.Add(l));
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
                                    DescriptionsList = new List<string> {"Metallurgical works", "Металлургический завод"},
                                    AddressesList = new List<string> {"Metallurgical works", "Металлургический завод"}
                                },
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Mine", "Шахта"}, 
                                    DescriptionsList = new List<string> {"Coalmine", "Угольная шахта"},
                                    AddressesList = new List<string> {"Metallurgical works", "Металлургический завод"}
                                }
                            }
                        },
                        new Region 
                        {
                            RegionsNamesList = new List<string> {"Kiev", "Киев"},
                            Businesses = new List<Business>
                            {
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Stadium", "Стадион"}, 
                                    DescriptionsList = new List<string> {"Olympic Stadium", "Олимпийский стадион"},
                                    AddressesList = new List<string> {"Metallurgical works", "Металлургический завод"}
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
                                    DescriptionsList = new List<string> {"Italian cuisine", "Итальянская кухня"},
                                    AddressesList = new List<string> {"Metallurgical works", "Металлургический завод"}
                                },
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Shopping center", "Торговый центр"}, 
                                    DescriptionsList = new List<string> {"London's biggest shopping center", "Крупнейший торговый центр Лондона"},
                                    AddressesList = new List<string> {"Metallurgical works", "Металлургический завод"}
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

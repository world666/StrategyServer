﻿using System;
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
                    new DataRepository.Models.Version {VersionName = "BusinessStartegy v1.0"},
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
                                    DescriptionsList = new List<string> {"Metallurgical works", "Металлургический завод"}
                                },
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Mine", "Шахта"}, 
                                    DescriptionsList = new List<string> {"Coalmine", "Угольная шахта"}
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
                                    DescriptionsList = new List<string> {"Olympic Stadium", "Олимпийский стадион"}
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
                                    DescriptionsList = new List<string> {"Italian cuisine", "Итальянская кухня"}
                                },
                                new Business
                                {
                                    BusinessesNamesList = new List<string> {"Shopping center", "Торговый центр"}, 
                                    DescriptionsList = new List<string> {"London's biggest shopping center", "Крупнейший торговый центр Лондона"}
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

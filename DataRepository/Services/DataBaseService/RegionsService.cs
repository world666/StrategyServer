﻿using System;
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
                StateId = r.StateId
            }).ToList();
        }
    }
}

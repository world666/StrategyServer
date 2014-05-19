﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Businesses
{
    public class BusinessService : IBusinessService
    {
        public BusinessService()
        {
            _businessesService = new BusinessesService();
        }
        public List<Business> GetBusinesses(Language lang, int regionId)
        {
            return _businessesService.GetBusinesses(lang, regionId);
        }

        private BusinessesService _businessesService;
    }
}
